using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Kazan_P1_9_14_2020.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Kazan_P1_9_14_2020
{
    [Activity(Label = "TransferHistoryActivity")]
    public class TransferHistoryActivity : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.transfer_history_layout);
            InitiView();
        }

        private async void InitiView()
        {
            using (var httpClient = new HttpClient())
            {
                var id = Intent.GetIntExtra("id", -1);
                var historyQuery = await httpClient.GetAsync($"http://10.0.2.2:56415/Assets/GetTransferHistory?id={id}");

                if (historyQuery.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<TransferHistoryModel>>(await historyQuery.Content.ReadAsStringAsync());
                    if (result.Count == 0)
                    {
                        Toast.MakeText(this, "No transfer history found", ToastLength.Short).Show();
                        Finish();
                        return;
                    }

                    FindViewById<ListView>(Resource.Id.assetTransferListView).Adapter = new TransferHistoryAdapter(result, this);
                }
            }
        }
    }
}