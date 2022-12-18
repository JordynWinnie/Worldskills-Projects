using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace Paper1
{
    [Activity(Label = "RegisteringAndAddingActivity")]
    public class RegisteringAndAddingActivity : Activity
    {
        private EditText assetName;
        private Spinner departmentSpinner;
        private Spinner locationSpinner;
        private Spinner assetGroupSpinner;
        private Spinner accountablePartySpinner;
        private EditText assetDescriptionEdiText;
        private EditText expiredWarranty;
        private TextView assetSN;
        private Button captureButton;
        private Button browseImageButton;
        private ListView pictureList;
        private Button submitBtn;
        private Button cancelBtn;
        private string loadedAssetSN;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.registering_and_editing_layout);

            InitView();
        }

        private async void InitView()
        {
            if (Intent.GetIntExtra("id", -1) == -1)
            {
            }
            assetName = FindViewById<EditText>(Resource.Id.assetNameSc2);
            departmentSpinner = FindViewById<Spinner>(Resource.Id.departmentSpinnerSc2);
            locationSpinner = FindViewById<Spinner>(Resource.Id.locationSpinnerSc2);
            assetGroupSpinner = FindViewById<Spinner>(Resource.Id.assetGroupSpinnerSc2);
            accountablePartySpinner = FindViewById<Spinner>(Resource.Id.accountablePartySc2);
            assetDescriptionEdiText = FindViewById<EditText>(Resource.Id.assetDescSc2);
            expiredWarranty = FindViewById<EditText>(Resource.Id.expiredWarrantySc2);
            assetSN = FindViewById<TextView>(Resource.Id.assetSNSc2);
            captureButton = FindViewById<Button>(Resource.Id.captureImageBtnSc2);
            browseImageButton = FindViewById<Button>(Resource.Id.browseImageBtnSc2);
            pictureList = FindViewById<ListView>(Resource.Id.pictureListSc2);
            submitBtn = FindViewById<Button>(Resource.Id.submitBtnSc2);
            cancelBtn = FindViewById<Button>(Resource.Id.cancelBtnSc2);

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

                var accountablePartyQuery = await httpClient.GetAsync("http://10.0.2.2:50697/Assets/GetAccountableParty");
                if (accountablePartyQuery.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await accountablePartyQuery.Content.ReadAsStringAsync());
                    accountablePartySpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, result);
                }

                RefreshLocation();
            }

            departmentSpinner.ItemSelected += DepartmentSpinner_ItemSelected;
            assetGroupSpinner.ItemSelected += AssetGroupSpinner_ItemSelected;

            expiredWarranty.Click += ExpiredWarranty_Click;
            cancelBtn.Click += CancelBtn_Click;
            submitBtn.Click += SubmitBtn_Click;

            captureButton.Click += CaptureButton_Click;
        }

        private void CaptureButton_Click(object sender, EventArgs e)
        {
        }

        private async void SubmitBtn_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                if (string.IsNullOrEmpty(assetName.Text))
                {
                    Toast.MakeText(this, "Enter asset name", ToastLength.Short).Show();
                    return;
                }
                DateTime? expWarranty = null;
                if (DateTime.TryParse(expiredWarranty.Text, out _))
                {
                    expWarranty = DateTime.Parse(expiredWarranty.Text);
                }
                var result = await httpClient.GetAsync($"http://10.0.2.2:50697/Assets/UploadAsset" +
                    $"?assetName={assetName.Text}" +
                    $"&assetGroup={assetGroupSpinner.SelectedItem}" +
                    $"&locationName={locationSpinner.SelectedItem}" +
                    $"&departmentName={WebUtility.UrlEncode(departmentSpinner.SelectedItem.ToString())}" +
                    $"&employeeName={accountablePartySpinner.SelectedItem}" +
                    $"&description={assetDescriptionEdiText.Text}" +
                    $"&assetSN={loadedAssetSN}" +
                    $"&expiredWarranty={expWarranty}");

                if (result.IsSuccessStatusCode)
                {
                    Toast.MakeText(this, "Asset Uploaded", ToastLength.Short).Show();
                    MainActivity.isRefresh = true;
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "Name cannot be repeated", ToastLength.Short).Show();
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void ExpiredWarranty_Click(object sender, EventArgs e)
        {
            var dpd = new DatePickerDialog(this, datePicked, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dpd.CancelEvent += Dpd_CancelEvent;
            dpd.Show();
        }

        private void Dpd_CancelEvent(object sender, EventArgs e)
        {
            expiredWarranty.Text = string.Empty;
        }

        private void datePicked(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            expiredWarranty.Text = e.Date.ToShortDateString();
        }

        private void AssetGroupSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            RefreshLocation();
            RefreshSN();
        }

        private void DepartmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            RefreshLocation();
            RefreshSN();
        }

        private async void RefreshSN()
        {
            using (var httpClient = new HttpClient())
            {
                var SNQuery = await httpClient.GetAsync($"http://10.0.2.2:50697/Assets/GetSN?departmentName={WebUtility.UrlEncode(departmentSpinner.SelectedItem.ToString())}&assetGroup={assetGroupSpinner.SelectedItem}");
                loadedAssetSN = await SNQuery.Content.ReadAsStringAsync();
                assetSN.Text = $"Asset SN: {loadedAssetSN}";
            }
        }

        private async void RefreshLocation()
        {
            using (var httpClient = new HttpClient())
            {
                var locationQuery = await httpClient.GetAsync($"http://10.0.2.2:50697/Assets/GetLocation?departmentName={WebUtility.UrlEncode(departmentSpinner.SelectedItem.ToString())}");
                if (locationQuery.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await locationQuery.Content.ReadAsStringAsync());
                    locationSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, result);
                }
            }

            RefreshSN();
        }
    }
}