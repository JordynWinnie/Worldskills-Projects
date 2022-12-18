using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace QR_TP_Session1_5_3_2020
{
    [Activity(Label = "Main Menu", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button createNewAccountBtn;
        private Button resourceManagerLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            createNewAccountBtn = FindViewById<Button>(Resource.Id.createNewAccountBtn);
            resourceManagerLogin = FindViewById<Button>(Resource.Id.resourceManagerLoginBtn);

            createNewAccountBtn.Click += CreateNewAccountBtn_Click;
            resourceManagerLogin.Click += ResourceManagerLogin_Click;

        }

        private void ResourceManagerLogin_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(RM_Login_Activity));
            StartActivity(intent);
        }

        private void CreateNewAccountBtn_Click(object sender, System.EventArgs e)
        { 
            var intent = new Intent(this, typeof(Rm_Account_Creation_Activity));
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}