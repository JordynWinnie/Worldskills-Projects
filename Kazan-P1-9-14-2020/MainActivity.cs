using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using Kazan_P1_9_14_2020.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Kazan_P1_9_14_2020
{
    [Activity(Label = "Main Menu", Theme = "@style/AppTheme", MainLauncher = true,
        ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : AppCompatActivity
    {
        public static bool isRefresh = false;
        private TextView warantyDateLbl;
        private Spinner departmentSpinner;
        private Spinner assetGroupSpinner;
        private EditText startDateDtp;
        private EditText endDateDtp;
        private EditText searchBoxEditText;
        private ListView assetListView;
        private TextView assetNumberTextView;
        private Button addAssetBtn;
        private List<AssetModel.AssetListViewModel> assetList;

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitViews();
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (isRefresh)
            {
                Toast.MakeText(this, "Database refreshed", ToastLength.Short).Show();
                ChangeSearch();
                isRefresh = false;
            }
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            if (newConfig.Orientation == Android.Content.Res.Orientation.Landscape)
            {
                Toast.MakeText(this, "landscape", ToastLength.Short).Show();
                departmentSpinner.Visibility = Android.Views.ViewStates.Gone;
                assetGroupSpinner.Visibility = Android.Views.ViewStates.Gone;
                searchBoxEditText.Visibility = Android.Views.ViewStates.Gone;
                startDateDtp.Visibility = Android.Views.ViewStates.Gone;
                endDateDtp.Visibility = Android.Views.ViewStates.Gone;
                assetNumberTextView.Visibility = Android.Views.ViewStates.Gone;
                warantyDateLbl.Visibility = Android.Views.ViewStates.Gone;
            }
            else
            {
                Toast.MakeText(this, "portrait", ToastLength.Short).Show();
                departmentSpinner.Visibility = Android.Views.ViewStates.Visible;
                assetGroupSpinner.Visibility = Android.Views.ViewStates.Visible;
                searchBoxEditText.Visibility = Android.Views.ViewStates.Visible;
                startDateDtp.Visibility = Android.Views.ViewStates.Visible;
                endDateDtp.Visibility = Android.Views.ViewStates.Visible;
                assetNumberTextView.Visibility = Android.Views.ViewStates.Visible;
                warantyDateLbl.Visibility = Android.Views.ViewStates.Visible;
            }
        }

        private async void InitViews()
        {
            warantyDateLbl = FindViewById<TextView>(Resource.Id.dateLbl);
            departmentSpinner = FindViewById<Spinner>(Resource.Id.departmentSpinner);
            assetGroupSpinner = FindViewById<Spinner>(Resource.Id.assetGroupSpinner);
            startDateDtp = FindViewById<EditText>(Resource.Id.startDateDtp);
            endDateDtp = FindViewById<EditText>(Resource.Id.endDateDtp);
            searchBoxEditText = FindViewById<EditText>(Resource.Id.searchBoxEditText);
            assetListView = FindViewById<ListView>(Resource.Id.assetListView);
            assetNumberTextView = FindViewById<TextView>(Resource.Id.assetNumberTextView);
            addAssetBtn = FindViewById<Button>(Resource.Id.addAssetBtn);

            addAssetBtn.Click += AddAssetBtn_Click;

            using (var httpClient = new HttpClient())
            {
                var assetGroupReq = await httpClient.GetAsync("http://10.0.2.2:56415/Assets/GetAssetGroup");
                if (assetGroupReq.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await assetGroupReq.Content.ReadAsStringAsync());
                    Console.WriteLine("Result:" + result);
                    assetGroupSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, result);
                }

                var departmentReq = await httpClient.GetAsync("http://10.0.2.2:56415/Assets/GetDepartments");
                if (departmentReq.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await departmentReq.Content.ReadAsStringAsync());
                    Console.WriteLine("Result:" + result);
                    departmentSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, result);
                }
            }

            ChangeSearch();

            endDateDtp.TextChanged += EndDateDtp_TextChanged;
            startDateDtp.TextChanged += StartDateDtp_TextChanged;

            startDateDtp.Click += StartDateDtp_Click;
            endDateDtp.Click += EndDateDtp_Click;

            departmentSpinner.ItemSelected += DepartmentSpinner_ItemSelected;
            assetGroupSpinner.ItemSelected += AssetGroupSpinner_ItemSelected;
            searchBoxEditText.TextChanged += SearchBoxEditText_TextChanged;
        }

        private void AddAssetBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RegisteringAndEditingAssetsActivity));

            StartActivityForResult(intent, 10);
        }

        private void EndDateDtp_Click(object sender, EventArgs e)
        {
            DatePickerDialog dpd = new DatePickerDialog(this, endDatePicked, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dpd.Show();
            dpd.CancelEvent += Dpd_CancelEvent1; ;
        }

        private void Dpd_CancelEvent1(object sender, EventArgs e)
        {
            endDateDtp.Text = string.Empty;
        }

        private void endDatePicked(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            endDateDtp.Text = e.Date.ToShortDateString();
        }

        private void StartDateDtp_Click(object sender, EventArgs e)
        {
            DatePickerDialog dpd = new DatePickerDialog(this, startDatePicked, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dpd.Show();
            dpd.CancelEvent += Dpd_CancelEvent;
        }

        private void Dpd_CancelEvent(object sender, EventArgs e)
        {
            startDateDtp.Text = string.Empty;
        }

        private void startDatePicked(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            startDateDtp.Text = e.Date.ToShortDateString();
        }

        private void SearchBoxEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            ChangeSearch();
        }

        private void AssetGroupSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            ChangeSearch();
        }

        private void DepartmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            ChangeSearch();
        }

        private void StartDateDtp_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            ChangeSearch();
        }

        private void EndDateDtp_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            ChangeSearch();
        }

        private async void ChangeSearch()
        {
            DateTime? startDate = null;
            DateTime? endDate = null;
            var searchTerm = string.Empty;
            if (searchBoxEditText.Text.Length > 2)
            {
                searchTerm = searchBoxEditText.Text;
            }
            if (startDateDtp.Text.Length > 0)
            {
                startDate = DateTime.Parse(startDateDtp.Text);
            }

            if (endDateDtp.Text.Length > 0)
            {
                endDate = DateTime.Parse(endDateDtp.Text);
            }
            using (var httpClient = new HttpClient())
            {
                var link = $"http://10.0.2.2:56415/Assets/GetAssets?searchTerm={searchTerm}" +
                    $"&department={WebUtility.UrlEncode(departmentSpinner.SelectedItem.ToString())}" +
                    $"&assetGroup={assetGroupSpinner.SelectedItem.ToString()}" +
                    $"&startDate={startDate}&endDate={endDate}";
                var assetQuery = await
                    httpClient.GetAsync(link);
                assetList = JsonConvert.DeserializeObject<List<AssetModel.AssetListViewModel>>(await assetQuery.Content.ReadAsStringAsync());
                assetListView.Adapter = new AssetListViewAdapter(assetList, this);

                var getAssetCount = await (await httpClient.GetAsync("http://10.0.2.2:56415/Assets/GetAssetCount")).Content.ReadAsStringAsync();
                assetNumberTextView.Text = $"{assetList.Count} assets from {getAssetCount}";
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}