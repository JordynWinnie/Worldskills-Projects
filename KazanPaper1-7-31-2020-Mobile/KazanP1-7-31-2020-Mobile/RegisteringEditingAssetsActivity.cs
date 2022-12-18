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
using Java.Sql;
using KazanP1_7_31_2020_Mobile.Models;
using Newtonsoft.Json;
using Org.Apache.Http.Protocol;

namespace KazanP1_7_31_2020_Mobile
{
    [Activity(Label = "RegisteringEditingAssetsActivity")]
    public class RegisteringEditingAssetsActivity : Activity
    {
        private EditText assetNameEditText;
        private Spinner departmentSpinner;
        private Spinner locationSpinner;
        private Spinner assetGroupSpinner;
        private Spinner accountablePartySpinner;
        private EditText assetDescriptionEditText;
        private EditText expiredWarranty;
        private TextView assetSNEditText;
        private Button submitButton;
        private Button cancelButton;

        private HttpClient httpClient = new HttpClient();
        private int assetID;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.registering_and_editing_assets_layout);
            assetID = Intent.GetIntExtra("assetid", -1);
            InitView();
        }

        private async void InitView()
        {
            assetNameEditText = FindViewById<EditText>(Resource.Id.assetName);
            departmentSpinner = FindViewById<Spinner>(Resource.Id.departmentSpinner);
            locationSpinner = FindViewById<Spinner>(Resource.Id.locationSpinner);
            assetGroupSpinner = FindViewById<Spinner>(Resource.Id.assetGroupSpinner);
            accountablePartySpinner = FindViewById<Spinner>(Resource.Id.accountablePartySpinner);
            assetDescriptionEditText = FindViewById<EditText>(Resource.Id.assetDescriptionEditText);
            expiredWarranty = FindViewById<EditText>(Resource.Id.expiredWarrantyEditText);
            assetSNEditText = FindViewById<TextView>(Resource.Id.assetSNTextView);
            submitButton = FindViewById<Button>(Resource.Id.submitButton);
            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);

            var departmentQuery = await httpClient.GetAsync("http://10.0.2.2:50854/Generic/GetDepartments");
            var departmentInformation = JsonConvert.DeserializeObject<List<DepartmentAssetGenericModel>>(await departmentQuery.Content.ReadAsStringAsync());

            var assetGroupQuery = await httpClient.GetAsync("http://10.0.2.2:50854/Generic/GetAssetGroups");
            var assetGroupInformation = JsonConvert.DeserializeObject<List<DepartmentAssetGenericModel>>(await assetGroupQuery.Content.ReadAsStringAsync());

            var employeeQuery = await httpClient.GetAsync("http://10.0.2.2:50854/Generic/GetEmployees");
            var employeeInformation = JsonConvert.DeserializeObject<List<EmployeeModel>>(await employeeQuery.Content.ReadAsStringAsync());

            var departmentList = new List<string>();
            var assetGroupList = new List<string>();
            var employeeList = new List<string>();

            foreach (var employee in employeeInformation)
            {
                employeeList.Add(employee.FirstName + " " + employee.LastName);
            }

            departmentList.AddRange(departmentInformation.Select(x => x.Name));
            assetGroupList.AddRange(assetGroupInformation.Select(x => x.Name));

            departmentSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, departmentList);
            assetGroupSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, assetGroupList);
            accountablePartySpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, employeeList);
            departmentSpinner.ItemSelected += DepartmentSpinner_ItemSelected;
            FilterLocation();

            locationSpinner.ItemSelected += LocationSpinner_ItemSelected;
            assetGroupSpinner.ItemSelected += AssetGroupSpinner_ItemSelected;
            expiredWarranty.Click += ExpiredWarranty_Click;

            UpdateSN();
            submitButton.Click += SubmitButton_Click;
            cancelButton.Click += CancelButton_Click;

            if (assetID != -1)
            {
                var assetQuery = await httpClient.GetAsync($"http://10.0.2.2:50854/Generic/GetAssetFromID?id={assetID}");
                var assetInfo = JsonConvert.DeserializeObject<AssetItem>(await assetQuery.Content.ReadAsStringAsync());

                var depList = new List<string> { assetInfo.DepartmentName };
                var assGrpList = new List<string> { assetInfo.AssetGroupName };
                var locList = new List<string> { assetInfo.LocationName };
                departmentSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, depList);
                assetGroupSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, assGrpList);
                locationSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, locList);

                departmentSpinner.Enabled = false;
                assetGroupSpinner.Enabled = false;
                locationSpinner.Enabled = false;

                assetNameEditText.Text = assetInfo.asset.AssetName;
                assetDescriptionEditText.Text = assetInfo.asset.Description;
                if (assetInfo.asset.WarrantyDate != null)
                {
                    expiredWarranty.Text = ((DateTime)assetInfo.asset.WarrantyDate).ToShortDateString();
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void ExpiredWarranty_Click(object sender, EventArgs e)
        {
            var dtp = new DatePickerDialog(this, ExpDateSelected, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dtp.CancelEvent += Dtp_CancelEvent;
            dtp.Show();
        }

        private void ExpDateSelected(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            expiredWarranty.Text = e.Date.ToShortDateString();
        }

        private void Dtp_CancelEvent(object sender, EventArgs e)
        {
            expiredWarranty.Text = string.Empty;
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            var addItemRequest =
                await httpClient.GetAsync($"http://10.0.2.2:50854/Generic/AddAsset?" +
                $"assetSN={assetSNEditText.Text.Substring(10)}" +
                $"&assetName={assetNameEditText.Text}" +
                $"&department={departmentSpinner.SelectedItem}" +
                $"&location={locationSpinner.SelectedItem}" +
                $"&employee={accountablePartySpinner.SelectedItem}" +
                $"&assetGroup={assetGroupSpinner.SelectedItem}" +
                $"&description={assetDescriptionEditText.Text}" +
                $"&warrantyDate={expiredWarranty.Text}");

            if (addItemRequest.IsSuccessStatusCode)
            {
                Toast.MakeText(this, "Item Added", ToastLength.Short).Show();
                MainActivity.isRefresh = true;
                Finish();
            }
            else
            {
                Toast.MakeText(this, "Error adding", ToastLength.Short).Show();
            }
        }

        private void AssetGroupSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateSN();
        }

        private void LocationSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateSN();
        }

        private async void UpdateSN()
        {
            var snQuery = await httpClient.GetAsync($"http://10.0.2.2:50854/Generic/GetAssetSN?departmentName={departmentSpinner.SelectedItem}" +
                $"&assetGroup={assetGroupSpinner.SelectedItem}");

            assetSNEditText.Text = $"Asset SN: {await snQuery.Content.ReadAsStringAsync()}";
        }

        private void DepartmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            FilterLocation();
            UpdateSN();
        }

        private async void FilterLocation()
        {
            var departmentLocationQuery = await httpClient.GetAsync("http://10.0.2.2:50854/Generic/GetDepartmentLocations");
            var departmentLocationInformation =
                JsonConvert.DeserializeObject<List<DepartmentAssetGenericModel.DepartmentLocation>>
                (await departmentLocationQuery.Content.ReadAsStringAsync());
            var currentDepartment = departmentSpinner.SelectedItem.ToString();
            var locationList = departmentLocationInformation.Where(x => x.DepartmentName.Equals(currentDepartment)).Select(x => x.LocationName);
            locationSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line,
                locationList.ToList());
        }
    }
}