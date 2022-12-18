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
    [Activity(Label = "HotelSelectionActivity")]
    public class HotelSelectionActivity : Activity
    {
        private Spinner hotelSpinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.hotel_selection_layout);

            hotelSpinner = FindViewById<Spinner>(Resource.Id.hotelSelectionSpinner);
        }
    }
}