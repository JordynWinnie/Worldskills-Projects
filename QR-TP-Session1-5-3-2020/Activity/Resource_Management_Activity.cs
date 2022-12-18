using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;

namespace QR_TP_Session1_5_3_2020
{
    [Activity(Label = "Manage Resources")]
    public class Resource_Management_Activity : Activity
    {
        private ListView resourceList;
        private Spinner resourceTypeSpinner;
        private Spinner skillTypeSpinner;
        private Button addButton;
        private List<ResourceListViewModel> resourceListFromDB;
        private List<ResourceTypeModel> resourceTypesFromDB;
        private List<Skill> skillTypesFromDB;
        private List<ResourceListViewModel> temporaryResourceList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Resource_Management_Layout);
            InitViews();
        }

        private async void InitViews()
        {
            //Finding all Views:
            resourceList = FindViewById<ListView>(Resource.Id.resourceManagementLV);
            resourceTypeSpinner = FindViewById<Spinner>(Resource.Id.resourceTypeSpinnerRM);
            skillTypeSpinner = FindViewById<Spinner>(Resource.Id.skillTypeSpinnerRM);
            addButton = FindViewById<Button>(Resource.Id.addButtonResourceManagement);

            //Onclicklistener for Button;
            addButton.Click += AddButton_Click;

            //Initilising ResourceList:

            using var webClient = new WebClient();
            var resourceBytes = await webClient.UploadDataTaskAsync($"http://10.0.2.2:50721/Users/GetResources",
                    "POST", Encoding.Default.GetBytes(""));

            resourceListFromDB = JsonConvert.DeserializeObject<List<ResourceListViewModel>>(Encoding.Default.GetString(resourceBytes));

            

            //Initialising ResourceType Spinner:
            var resourceTypeBytes = await webClient.UploadDataTaskAsync($"http://10.0.2.2:50721/Users/GetResourceTypeList",
                    "POST", Encoding.Default.GetBytes(""));

            resourceTypesFromDB = JsonConvert.DeserializeObject<List<ResourceTypeModel>>
               (Encoding.Default.GetString(resourceTypeBytes));

            var resourceTypes = new List<string>();
            resourceTypes.Add("None");
            resourceTypes.AddRange(resourceTypesFromDB.Select(x => x.resTypeName).ToList());

            var resourceTypeAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, resourceTypes);

            resourceTypeSpinner.Adapter = resourceTypeAdapter;

            //Initialising SkillType Spinner:
            var skillTypeBytes = await webClient.UploadDataTaskAsync($"http://10.0.2.2:50721/Users/GetSkillList",
                    "POST", Encoding.Default.GetBytes(""));

            skillTypesFromDB = JsonConvert.DeserializeObject<List<Skill>>
               (Encoding.Default.GetString(skillTypeBytes));

            var skillTypes = new List<string>();
            skillTypes.Add("None");
            skillTypes.AddRange(skillTypesFromDB.Select(x => x.skillName).ToList());

            var skillTypesAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, skillTypes);

            skillTypeSpinner.Adapter = skillTypesAdapter;

            resourceList.ItemClick += ResourceList_ItemClick; ;
            resourceTypeSpinner.ItemSelected += ResourceTypeSpinner_ItemSelected;
            skillTypeSpinner.ItemSelected += SkillTypeSpinner_ItemSelected;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Add_Resource_Activity));
            StartActivity(intent);
        }

        private void ResourceList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine("ResourceID: " + temporaryResourceList[e.Position].ResourceId);

            var intent = new Intent(this, typeof(Update_Resource_Activity));
            intent.PutExtra("id", temporaryResourceList[e.Position].ResourceId);

            StartActivity(intent);
        }

        private void SkillTypeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateResourceList();
        }

        private void UpdateResourceList()
        {
            var defaultQuery = (from x in resourceListFromDB
                               select x).ToList();

            if (!skillTypeSpinner.SelectedItem.ToString().Equals("None"))
            {
                var selectedItem = skillTypeSpinner.SelectedItem.ToString();
        
                defaultQuery = defaultQuery.Where(x=>x.AllocatedSkillString.Contains(selectedItem)).ToList();
            }

            if (!resourceTypeSpinner.SelectedItem.ToString().Equals("None"))
            {
                var selectedItem = resourceTypeSpinner.SelectedItem.ToString();
                defaultQuery = defaultQuery.Where(x=>x.ResourceType.Equals(selectedItem)).ToList();
            }
            var resourceListAdapter = new ResourceListViewAdapter(defaultQuery, this);

            temporaryResourceList = defaultQuery.ToList();
            resourceList.Adapter = resourceListAdapter;
        }

        private void ResourceTypeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateResourceList();
        }

       
    }
}