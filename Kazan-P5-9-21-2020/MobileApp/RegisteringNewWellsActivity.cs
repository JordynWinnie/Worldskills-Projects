using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace MobileApp
{
    [Activity(Label = "RegisteringNewWellsActivity")]
    public class RegisteringNewWellsActivity : Activity
    {
        private EditText wellNameEditText;
        private EditText depthOfGas;
        private EditText wellCapacityEditText;
        private Spinner rockLayerSpinner;
        private EditText fromDepthEdiText;
        private EditText toDepthEditText;
        private Button addLayersButton;
        private ListView layerList;
        private Button submitBtn;

        private List<RockDepthInformation> rockDepthInfo = new List<RockDepthInformation>();
        private int currentDepth = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.registering_new_wells);
            InitView();
        }

        private async void InitView()
        {
            wellNameEditText = FindViewById<EditText>(Resource.Id.wellNameEditText);
            depthOfGas = FindViewById<EditText>(Resource.Id.depthOfGas);
            wellCapacityEditText = FindViewById<EditText>(Resource.Id.wellCapacityEditText);
            rockLayerSpinner = FindViewById<Spinner>(Resource.Id.rockLayerSpinner);
            fromDepthEdiText = FindViewById<EditText>(Resource.Id.fromDepthEdiText);
            toDepthEditText = FindViewById<EditText>(Resource.Id.toDepthEditText);
            addLayersButton = FindViewById<Button>(Resource.Id.addLayersButton);
            layerList = FindViewById<ListView>(Resource.Id.layerList);
            submitBtn = FindViewById<Button>(Resource.Id.submitBtn);

            using (var httpClient = new HttpClient())
            {
                if (!string.IsNullOrEmpty(Intent.GetStringExtra("wellName")))
                {
                    var rockInfo = await httpClient.GetAsync($"http://10.0.2.2:64752/Wells/GetWellInformation?wellName={WebUtility.UrlEncode(Intent.GetStringExtra("wellName"))}");
                    if (rockInfo.IsSuccessStatusCode)
                    {
                        var result = JsonConvert.DeserializeObject<List<WellInformationRowModel>>(await rockInfo.Content.ReadAsStringAsync());
                        wellNameEditText.Text = result[0].WellName;
                        depthOfGas.Text = result[0].GasOilDepth.ToString();
                        wellCapacityEditText.Text = result[0].Capacity.ToString();

                        foreach (var rock in result)
                        {
                            rockDepthInfo.Add(new RockDepthInformation { fromDepth = rock.StartPoint, toDepth = rock.EndPoint, RockName = rock.RockName });
                        }
                        currentDepth = result[0].GasOilDepth;
                        UpdateLayerList();
                    }
                }

                var rockQuery = await httpClient.GetAsync("http://10.0.2.2:64752/Wells/GetRockLayers");
                if (rockQuery.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<string>>(await rockQuery.Content.ReadAsStringAsync());
                    rockLayerSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, result);
                }
            }

            submitBtn.Click += SubmitBtn_Click;
            addLayersButton.Click += AddLayersButton_Click;
            layerList.ItemClick += LayerList_ItemClick;

            depthOfGas.FocusChange += DepthOfGas_FocusChange;
        }

        private void DepthOfGas_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if (!depthOfGas.IsFocused)
            {
                var tempDepth = 0;
                if (!int.TryParse(depthOfGas.Text, out tempDepth))
                {
                    Toast.MakeText(this, "Charatcer not allowed", ToastLength.Short).Show();
                    depthOfGas.Text = currentDepth.ToString();
                }
                else
                {
                    if (rockDepthInfo.Where(x => x.toDepth > tempDepth).Any())
                    {
                        Toast.MakeText(this, "Rocks in list exceed current depth", ToastLength.Short).Show();
                        depthOfGas.Text = currentDepth.ToString();
                    }
                    else
                    {
                        currentDepth = tempDepth;
                    }
                }
            }
        }

        private void DepthOfGas_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
        }

        private void DepthOfGas_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
        }

        private void LayerList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            rockDepthInfo.RemoveAt(e.Position);
            UpdateLayerList();
        }

        private void AddLayersButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fromDepthEdiText.Text) || string.IsNullOrEmpty(toDepthEditText.Text) || string.IsNullOrEmpty(depthOfGas.Text))
            {
                Toast.MakeText(this, "Please fill depth information.", ToastLength.Short).Show();
                return;
            }
            var fromDepth = 0;
            var toDepth = 0;
            var depthOfGasOut = 0;
            var selectedRock = rockLayerSpinner.SelectedItem.ToString();
            if (!int.TryParse(fromDepthEdiText.Text, out fromDepth) || !int.TryParse(toDepthEditText.Text, out toDepth) ||
                !int.TryParse(depthOfGas.Text, out depthOfGasOut))
            {
                Toast.MakeText(this, "One or more fields have unrecognised numbers", ToastLength.Short).Show();
                return;
            }
            if (toDepth < 0 || fromDepth < 0)
            {
                Toast.MakeText(this, "Depth cannot be less than 0", ToastLength.Short).Show();
                return;
            }
            if (toDepth < fromDepth)
            {
                Toast.MakeText(this, "ToDepth should be more than fromDepth", ToastLength.Short).Show();
                return;
            }

            if (rockDepthInfo.Where(x => (fromDepth > x.fromDepth && fromDepth < x.toDepth) || (toDepth > x.fromDepth && toDepth < x.toDepth)).Any())
            {
                Toast.MakeText(this, "Depth cannot be repeated", ToastLength.Short).Show();
                return;
            }

            if (toDepth > depthOfGasOut || fromDepth > depthOfGasOut)
            {
                Toast.MakeText(this, "Depth cannot exceed depth of gas/oil extraction", ToastLength.Short).Show();
                return;
            }

            if (rockDepthInfo.Where(x => x.RockName == selectedRock).Any())
            {
                Toast.MakeText(this, "Cannot repeat rocks on same well", ToastLength.Short).Show();
                return;
            }

            if (toDepth - fromDepth < 100)
            {
                Toast.MakeText(this, "Cannot add layer with 100 or less depth", ToastLength.Short).Show();
                return;
            }

            rockDepthInfo.Add(new RockDepthInformation { fromDepth = fromDepth, toDepth = toDepth, RockName = rockLayerSpinner.SelectedItem.ToString() });
            rockDepthInfo = rockDepthInfo.OrderBy(x => x.fromDepth).ToList();
            UpdateLayerList();
        }

        private void UpdateLayerList()
        {
            var tempList = new List<string>();
            foreach (var rock in rockDepthInfo)
            {
                tempList.Add($"{rock.RockName}\nFrom: {rock.fromDepth} to {rock.toDepth}");
            }

            layerList.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, tempList);
        }

        private async void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(wellNameEditText.Text) || string.IsNullOrEmpty(depthOfGas.Text) || string.IsNullOrEmpty(wellCapacityEditText.Text))
            {
                Toast.MakeText(this, "Please fill in all fields", ToastLength.Short).Show();
                return;
            }

            if (!rockDepthInfo.Where(x => x.fromDepth == 0).Any())
            {
                Toast.MakeText(this, "There must be a starting layer (from depth of 0)", ToastLength.Short).Show();
                return;
            }
            var wellCapacity = 0;
            var depthOfGasOut = 0;
            if (!int.TryParse(wellCapacityEditText.Text, out wellCapacity) ||
                !int.TryParse(depthOfGas.Text, out depthOfGasOut))
            {
                Toast.MakeText(this, "One or more fields have unrecognised numbers", ToastLength.Short).Show();
                return;
            }

            var oldWellName = Intent.GetStringExtra("wellName");
            var rockDepthServer = new RockDepthServer
            {
                DepthOfGas = depthOfGasOut,
                RockInfo = rockDepthInfo,
                WellCapacity = wellCapacity,
                WellName = wellNameEditText.Text,
                isEditMode = string.IsNullOrEmpty(oldWellName) ? false : true,
                OldWellName = oldWellName
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(rockDepthServer), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.PostAsync("http://10.0.2.2:64752/Wells/PostWellInfo", stringContent);
                if (result.IsSuccessStatusCode)
                {
                    Toast.MakeText(this, "Uploaded to database", ToastLength.Short).Show();
                    MainActivity.firstBoot = true;
                    Finish();
                    return;
                }
                else
                {
                    Toast.MakeText(this, "Well name taken, please choose another", ToastLength.Short).Show();
                    return;
                }
            }
        }
    }
}