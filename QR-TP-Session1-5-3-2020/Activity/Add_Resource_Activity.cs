using Android.App;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace QR_TP_Session1_5_3_2020
{
    [Activity(Label = "Add A Resource")]
    public class Add_Resource_Activity : Activity
    {
        private EditText resourceNameEditText;
        private EditText resourceQuantityEditText;
        private Spinner resourceTypeSpinner;
        private Button addResourceButton;
        private CheckBox cyberSecCheckBox;
        private CheckBox softwareSolutionsCheckBox;
        private CheckBox networkingCheckBox;
        private CheckBox webTechCheckBox;
        private List<ResourceTypeModel> resourceTypeList;
        private List<Skill> skillList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Add_Resource_Layout);

            InitViews();
        }

        private async void InitViews()
        {
            resourceNameEditText = FindViewById<EditText>(Resource.Id.resourceNameEditTxtAddNew);
            resourceQuantityEditText = FindViewById<EditText>(Resource.Id.resourceQuantityEditTxtAddNew);
            resourceTypeSpinner = FindViewById<Spinner>(Resource.Id.resourceTypeSpinnerAddNew);
            addResourceButton = FindViewById<Button>(Resource.Id.addResourceButton);

            cyberSecCheckBox = FindViewById<CheckBox>(Resource.Id.cyberSecCheckBox);
            softwareSolutionsCheckBox = FindViewById<CheckBox>(Resource.Id.softwareSolutionsSecCheckBox);
            networkingCheckBox = FindViewById<CheckBox>(Resource.Id.networkingCheckBox);
            webTechCheckBox = FindViewById<CheckBox>(Resource.Id.webTechCheckBox);

            addResourceButton.Click += AddResourceButton_Click;

            using var webClient = new WebClient();

            webClient.Headers.Add("Content-Type", "application/json");

            var resourceTypeByte = await webClient.UploadDataTaskAsync("http://10.0.2.2:50721/Users/GetResourceTypeList",
                "POST", Encoding.UTF8.GetBytes(""));

            var skillBytes = await webClient.UploadDataTaskAsync("http://10.0.2.2:50721/Users/GetSkillList",
                "POST", Encoding.UTF8.GetBytes(""));

            resourceTypeList = JsonConvert.DeserializeObject<List<ResourceTypeModel>>(Encoding.UTF8.GetString(resourceTypeByte));
            skillList = JsonConvert.DeserializeObject<List<Skill>>(Encoding.UTF8.GetString(skillBytes));

            var resourceTypes = resourceTypeList.Select(x => x.resTypeName).ToList();

            resourceTypeSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem,
                resourceTypes);

        }

        private async void AddResourceButton_Click(object sender, System.EventArgs e)
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

                var resourceID = resourceTypeList.Where(x=>x.resTypeName.Equals(resourceTypeSpinner.SelectedItem.ToString()))
                    .Select(x=>x.resTypeId).FirstOrDefault();

                var insertResource = new CustomAllocation(resourceNameEditText.Text, resourceID, int.Parse(resourceQuantityEditText.Text),
                    skills);

                using var webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/json");

                try
                {
                    var insertAllocation = JsonConvert.SerializeObject(insertResource);
                    var createAllocation = await webClient.UploadDataTaskAsync("http://10.0.2.2:50721/Users/CreateAllocations",
                    "POST", Encoding.UTF8.GetBytes(insertAllocation));
                }
                catch (System.Exception)
                {
                    Toast.MakeText(this, "Resource name cannot be the same!", ToastLength.Short).Show();
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

            if (resourceNameEditText.Text.Equals(string.Empty))
            {
                Toast.MakeText(this, "Resource name cannot be empty", ToastLength.Short).Show();
                return false;
            }

            return true;
        }
    }
}