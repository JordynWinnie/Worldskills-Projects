using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Net;
using Encoding = System.Text.Encoding;

namespace QR_TP_Session1_5_3_2020
{
    [Activity(Label = "Login")]
    public class RM_Login_Activity : Activity
    {
        private Button loginBtn;
        private TextView usernameField;
        private TextView passwordField;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.RM_Login_Layout);

            InitViews();

        }

        private void InitViews()
        {
            loginBtn = FindViewById<Button>(Resource.Id.loginBtnRMLogin);
            usernameField = FindViewById<TextView>(Resource.Id.userIdEditTxtRMLogin);
            passwordField = FindViewById<TextView>(Resource.Id.passwordEditTxtRMLogin);

            loginBtn.Click += LoginBtn_Click;
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine($"http://10.0.2.2:50721/Users/Login?username={usernameField.Text}&password={passwordField.Text}");
                using var webClient = new WebClient();

                var userBytes = await webClient.UploadDataTaskAsync($"http://10.0.2.2:50721/Users/Login?username={usernameField.Text}&password={passwordField.Text}",
                    "POST", Encoding.Default.GetBytes(""));
               
                var user = JsonConvert.DeserializeObject<UserModel>(Encoding.Default.GetString(userBytes));

                if (user.userTypeIdFK == 1)
                {
                    var intent = new Intent(this, typeof(Resource_Management_Activity));
                    StartActivity(intent);
                    Toast.MakeText(this, $"Welcome back, {user.userName}!", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, $"{user.userName}, you are not allowed to login in.", ToastLength.Long).Show();
                }

                
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Cannot login", ToastLength.Short).Show();
                
            }
        }

    }
}