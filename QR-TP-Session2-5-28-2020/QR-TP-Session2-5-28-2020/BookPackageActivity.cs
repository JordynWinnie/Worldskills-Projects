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
    [Activity(Label = "BookPackageActivity")]
    public class BookPackageActivity : Activity
    {
        private ListView packageListView;
        private TextView benefitsEditText;
        private Spinner tierSpinner;
        private List<PackagesModel> packageList;
        private EditText budgetEditText;
        private CheckBox onlineCheckbox;
        private CheckBox flyerCheckBox;
        private CheckBox bannerCheckBox;
        private Button bookPackageButton;
        private EditText quantityToBookEditText;
        private int actualValue;
        private int selectedPackage = -1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.book_package_layout);
            // Create your application here

            InitView();
        }

        private async void InitView()
        {
            packageListView = FindViewById<ListView>(Resource.Id.packagesListView);
            benefitsEditText = FindViewById<TextView>(Resource.Id.benefitTextview);
            tierSpinner = FindViewById<Spinner>(Resource.Id.tierSpinnerBookPackage);
            budgetEditText = FindViewById<EditText>(Resource.Id.budgetTextViewBookPackage);
            onlineCheckbox = FindViewById<CheckBox>(Resource.Id.onlineCheckBox);
            flyerCheckBox = FindViewById<CheckBox>(Resource.Id.flyerCheckBox);
            bannerCheckBox = FindViewById<CheckBox>(Resource.Id.bannerCheckBox);
            bookPackageButton = FindViewById<Button>(Resource.Id.bookPackageButton);
            quantityToBookEditText = FindViewById<EditText>(Resource.Id.quantityToBookEditText);

            tierSpinner.ItemSelected += TierSpinner_ItemSelected;
            budgetEditText.TextChanged += BudgetEditText_TextChanged;
            onlineCheckbox.CheckedChange += OnlineCheckbox_CheckedChange;
            flyerCheckBox.CheckedChange += FlyerCheckBox_CheckedChange;
            bannerCheckBox.CheckedChange += BannerCheckBox_CheckedChange;
            bookPackageButton.Click += BookPackageButton_Click;

            var tierList = new List<string> { "None", "Bronze", "Silver", "Gold" };

            tierSpinner.Adapter = new ArrayAdapter<string>
                (this, Android.Resource.Layout.SimpleSpinnerDropDownItem, tierList);

            FilterTable();

            packageListView.ItemClick += PackageListView_ItemClick;
        }

        private async void BookPackageButton_Click(object sender, EventArgs e)
        {
            int finalNumber = 0;
            if (int.TryParse(quantityToBookEditText.Text, out finalNumber))
            {
                if (finalNumber <= 0)
                {
                    Toast.MakeText(this, "Please enter a quantity that's more than zero", ToastLength.Short).Show();
                }
                else
                {
                    if (selectedPackage != -1)
                    {
                        var currentUserId = Intent.GetStringExtra("userid");
                        //Check db:
                        using var webClient = new WebClient();

                        try
                        {
                            var response = await webClient.UploadDataTaskAsync(
                            $"http://10.0.2.2:60860/Packages/AttemptBooking?packageID={selectedPackage}&bookingQuantity={finalNumber}&currentUserID={currentUserId}",
                            "POST", Encoding.UTF8.GetBytes(""));
                            selectedPackage = -1;
                            FilterTable();
                            Toast.MakeText(this, "Booking Successful", ToastLength.Short).Show();
                        }
                        catch (Exception)
                        {
                            Toast.MakeText(this, "There are insufficient packages available", ToastLength.Short).Show();
                        }
                    }
                    else
                    {
                        Toast.MakeText(this, "Please click on another package", ToastLength.Short).Show();
                    }
                }
            }
            else
            {
                Toast.MakeText(this, "Please type in a valid number", ToastLength.Short).Show();
            }
        }

        private void BannerCheckBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            FilterTable();
        }

        private void FlyerCheckBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            FilterTable();
        }

        private void OnlineCheckbox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            FilterTable();
        }

        private void BudgetEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            actualValue = 0;
            if (int.TryParse(budgetEditText.Text, out actualValue))
            {
                FilterTable();
            }
            else
            {
                Toast.MakeText(this, "Please type in a valid number", ToastLength.Short).Show();
            }
        }

        private void TierSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            FilterTable();
        }

        private void PackageListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(packageList[e.Position]);
            benefitsEditText.Text = $"Benefits: Online: { (packageList[e.Position].isOnline ? "Yes" : "No")} " +
                $"Flyer: {(packageList[e.Position].isFlyer ? "Yes" : "No")} Banner: {(packageList[e.Position].isBanner ? "Yes" : "No")}";
            selectedPackage = packageList[e.Position].PackageID;
        }

        private async void FilterTable()
        {
            using var webClient = new WebClient();

            var responseBytes = await webClient.UploadDataTaskAsync("http://10.0.2.2:60860/Packages/GetPackages?accessType=0"
                , "POST", Encoding.UTF8.GetBytes(""));

            packageList = JsonConvert.DeserializeObject<List<PackagesModel>>(Encoding.UTF8.GetString(responseBytes));

            var baseQuery = (from x in packageList
                             where x.Quantity != 0
                             select x).ToList();

            if (!tierSpinner.SelectedItem.ToString().Equals("None"))
            {
                baseQuery = baseQuery.Where(x => x.Tier.Equals(tierSpinner.SelectedItem.ToString())).ToList();
            }

            if (onlineCheckbox.Checked)
            {
                baseQuery = baseQuery.Where(x => x.isOnline).ToList();
            }

            if (flyerCheckBox.Checked)
            {
                baseQuery = baseQuery.Where(x => x.isFlyer).ToList();
            }

            if (bannerCheckBox.Checked)
            {
                baseQuery = baseQuery.Where(x => x.isBanner).ToList();
            }

            if (budgetEditText.Text.Length != 0)
            {
                baseQuery = baseQuery.Where(x => x.Value <= actualValue).ToList();
            }

            var packagesAdapter = new PackageGridAdapter(this, baseQuery);

            packageListView.Adapter = packagesAdapter;
        }
    }
}