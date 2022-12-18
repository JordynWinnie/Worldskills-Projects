using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Widget;
using Kazan_P1_9_14_2020.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Kazan_P1_9_14_2020
{
    [Activity(Label = "Register and Edit Assets")]
    public class RegisteringAndEditingAssetsActivity : Activity
    {
        private EditText assetNameEditText;
        private Spinner departmentSpinner;
        private Spinner locationSpinner;
        private Spinner assetGroupSpinner;
        private Spinner accountableParty;
        private EditText descriptionEditText;
        private EditText expiredWarrantyEditText;
        private TextView assetSNTextView;
        private Button captureImageBtn;
        private Button browseBtn;
        private Button submitBtn;
        private Button cancelBtn;
        private ListView assetListView;

        private List<AssetPhotoModel> photoList = new List<AssetPhotoModel>();

        public string SNNumber { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.registering_and_editing_assets_layout);

            InitView();
        }

        private async void InitView()
        {
            assetNameEditText = FindViewById<EditText>(Resource.Id.assetNameEditTextADD);
            departmentSpinner = FindViewById<Spinner>(Resource.Id.departmentSpinnerADD);
            locationSpinner = FindViewById<Spinner>(Resource.Id.locationSpinnerADD);
            assetGroupSpinner = FindViewById<Spinner>(Resource.Id.assetGroupSpinnerADD);
            accountableParty = FindViewById<Spinner>(Resource.Id.accountablePartyADD);
            descriptionEditText = FindViewById<EditText>(Resource.Id.descriptionTextBoxADD);
            expiredWarrantyEditText = FindViewById<EditText>(Resource.Id.expiredWarrantyADD);
            assetSNTextView = FindViewById<TextView>(Resource.Id.assetSNADD);
            captureImageBtn = FindViewById<Button>(Resource.Id.captureImageADD);
            browseBtn = FindViewById<Button>(Resource.Id.browseADD);
            submitBtn = FindViewById<Button>(Resource.Id.submitADD);
            cancelBtn = FindViewById<Button>(Resource.Id.cancelADD);
            assetListView = FindViewById<ListView>(Resource.Id.assetListViewADD);

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

                var accountablePartyReq = await httpClient.GetAsync("http://10.0.2.2:56415/Assets/GetAccountableParty");

                if (accountablePartyReq.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await accountablePartyReq.Content.ReadAsStringAsync());
                    Console.WriteLine("Result:" + result);
                    accountableParty.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, result);
                }
            }

            departmentSpinner.ItemSelected += DepartmentSpinner_ItemSelected;
            UpdateLocations();
            UpdateSN();

            assetGroupSpinner.ItemSelected += AssetGroupSpinner_ItemSelected;
            departmentSpinner.ItemSelected += DepartmentSpinner_ItemSelected1;
            captureImageBtn.Click += CaptureImageBtn_Click;
            browseBtn.Click += BrowseBtn_Click;

            submitBtn.Click += SubmitBtn_Click;
            expiredWarrantyEditText.Click += ExpiredWarrantyEditText_Click;

            if (Intent.GetIntExtra("id", -1) != -1)
            {
                using (var httpClient = new HttpClient())
                {
                    var id = Intent.GetIntExtra("id", -1);
                    var assetQuery = await httpClient.GetAsync($"http://10.0.2.2:56415/Assets/GetAssetById?id={id}");

                    if (assetQuery.IsSuccessStatusCode)
                    {
                        photoList.Clear();
                        var result = JsonConvert.DeserializeObject<AssetModel.EditAssetModel>(await assetQuery.Content.ReadAsStringAsync());

                        descriptionEditText.Text = result.Description;
                        assetNameEditText.Text = result.AssetName;
                        if (result.WarrantyDate != null)
                        {
                            expiredWarrantyEditText.Text = result.WarrantyDate.Value.ToShortDateString();
                        }
                        assetSNTextView.Text = result.AssetSN;
                        locationSpinner.SetSelection(((ArrayAdapter)locationSpinner.Adapter).GetPosition(result.LocationName));
                        departmentSpinner.SetSelection(((ArrayAdapter)departmentSpinner.Adapter).GetPosition(result.DepartmentName));
                        assetGroupSpinner.SetSelection(((ArrayAdapter)assetGroupSpinner.Adapter).GetPosition(result.AssetGroup));

                        locationSpinner.Enabled = false;
                        departmentSpinner.Enabled = false;
                        assetGroupSpinner.Enabled = false;
                        accountableParty.SetSelection(((ArrayAdapter)accountableParty.Adapter).GetPosition(result.EmployeeName));

                        foreach (var photo in result.AssetPhotos)
                        {
                            photoList.Add(photo);
                        }

                        assetListView.Adapter = new PhotoRowAdapter(photoList, this);
                    }
                }
            }

            cancelBtn.Click += CancelBtn_Click;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void ExpiredWarrantyEditText_Click(object sender, EventArgs e)
        {
            DatePickerDialog dpd = new DatePickerDialog(this, expiredWarrantyCallBack, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dpd.Show();
            dpd.CancelEvent += Dpd_CancelEvent;
        }

        private void Dpd_CancelEvent(object sender, EventArgs e)
        {
            expiredWarrantyEditText.Text = string.Empty;
        }

        private void expiredWarrantyCallBack(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            expiredWarrantyEditText.Text = e.Date.ToShortDateString();
        }

        private async void SubmitBtn_Click(object sender, EventArgs e)
        {
            UpdateSN();
            using (var httpClient = new HttpClient())
            {
                DateTime? warranty = null;
                if (expiredWarrantyEditText.Text.Length > 0)
                {
                    warranty = DateTime.Parse(expiredWarrantyEditText.Text);
                }

                var assetGroupID = await (await httpClient.GetAsync($"http://10.0.2.2:56415/Assets/GetAssetGroupID?assetGroup={assetGroupSpinner.SelectedItem}")).Content.ReadAsStringAsync();
                var departmentLocationId = await (await httpClient.GetAsync($"http://10.0.2.2:56415/Assets/GetDepartmentLocation?department={WebUtility.UrlEncode(departmentSpinner.SelectedItem.ToString())}&location={locationSpinner.SelectedItem}")).Content.ReadAsStringAsync();
                var employeeId = await (await httpClient.GetAsync($"http://10.0.2.2:56415/Assets/GetEmployeeID?employeeName={accountableParty.SelectedItem}")).Content.ReadAsStringAsync();

                if (Intent.GetIntExtra("id", -1) != -1)
                {
                    var updateAsset = new AssetModel.CreateAsset
                    {
                        ID = Intent.GetIntExtra("id", -1),
                        AssetName = assetNameEditText.Text,
                        AssetPhotos = photoList,
                        AssetSN = SNNumber,
                        WarrantyDate = warranty,
                        Description = descriptionEditText.Text,
                        AssetGroupID = int.Parse(assetGroupID),
                        DepartmentLocationID = int.Parse(departmentLocationId),
                        EmployeeID = int.Parse(employeeId)
                    };

                    StringContent sc = new StringContent(JsonConvert.SerializeObject(updateAsset), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"http://10.0.2.2:56415/Assets/EditAsset", sc);

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        Toast.MakeText(this, "Duplicate name detected", ToastLength.Short).Show();
                    }
                    else
                    {
                        Toast.MakeText(this, "Item Updated", ToastLength.Short).Show();
                        MainActivity.isRefresh = true;
                        Finish();
                    }
                }
                else
                {
                    var insertAsset = new AssetModel.CreateAsset
                    {
                        AssetName = assetNameEditText.Text,
                        AssetPhotos = photoList,
                        AssetSN = SNNumber,
                        WarrantyDate = warranty,
                        Description = descriptionEditText.Text,
                        AssetGroupID = int.Parse(assetGroupID),
                        DepartmentLocationID = int.Parse(departmentLocationId),
                        EmployeeID = int.Parse(employeeId)
                    };
                    StringContent sc = new StringContent(JsonConvert.SerializeObject(insertAsset), Encoding.UTF8, "application/json");

                    await httpClient.PostAsync($"http://10.0.2.2:56415/Assets/CreateAsset", sc);
                    Toast.MakeText(this, "Item Added", ToastLength.Short).Show();
                    MainActivity.isRefresh = true;
                    Finish();
                }
            }
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent();
            intent.SetAction(Intent.ActionGetContent);
            intent.SetType("image/*");
            StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), 1);
        }

        private void CaptureImageBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 0 && resultCode == Result.Ok)
            {
                MemoryStream stream = new MemoryStream();

                Bitmap bitmap = (Bitmap)data.Extras.Get("data");
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                byte[] bitmapData = stream.ToArray();

                photoList.Add(new AssetPhotoModel { AssetPhoto1 = bitmapData });
                assetListView.Adapter = new PhotoRowAdapter(photoList, this);
            }
            else if (requestCode == 1 && resultCode == Result.Ok)
            {
                MemoryStream stream = new MemoryStream();
                var uri = data.Data;
                Bitmap bitmap = MediaStore.Images.Media.GetBitmap(this.ContentResolver, uri);

                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                byte[] bitmapData = stream.ToArray();

                photoList.Add(new AssetPhotoModel { AssetPhoto1 = bitmapData });
                assetListView.Adapter = new PhotoRowAdapter(photoList, this);

                new ImageConverter().ConvertFrom(bitmapData);
            }
        }

        private void DepartmentSpinner_ItemSelected1(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateSN();
        }

        private void AssetGroupSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateSN();
        }

        private async void UpdateSN()
        {
            assetSNTextView.Text = "Loading SN";
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("Web Encode: " + $"http://10.0.2.2:56415/Assets/GetSN?department={WebUtility.UrlEncode(departmentSpinner.SelectedItem.ToString())}&assetGroup={assetGroupSpinner.SelectedItem.ToString()}&location={locationSpinner.SelectedItem}");

                var SN = await httpClient.GetAsync($"http://10.0.2.2:56415/Assets/GetSN?department={WebUtility.UrlEncode(departmentSpinner.SelectedItem.ToString())}&assetGroup={assetGroupSpinner.SelectedItem.ToString()}&location={locationSpinner.SelectedItem}");
                if (SN.IsSuccessStatusCode)
                {
                    SNNumber = await SN.Content.ReadAsStringAsync();

                    assetSNTextView.Text = $"Asset SN: {SNNumber}";
                }
            }
        }

        private void DepartmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateSN();
            UpdateLocations();
        }

        private async void UpdateLocations()
        {
            using (var httpClient = new HttpClient())
            {
                var locations = await httpClient.GetAsync(WebUtility.HtmlEncode($"http://10.0.2.2:56415/Assets/GetLocation?department={WebUtility.UrlEncode(departmentSpinner.SelectedItem.ToString())}"));
                if (locations.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await locations.Content.ReadAsStringAsync());
                    Console.WriteLine("Result:" + result);
                    locationSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, result);
                }
            }

            UpdateSN();
        }
    }
}