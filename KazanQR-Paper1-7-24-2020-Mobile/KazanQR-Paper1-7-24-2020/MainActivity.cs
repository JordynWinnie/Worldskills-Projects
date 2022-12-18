using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.Res;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using KazanQR_Paper1_7_24_2020.Models;
using System.Collections.Generic;
using System.Linq;
using Android.Content;

namespace KazanQR_Paper1_7_24_2020
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Spinner assetGroupSpinner;
        private Spinner departmentSpinner;
        private EditText startDateEditText;
        private EditText endDateEditText;
        private ListView assetListView;
        private TextView assetInfoCountTextView;
        private EditText searchBarEditText;
        private Button addButton;
        private HttpClient httpClient = new HttpClient();
        private List<AssetGroupModel> assetGroupList;
        private List<AssetGroupModel> departmentList;
        private List<AssetModel> assetList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitViews();
        }

        private async void InitViews()
        {
            assetGroupSpinner = FindViewById<Spinner>(Resource.Id.assetGroupSpinnerAsset);
            departmentSpinner = FindViewById<Spinner>(Resource.Id.departmentSpinnerAsset);
            startDateEditText = FindViewById<EditText>(Resource.Id.startDate);
            endDateEditText = FindViewById<EditText>(Resource.Id.endDate);
            assetListView = FindViewById<ListView>(Resource.Id.assetListView);
            assetInfoCountTextView = FindViewById<TextView>(Resource.Id.assetCountTextView);
            searchBarEditText = FindViewById<EditText>(Resource.Id.searchBarEditText);
            addButton = FindViewById<Button>(Resource.Id.addButton);

            addButton.Click += AddButton_Click;
            startDateEditText.Click += StartDateEditText_Click;
            endDateEditText.Click += EndDateEditText_Click;

            var assetResult = await httpClient.GetAsync("http://10.0.2.2:54733/Assets/GetAssetGroups");
            var departmentResult = await httpClient.GetAsync("http://10.0.2.2:54733/Assets/GetDepartments");
            var assetListResult = await httpClient.GetAsync("http://10.0.2.2:54733/Assets/GetAssetInformation");

            assetGroupList = JsonConvert.DeserializeObject<List<AssetGroupModel>>(await assetResult.Content.ReadAsStringAsync());
            departmentList = JsonConvert.DeserializeObject<List<AssetGroupModel>>(await departmentResult.Content.ReadAsStringAsync());
            assetList = JsonConvert.DeserializeObject<List<AssetModel>>(await assetListResult.Content.ReadAsStringAsync());

            var tempAssetGroupList = new List<string>()
            { "None"};
            tempAssetGroupList.AddRange(assetGroupList.Select(x => x.Name));
            var tempDepartmentList = new List<string>() { "None" };
            tempDepartmentList.AddRange(departmentList.Select(x => x.Name));
            assetGroupSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, tempAssetGroupList);
            departmentSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, tempDepartmentList);
            assetListView.Adapter = new AssetListViewLayoutAdapter(assetList, this);

            assetInfoCountTextView.Text = $"{assetList.Count} items of {assetList.Count}";
            searchBarEditText.TextChanged += SearchBarEditText_TextChanged;
            assetGroupSpinner.ItemSelected += AssetGroupSpinner_ItemSelected;
            departmentSpinner.ItemSelected += DepartmentSpinner_ItemSelected;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisteringAndEditingAssetsActivity));
            StartActivity(intent);
        }

        private void DepartmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateListView();
        }

        private void AssetGroupSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateListView();
        }

        private void SearchBarEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (e.Text.ToString().Length > 2)
            {
                UpdateListView();
            }
            if (e.Text.ToString().Length == 0)
            {
                UpdateListView();
            }
        }

        private void UpdateListView()
        {
            var tempList = assetList.ToList();

            if (!searchBarEditText.Text.Equals(string.Empty))
            {
                tempList = tempList.Where(x => x.AssetName.Contains(searchBarEditText.Text)).ToList();
            }

            if (!assetGroupSpinner.SelectedItem.ToString().Equals("None"))
            {
                var selectedItem = assetGroupSpinner.SelectedItem.ToString();
                tempList = tempList.Where(x => x.AssetGroupName.Equals(selectedItem)).ToList();
            }

            if (!departmentSpinner.SelectedItem.ToString().Equals("None"))
            {
                var selectedItem = departmentSpinner.SelectedItem.ToString();
                tempList = tempList.Where(x => x.DepartmentName.Equals(selectedItem)).ToList();
            }

            if (!startDateEditText.Text.Equals(string.Empty))
            {
                var date = DateTime.Parse(startDateEditText.Text);
                tempList = tempList.Where(x => x.WarrantyDate >= date).ToList();
            }

            if (!endDateEditText.Text.Equals(string.Empty))
            {
                var date = DateTime.Parse(endDateEditText.Text);
                tempList = tempList.Where(x => x.WarrantyDate <= date).ToList();
            }
            assetListView.Adapter = new AssetListViewLayoutAdapter(tempList, this);
        }

        private void EndDateEditText_Click(object sender, EventArgs e)
        {
            DatePickerDialog dtp = new DatePickerDialog(this, endDatePicked, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dtp.CancelEvent += endDate_Cancel;
            dtp.Show();
        }

        private void endDate_Cancel(object sender, EventArgs e)
        {
            endDateEditText.Text = string.Empty;
            UpdateListView();
        }

        private void endDatePicked(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            endDateEditText.Text = e.Date.ToShortDateString();
            UpdateListView();
        }

        private void StartDateEditText_Click(object sender, EventArgs e)
        {
            DatePickerDialog dtp = new DatePickerDialog(this, startDatePicked, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dtp.CancelEvent += startDateCancel;
            dtp.Show();
        }

        private void startDateCancel(object sender, EventArgs e)
        {
            startDateEditText.Text = string.Empty;
            UpdateListView();
        }

        private void startDatePicked(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            startDateEditText.Text = e.Date.ToShortDateString();
            UpdateListView();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}