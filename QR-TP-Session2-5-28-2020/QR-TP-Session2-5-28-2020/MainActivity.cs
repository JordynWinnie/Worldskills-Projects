using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using QR_TP_Session2_5_28_2020.Models;
using System.Net;
using Android.Media;
using System.Text;
using Encoding = System.Text.Encoding;
using Newtonsoft.Json;
using Android.Content;

namespace QR_TP_Session2_5_28_2020
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button loginBtn;
        private Button createAccount;
        private EditText userIdEditText;
        private EditText passwordEditText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitView();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void InitView()
        {
            loginBtn = FindViewById<Button>(Resource.Id.buttonLogin);
            createAccount = FindViewById<Button>(Resource.Id.createNewSponsorAccountLogin);
            userIdEditText = FindViewById<EditText>(Resource.Id.userIdEditTextLogin);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditTextLogin);

            loginBtn.Click += LoginBtn_Click;
            createAccount.Click += CreateAccount_Click;
        }

        private void CreateAccount_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(SponsorAccountCreationActivity));
            StartActivity(intent);
        }

        private async void LoginBtn_Click(object sender, System.EventArgs e)
        {
            using var client = new WebClient();

            var responseBytes = await client.UploadDataTaskAsync(
                 $"http://10.0.2.2:60860/Packages/Login?userID={userIdEditText.Text}&password={passwordEditText.Text}",
                 "POST", Encoding.UTF8.GetBytes(""));

            var response = JsonConvert.DeserializeObject<UserModel>(Encoding.UTF8.GetString(responseBytes));

            if (response.userTypeIdFK == 1)
            {
                //Open manager
                var intent = new Intent(this, typeof(SponsorManagerMainMenuActivity));
                intent.PutExtra("userid", response.userId);
                StartActivity(intent);
            }
            else if (response.userTypeIdFK == 2)
            {
                //Open Sponsor
                var intent = new Intent(this, typeof(SponsorMainMenuActivity));
                intent.PutExtra("userid", response.userId);
                StartActivity(intent);
            }
        }
    }
}