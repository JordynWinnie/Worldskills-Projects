using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using KazanSession1_17_02_2020.Models;
using System.Linq;
using System.Globalization;
using Android.Content;

namespace KazanSession1_17_02_2020
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static byte[] defaultUpload = Encoding.UTF8.GetBytes("");

        private Spinner departmentSpinner;
        private Spinner assetGroupSpinner;
        private EditText startDateEditText;
        private EditText endDateEditText;
        private EditText searchFieldEditText;
        private ListView assetListView;
        private TextView assetCountTextView;
        private Button addAssetButton;

        public static List<string> mDepartmentList = new List<string>();
        public static List<string> mAssetGroupList = new List<string>();
        public static List<DepartmentLocationModel> mLocationList = new List<DepartmentLocationModel>();
        public static List<AccountablePartyModel> mAccountablePartyList = new List<AccountablePartyModel>();
        public static List<AssetModel> mAssetList = new List<AssetModel>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitialiseViews();

            RefreshWebClient();
        }

        private async void RefreshWebClient()
        {
            using var webclient = new WebClient();

            webclient.Headers.Add("Content-Type", "application/json");

            var departmentJson = await webclient.UploadDataTaskAsync("http://10.0.2.2:54495/Assets/GetDepartments", "POST", defaultUpload);

            var assetGroupJson = await webclient.UploadDataTaskAsync("http://10.0.2.2:54495/Assets/GetAssetGroups", "POST", defaultUpload);

            var assetListJson = await webclient.UploadDataTaskAsync("http://10.0.2.2:54495/Assets/GetAssets", "POST", defaultUpload);

            var departmentLocationJson = await webclient.UploadDataTaskAsync("http://10.0.2.2:54495/Assets/GetLocationDepartment", "POST", defaultUpload);

            var employeeListJson = await webclient.UploadDataTaskAsync("http://10.0.2.2:54495/Assets/GetEmployees", "POST", defaultUpload);

            mDepartmentList = JsonConvert.DeserializeObject<List<string>>(Encoding.UTF8.GetString(departmentJson));
            mAssetGroupList = JsonConvert.DeserializeObject<List<string>>(Encoding.UTF8.GetString(assetGroupJson));
            mLocationList = JsonConvert.DeserializeObject<List<DepartmentLocationModel>>(Encoding.UTF8.GetString(departmentLocationJson));
            mAccountablePartyList = JsonConvert.DeserializeObject<List<AccountablePartyModel>>(Encoding.UTF8.GetString(employeeListJson));


            var tempDepList = mDepartmentList;
            tempDepList.Add("None");
            var tempAssetGroupList = mAssetGroupList;
            tempAssetGroupList.Add("None");

            var mDepartmentAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, tempDepList);
            departmentSpinner.Adapter = mDepartmentAdapter;
            var mAssetGroupAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, tempAssetGroupList);
            assetGroupSpinner.Adapter = mAssetGroupAdapter;

            departmentSpinner.SetSelection(mDepartmentAdapter.GetPosition("None"));
            assetGroupSpinner.SetSelection(mAssetGroupAdapter.GetPosition("None"));
            mAssetList = JsonConvert.DeserializeObject<List<AssetModel>>(Encoding.UTF8.GetString(assetListJson));

            FilterSearch();
        }

        private void InitialiseViews()
        {
            departmentSpinner = FindViewById<Spinner>(Resource.Id.departmentSpinnerAssetCat);
            assetGroupSpinner = FindViewById<Spinner>(Resource.Id.assetGroupSpinnerAssetCat);

            startDateEditText = FindViewById<EditText>(Resource.Id.startDateEditTextAssetCat);
            endDateEditText = FindViewById<EditText>(Resource.Id.endtDateEditTextAssetCat);

            searchFieldEditText = FindViewById<EditText>(Resource.Id.searchEditTextAssetCat);

            assetListView = FindViewById<ListView>(Resource.Id.assetListAssetCat);

            assetCountTextView = FindViewById<TextView>(Resource.Id.assetCountTextViewAssetCat);

            addAssetButton = FindViewById<Button>(Resource.Id.addAssetButtonAssetCat);

            startDateEditText.Focusable = false;
            endDateEditText.Focusable = false;

            startDateEditText.Click += (s, e) =>
            {
                DatePickerDialog dpd = new DatePickerDialog(this, StartDateListener, DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                dpd.Show();

                dpd.CancelEvent += DpdStart_CancelEvent;

            };

            endDateEditText.Click += (s, e) =>
            {
                DatePickerDialog dpd = new DatePickerDialog(this, EndDateListener, DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                dpd.Show();

                dpd.CancelEvent += DpdEnd_CancelEvent;
            };

            searchFieldEditText.TextChanged += SearchFieldEditText_TextChanged;
            departmentSpinner.ItemSelected += DepartmentSpinner_ItemSelected;
            assetGroupSpinner.ItemSelected += AssetGroupSpinner_ItemSelected;

            addAssetButton.Click += AddAssetButton_Click;
        }

        private void AddAssetButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisteringAndEditingAssetsActivity));
            StartActivity(intent);
            
        }

        private void AssetGroupSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            FilterSearch();
        }

        private void DepartmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            FilterSearch();
        }

        private void SearchFieldEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            FilterSearch();
        }

        private void EndDateListener(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            endDateEditText.Text = e.Date.ToString("dd/MM/yyyy");
            FilterSearch();
        }

        private void StartDateListener(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            startDateEditText.Text = e.Date.ToString("dd/MM/yyyy");
            FilterSearch();
        }

        private void DpdEnd_CancelEvent(object sender, EventArgs e)
        {
            endDateEditText.Text = string.Empty;
            FilterSearch();
        }

        private void DpdStart_CancelEvent(object sender, EventArgs e)
        {
            startDateEditText.Text = string.Empty;
            FilterSearch();
        }

        private void FilterSearch()
        {
            var originalSearch = (from x in mAssetList
                                  select x).ToList();

            if (!departmentSpinner.SelectedItem.ToString().Equals("None"))
            {
                originalSearch = (from x in originalSearch
                                  where x.DepartmentName.Equals(departmentSpinner.SelectedItem.ToString())
                                  select x).ToList();
            }


            if (!assetGroupSpinner.SelectedItem.ToString().Equals("None"))
            {
                originalSearch = (from x in originalSearch
                                  where x.AssetGroupName.Equals(assetGroupSpinner.SelectedItem.ToString())
                                  select x).ToList();
            }

            if (!string.IsNullOrEmpty(startDateEditText.Text))
            {
                var date = DateTime.ParseExact(startDateEditText.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                originalSearch = (from x in originalSearch
                                  where x.WarrantyDate >= date
                                  select x).ToList();
            }

            if (!string.IsNullOrEmpty(endDateEditText.Text))
            {
                var date = DateTime.ParseExact(endDateEditText.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                originalSearch = (from x in originalSearch
                                  where x.WarrantyDate <= date
                                  select x).ToList();
            }

            if (!string.IsNullOrEmpty(searchFieldEditText.Text))
            {
                originalSearch = (from x in originalSearch
                                  where x.AssetName.ToLower().Contains(searchFieldEditText.Text.ToLower())
                                  select x).ToList();
            }
            assetListView.Adapter = new AssetCatelogueAdapter(this, originalSearch);
            assetCountTextView.Text = $"{originalSearch.Count} assets from {mAssetList.Count}";
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}