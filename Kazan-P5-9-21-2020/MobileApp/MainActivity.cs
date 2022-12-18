using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace MobileApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Spinner wellNameSpinner;
        private ListView oilListView;
        private TextView wellCapacity;
        private Button addWellButton;
        private Button editButton;
        private TextView connectionStatus;
        private bool isConnected;

        private bool previousConnectivityState = true;
        public static bool firstBoot = true;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitView();

            using (var httpClient = new HttpClient())
            {
                var wellQuery = await httpClient.GetAsync("http://10.0.2.2/Wells/GetWellInformation?wellName=Yolka %2312 ");
                if (wellQuery.IsSuccessStatusCode)
                {
                    Toast.MakeText(this, await wellQuery.Content.ReadAsStringAsync(), ToastLength.Short).Show();
                }
            }

            var timer = new System.Threading.Timer(
                (e) =>
            {
                RunOnUiThread(new Action(CheckForNetwork));
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        private void CheckForNetwork()
        {
            ConnectivityManager cm = (ConnectivityManager)this.GetSystemService(Context.ConnectivityService);
            var activeNetwork = cm.ActiveNetworkInfo;

            isConnected = activeNetwork != null &&
                      activeNetwork.IsConnectedOrConnecting;

            string lastSysTime = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "time.txt");

            if (isConnected && previousConnectivityState == false)
            {
                RefreshDataBase();
                previousConnectivityState = true;
                Toast.MakeText(this, $"Internet Connection restored.", ToastLength.Short).Show();
                connectionStatus.Text = $"Connection Status: Connected to database";

                addWellButton.Enabled = true;
                editButton.Enabled = true;
            }
            else if (!isConnected && previousConnectivityState == true)
            {
                string wellnamePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "wellNames.txt");
                if (File.Exists(wellnamePath))
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(wellnamePath));
                    wellNameSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, result);
                }
                addWellButton.Enabled = false;
                editButton.Enabled = false;
                previousConnectivityState = false;
                Toast.MakeText(this, $"Internet Connection has been lost.", ToastLength.Short).Show();
                if (File.Exists(lastSysTime))
                {
                    connectionStatus.Text = $"Connection Status: No Internet. Last Updated: {File.ReadAllText(lastSysTime)}";
                }
                else
                {
                    connectionStatus.Text = $"Connection Status: No Internet. Last Updated: -";
                }
            }
            else if (!isConnected && previousConnectivityState == false)
            {
                addWellButton.Enabled = false;
                editButton.Enabled = false;
                if (File.Exists(lastSysTime))
                {
                    connectionStatus.Text = $"Connection Status: No Internet. Last Updated: {File.ReadAllText(lastSysTime)}";
                }
                else
                {
                    connectionStatus.Text = $"Connection Status: No Internet. Last Updated: -";
                }
            }
            else
            {
                if (firstBoot)
                {
                    RefreshDataBase();
                    firstBoot = false;
                }
                addWellButton.Enabled = true;
                editButton.Enabled = true;
                connectionStatus.Text = $"Connection Status: Connected to database";
            }
        }

        private async void InitView()
        {
            connectionStatus = FindViewById<TextView>(Resource.Id.connectionStatus);
            wellNameSpinner = FindViewById<Spinner>(Resource.Id.wellNameSpinner);
            oilListView = FindViewById<ListView>(Resource.Id.oilView);
            wellCapacity = FindViewById<TextView>(Resource.Id.wellCapacity);
            addWellButton = FindViewById<Button>(Resource.Id.addWellButton);
            editButton = FindViewById<Button>(Resource.Id.editButton);

            wellNameSpinner.ItemSelected += WellNameSpinner_ItemSelected;
            addWellButton.Click += AddWellButton_Click;
            editButton.Click += EditButton_Click;
        }

        private async void RefreshDataBase()
        {
            string wellnamePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "wellNames.txt");
            string oilPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "oilList.txt");
            string lastSysTime = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "time.txt");

            using (var httpClient = new HttpClient())
            {
                var wellName = await httpClient.GetAsync("http://10.0.2.2:64752/Wells/GetWells");
                if (wellName.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await wellName.Content.ReadAsStringAsync());
                    wellNameSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, result);

                    File.WriteAllText(wellnamePath, JsonConvert.SerializeObject(result));
                }
                var wellInformation = await httpClient.GetAsync($"http://10.0.2.2:64752/Wells/GetWellInformation?wellName={WebUtility.UrlEncode(wellNameSpinner.SelectedItem.ToString())}");
                if (wellInformation.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<WellInformationRowModel>>(await wellInformation.Content.ReadAsStringAsync());
                    oilListView.Adapter = new WellAdapter(result, this);

                    wellCapacity.Text = $"Well Capacity: {result[0].Capacity} m^3";
                }
                var offlineInfo = await httpClient.GetAsync($"http://10.0.2.2:64752/Wells/GetWellInformation?wellName=");
                if (offlineInfo.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<WellInformationRowModel>>(await offlineInfo.Content.ReadAsStringAsync());
                    File.WriteAllText(oilPath, JsonConvert.SerializeObject(result));
                }

                File.WriteAllText(lastSysTime, $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisteringNewWellsActivity));
            intent.PutExtra("wellName", wellNameSpinner.SelectedItem.ToString());
            StartActivity(intent);
        }

        private void AddWellButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisteringNewWellsActivity));
            StartActivity(intent);
        }

        private async void WellNameSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                if (isConnected)
                {
                    var wellInformation = await httpClient.GetAsync($"http://10.0.2.2:64752/Wells/GetWellInformation?wellName={WebUtility.UrlEncode(wellNameSpinner.SelectedItem.ToString())}");
                    if (wellInformation.IsSuccessStatusCode)
                    {
                        var result = JsonConvert.DeserializeObject<List<WellInformationRowModel>>(await wellInformation.Content.ReadAsStringAsync());
                        oilListView.Adapter = new WellAdapter(result, this);
                        wellCapacity.Text = $"Well Capacity: {result[0].Capacity} m^3";
                    }
                }
                else
                {
                    string oilPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "oilList.txt");

                    if (File.Exists(oilPath))
                    {
                        var result = JsonConvert.DeserializeObject<List<WellInformationRowModel>>(File.ReadAllText(oilPath));
                        result = result.Where(x => x.WellName == wellNameSpinner.SelectedItem.ToString()).ToList();
                        oilListView.Adapter = new WellAdapter(result, this);
                    }
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}