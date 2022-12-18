using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using System.Net;
using Android.Media;
using System.Text;
using Newtonsoft.Json;
using TP_QR_Session3_7_6_2020.Models;
using System.Collections.Generic;

namespace TP_QR_Session3_7_6_2020
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText userId;
        private EditText password;
        private Button loginBtn;
        private Button createAccount;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitViews();
        }

        private void InitViews()
        {
            userId = FindViewById<EditText>(Resource.Id.userIDEditTextLogin);
            password = FindViewById<EditText>(Resource.Id.passwordEditTextLogin);
            loginBtn = FindViewById<Button>(Resource.Id.loginBtnLogin);
            createAccount = FindViewById<Button>(Resource.Id.createNewCRALogin);

            loginBtn.Click += LoginBtn_Click;
            createAccount.Click += CreateAccount_Click;
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AccountCreationActivity));
            StartActivity(intent);
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            using var webClient = new WebClient();

            try
            {
                var responseBytes = await
                        webClient.UploadDataTaskAsync($"http://10.0.2.2:54037/Users/Login?userid={userId.Text}&password={password.Text}", "POST",
                        System.Text.Encoding.UTF8.GetBytes(""));

                var user = JsonConvert.DeserializeObject<UserModel>(System.Text.Encoding.UTF8.GetString(responseBytes));

                if (user.userTypeIdFK == 1)
                {
                    var intent = new Intent(this, typeof(AdminActivity));
                    StartActivity(intent);
                }
                else if (user.userTypeIdFK == 2)
                {
                    var intent = new Intent(this, typeof(CountryRepresentativeActivity));
                    StartActivity(intent);
                }
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Error logging in", ToastLength.Short).Show();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}