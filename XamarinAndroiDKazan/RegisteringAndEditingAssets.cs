using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using XamarinSampleAndroid.Models;
using XamarinSampleAndroid.Resources.layout;

namespace XamarinSampleAndroid
{
    [Activity(Label = "RegisteringAndEditingAssets")]
    public class RegisteringAndEditingAssets : AppCompatActivity
    {
        EditText txtAssetName;
        EditText txtAssetDescription;
        EditText txtExpWarranty;
        Spinner departmentSpinner;
        Spinner locationSpinner;
        Spinner assetGroupSpinner;
        Spinner accountablePartySpinner;
        TextView txtAssetSN;
        ListView pictureLV;
        Button captureBtn;
        Button browseBtn;
        private Button submitBtn;
        private Button closeBtn;
        AssetClass mCurrentAsset = new AssetClass();
        List<PictureClass> mPictureList = new List<PictureClass>();
        PictureViewRowAdapter mPicAdapter;
        Context mContext;

        private ArrayAdapter<string> mLocationListAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_registerAsset);
            FindViews();
            // Create your application here

            var assetUUID = Intent.GetLongExtra("id", -1);


            var tempDepList = new List<string>();


            foreach (var item in MainActivity.mDepartmentList)
            {
                tempDepList.Add(item);
            }
            tempDepList.Remove("None");

            var tempAssetGroupList = new List<string>();

            foreach (var assetGroup in MainActivity.mAssetGroupList)
            {
                tempAssetGroupList.Add(assetGroup.AssetGroupName);
            }
            tempAssetGroupList.Remove("None");

            var employeeList = new List<string>();
            foreach (var item in MainActivity.mEmployeeList)
            {
                employeeList.Add($"{item.EmployeeFirstName} {item.EmployeeLastName}");
            }

            var deptSpinnerAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, tempDepList);
            var assetGroupAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, tempAssetGroupList);
            var employeeListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, employeeList);


            departmentSpinner.Adapter = deptSpinnerAdapter;
            assetGroupSpinner.Adapter = assetGroupAdapter;
            accountablePartySpinner.Adapter = employeeListAdapter;

            departmentSpinner.ItemSelected += DepartmentSpinner_ItemSelected;
            locationSpinner.ItemSelected += LocationSpinner_ItemSelected;
            assetGroupSpinner.ItemSelected += AssetGroupSpinner_ItemSelected;

            txtExpWarranty.Click += (s, e) =>
            {
                DatePickerDialog dpd = new DatePickerDialog(this, OnDateSelected, DateTime.Today.Year,
                    DateTime.Today.Month, DateTime.Today.Day);

                dpd.CancelEvent += (s, e) =>
                {
                    txtExpWarranty.Text = "No Warranty Date";
                };

                dpd.Show();
            };

            if (assetUUID == -1)
            {

            }
            else
            {
                mCurrentAsset = (from x in MainActivity.mAssetList
                                 where x.UUID == assetUUID
                                 select x).First();

                txtAssetName.Text = mCurrentAsset.AssetName;
                txtAssetDescription.Text = mCurrentAsset.Description;
                if (mCurrentAsset.WarrantyDate != null)
                {
                    txtExpWarranty.Text = ((DateTime)mCurrentAsset.WarrantyDate).ToString("dd/MM/yyyy");
                }
                else
                {
                    txtExpWarranty.Text = "No Warranty Date";
                }
                txtAssetSN.Text = mCurrentAsset.AssetSN;
                departmentSpinner.SetSelection(deptSpinnerAdapter.GetPosition(mCurrentAsset.DepartmentName));
                assetGroupSpinner.SetSelection(assetGroupAdapter.GetPosition(mCurrentAsset.AssetGroupName));
                accountablePartySpinner.SetSelection(employeeListAdapter.
                    GetPosition($"{mCurrentAsset.EmployeeFirstName} {mCurrentAsset.EmployeeLastName}"));

                if (mCurrentAsset.AssetPhotos.Count != 0)
                {
                    foreach (var item in mCurrentAsset.AssetPhotos)
                    {
                        mPictureList.Add(new PictureClass(BitmapFactory.DecodeByteArray(item.AssetPhoto1, 0, item.AssetPhoto1.Length), "Photo", item.AssetPhoto1));
                    }
                }

                locationSpinner.Enabled = false;
                departmentSpinner.Enabled = false;
                assetGroupSpinner.Enabled = false;
            }

            mPicAdapter = new PictureViewRowAdapter(mPictureList, this);
            pictureLV.Adapter = mPicAdapter;

            captureBtn.Click += (s, e) =>
            {
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 0);
            };

            browseBtn.Click += (s, e) =>
            {
                Intent intent = new Intent();
                intent.SetType("image/*");
                intent.SetAction(Intent.ActionGetContent);

                StartActivityForResult(Intent.CreateChooser(intent, "Select Image"), 1);
            };

            submitBtn.Click += SubmitBtn_Click;
            closeBtn.Click += (s, e) =>
            {
                Intent intent = new Intent();
                SetResult(Result.Canceled, intent);
                Finish();
            };
        }

        private void LocationSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateSN();
        }

        private async void SubmitBtn_Click(object sender, EventArgs e)
        {

            var tempPhotoList = new List<AssetPhotoModel>();

            //Vat checks:
            
            if (Intent.GetLongExtra("id", -1) != -1)
            {
                //Editing Asset:
                var assetId = Intent.GetLongExtra("id", -1);
                var employeeID = (from x in MainActivity.mEmployeeList
                                  where x.EmployeeFullName == accountablePartySpinner.SelectedItem.ToString()
                                  select x.EmployeeID).First();

                if (string.IsNullOrEmpty(txtAssetDescription.Text))
                {
                    Toast.MakeText(this, "Description cannot be empty", ToastLength.Short).Show();
                }
                else
                {
                    DateTime? tempDateTime;
                    if (txtExpWarranty.Text.Contains(string.Empty))
                    {
                        tempDateTime = null;
                    }
                    else
                    {
                        tempDateTime = DateTime.ParseExact(txtExpWarranty.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }

                    var updateAsset = new AssetModelClass()
                    {
                        AssetGroupID = mCurrentAsset.AssetGroupID,
                        AssetName = txtAssetName.Text,
                        AssetSN = mCurrentAsset.AssetSN,
                        DepartmentLocationID = mCurrentAsset.DepartmentLocationID,
                        Description = txtAssetDescription.Text,
                        EmployeeID = employeeID,
                        ID = mCurrentAsset.UUID,
                        WarrantyDate = tempDateTime
                    };

                    var assetJson = JsonConvert.SerializeObject(updateAsset);
                    using (var webclient = new WebClient())
                    {
                        webclient.Headers.Add("Content-Type", "application/json");
                        await webclient.UploadDataTaskAsync("http://10.0.2.2:50308/Assets/EditAsset", "POST", Encoding.UTF8.GetBytes(assetJson));
                    }

                    foreach (var item in mPictureList)
                    {
                        tempPhotoList.Add(new AssetPhotoModel { AssetID = Intent.GetLongExtra("id", -1), AssetPhoto1 = item.ImageByteArray });
                    }
                    var json = JsonConvert.SerializeObject(tempPhotoList);

                    using (var webclient = new WebClient())
                    {
                        webclient.Headers.Add("Content-Type", "application/json");
                        await webclient.UploadDataTaskAsync($"http://10.0.2.2:50308/Assets/RemoveOldPhotos/{assetId}", "POST", Encoding.UTF8.GetBytes(""));
                    }

                    using (var webclient = new WebClient())
                    {
                        webclient.Headers.Add("Content-Type", "application/json");
                        await webclient.UploadDataTaskAsync("http://10.0.2.2:50308/Assets/CreateAssetPhotos/", "POST", Encoding.UTF8.GetBytes(json));
                    }

                    
                    
                    MainActivity.needToUpdate = true;
                    Finish();
                }
            }
            else
            {
                //Add Asset:
                var assetID = (from x in MainActivity.mAssetList
                               orderby x.UUID descending
                               select x.UUID).First() + 1;

                var employeeID = (from x in MainActivity.mEmployeeList
                                  where x.EmployeeFullName == accountablePartySpinner.SelectedItem.ToString()
                                  select x.EmployeeID).First();
                var departmentId = (from x in MainActivity.mDepartmentLocationList
                                    where x.DepartmentName == departmentSpinner.SelectedItem.ToString()
                                    where x.LocationName == locationSpinner.SelectedItem.ToString()
                                    select x.DepartmentLocationID).First();

                //Vat Check:
                //Check if same name, same location:
                var checkForDuplicate = (from x in MainActivity.mAssetList
                                         where x.DepartmentLocationID == departmentId &&
                                         x.AssetName.Equals(txtAssetName.Text)
                                         select x).Any();

                if (checkForDuplicate)
                {
                    Toast.MakeText(this, "Asset name cannot be duplicate in same department!", ToastLength.Short).Show();
                }
                else if (string.IsNullOrEmpty(txtAssetDescription.Text))
                {
                    Toast.MakeText(this, "Description cannot be empty", ToastLength.Short).Show();
                }
                else
                {
                    DateTime? tempDateTime;
                    if (txtExpWarranty.Text.Contains(string.Empty))
                    {
                        tempDateTime = null;
                    }
                    else
                    {
                        tempDateTime = DateTime.ParseExact(txtExpWarranty.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }

                    var assetGroupId = (from x in MainActivity.mAssetGroupList
                                        where x.AssetGroupName == assetGroupSpinner.SelectedItem.ToString()
                                        select x.AssetGroupID).First();

                    
                    var insertAsset = new AssetModelClass()
                    {
                        AssetGroupID = assetGroupId,
                        AssetName = txtAssetName.Text,
                        AssetSN = txtAssetSN.Text,
                        DepartmentLocationID = departmentId,
                        Description = txtAssetDescription.Text,
                        EmployeeID = employeeID,
                        WarrantyDate = tempDateTime,
                        ID = assetID
                    };

                    var assetJson = JsonConvert.SerializeObject(insertAsset);
                    using (var webclient = new WebClient())
                    {
                        webclient.Headers.Add("Content-Type", "application/json");
                        webclient.UploadData("http://10.0.2.2:50308/Assets/Create", "POST", Encoding.UTF8.GetBytes(assetJson));
                    }

                    foreach (var item in mPictureList)
                    {
                        tempPhotoList.Add(new AssetPhotoModel { AssetID = assetID, AssetPhoto1 = item.ImageByteArray });
                    }
                    var json = JsonConvert.SerializeObject(tempPhotoList);

                    using (var webclient = new WebClient())
                    {
                        webclient.Headers.Add("Content-Type", "application/json");
                        await webclient.UploadDataTaskAsync("http://10.0.2.2:50308/Assets/CreateAssetPhotos/", "POST", Encoding.UTF8.GetBytes(json));
                    }
                    MainActivity.needToUpdate = true;
                    Finish();
                }

            }
           
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                switch (requestCode)
                {
                    case 0:
                        var image = (Bitmap)data.Extras.Get("data");
                        var memStream = new MemoryStream();
                        image.Compress(Bitmap.CompressFormat.Webp, 100, memStream);

                        mPictureList.Add(new PictureClass(image, "Photo 1", memStream.ToArray()));
                        mPicAdapter = new PictureViewRowAdapter(mPictureList, this);
                        pictureLV.Adapter = mPicAdapter;
                        break;
                    case 1:
                        //Get the streamed data from Image
                        System.IO.Stream stream = ContentResolver.OpenInputStream(data.Data);
                        var bitmap = BitmapFactory.DecodeStream(stream);
                        MemoryStream memoryStream = new MemoryStream();
                        //Data goes into memory stream
                        bitmap.Compress(Bitmap.CompressFormat.Webp, 100, memoryStream);

                        byte[] picData = memoryStream.ToArray();

                        mPictureList.Add(new PictureClass(bitmap, "Photoname", picData));
                        mPicAdapter = new PictureViewRowAdapter(mPictureList, this);
                        pictureLV.Adapter = mPicAdapter;
                        break;
                    default:
                        break;
                }
            }


        }

        private void AssetGroupSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateSN();
        }

        private void OnDateSelected(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            txtExpWarranty.Text = e.Date.ToString("dd/MM/yyyy");
        }

        private void DepartmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var selectedItem = departmentSpinner.SelectedItem.ToString();
            var locationList = (from x in MainActivity.mDepartmentLocationList
                                where x.DepartmentName.Equals(selectedItem)
                                select x.LocationName).ToList();

            mLocationListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem,
                locationList);



            locationSpinner.Adapter = mLocationListAdapter;

            if (Intent.GetLongExtra("id", -1) != -1)
            {
                locationSpinner.SetSelection(mLocationListAdapter.GetPosition(mCurrentAsset.LocationName));
            }

            UpdateSN();
        }

        void FindViews()
        {
            txtAssetName = FindViewById<EditText>(Resource.Id.txtAssetName);
            txtAssetDescription = FindViewById<EditText>(Resource.Id.txtAssetDesc);
            txtExpWarranty = FindViewById<EditText>(Resource.Id.txtExpWarranty);
            departmentSpinner = FindViewById<Spinner>(Resource.Id.assetDepartmentSpinner);
            locationSpinner = FindViewById<Spinner>(Resource.Id.assetLocationSpinner);
            assetGroupSpinner = FindViewById<Spinner>(Resource.Id.assetAssetGroupSpinner);
            accountablePartySpinner = FindViewById<Spinner>(Resource.Id.assetAccountablePartySpinner);
            txtAssetSN = FindViewById<TextView>(Resource.Id.txtAssetSN);
            pictureLV = FindViewById<ListView>(Resource.Id.pictureLV);
            captureBtn = FindViewById<Button>(Resource.Id.captureBtn);
            browseBtn = FindViewById<Button>(Resource.Id.browseBtn);
            submitBtn = FindViewById<Button>(Resource.Id.submitBtn);
            closeBtn = FindViewById<Button>(Resource.Id.closeBtn);
        }

        void UpdateSN()
        {
            if (Intent.GetLongExtra("id", -1) == -1)
            {
                StringBuilder depString = new StringBuilder();
                StringBuilder assetGrpString = new StringBuilder();
                StringBuilder lastFourString = new StringBuilder();

                var departmentID = (from x in MainActivity.mDepartmentLocationList
                                    where x.DepartmentName.Equals(departmentSpinner.SelectedItem.ToString()) &&
                                    x.LocationName.Equals(locationSpinner.SelectedItem.ToString())
                                    select x.DepartmentLocationID).First();

                var assetGroupID = (from x in MainActivity.mAssetGroupList
                                    where x.AssetGroupName.Equals(assetGroupSpinner.SelectedItem.ToString())
                                    select x.AssetGroupID).First();

                var currentLastFourDigits = (from x in MainActivity.mAssetList
                                             where x.AssetGroupID == assetGroupID && x.DepartmentID == departmentID
                                             orderby x.AssetSN descending
                                             select x.AssetSN);

                //Using .PadLeft(int numberOfChar, char filler)

                if (currentLastFourDigits.Any())
                {
                    var tempLastFour = int.Parse(currentLastFourDigits.First().Substring(6, 4));
                    Console.WriteLine($"Last 4 digits: {tempLastFour}");
                    tempLastFour += 1;
                    if (tempLastFour <= 9)
                    {
                        lastFourString.Append("000");
                        lastFourString.Append(tempLastFour.ToString());
                    }
                    else if (tempLastFour <= 99)
                    {
                        lastFourString.Append("00");
                        lastFourString.Append(tempLastFour.ToString());
                    }
                    else if (tempLastFour <= 999)
                    {
                        lastFourString.Append("0");
                        lastFourString.Append(tempLastFour.ToString());
                    }
                    else
                    {
                        lastFourString.Append(tempLastFour.ToString());
                    }
                }
                else
                {
                    lastFourString.Append("0001");
                }



                if (departmentID <= 9)
                {
                    depString.Append("0");
                    depString.Append(departmentID.ToString());
                }
                else
                {
                    depString.Append(departmentID.ToString());
                }

                if (assetGroupID <= 9)
                {
                    assetGrpString.Append("0");
                    assetGrpString.Append(assetGroupID.ToString());
                }
                else
                {
                    assetGrpString.Append(assetGroupID.ToString());
                }

                txtAssetSN.Text = $"{depString.ToString()}/{assetGrpString.ToString()}/{lastFourString.ToString()}";
            }

        }
    }
}