using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using KazanP1_7_31_2020_Mobile.Models;
using System.Linq;
using Android.Content;

namespace KazanP1_7_31_2020_Mobile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static bool isRefresh = false;
        private Spinner departmentSpinner;
        private Spinner assetGroupSpinner;
        private EditText startDateEditText;
        private EditText endDateEditText;
        private EditText searchEditText;
        private ListView assetListView;
        private TextView assetInformationTextView;
        private Button addAssetButton;

        private HttpClient httpClient = new HttpClient();
        private List<AssetItem> assetInformation;

        protected override void OnCreate(Bundle savedInstanceState)

        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            InitView();
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (isRefresh)
            {
                FilterList();
            }
        }

        private async void InitView()
        {
            departmentSpinner = FindViewById<Spinner>(Resource.Id.departmentSpinner);
            assetGroupSpinner = FindViewById<Spinner>(Resource.Id.assetGroupSpinner);
            startDateEditText = FindViewById<EditText>(Resource.Id.startDateEditText);
            endDateEditText = FindViewById<EditText>(Resource.Id.endDateEditText);
            searchEditText = FindViewById<EditText>(Resource.Id.searchEditText);
            assetListView = FindViewById<ListView>(Resource.Id.assetListView);
            assetInformationTextView = FindViewById<TextView>(Resource.Id.assetCountInformationTextView);
            addAssetButton = FindViewById<Button>(Resource.Id.addAssetButton);

            var departmentQuery = await httpClient.GetAsync("http://10.0.2.2:50854/Generic/GetDepartments");
            var departmentInformation = JsonConvert.DeserializeObject<List<DepartmentAssetGenericModel>>(await departmentQuery.Content.ReadAsStringAsync());

            var assetGroupQuery = await httpClient.GetAsync("http://10.0.2.2:50854/Generic/GetAssetGroups");
            var assetGroupInformation = JsonConvert.DeserializeObject<List<DepartmentAssetGenericModel>>(await assetGroupQuery.Content.ReadAsStringAsync());

            var departmentList = new List<string> { "None" };
            var assetGroupList = new List<string> { "None" };

            departmentList.AddRange(departmentInformation.Select(x => x.Name));
            assetGroupList.AddRange(assetGroupInformation.Select(x => x.Name));

            var assetQuery = await httpClient.GetAsync("http://10.0.2.2:50854/Generic/GetAssetInformation");
            assetInformation = JsonConvert.DeserializeObject<List<AssetItem>>(await assetQuery.Content.ReadAsStringAsync());

            assetListView.Adapter = new AssetItemAdapter(assetInformation, this);
            departmentSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, departmentList);
            assetGroupSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, assetGroupList);

            FilterList();
            departmentSpinner.ItemSelected += DepartmentSpinner_ItemSelected;
            assetGroupSpinner.ItemSelected += AssetGroupSpinner_ItemSelected;
            searchEditText.TextChanged += SearchEditText_TextChanged;
            startDateEditText.Click += StartDateEditText_Click;
            endDateEditText.Click += EndDateEditText_Click;

            addAssetButton.Click += AddAssetButton_Click;
        }

        private void AddAssetButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisteringEditingAssetsActivity));
            StartActivity(intent);
        }

        private void EndDateEditText_Click(object sender, EventArgs e)
        {
            var dtp = new DatePickerDialog(this, endDatePicked, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dtp.CancelEvent += endDtp_Cancel;
            dtp.Show();
        }

        private void endDtp_Cancel(object sender, EventArgs e)
        {
            endDateEditText.Text = string.Empty;
            FilterList();
        }

        private void endDatePicked(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            endDateEditText.Text = e.Date.ToShortDateString();
            FilterList();
        }

        private void StartDateEditText_Click(object sender, EventArgs e)
        {
            var dtp = new DatePickerDialog(this, startDatePicked, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dtp.CancelEvent += startDtp_Cancel;
            dtp.Show();
        }

        private void startDtp_Cancel(object sender, EventArgs e)
        {
            startDateEditText.Text = string.Empty;
            FilterList();
        }

        private void startDatePicked(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            startDateEditText.Text = e.Date.ToShortDateString();
            FilterList();
        }

        private void SearchEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            FilterList();
        }

        private void AssetGroupSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            FilterList();
        }

        private void DepartmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            FilterList();
        }

        private void FilterList()
        {
            var tempList = assetInformation;

            if (!departmentSpinner.SelectedItem.ToString().Equals("None"))
            {
                var department = departmentSpinner.SelectedItem.ToString();
                tempList = tempList.Where(x => x.DepartmentName.Equals(department)).ToList();
            }

            if (!assetGroupSpinner.SelectedItem.ToString().Equals("None"))
            {
                var assetGroup = assetGroupSpinner.SelectedItem.ToString();
                tempList = tempList.Where(x => x.AssetGroupName.Equals(assetGroup)).ToList();
            }

            if (!searchEditText.Text.Equals(string.Empty))
            {
                var searchTerm = searchEditText.Text.ToLower();
                tempList = tempList.Where(x => x.asset.AssetName.ToLower().Contains(searchTerm)).ToList();
            }

            if (!startDateEditText.Text.Equals(string.Empty))
            {
                var date = DateTime.Parse(startDateEditText.Text);
                tempList = tempList.Where(x => x.asset.WarrantyDate >= date).ToList();
            }

            if (!endDateEditText.Text.Equals(string.Empty))
            {
                var date = DateTime.Parse(endDateEditText.Text);
                tempList = tempList.Where(x => x.asset.WarrantyDate <= date).ToList();
            }

            assetInformationTextView.Text = $"{tempList.Count} assets from {assetInformation.Count}";
            assetListView.Adapter = new AssetItemAdapter(tempList, this);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}