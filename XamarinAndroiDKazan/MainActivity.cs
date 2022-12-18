using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using XamarinSampleAndroid.Models;
using XamarinSampleAndroid.Resources.layout;

namespace XamarinSampleAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView mListView;
        
        private Spinner mDepartmentSpinner;
        private Spinner mAssetGroupSpinner;
        private TextView mSearchField;
        private TextView startDateEditText;
        private TextView endDateEditText;
        private MyListViewAdapter mAdapter;
        private TextView mTxtAssetInfo;
        private Button addBtn;

        //Global Fields
        public static List<AssetClass> mAssetList;
        public static List<AssetClass> mDepartmentLocationList;
        public static List<string> mDepartmentList;
        public static bool needToUpdate = false;
        public static List<AssetClass> mAssetGroupList;
        public static List<AssetClass> mEmployeeList;
        private ArrayAdapter<string> assetGroupAdapter;
        private ArrayAdapter<string> departmentAdapter;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            mListView = FindViewById<ListView>(Resource.Id.listView1);
            mDepartmentSpinner = FindViewById<Spinner>(Resource.Id.departmentSpinner);
            mAssetGroupSpinner = FindViewById<Spinner>(Resource.Id.assetGroupSpinner);
            mSearchField = FindViewById<TextView>(Resource.Id.searchField);
            startDateEditText = FindViewById<TextView>(Resource.Id.startDate);
            endDateEditText = FindViewById<TextView>(Resource.Id.endDate);
            mTxtAssetInfo = FindViewById<TextView>(Resource.Id.txtAssetInfo);
            addBtn = FindViewById<Button>(Resource.Id.addNewAssetBtn);

            UpdateList();

            startDateEditText.Click += (s, e) =>
            {
                DatePickerDialog dpd = new DatePickerDialog(this, DateListener,
                    2019, 1, 1);
                dpd.CancelEvent += Dpd_CancelEvent;
                dpd.Show();
            };

            endDateEditText.Click += (s, e) =>
            {
                DatePickerDialog dpd = new DatePickerDialog(this, EndDateSelectListener, DateTime.Today.Year, DateTime.Today.Month,
                    DateTime.Today.Day);
                dpd.CancelEvent += Dpd_end_CancelEvent;
                dpd.Show();
            };

            addBtn.Click += (s, e) =>
            {
                Intent intent = new Intent(this, typeof(RegisteringAndEditingAssets));
                StartActivityForResult(intent, 100);
            };
            
            mSearchField.TextChanged += SearchField_TextChanged;

            if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Portrait)
            {
                UpdateList();
                Toast.MakeText(this, "Portrait", ToastLength.Short).Show();
                mAssetGroupSpinner.Visibility = Android.Views.ViewStates.Visible;
                mDepartmentSpinner.Visibility = Android.Views.ViewStates.Visible;
                mSearchField.Visibility = Android.Views.ViewStates.Visible;
                startDateEditText.Visibility = Android.Views.ViewStates.Visible;
                endDateEditText.Visibility = Android.Views.ViewStates.Visible;
                mTxtAssetInfo.Visibility = Android.Views.ViewStates.Visible;
            }
            else
            {
                UpdateList();
                Toast.MakeText(this, "Landscape", ToastLength.Short).Show();
                mAssetGroupSpinner.Visibility = Android.Views.ViewStates.Gone;
                mDepartmentSpinner.Visibility = Android.Views.ViewStates.Gone;
                mSearchField.Visibility = Android.Views.ViewStates.Gone;
                startDateEditText.Visibility = Android.Views.ViewStates.Gone;
                endDateEditText.Visibility = Android.Views.ViewStates.Gone;
                mTxtAssetInfo.Visibility = Android.Views.ViewStates.Gone;
            }

        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 100 && resultCode == Result.Ok)
            {
                UpdateList();
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (needToUpdate)
            {
                UpdateList();
            }
        }

        public async void UpdateList()
        {
            mTxtAssetInfo.Text = "Loading asset data...";
            //Freeze UI Elements:
            startDateEditText.Focusable = false;
            endDateEditText.Focusable = false;
            addBtn.Clickable = false;
            mSearchField.Clickable = false;
            mAssetGroupSpinner.Clickable = false;
            mDepartmentSpinner.Clickable = false;

            var webClient = new WebClient();

            webClient.Headers.Add("Content-Type", "application/json");

            var assetDetailResponse = await webClient.UploadDataTaskAsync("http://10.0.2.2:50308/Assets/GetAssetDetails", "POST", Encoding.Default.
                GetBytes(""));

            var assetGroupResponse = await webClient.UploadDataTaskAsync("http://10.0.2.2:50308/Assets/GetAssetGroup", "POST", Encoding.Default.
                GetBytes(""));

            var departmentResponse = await webClient.UploadDataTaskAsync("http://10.0.2.2:50308/Assets/GetDepartment", "POST", Encoding.Default.
                GetBytes(""));

            var departmentLocationResponse = await webClient.UploadDataTaskAsync("http://10.0.2.2:50308/Assets/GetAllDepartmentLocations", "POST", Encoding.Default.
                GetBytes(""));

            var employeeResponse = await webClient.UploadDataTaskAsync("http://10.0.2.2:50308/Assets/GetAllEmployees", "POST", Encoding.Default.
                GetBytes(""));


            mAssetList = JsonConvert.DeserializeObject<List<AssetClass>>(Encoding.Default.GetString(assetDetailResponse));
            mDepartmentLocationList = JsonConvert.DeserializeObject<List<AssetClass>>(Encoding.Default.GetString(departmentLocationResponse));
            mEmployeeList = JsonConvert.DeserializeObject<List<AssetClass>>(Encoding.Default.GetString(employeeResponse));

            
            mAssetGroupList = JsonConvert.DeserializeObject<List<AssetClass>>(Encoding.Default.GetString(assetGroupResponse));

            var tempDepList = new List<string>();
            tempDepList.Add("None");

            foreach (var department in mDepartmentLocationList)
            {
                tempDepList.Add(department.DepartmentName);
                Console.WriteLine(department.DepartmentName);
            }

            mDepartmentList = tempDepList.Distinct().ToList();

            var tempAssetGroupList = new List<string>();
            tempAssetGroupList.Add("None");
            foreach (var assetGroup in mAssetGroupList)
            {
                tempAssetGroupList.Add(assetGroup.AssetGroupName);
            }


            assetGroupAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, tempAssetGroupList);
            mAssetGroupSpinner.Adapter = assetGroupAdapter;
            mAssetGroupSpinner.ItemSelected += AssetGroupSpinner_ItemSelected;

            departmentAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, mDepartmentList);
            mDepartmentSpinner.Adapter = departmentAdapter;
            mDepartmentSpinner.ItemSelected += MDepartmentSpinner_ItemSelected;

            if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Portrait)
            {
                if (mAssetGroupSpinner.Count != 0 && mAssetGroupSpinner.Count != 0)
                {
                    SearchComplete(mSearchField.Text, mAssetGroupSpinner.SelectedItem.ToString(), mDepartmentSpinner.SelectedItem.ToString(),
                        startDateEditText.Text, endDateEditText.Text);
                    mAdapter = new MyListViewAdapter(this, mAssetList, true);
                }
                
            }
            else
            {
                if (mAssetGroupSpinner.Count != 0 && mAssetGroupSpinner.Count != 0)
                {
                    SearchComplete(mSearchField.Text, mAssetGroupSpinner.SelectedItem.ToString(), mDepartmentSpinner.SelectedItem.ToString(),
                        startDateEditText.Text, endDateEditText.Text);
                    mAdapter = new MyListViewAdapter(this, mAssetList, false);
                }
            }
            

            mListView.Adapter = mAdapter;

            mTxtAssetInfo.Text = $"{mAssetList.Count} assets from {mAssetList.Count}";

            startDateEditText.Focusable = true;
            endDateEditText.Focusable = true;
            addBtn.Clickable = true;
            mSearchField.Clickable = true;
            mAssetGroupSpinner.Clickable = true;
            mDepartmentSpinner.Clickable = true;
        }

        private void MDepartmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            SearchComplete(mSearchField.Text, mAssetGroupSpinner.SelectedItem.ToString(), mDepartmentSpinner.SelectedItem.ToString(),
                    startDateEditText.Text, endDateEditText.Text);
        }

        private void SearchField_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (mAssetGroupSpinner.Count != 0 && mAssetGroupSpinner.Count != 0)
            {
                SearchComplete(mSearchField.Text, mAssetGroupSpinner.SelectedItem.ToString(), mDepartmentSpinner.SelectedItem.ToString(),
                    startDateEditText.Text, endDateEditText.Text);
            }

        }

        private void Dpd_CancelEvent(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Event Cancelled", ToastLength.Short).Show();
            startDateEditText.Text = "";

            SearchComplete(mSearchField.Text, mAssetGroupSpinner.SelectedItem.ToString(), mDepartmentSpinner.SelectedItem.ToString(),
                     startDateEditText.Text, endDateEditText.Text);
        }

        private void Dpd_end_CancelEvent(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Event Cancelled", ToastLength.Short).Show();
            endDateEditText.Text = "";

            SearchComplete(mSearchField.Text, mAssetGroupSpinner.SelectedItem.ToString(), mDepartmentSpinner.SelectedItem.ToString(),
                     startDateEditText.Text, endDateEditText.Text);
        }

        private void EndDateSelectListener(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            endDateEditText.Text = e.Date.ToString("dd/MM/yyyy");

            SearchComplete(mSearchField.Text, mAssetGroupSpinner.SelectedItem.ToString(), mDepartmentSpinner.SelectedItem.ToString(),
                    startDateEditText.Text, endDateEditText.Text);
        }

        private void DateListener(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            startDateEditText.Text = e.Date.ToString("dd/MM/yyyy");

            SearchComplete(mSearchField.Text, mAssetGroupSpinner.SelectedItem.ToString(), mDepartmentSpinner.SelectedItem.ToString(),
                     startDateEditText.Text, endDateEditText.Text);

        }

        private void AssetGroupSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            SearchComplete(mSearchField.Text, mAssetGroupSpinner.SelectedItem.ToString(), mDepartmentSpinner.SelectedItem.ToString(),
                     startDateEditText.Text, endDateEditText.Text);
        }


        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void SearchComplete(string searchTerm, string assetGroup, string department, string startDate, string
            endDate)
        {
            var originalSearch = (from x in mAssetList
                                  select x).ToList();

            if (searchTerm.Length >= 3)
            {
                originalSearch = (from x in originalSearch
                                  where x.AssetName.Contains(searchTerm)
                                  select x).ToList();
            }

            if (!assetGroup.Equals("None"))
            {
                originalSearch = (from x in originalSearch
                                  where x.AssetGroupName.Equals(assetGroup)
                                  select x).ToList();
            }

            if (!department.Equals("None"))
            {
                originalSearch = (from x in originalSearch
                                  where x.DepartmentName.Equals(department)
                                  select x).ToList();
            }

            if (!startDate.Equals(string.Empty))
            {
                var currentDate = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                originalSearch = (from x in originalSearch
                                  where x.WarrantyDate >= currentDate
                                  select x).ToList();
            }

            if (!endDate.Equals(string.Empty))
            {
                var currentDate = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                originalSearch = (from x in originalSearch
                                  where x.WarrantyDate <= currentDate
                                  select x).ToList();
            }

            if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Portrait)
            {
                mAdapter = new MyListViewAdapter(this, originalSearch, true);
            }
            else
            {
                mAdapter = new MyListViewAdapter(this, originalSearch, false);
            }
            
            mListView.Adapter = mAdapter;
            mTxtAssetInfo.Text = $"{originalSearch.Count} assets from {mAssetList.Count}";
        }
    }
}