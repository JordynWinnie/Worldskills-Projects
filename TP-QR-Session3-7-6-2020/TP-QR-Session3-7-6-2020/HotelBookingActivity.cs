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
    [Activity(Label = "HotelBookingActivity")]
    public class HotelBookingActivity : Activity
    {
        private TextView hotelNameTextView;
        private TextView delegateNumberTextView;
        private TextView competitorNumberTextView;
        private TextView singleRateTextView;
        private TextView numberOfSingleRoomsTextView;
        private TextView doubleRateTextView;
        private TextView numberOfDoubleRoomsTextView;
        private EditText singleRoomEditext;
        private TextView subtotalSingleRoom;
        private EditText doubleRoomEdiText;
        private TextView subtotalDoubleRoom;
        private TextView totalCostTextView;
        private Button bookHotelBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.hotel_booking_layout);
            InitView();
        }

        private void InitView()
        {
            hotelNameTextView = FindViewById<TextView>(Resource.Id.hotelNameTextViewHotelBooking);
            delegateNumberTextView = FindViewById<TextView>(Resource.Id.delegateNumberTextViewHotelBooking);
            competitorNumberTextView = FindViewById<TextView>(Resource.Id.competitorNumberTextViewHotelBooking);
            singleRateTextView = FindViewById<TextView>(Resource.Id.singleRateTextviewHotelBooking);
            numberOfSingleRoomsTextView = FindViewById<TextView>(Resource.Id.numberOfSingleRmTextviewHotelBooking);
            doubleRateTextView = FindViewById<TextView>(Resource.Id.doubleRateTextviewHotelBooking);
            numberOfDoubleRoomsTextView = FindViewById<TextView>(Resource.Id.numberOfDoubleRmTextviewHotelBooking);
            singleRoomEditext = FindViewById<EditText>(Resource.Id.SingleRmEditTextHotelBooking);
            subtotalSingleRoom = FindViewById<TextView>(Resource.Id.subtotalSingleRmTextviewHotelBooking);

            doubleRoomEdiText = FindViewById<EditText>(Resource.Id.DoubleRmEditTextHotelBooking);
            subtotalDoubleRoom = FindViewById<TextView>(Resource.Id.subtotalDoubleRmTextviewHotelBooking);

            totalCostTextView = FindViewById<TextView>(Resource.Id.totalCostTextviewHotelBooking);
            bookHotelBtn = FindViewById<Button>(Resource.Id.bookBtnHotelBooking);
        }
    }
}