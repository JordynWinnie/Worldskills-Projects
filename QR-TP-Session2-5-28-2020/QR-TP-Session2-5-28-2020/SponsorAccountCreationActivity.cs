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
    [Activity(Label = "SponsorAccountCreationActivity")]
    public class SponsorAccountCreationActivity : Activity
    {
        private EditText companyNameEditText;
        private EditText userIdEditText;
        private EditText passwordEditText;
        private EditText rePasswordEditText;
        private Button createAccountBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.account_creation_layout);

            InitViews();
        }

        private void InitViews()
        {
            companyNameEditText = FindViewById<EditText>(Resource.Id.companyNameEditTextAC);
            userIdEditText = FindViewById<EditText>(Resource.Id.userIdEditTextAC);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditTextAC);
            rePasswordEditText = FindViewById<EditText>(Resource.Id.rePasswordTextAC);
            createAccountBtn = FindViewById<Button>(Resource.Id.createAccountBtnAC);

            createAccountBtn.Click += CreateAccountBtn_Click;
        }

        private async void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            if (userIdEditText.Text.Length < 8)
            {
                Toast.MakeText(this, "User ID must be 8 characters or more", ToastLength.Long).Show();
            }
            else if (!passwordEditText.Text.Equals(rePasswordEditText.Text))
            {
                Toast.MakeText(this, "Password does not match", ToastLength.Long).Show();
            }
            else
            {
                try
                {
                    var insertUser = new UserModel()
                    {
                        name = companyNameEditText.Text,
                        userId = userIdEditText.Text,
                        passwd = passwordEditText.Text,
                        userTypeIdFK = 2
                    };

                    using var webClient = new WebClient();
                    webClient.Headers.Add("Content-Type", "application/json");
                    var responseBytes = await webClient.UploadDataTaskAsync("http://10.0.2.2:60860/Packages/CreateAccount",
                        "POST", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(insertUser)));

                    Toast.MakeText(this, "User created", ToastLength.Long).Show();
                    Finish();
                }
                catch (Exception)
                {
                    Toast.MakeText(this, "User ID taken, please try another", ToastLength.Long).Show();
                }
            }
        }
    }
}