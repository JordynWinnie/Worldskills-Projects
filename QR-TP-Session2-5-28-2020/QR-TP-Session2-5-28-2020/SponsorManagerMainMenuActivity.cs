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
    [Activity(Label = "SponsorManagerMainMenuActivity")]
    public class SponsorManagerMainMenuActivity : Activity
    {
        private Button viewSponsorshipPackagesBtn;
        private Button addSponsorshipPackageBtn;
        private Button approveSponsorshipBookingBtn;
        private Button viewSponsorshipSummaryBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.sponsor_manager_main_menu_layout);

            InitView();
        }

        private void InitView()
        {
            viewSponsorshipPackagesBtn = FindViewById<Button>(Resource.Id.viewSponsorShipPackageBtnSMMM);
            addSponsorshipPackageBtn = FindViewById<Button>(Resource.Id.addSponsorShipPackageBtnSMMM);
            approveSponsorshipBookingBtn = FindViewById<Button>(Resource.Id.approveSponsorShipBookingBtnSMMM);
            viewSponsorshipSummaryBtn = FindViewById<Button>(Resource.Id.viewSponsorShipSummaryBtnSMMM);

            viewSponsorshipPackagesBtn.Click += ViewSponsorshipPackagesBtn_Click;
            addSponsorshipPackageBtn.Click += AddSponsorshipPackageBtn_Click;
            approveSponsorshipBookingBtn.Click += ApproveSponsorshipBookingBtn_Click;
            viewSponsorshipSummaryBtn.Click += ViewSponsorshipSummaryBtn_Click;
        }

        private void ViewSponsorshipSummaryBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ApproveSponsorshipBookingBtn_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ApproveSponsorshipActivity));
            StartActivity(intent);
        }

        private void AddSponsorshipPackageBtn_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AddPackagesActivity));
            StartActivity(intent);
        }

        private void ViewSponsorshipPackagesBtn_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ViewPackageActivity));
            StartActivity(intent);
        }
    }
}