using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using QR_TP_Session2_5_28_2020.Models;

namespace QR_TP_Session2_5_28_2020
{
    [Activity(Label = "ViewPackageActivity")]
    public class ViewPackageActivity : Activity
    {
        private RadioGroup radioGroupViewPack;
        private RadioButton tierRadioBtn;
        private RadioButton nameRadioBtn;
        private RadioButton valueRadioBtn;
        private RadioButton availableQtyRadioBtn;
        private ListView viewPackagesLV;
        private List<PackagesModel> packageList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.view_packages_layout);
            // Create your application here

            InitView();
        }

        private void InitView()
        {
            tierRadioBtn = FindViewById<RadioButton>(Resource.Id.tierRadioBtn);
            nameRadioBtn = FindViewById<RadioButton>(Resource.Id.nameRadioBtn);
            valueRadioBtn = FindViewById<RadioButton>(Resource.Id.valueRadioBtn);
            availableQtyRadioBtn = FindViewById<RadioButton>(Resource.Id.availableQtyRadioBtn);
            viewPackagesLV = FindViewById<ListView>(Resource.Id.viewPackagesLV);

            tierRadioBtn.Checked = true;

            tierRadioBtn.CheckedChange += TierRadioBtn_CheckedChange;
            nameRadioBtn.CheckedChange += NameRadioBtn_CheckedChange;
            valueRadioBtn.CheckedChange += ValueRadioBtn_CheckedChange;
            availableQtyRadioBtn.CheckedChange += AvailableQtyRadioBtn_CheckedChange;

            RefreshList();
        }

        private void AvailableQtyRadioBtn_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            RefreshList();
        }

        private void ValueRadioBtn_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            RefreshList();
        }

        private void NameRadioBtn_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            RefreshList();
        }

        private void TierRadioBtn_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            RefreshList();
        }

        private async void RefreshList()
        {
            using var webClient = new WebClient();

            var responseBytes = await webClient.UploadDataTaskAsync("http://10.0.2.2:60860/Packages/GetPackages?accessType=1"
                , "POST", Encoding.UTF8.GetBytes(""));

            packageList = JsonConvert.DeserializeObject<List<PackagesModel>>(Encoding.UTF8.GetString(responseBytes));

            var baseQuery = (from x in packageList
                             select x).ToList();

            if (tierRadioBtn.Checked)
            {
                baseQuery = baseQuery.OrderBy(x => x.Tier).ToList();
            }

            if (nameRadioBtn.Checked)
            {
                baseQuery = baseQuery.OrderBy(x => x.Name).ToList();
            }

            if (valueRadioBtn.Checked)
            {
                baseQuery = baseQuery.OrderBy(x => x.Value).ToList();
            }

            if (availableQtyRadioBtn.Checked)
            {
                baseQuery = baseQuery.OrderByDescending(x => x.Quantity).ToList();
            }

            var packagesAdapter = new PackageGridAdapter(this, baseQuery);

            viewPackagesLV.Adapter = packagesAdapter;
        }
    }
}