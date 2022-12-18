using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TP_QR_Session3_7_6_2020
{
    [Activity(Label = "AdminActivity")]
    public class AdminActivity : Activity
    {
        private Button arrivalSummaryBtn;
        private Button hotelSummaryBtn;
        private Button guestsSummaryBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.admin_main_menu_layout);
            InitView();
        }

        private void InitView()
        {
            arrivalSummaryBtn = FindViewById<Button>(Resource.Id.arrivalSummaryBtnAMM);
            hotelSummaryBtn = FindViewById<Button>(Resource.Id.hotelSummaryBtnAMM);
            guestsSummaryBtn = FindViewById<Button>(Resource.Id.guestsSummaryBtnAMM);

            arrivalSummaryBtn.Click += ArrivalSummaryBtn_Click;
            hotelSummaryBtn.Click += HotelSummaryBtn_Click;
            guestsSummaryBtn.Click += GuestsSummaryBtn_Click;
        }

        private void GuestsSummaryBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void HotelSummaryBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ArrivalSummaryBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}