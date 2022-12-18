using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using Newtonsoft.Json;
using Paper1.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Paper1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Spinner departmentSpinner;
        private Spinner assetGroupSpinner;
        private EditText startDateEdit;
        private EditText endDateEdit;
        private EditText searchEditText;
        private ListView assetListLV;
        private TextView assetCountTextView;
        private Button addAssetButton;

        public static bool isRefresh = false;

        private bool isStartOnScreen = true;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitView();
            if (isStartOnScreen)
            {
                var intent = new Intent(this, typeof(RegisteringAndAddingActivity));
                StartActivity(intent);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (isRefresh)
            {
                RefreshList();
            }
        }

        private async void InitView()
        {
            departmentSpinner = FindViewById<Spinner>(Resource.Id.departmentSpinnerSc1);
            assetGroupSpinner = FindViewById<Spinner>(Resource.Id.assetGroupSpinnerSc1);
            startDateEdit = FindViewById<EditText>(Resource.Id.startDateEditTextSc1);
            endDateEdit = FindViewById<EditText>(Resource.Id.endDateEditTextSc1);
            searchEditText = FindViewById<EditText>(Resource.Id.searchEditTextSc1);
            assetListLV = FindViewById<ListView>(Resource.Id.assetListSc1);
            assetCountTextView = FindViewById<TextView>(Resource.Id.assetCountTextViewSc1);
            addAssetButton = FindViewById<Button>(Resource.Id.assAssetBtnSc1);

            using (var httpClient = new HttpClient())
            {
                var departmentQuery = await httpClient.GetAsync("http://10.0.2.2:50697/Assets/GetDepartments");
                if (departmentQuery.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await departmentQuery.Content.ReadAsStringAsync());
                    departmentSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, result);
                }

                var assetGroupQuery = await httpClient.GetAsync("http://10.0.2.2:50697/Assets/GetAssetGroups");
                if (assetGroupQuery.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await assetGroupQuery.Content.ReadAsStringAsync());
                    assetGroupSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, result);
                }

                RefreshList();
            }

            departmentSpinner.ItemSelected += DepartmentSpinner_ItemSelected;
            assetGroupSpinner.ItemSelected += AssetGroupSpinner_ItemSelected;
            searchEditText.TextChanged += SearchEditText_TextChanged;

            startDateEdit.Click += StartDateEdit_Click;
            endDateEdit.Click += EndDateEdit_Click;

            addAssetButton.Click += AddAssetButton_Click;
        }

        private void AddAssetButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisteringAndAddingActivity));
            StartActivity(intent);
        }

        private void EndDateEdit_Click(object sender, EventArgs e)
        {
            var dpd = new DatePickerDialog(this, endDateChoosen, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dpd.CancelEvent += endDpd_Cancel;
            dpd.Show();
        }

        private void endDpd_Cancel(object sender, EventArgs e)
        {
            endDateEdit.Text = string.Empty;
            RefreshList();
        }

        private void endDateChoosen(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            endDateEdit.Text = e.Date.ToShortDateString();
            RefreshList();
        }

        private void StartDateEdit_Click(object sender, EventArgs e)
        {
            var dpd = new DatePickerDialog(this, startDateChoosen, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dpd.CancelEvent += startDate_Cancel;
            dpd.Show();
        }

        private void startDate_Cancel(object sender, EventArgs e)
        {
            startDateEdit.Text = string.Empty;
            RefreshList();
        }

        private void startDateChoosen(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            startDateEdit.Text = e.Date.ToShortDateString();
            RefreshList();
        }

        private void SearchEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            RefreshList();
        }

        private void AssetGroupSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            RefreshList();
        }

        private void DepartmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            RefreshList();
        }

        private async void RefreshList()
        {
            using (var httpClient = new HttpClient())
            {
                assetCountTextView.Text = "Loading Assets...";

                var assetCountQuery = await httpClient.GetAsync("http://10.0.2.2:50697/Assets/GetCount");

                var searchText = string.Empty;
                DateTime? startDate = null;
                DateTime? endDate = null;
                if (searchEditText.Text.Length > 2)
                {
                    searchText = searchEditText.Text;
                }

                if (DateTime.TryParse(startDateEdit.Text, out _))
                {
                    startDate = DateTime.Parse(startDateEdit.Text);
                }

                if (DateTime.TryParse(endDateEdit.Text, out _))
                {
                    endDate = DateTime.Parse(endDateEdit.Text);
                }

                var assetQuery = await httpClient.GetAsync($"http://10.0.2.2:50697/Assets/GetAssetList?departmentName={WebUtility.UrlEncode(departmentSpinner.SelectedItem.ToString())}" +
                    $"&assetGroup={assetGroupSpinner.SelectedItem}&searchPattern={searchText}&startDate={startDate}&endDate={endDate}");

                if (assetQuery.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<AssetModel>>(await assetQuery.Content.ReadAsStringAsync());
                    assetListLV.Adapter = new AssetListAdapter(result, this);

                    if (assetCountQuery.IsSuccessStatusCode)
                    {
                        var result1 = await assetCountQuery.Content.ReadAsStringAsync();
                        assetCountTextView.Text = $"{result.Count} assets from {result1}";
                    }
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}