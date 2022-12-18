using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KazanQR_Paper1_7_24_2020.Models;
using Newtonsoft.Json;

namespace KazanQR_Paper1_7_24_2020
{
    [Activity(Label = "RegisteringAndEditingAssetsActivity")]
    public class RegisteringAndEditingAssetsActivity : Activity
    {
        private EditText assetNameEditText;
        private Spinner departmentSpinner;
        private Spinner locationSpinner;
        private Spinner assetGroupSpinner;
        private Spinner accountablePartySpinner;
        private EditText assetDescEditText;
        private EditText expiredWarrantyEditText;
        private TextView assetSNTextView;
        private Button submitButton;
        private Button cancelButton;
        private EditText descriptionEditText;
        private HttpClient httpClient = new HttpClient();
        private List<AssetGroupModel> departmentList;
        private List<AssetGroupModel> assetGroupList;
        private List<EmployeeNameModel> accoutablePartyList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.registering_and_editing_assetsActivity);
            InitView();
        }

        private async void InitView()
        {
            assetNameEditText = FindViewById<EditText>(Resource.Id.assetNameEditText);
            departmentSpinner = FindViewById<Spinner>(Resource.Id.departmentSpinner);
            locationSpinner = FindViewById<Spinner>(Resource.Id.locationSpinner);
            assetGroupSpinner = FindViewById<Spinner>(Resource.Id.assetGroupSpinner);
            accountablePartySpinner = FindViewById<Spinner>(Resource.Id.accountablePartySpinner);
            assetDescEditText = FindViewById<EditText>(Resource.Id.assetDescription);
            expiredWarrantyEditText = FindViewById<EditText>(Resource.Id.expiredWarranty);
            assetSNTextView = FindViewById<TextView>(Resource.Id.assetSNTextView);
            submitButton = FindViewById<Button>(Resource.Id.submitButton);
            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            descriptionEditText = FindViewById<EditText>(Resource.Id.assetDescription);

            var departmentRequest = await httpClient.GetAsync("http://10.0.2.2:54733/Assets/GetDepartments");

            var assetGroupRequest = await httpClient.GetAsync("http://10.0.2.2:54733/Assets/GetAssetGroups");
            var accountablePartyRequest = await httpClient.GetAsync("http://10.0.2.2:54733/Assets/GetEmployeeNames");

            departmentList = JsonConvert.DeserializeObject<List<AssetGroupModel>>(await departmentRequest.Content.ReadAsStringAsync());
            assetGroupList = JsonConvert.DeserializeObject<List<AssetGroupModel>>(await assetGroupRequest.Content.ReadAsStringAsync());
            accoutablePartyList = JsonConvert.DeserializeObject<List<EmployeeNameModel>>(await accountablePartyRequest.Content.ReadAsStringAsync());
            departmentSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, departmentList.Select(x => x.Name).ToArray());
            assetGroupSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, assetGroupList.Select(x => x.Name).ToArray());
            departmentSpinner.ItemSelected += DepartmentSpinner_ItemSelected;

            var tempNameList = new List<string>();

            foreach (var employee in accoutablePartyList)
            {
                tempNameList.Add($"{employee.FirstName} {employee.LastName}");
            }
            accountablePartySpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, tempNameList);
            UpdateLocationSpinner();
            UpdateSN();

            assetGroupSpinner.ItemSelected += AssetGroupSpinner_ItemSelected;
            cancelButton.Click += CancelButton_Click;
            submitButton.Click += SubmitButton_Click;
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            var req = await httpClient.GetAsync($"http://10.0.2.2:54733/Assets" +
                $"/AddAsset?assetName={assetNameEditText.Text}&" +
                $"department={departmentSpinner.SelectedItem.ToString()}&" +
                $"location={locationSpinner.SelectedItem.ToString()}&" +
                $"employee={accountablePartySpinner.SelectedItem.ToString()}&" +
                $"assetGroup={assetGroupSpinner.SelectedItem.ToString()}&description=" +
                $"{descriptionEditText.Text}&warranty=&assetSN={assetSNTextView.Text}");

            if (req.IsSuccessStatusCode)
            {
                Toast.MakeText(this, "Added", ToastLength.Short).Show();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void AssetGroupSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateSN();
        }

        private void DepartmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateLocationSpinner();
            UpdateSN();
        }

        private async void UpdateLocationSpinner()
        {
            var locationRequest = await httpClient.GetAsync("http://10.0.2.2:54733/Assets/GetDepartmentLocations");
            var locationList = JsonConvert.DeserializeObject<List<DepartmentLocationModel>>(await locationRequest.Content.ReadAsStringAsync());

            var templocationList = locationList.Where(x => x.DepartmentName.Equals(departmentSpinner.SelectedItem.ToString())).Select(x => x.DepartmentLocationName).ToList();
            locationSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, templocationList);
        }

        private async void UpdateSN()
        {
            var SNRequest = await httpClient.GetAsync($"http://10.0.2.2:54733/Assets/CalculateSN?department={departmentSpinner.SelectedItem.ToString()}&assetGroup={assetGroupSpinner.SelectedItem.ToString()}");

            assetSNTextView.Text = await SNRequest.Content.ReadAsStringAsync();
        }
    }
}