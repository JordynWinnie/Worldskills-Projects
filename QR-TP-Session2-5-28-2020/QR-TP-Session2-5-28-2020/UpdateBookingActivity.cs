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
    [Activity(Label = "UpdateBookingActivity")]
    public class UpdateBookingActivity : Activity
    {
        private ListView updateSponsorshipBookingListView;
        private TextView totalValueTextView;
        private EditText quantityEditText;
        private Button updateQuantityBtn;
        private Button deleteQuantityBtn;
        private TextView selectedBookingTextView;
        private List<BookingModel> sponsorShipList;
        private int selectedBookingId = -1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.update_booking_layout);
            // Create your application here
            InitView();

            RefreshList();
        }

        private async void RefreshList()
        {
            var userid = Intent.GetStringExtra("userid");
            using var webClient = new WebClient();
            var responseBytes = await webClient.UploadDataTaskAsync($"http://10.0.2.2:60860/Packages/GetBookings",
                "POST", Encoding.UTF8.GetBytes(""));
            sponsorShipList = JsonConvert.DeserializeObject<List<BookingModel>>
                (Encoding.UTF8.GetString(responseBytes))
                .Where(x => x.userIdFK == userid && x.status.Equals("Approved")).ToList();

            var sponsorshipAdapter = new PackageGridAdapter(this, sponsorShipList);
            updateSponsorshipBookingListView.Adapter = sponsorshipAdapter;

            int totalValue = 0;
            foreach (var sponsorship in sponsorShipList)
            {
                var subTotal = sponsorship.packageValue * sponsorship.quantityBooked;
                totalValue += subTotal;
            }

            totalValueTextView.Text = totalValue.ToString();
        }

        private void InitView()
        {
            updateSponsorshipBookingListView = FindViewById<ListView>(Resource.Id.updateSponsorshipbookingLV);
            totalValueTextView = FindViewById<TextView>(Resource.Id.totalCostTV);
            quantityEditText = FindViewById<EditText>(Resource.Id.quantityUpdateBookingET);
            updateQuantityBtn = FindViewById<Button>(Resource.Id.updateQuantityBookingBtn);
            deleteQuantityBtn = FindViewById<Button>(Resource.Id.deleteQuantityBtn);
            selectedBookingTextView = FindViewById<TextView>(Resource.Id.selectedAPackageTV);

            updateSponsorshipBookingListView.ItemClick += UpdateSponsorshipBookingListView_ItemClick;

            updateQuantityBtn.Click += UpdateQuantityBtn_Click;
            deleteQuantityBtn.Click += DeleteQuantityBtn_Click;
        }

        private async void DeleteQuantityBtn_Click(object sender, EventArgs e)
        {
            if (selectedBookingId == -1)
            {
                Toast.MakeText(this, "Please select a package", ToastLength.Short).Show();
            }
            else
            {
                using var webClient = new WebClient();

                try
                {
                    await webClient.UploadDataTaskAsync
                    ($"http://10.0.2.2:60860/Packages/DeleteBooking?bookingID={selectedBookingId}",
                    "POST", Encoding.UTF8.GetBytes(""));
                    Toast.MakeText(this, "Delete Successful", ToastLength.Short).Show();
                    RefreshList();
                }
                catch (Exception)
                {
                    Toast.MakeText(this, "Another company has booked, you may not delete this", ToastLength.Short).Show();
                }
            }
        }

        private async void UpdateQuantityBtn_Click(object sender, EventArgs e)
        {
            int finalNumber = 0;
            if (selectedBookingId == -1)
            {
                Toast.MakeText(this, "Please select a package", ToastLength.Short).Show();
                return;
            }
            if (int.TryParse(quantityEditText.Text, out finalNumber))
            {
                if (finalNumber <= 0)
                {
                    Toast.MakeText(this, "Please enter a number larger than zero, if you would like to make it zero, please use Delete Function", ToastLength.Short).Show();
                }
                else
                {
                    using var webClient = new WebClient();

                    try
                    {
                        await webClient.UploadDataTaskAsync
                        ($"http://10.0.2.2:60860/Packages/UpdateBooking?bookingID={selectedBookingId}&quantityToUpdate={finalNumber}",
                        "POST", Encoding.UTF8.GetBytes(""));
                        Toast.MakeText(this, "Update Successful", ToastLength.Short).Show();
                        RefreshList();
                    }
                    catch (Exception)
                    {
                        Toast.MakeText(this, "Insufficient Packages available", ToastLength.Short).Show();
                    }
                }
            }
            else
            {
                Toast.MakeText(this, "Please enter a valid number", ToastLength.Short).Show();
            }
        }

        private void UpdateSponsorshipBookingListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var subtotal = sponsorShipList[e.Position].packageValue * sponsorShipList[e.Position].quantityBooked;
            selectedBookingTextView.Text = $"Selected: {sponsorShipList[e.Position].packageName} ({sponsorShipList[e.Position].packageTier}) Subtotal: {subtotal}";
            selectedBookingId = sponsorShipList[e.Position].bookingId;
        }
    }
}