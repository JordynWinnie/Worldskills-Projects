using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using XamarinSampleAndroid.Models;

namespace XamarinSampleAndroid
{
    [Activity(Label = "AssetTransferActivity")]
    public class AssetTransferActivity : Activity
    {
        private TextView assetNameTxt;
        private TextView currentDepartmentTxt;
        private TextView currentAssetSNTxt;
        private Spinner destinationDepartmentSpinner;
        private Spinner destinationLocationSpinner;
        private TextView newAssetSNTxt;
        private Button submitBtn;
        private Button cancelBtn;
        private AssetClass mCurrentAsset;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_asset_transfers);
            // Create your application here


            assetNameTxt = FindViewById<TextView>(Resource.Id.assetTransferAssetNameTxt);
            currentDepartmentTxt = FindViewById<TextView>(Resource.Id.assetTransferCurrentDepartmentTxt);
            currentAssetSNTxt = FindViewById<TextView>(Resource.Id.assetTransferAssetSN);
            destinationDepartmentSpinner = FindViewById<Spinner>(Resource.Id.assetTransferDestinationDepartmentSpinner);
            destinationLocationSpinner = FindViewById<Spinner>(Resource.Id.assetTransferDestinationLocationSpinner);
            newAssetSNTxt = FindViewById<TextView>(Resource.Id.assetTransferNewAssetSN);
            submitBtn = FindViewById<Button>(Resource.Id.assetTransferSubmitBtn);
            cancelBtn = FindViewById<Button>(Resource.Id.assetTransferCancelBtn);

            mCurrentAsset = (from x in MainActivity.mAssetList
                             where x.UUID == Intent.GetLongExtra("id", -1)
                             select x).First();

            assetNameTxt.Text = mCurrentAsset.AssetName;
            currentDepartmentTxt.Text = mCurrentAsset.DepartmentName;
            currentAssetSNTxt.Text = mCurrentAsset.AssetSN;
            var departments = new List<string>();

            foreach (var item in MainActivity.mDepartmentList)
            {
                departments.Add(item);
            }

            departments.Remove("None");
            departments.Remove(mCurrentAsset.DepartmentName);
            var departmentAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, departments);
            destinationDepartmentSpinner.Adapter = departmentAdapter;

            destinationDepartmentSpinner.ItemSelected += DestinationDepartmentSpinner_ItemSelected;
            destinationLocationSpinner.ItemSelected += DestinationLocationSpinner_ItemSelected;

            var locationList = (from x in MainActivity.mDepartmentLocationList
                                where x.DepartmentName.Equals(destinationDepartmentSpinner.SelectedItem.ToString())
                                select x.LocationName).ToList();

            var locationAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, locationList);

            destinationLocationSpinner.Adapter = locationAdapter;

            newAssetSNTxt.Text = mCurrentAsset.AssetSN;
            submitBtn.Click += SubmitBtn_Click;
            cancelBtn.Click += (s, e) =>
            {
                Finish();
            };
        }

        private void SubmitBtn_Click(object sender, System.EventArgs e)
        {
            var webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/json");

            var departmentID = (from x in MainActivity.mDepartmentLocationList
                                where x.DepartmentName.Equals(destinationDepartmentSpinner.SelectedItem.ToString()) &&
                                x.LocationName.Equals(destinationLocationSpinner.SelectedItem.ToString())
                                select x.DepartmentLocationID).First();

            var insertTransferLog = new AssetTransferLogModelClass
            {
                FromAssetSN = mCurrentAsset.AssetSN,
                AssetID = mCurrentAsset.UUID,
                FromDepartmentLocationID = mCurrentAsset.DepartmentLocationID,
                ToDepartmentLocationID = departmentID,
                ToAssetSN = newAssetSNTxt.Text,
                TransferDate = DateTime.Now
            };

            var json = JsonConvert.SerializeObject(insertTransferLog);

            webClient.UploadDataTaskAsync("http://10.0.2.2:50308/Assets/AddAssetTransferLog", "POST", Encoding.UTF8.GetBytes(json));

            MainActivity.needToUpdate = true;
            Finish();
        }

        private void DestinationLocationSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateSN();
        }

        private void DestinationDepartmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            var locationList = (from x in MainActivity.mDepartmentLocationList
                                where x.DepartmentName.Equals(destinationDepartmentSpinner.SelectedItem.ToString())
                                select x.LocationName).ToList();

            var locationAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, locationList);

            destinationLocationSpinner.Adapter = locationAdapter;
            UpdateSN();
        }

        void UpdateSN()
        {
            var lastFour = "";

            var departmentID = (from x in MainActivity.mDepartmentLocationList
                                where x.DepartmentName.Equals(destinationDepartmentSpinner.SelectedItem.ToString()) &&
                                x.LocationName.Equals(destinationLocationSpinner.SelectedItem.ToString())
                                select x.DepartmentLocationID).First();



            var currentLastFourDigits = (from x in MainActivity.mAssetList
                                         where x.AssetGroupID == mCurrentAsset.AssetGroupID
                                         && x.DepartmentID == departmentID
                                         orderby x.AssetSN descending
                                         select x.AssetSN);
            if (currentLastFourDigits.Any())
            {
                var tempLastFour = int.Parse(currentLastFourDigits.First().Substring(6, 4));
                lastFour = tempLastFour.ToString().PadLeft(4, '0');
            }
            else
            {
                lastFour = "0001";
            }

            newAssetSNTxt.Text = $"{departmentID.ToString().PadLeft(2, '0')}/{mCurrentAsset.AssetGroupID.ToString().PadLeft(2, '0')}/{lastFour}";
        }
    }
}