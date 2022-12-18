using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using KazanSession1_17_02_2020.Models;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace KazanSession1_17_02_2020
{
    [Activity(Label = "RegisteringAndEditingAssetsActivity")]
    public class RegisteringAndEditingAssetsActivity : Activity
    {
        private EditText assetNameEditTxt;
        private Spinner departmentSpinner;
        private Spinner locationSpinner;
        private Spinner assetGroupSpinner;
        private Spinner accountablePartySpinner;
        private EditText assetDescriptionEditTxt;
        private EditText expWarrantyDateEditTxt;
        private TextView assetSNTextView;
        private Button captureImgButton;
        private Button browseBtn;
        private ListView imgListView;
        private Button submitBtn;
        private Button cancelBtn;
        private ArrayAdapter<string> assetGroupAdapter;
        private ArrayAdapter<string> departmentAdapter;
        private long intentId = -1;
        private ArrayAdapter<string> locationAdapter;
        private ArrayAdapter<string> accountablePartyAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_registeringAndEditing);
            // Create your application here

            InitialiseViews();

            intentId = Intent.GetLongExtra("id", -1);

            SetUpViews(intentId);
        }

        private void SetUpViews(long id)
        {

            if (id == -1)
            {
                //Code for add Asset:
            }
            else
            {
                //Code for editing assets:
                var currentAsset = (from x in MainActivity.mAssetList
                                    where x.UUID == id
                                    select x).First();

                assetNameEditTxt.Text = currentAsset.AssetName;
            }
        }

        private async void InitialiseViews()
        {
            assetNameEditTxt = FindViewById<EditText>(Resource.Id.regassetAssetName);
            departmentSpinner = FindViewById<Spinner>(Resource.Id.regAssetDepartmentSpinner);
            locationSpinner = FindViewById<Spinner>(Resource.Id.regAssetLocationSpinner);
            assetGroupSpinner = FindViewById<Spinner>(Resource.Id.regAssetAssetGroupSpinner);
            accountablePartySpinner = FindViewById<Spinner>(Resource.Id.regAssetAccountablePartySpinner);
            assetDescriptionEditTxt = FindViewById<EditText>(Resource.Id.regAssetAsetDescEdittxt);
            expWarrantyDateEditTxt = FindViewById<EditText>(Resource.Id.regAssetExpWarrantyEditTxt);
            assetSNTextView = FindViewById<TextView>(Resource.Id.regAssetAssetSNTextView);

            captureImgButton = FindViewById<Button>(Resource.Id.regAssetCaptureImgBtn);
            browseBtn = FindViewById<Button>(Resource.Id.regAssetBrowseImgBtn);

            imgListView = FindViewById<ListView>(Resource.Id.regAssetListView);

            submitBtn = FindViewById<Button>(Resource.Id.regAssetSubmitBtn);
            cancelBtn = FindViewById<Button>(Resource.Id.regAssetCancelBtn);

            //Population Logic:

            departmentAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, MainActivity.mDepartmentList);
            departmentSpinner.Adapter = departmentAdapter;

            assetGroupAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, MainActivity.mAssetGroupList);
            assetGroupSpinner.Adapter = assetGroupAdapter;

            departmentAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, MainActivity.mDepartmentList);
            departmentSpinner.Adapter = departmentAdapter;

            departmentAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, MainActivity.mDepartmentList);
            departmentSpinner.Adapter = departmentAdapter;

            var employeeList = (from x in MainActivity.mAccountablePartyList
                                select x.FullName).ToList();

            accountablePartyAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, employeeList);
            accountablePartySpinner.Adapter = accountablePartyAdapter;

            departmentSpinner.ItemSelected += DepartmentSpinner_ItemSelected;

            expWarrantyDateEditTxt.Clickable = false;
            expWarrantyDateEditTxt.Click += ExpWarrantyDateEditTxt_Click1;

            submitBtn.Click += SubmitBtn_Click;
            cancelBtn.Click += (s, e) =>
            {
                Finish();
            };
        }

        private void ExpWarrantyDateEditTxt_Click1(object sender, EventArgs e)
        {
            DatePickerDialog dpd = new DatePickerDialog(this, DateFinishListener, DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            dpd.Show();

            dpd.CancelEvent += (s, e) =>
            {
                expWarrantyDateEditTxt.Text = string.Empty;
            };
        }

        private async void SubmitBtn_Click(object sender, EventArgs e)
        {
            var insertAsset = new AssetUploadModel();

            insertAsset.AssetName = assetNameEditTxt.Text;

            var departmentId = (from x in MainActivity.mLocationList
                                where x.DepartmentName.Equals(departmentSpinner.SelectedItem.ToString()) && x.LocationName.Equals(locationSpinner.SelectedItem.ToString())
                                select x.DepartmentLocationID).First();

            insertAsset.DepartmentLocationID = departmentId;

            insertAsset.AssetSN = "00/00/0000";

            var employeeId = (from x in MainActivity.mAccountablePartyList
                              where x.FullName.Equals(accountablePartySpinner.SelectedItem.ToString())
                              select x.ID).First();

            insertAsset.EmployeeID = employeeId;

            var assetGroupID = 1;

            insertAsset.AssetGroupID = 1;

            insertAsset.Description = "test";

            insertAsset.WarrantyDate = DateTime.ParseExact(expWarrantyDateEditTxt.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            using var webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/json");
            var assetListJson = await webClient.UploadDataTaskAsync("http://10.0.2.2:54495/Assets/Create", "POST", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(insertAsset)));

        }

        private void ExpWarrantyDateEditTxt_Click(object sender, EventArgs e)
        {

        }

        private void DateFinishListener(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            expWarrantyDateEditTxt.Text = e.Date.ToString("dd/MM/yyyy");
        }

        private void DepartmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var locationList = (from x in MainActivity.mLocationList
                                where x.DepartmentName == departmentSpinner.SelectedItem.ToString()
                                select x.LocationName).ToList();

            locationAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, locationList);
            locationSpinner.Adapter = locationAdapter;
        }
    }
}