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
    [Activity(Label = "CountryRepresentativeActivity")]
    public class CountryRepresentativeActivity : Activity
    {
        private Button confirmArrivalBtn;
        private Button hotelBookingBtn;
        private Button updateInfoBookingBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.country_rep_main_menu_layout);
            InitView();
        }

        private void InitView()
        {
            confirmArrivalBtn = FindViewById<Button>(Resource.Id.confirmArrivalDetailsBtnCRMM);
            hotelBookingBtn = FindViewById<Button>(Resource.Id.hotelBookingBtnCRMM);
            updateInfoBookingBtn = FindViewById<Button>(Resource.Id.updateInfoBtnCRMM);

            confirmArrivalBtn.Click += ConfirmArrivalBtn_Click;
            hotelBookingBtn.Click += HotelBookingBtn_Click;
            updateInfoBookingBtn.Click += UpdateInfoBookingBtn_Click;
        }

        private void UpdateInfoBookingBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void HotelBookingBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ConfirmArrivalBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}