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

namespace QR_TP_Session2_5_28_2020
{
    [Activity(Label = "AddPackagesActivity")]
    public class AddPackagesActivity : Activity
    {
        private Spinner tierSpinner;
        private EditText packageNameET;
        private EditText valueET;
        private EditText availableQuantityET;
        private CheckBox onlineCheckBox;
        private CheckBox flyerCheckBox;
        private CheckBox bannerCheckBox;
        private Button clearFormBtn;
        private Button addPackageBtn;

        private int itemsChecked = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.add_packages_layout);

            // Create your application here
            InitViews();
        }

        private void InitViews()
        {
            tierSpinner = FindViewById<Spinner>(Resource.Id.tierSpinnerSP);
            packageNameET = FindViewById<EditText>(Resource.Id.packageNameSP);
            valueET = FindViewById<EditText>(Resource.Id.valueSP);
            availableQuantityET = FindViewById<EditText>(Resource.Id.quantitySP);

            onlineCheckBox = FindViewById<CheckBox>(Resource.Id.onlineCheckBoxSP);
            flyerCheckBox = FindViewById<CheckBox>(Resource.Id.flyerCheckBoxSP);
            bannerCheckBox = FindViewById<CheckBox>(Resource.Id.bannerCheckBoxSP);

            clearFormBtn = FindViewById<Button>(Resource.Id.clearFormBtnSP);
            addPackageBtn = FindViewById<Button>(Resource.Id.addPackageBtnSP);

            var tierList = new List<string>() { "Gold", "Silver", "Bronze" };
            tierSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem,
                tierList);

            onlineCheckBox.CheckedChange += OnlineCheckBox_CheckedChange;
            flyerCheckBox.CheckedChange += FlyerCheckBox_CheckedChange;
            bannerCheckBox.CheckedChange += BannerCheckBox_CheckedChange;
            clearFormBtn.Click += ClearFormBtn_Click;

            addPackageBtn.Click += AddPackageBtn_Click;
        }

        private void AddPackageBtn_Click(object sender, EventArgs e)
        {
            int finalNumber = 0;
            int quantityNumber = 0;
            if (int.TryParse(availableQuantityET.Text, out quantityNumber))
            {
                if (quantityNumber <= 0)
                {
                    Toast.MakeText(this, "Please enter a quantity that is above zero", ToastLength.Short).Show();
                    return;
                }
            }
            else
            {
                Toast.MakeText(this, "Please enter a valid quantity", ToastLength.Short).Show();
                return;
            }

            if (int.TryParse(valueET.Text, out finalNumber))
            {
                if (finalNumber >= 0)
                {
                    var selectedTier = tierSpinner.SelectedItem.ToString();

                    if (selectedTier.Equals("Gold"))
                    {
                        if (finalNumber < 50000)
                        {
                            Toast.MakeText(this, "Gold items need a value of 50,000 and above", ToastLength.Short).Show();
                        }
                        else
                        {
                            if (itemsChecked != 3)
                            {
                                Toast.MakeText(this, "Gold items need all 3 benefits ticked", ToastLength.Short).Show();
                            }
                            else
                            {
                                AttemptBooking("Gold");
                            }
                        }
                    }

                    if (selectedTier.Equals("Silver"))
                    {
                        if (finalNumber < 10000 || finalNumber > 50000)
                        {
                            Toast.MakeText(this, "Silver items need a value of 10,000 to 50,000", ToastLength.Short).Show();
                        }
                        else
                        {
                            if (itemsChecked != 2)
                            {
                                Toast.MakeText(this, "Silver items can only have 2 benefits ticked", ToastLength.Short).Show();
                            }
                            else
                            {
                                AttemptBooking("Silver");
                            }
                        }
                    }

                    if (selectedTier.Equals("Bronze"))
                    {
                        if (finalNumber > 9999)
                        {
                            Toast.MakeText(this, "Bronze items need a value of below 10,000", ToastLength.Short).Show();
                        }
                        else
                        {
                            if (itemsChecked != 1)
                            {
                                Toast.MakeText(this, "Bronze items can only have 1 benefit ticked", ToastLength.Short).Show();
                            }
                            else
                            {
                                AttemptBooking("Bronze");
                            }
                        }
                    }
                }
                else
                {
                    Toast.MakeText(this, "Please enter a number more than zero", ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Please enter a valid number", ToastLength.Short).Show();
            }
        }

        private async void AttemptBooking(string tier)
        {
            using var webClient = new WebClient();
            try
            {
                await webClient.UploadDataTaskAsync(
                $"http://10.0.2.2:60860/Packages/AddPackage?tier={tier}&packageName={packageNameET.Text}&packageValue={valueET.Text}&packageQuantity={availableQuantityET.Text}&isOnline={onlineCheckBox.Checked}&isFlyer={flyerCheckBox.Checked}&isBanner={bannerCheckBox.Checked}",
                "POST", Encoding.UTF8.GetBytes(""));
                Toast.MakeText(this, "Package Uploaded", ToastLength.Short).Show();
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Package name taken, please use another", ToastLength.Short).Show();
            }
        }

        private void ClearFormBtn_Click(object sender, EventArgs e)
        {
            onlineCheckBox.Checked = false;
            flyerCheckBox.Checked = false;
            bannerCheckBox.Checked = false;

            itemsChecked = 0;
            packageNameET.Text = "";
            valueET.Text = "";
            availableQuantityET.Text = "";
        }

        private void BannerCheckBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (bannerCheckBox.Checked)
            {
                itemsChecked++;
            }
            else
            {
                itemsChecked--;
            }
        }

        private void FlyerCheckBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (flyerCheckBox.Checked)
            {
                itemsChecked++;
            }
            else
            {
                itemsChecked--;
            }
        }

        private void OnlineCheckBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (onlineCheckBox.Checked)
            {
                itemsChecked++;
            }
            else
            {
                itemsChecked--;
            }
        }
    }
}