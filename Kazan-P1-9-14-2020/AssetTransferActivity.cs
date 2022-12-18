using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Kazan_P1_9_14_2020.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Kazan_P1_9_14_2020
{
    [Activity(Label = "Asset Transfer")]
    public class AssetTransferActivity : Activity
    {
        private TextView assetNameLabel;
        private TextView currentDepartmentLabel;
        private TextView currentAssetSN;
        private Spinner destinationDepartmentSpinner;
        private Spinner destinationLocationSpinner;
        private TextView newAssetSN;
        private Button moveAssetSubmitBtn;
        private Button moveAssetCancelBtn;
        private AssetModel.EditAssetModel assetResult;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.asset_transfer_layout);

            InitViews();
        }

        private async void InitViews()
        {
            assetNameLabel = FindViewById<TextView>(Resource.Id.assetNameLabel);
            currentDepartmentLabel = FindViewById<TextView>(Resource.Id.currentDepartmentLabel);
            currentAssetSN = FindViewById<TextView>(Resource.Id.currentAssetSN);
            destinationDepartmentSpinner = FindViewById<Spinner>(Resource.Id.destinationDepartmentSpinner);
            destinationLocationSpinner = FindViewById<Spinner>(Resource.Id.destinationLocationSpinner);
            newAssetSN = FindViewById<TextView>(Resource.Id.newAssetSN);
            moveAssetSubmitBtn = FindViewById<Button>(Resource.Id.moveAssetSubmitBtn);
            moveAssetCancelBtn = FindViewById<Button>(Resource.Id.moveAssetCancelBtn);

            var id = Intent.GetIntExtra("id", -1);

            using (var httpClient = new HttpClient())
            {
                var assetQuery = await httpClient.GetAsync($"http://10.0.2.2:56415/Assets/GetAssetById?id={id}");
                if (assetQuery.IsSuccessStatusCode)
                {
                    assetResult = JsonConvert.DeserializeObject<AssetModel.EditAssetModel>(await assetQuery.Content.ReadAsStringAsync());

                    assetNameLabel.Text = assetResult.AssetName;

                    currentDepartmentLabel.Text = assetResult.DepartmentName;
                    currentAssetSN.Text = assetResult.AssetSN;
                }
                var departmentReq = await httpClient.GetAsync("http://10.0.2.2:56415/Assets/GetDepartments");
                if (departmentReq.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await departmentReq.Content.ReadAsStringAsync());
                    Console.WriteLine("Result:" + result);
                    result.Remove(assetResult.DepartmentName);
                    destinationDepartmentSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, result);
                    UpdateLocations();
                }
            }

            destinationDepartmentSpinner.ItemSelected += DestinationDepartmentSpinner_ItemSelected;
            destinationLocationSpinner.ItemSelected += DestinationLocationSpinner_ItemSelected;

            UpdateSN();
            UpdateLocations();

            moveAssetSubmitBtn.Click += MoveAssetSubmitBtn_Click;
            moveAssetCancelBtn.Click += MoveAssetCancelBtn_Click;
        }

        private void MoveAssetCancelBtn_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private async void MoveAssetSubmitBtn_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                var fromDepartmentLocationId = await (await
                    httpClient
                    .GetAsync($"http://10.0.2.2:56415/Assets/GetDepartmentLocation?department={WebUtility.UrlEncode(assetResult.DepartmentName)}&location={assetResult.LocationName}")).Content.ReadAsStringAsync();

                var toDepartmentLocationId = await (await
                    httpClient
                    .GetAsync($"http://10.0.2.2:56415/Assets/GetDepartmentLocation?department={WebUtility.UrlEncode(destinationDepartmentSpinner.SelectedItem.ToString())}&location={destinationLocationSpinner.SelectedItem}")).Content.ReadAsStringAsync();

                var performTransfer =
                    await httpClient.GetAsync($"http://10.0.2.2:56415/Assets/TransferAsset?currentAssetSN={currentAssetSN.Text}&changedAssetSN={newAssetSN.Text}&fromDepartmentLocation={fromDepartmentLocationId}&toDepartmentLocation={toDepartmentLocationId}&id={assetResult.ID}");

                Toast.MakeText(this, "Transferred", ToastLength.Short).Show();
                MainActivity.isRefresh = true;
                Finish();
            }
        }

        private void DestinationLocationSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateSN();
        }

        private async void UpdateSN()
        {
            newAssetSN.Text = "Loading SN...";
            using (var httpClient = new HttpClient())
            {
                var SN = await httpClient.GetAsync($"http://10.0.2.2:56415/Assets/GetSN?department={WebUtility.UrlEncode(destinationDepartmentSpinner.SelectedItem.ToString())}&assetGroup={assetResult.AssetGroup}&location={destinationLocationSpinner.SelectedItem}&id={assetResult.ID}");
                if (SN.IsSuccessStatusCode)
                {
                    newAssetSN.Text = await SN.Content.ReadAsStringAsync();
                }
            }
        }

        private void DestinationDepartmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            UpdateLocations();
            UpdateSN();
        }

        private async void UpdateLocations()
        {
            using (var httpClient = new HttpClient())
            {
                var locations = await httpClient.GetAsync(WebUtility.HtmlEncode($"http://10.0.2.2:56415/Assets/GetLocation?department={WebUtility.UrlEncode(destinationDepartmentSpinner.SelectedItem.ToString())}"));
                if (locations.IsSuccessStatusCode)
                {
                    var locationResult = JsonConvert.DeserializeObject<List<string>>(await locations.Content.ReadAsStringAsync());

                    destinationLocationSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, locationResult);
                }
            }
        }
    }
}