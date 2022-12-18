using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace XamarinSampleAndroid
{
    [Activity(Label = "TransferHistoryActivity")]
    public class TransferHistoryActivity : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var id = Intent.GetLongExtra("id", -1);
            SetContentView(Resource.Layout.activity_transfer_history);
            // Create your application here

            var webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/json");

            var response =
                await webClient.UploadDataTaskAsync($"http://10.0.2.2:50308/Assets/GetAllTransferHistory/{id}", "POST",
                Encoding.UTF8.GetBytes(""));

            var listOfAssetHistory = JsonConvert.DeserializeObject<List<AssetTransferLogModelClass>>(Encoding.UTF8.GetString
                (response));

            if (listOfAssetHistory.Count == 0)
            {
                Toast.MakeText(this, "No records have been found", ToastLength.Long).Show();
                Finish();
            }

            var listview = FindViewById<ListView>(Resource.Id.transferHistoryListView);
            var closeBtn = FindViewById<Button>(Resource.Id.transferHistoryCloseBtn);


            listview.Adapter = new TransferHistoryRowAdapter(listOfAssetHistory, this);

            closeBtn.Click += (s, e) =>
            {
                Finish();
            };
        }
    }
}