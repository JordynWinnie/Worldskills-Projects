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
    [Activity(Label = "AccountCreationActivity")]
    public class AccountCreationActivity : Activity
    {
        private Spinner countrySpinner;
        private EditText userIDEditText;
        private EditText passwordEditText;
        private EditText repasswordEditText;
        private Button createAccountBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.country_rep_account_creation_layout);

            InitView();
        }

        private void InitView()
        {
            countrySpinner = FindViewById<Spinner>(Resource.Id.countrySpinnerAccountCreate);
            userIDEditText = FindViewById<EditText>(Resource.Id.userIDEditTextAccountCreate);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditTextAccountCreate);
            repasswordEditText = FindViewById<EditText>(Resource.Id.repasswordEditTextAccountCreate);
            createAccountBtn = FindViewById<Button>(Resource.Id.createAccountBtnAccountCreate);

            createAccountBtn.Click += CreateAccountBtn_Click;
        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}