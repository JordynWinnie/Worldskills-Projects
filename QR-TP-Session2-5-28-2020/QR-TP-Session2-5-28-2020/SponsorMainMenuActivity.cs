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

namespace QR_TP_Session2_5_28_2020
{
    [Activity(Label = "SponsorMainMenuActivity")]
    public class SponsorMainMenuActivity : Activity
    {
        private Button bookSponsorShipPackageBtn;
        private Button updateSponsorShipBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.sponsor_main_menu);

            InitView();
        }

        private void InitView()
        {
            bookSponsorShipPackageBtn = FindViewById<Button>(Resource.Id.bookSponsorshipBtnMainMenu);
            updateSponsorShipBtn = FindViewById<Button>(Resource.Id.updateSponsorshipBookngsBtnMainMenu);

            bookSponsorShipPackageBtn.Click += BookSponsorShipPackageBtn_Click;
            updateSponsorShipBtn.Click += UpdateSponsorShipBtn_Click;
        }

        private void UpdateSponsorShipBtn_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(UpdateBookingActivity));
            intent.PutExtra("userid", Intent.GetStringExtra("userid"));
            StartActivity(intent);
        }

        private void BookSponsorShipPackageBtn_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BookPackageActivity));
            intent.PutExtra("userid", Intent.GetStringExtra("userid"));
            StartActivity(intent);
        }
    }
}