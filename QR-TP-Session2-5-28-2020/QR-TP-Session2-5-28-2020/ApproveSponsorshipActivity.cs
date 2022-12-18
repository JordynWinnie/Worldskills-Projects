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
    [Activity(Label = "ApproveSponsorshipActivity")]
    public class ApproveSponsorshipActivity : Activity
    {
        private ListView approveSponsorshipListView;
        private Button approveBtn;
        private Button rejectBtn;
        private TextView selectedPackageTextView;
        private List<BookingModel> bookingList;
        private int selectedBookingID = -1;
        private string approvalStatus;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.approve_sponsorship_layout);
            // Create your application here
            InitView();
        }

        private void InitView()
        {
            approveSponsorshipListView = FindViewById<ListView>(Resource.Id.approveSponsorshipListView);
            approveBtn = FindViewById<Button>(Resource.Id.approveBtn);
            rejectBtn = FindViewById<Button>(Resource.Id.rejectBtn);
            selectedPackageTextView = FindViewById<TextView>(Resource.Id.selectedPackageTV);

            approveBtn.Click += ApproveBtn_Click;
            rejectBtn.Click += RejectBtn_Click;
            approveSponsorshipListView.ItemClick += ApproveSponsorshipListView_ItemClick;

            RefreshList();
        }

        private void ApproveSponsorshipListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            selectedPackageTextView.Text = $"Selected Package: {bookingList[e.Position].packageName} by {bookingList[e.Position].companyName}";
            selectedBookingID = bookingList[e.Position].bookingId;
            approvalStatus = bookingList[e.Position].status;
        }

        private async void RefreshList()
        {
            using var webClient = new WebClient();

            var responseByte = await webClient.UploadDataTaskAsync("http://10.0.2.2:60860/Packages/GetBookings", "POST",
                Encoding.UTF8.GetBytes(""));

            bookingList = JsonConvert.DeserializeObject<List<BookingModel>>(Encoding.UTF8.GetString(responseByte)).OrderBy(x => x.status).ToList();

            var bookingAdapter = new BookingAdapter(this, bookingList);
            approveSponsorshipListView.Adapter = bookingAdapter;
        }

        private async void RejectBtn_Click(object sender, EventArgs e)
        {
            if (selectedBookingID != -1)
            {
                if (approvalStatus.Equals("Pending"))
                {
                    using var webClient = new WebClient();
                    await webClient.UploadDataTaskAsync($"http://10.0.2.2:60860/Packages/ChangeBookingStatus?bookingID={selectedBookingID}&approved=false",
                        "POST", Encoding.UTF8.GetBytes(""));

                    Toast.MakeText(this, "Reject successful", ToastLength.Short).Show();
                    RefreshList();
                }
                else
                {
                    Toast.MakeText(this, "Package has already been " + approvalStatus, ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Please select a package to reject", ToastLength.Short).Show();
            }
        }

        private async void ApproveBtn_Click(object sender, EventArgs e)
        {
            if (selectedBookingID != -1)
            {
                if (approvalStatus.Equals("Pending"))
                {
                    using var webClient = new WebClient();
                    await webClient.UploadDataTaskAsync($"http://10.0.2.2:60860/Packages/ChangeBookingStatus?bookingID={selectedBookingID}&approved=true",
                        "POST", Encoding.UTF8.GetBytes(""));

                    Toast.MakeText(this, "Approval successful", ToastLength.Short).Show();
                    RefreshList();
                }
                else
                {
                    Toast.MakeText(this, "Package has already been " + approvalStatus, ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Please select a package to approve", ToastLength.Short).Show();
            }
        }
    }
}