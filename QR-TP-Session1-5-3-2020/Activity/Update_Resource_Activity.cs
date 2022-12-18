using Android.App;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace QR_TP_Session1_5_3_2020
{
    [Activity(Label = "Update A Resource")]
    public class Update_Resource_Activity : Activity
    {
        private List<Skill> skillList;
        private TextView resourceNameField;
        private EditText resourceQuantityEditText;
        private TextView resourceTypeField;
        private CheckBox cyberSecCheckBox;
        private CheckBox softwareSolutionsCheckBox;
        private CheckBox networkingCheckBox;
        private CheckBox webTechCheckBox;
        private Button updateButton;
        private Button deleteButton;
        private List<ResourceListViewModel> resourceListFromDB;
        private int currentResourceID;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Update_Resource_Layout);

            InitViews();
        }

        private async void InitViews()
        {
            

            resourceNameField = FindViewById<TextView>(Resource.Id.resourceNameTextViewUR);
            resourceQuantityEditText = FindViewById<EditText>(Resource.Id.quantityEditTextUR);
            resourceTypeField = FindViewById<TextView>(Resource.Id.resourceTypeTextViewUR);
            
            cyberSecCheckBox = FindViewById<CheckBox>(Resource.Id.cyberSecCheckBoxUR);
            softwareSolutionsCheckBox = FindViewById<CheckBox>(Resource.Id.SoftwareSolutionsCheckBoxUR);
            networkingCheckBox = FindViewById<CheckBox>(Resource.Id.networkingCheckBoxUR);
            webTechCheckBox = FindViewById<CheckBox>(Resource.Id.webTechCheckBoxUR);

            updateButton = FindViewById<Button>(Resource.Id.updateResourceUR);
            deleteButton = FindViewById<Button>(Resource.Id.deleteResourceUR);

            updateButton.Click += UpdateButton_Click;
            deleteButton.Click += DeleteButton_Click;

            //Get ID from previous intent:
            currentResourceID = Intent.GetIntExtra("id", -1);

            using var webClient = new WebClient();

            //Download skill list:
            var skillBytes = await webClient.UploadDataTaskAsync("http://10.0.2.2:50721/Users/GetSkillList",
                "POST", Encoding.UTF8.GetBytes(""));
            skillList = JsonConvert.DeserializeObject<List<Skill>>(Encoding.UTF8.GetString(skillBytes));


            var resourceBytes = await webClient.UploadDataTaskAsync($"http://10.0.2.2:50721/Users/GetResources/{currentResourceID}",
                    "POST", Encoding.Default.GetBytes(""));
            resourceListFromDB = JsonConvert.DeserializeObject<List<ResourceListViewModel>>(Encoding.Default.GetString(resourceBytes));

            resourceNameField.Text = resourceListFromDB[0].ResourceName;
            resourceQuantityEditText.Text = resourceListFromDB[0].Quantity.ToString();
            resourceTypeField.Text = resourceListFromDB[0].ResourceType;

            if (resourceListFromDB[0].AllocatedSkillString.Contains("Cyber Security"))
            {
                cyberSecCheckBox.Checked = true;
            }
            if (resourceListFromDB[0].AllocatedSkillString.Contains("Software Solutions"))
            {
                softwareSolutionsCheckBox.Checked = true;
            }
            if (resourceListFromDB[0].AllocatedSkillString.Contains("Web Tech"))
            {
                webTechCheckBox.Checked = true;
            }
            if (resourceListFromDB[0].AllocatedSkillString.Contains("Networking"))
            {
                networkingCheckBox.Checked = true;
            }


        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            using var webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/json");
            try
            {
                var createAllocation = await webClient.UploadDataTaskAsync($"http://10.0.2.2:50721/Users/DeleteResource?resourceTypeId={currentResourceID}",
                "POST", Encoding.UTF8.GetBytes(""));

                Toast.MakeText(this, "Resource Deleted", ToastLength.Short).Show();

                Finish();
            }
            catch (System.Exception)
            {
                Toast.MakeText(this, "Error deleting.", ToastLength.Short).Show();
            }
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                var skills = new List<Skill>();

                if (cyberSecCheckBox.Checked)
                {
                    var skill = skillList.Where(x => x.skillName.Equals("Cyber Security")).Select(x => x).FirstOrDefault();
                    skills.Add(skill);
                }

                if (softwareSolutionsCheckBox.Checked)
                {
                    var skill = skillList.Where(x => x.skillName.Equals("Software Solutions")).Select(x => x).FirstOrDefault();
                    skills.Add(skill);
                }

                if (webTechCheckBox.Checked)
                {
                    var skill = skillList.Where(x => x.skillName.Equals("Web Tech")).Select(x => x).FirstOrDefault();
                    skills.Add(skill);
                }

                if (networkingCheckBox.Checked)
                {
                    var skill = skillList.Where(x => x.skillName.Equals("Networking")).Select(x => x).FirstOrDefault();
                    skills.Add(skill);
                }

               

                var insertResource = new CustomAllocation(resourceNameField.Text, currentResourceID, 
                    int.Parse(resourceQuantityEditText.Text),
                    skills);

                using var webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/json");

                try
                {
                    var insertAllocation = JsonConvert.SerializeObject(insertResource);
                    var createAllocation = await webClient.UploadDataTaskAsync("http://10.0.2.2:50721/Users/UpdateResource",
                    "POST", Encoding.UTF8.GetBytes(insertAllocation));

                    Toast.MakeText(this, "Resource Updated", ToastLength.Short).Show();
                    Finish();
                }
                catch (System.Exception)
                {
                    Toast.MakeText(this, "Error updating.", ToastLength.Short).Show();
                }
            }
        }

        private bool CheckFields()
        {
            int tempInt;
            if (!int.TryParse(resourceQuantityEditText.Text, out tempInt))
            {
                Toast.MakeText(this, "Please enter a valid quantity", ToastLength.Short).Show();
                return false;
            }

            if (tempInt < 0)
            {
                Toast.MakeText(this, "Please enter a quantity higher than zero", ToastLength.Short).Show();
                return false;
            }

            if (tempInt == 0)
            {
                if (cyberSecCheckBox.Checked || networkingCheckBox.Checked
                    || softwareSolutionsCheckBox.Checked || webTechCheckBox.Checked)
                {
                    Toast.MakeText(this, "Quantity is zero, cannot assign to any skill", ToastLength.Short).Show();
                    return false;
                }
            }

            if (resourceNameField.Text.Equals(string.Empty))
            {
                Toast.MakeText(this, "Resource name cannot be empty", ToastLength.Short).Show();
                return false;
            }

            return true;
        }
    }
}