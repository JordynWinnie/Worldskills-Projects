using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;

namespace QR_TP_Session1_5_3_2020
{
    [Activity(Label = "Create an Account")]
    public class Rm_Account_Creation_Activity : Activity
    {
        private EditText usernameField;
        private EditText userIDField;
        private EditText passwordField;
        private EditText reEnterPasswordField;
        private Spinner userTypeSpinner;
        private Button createAccountButton;
        private List<UserTypeModel> userTypesRawList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RM_Account_Creation_Layout);
            // Create your application here
            Initviews();
        }

        private async void Initviews()
        {
            usernameField = FindViewById<EditText>(Resource.Id.usernameFieldRmAccountCreation);
            userIDField = FindViewById<EditText>(Resource.Id.userIDEditTxtRmAccountCreation);
            passwordField = FindViewById<EditText>(Resource.Id.passwordEditTxtRmAccountCreation);
            reEnterPasswordField = FindViewById<EditText>(Resource.Id.confirmPasswordEditTxtRmAccountCreation);
            userTypeSpinner = FindViewById<Spinner>(Resource.Id.userTypeSpinnerRMAccountCreation);
            createAccountButton = FindViewById<Button>(Resource.Id.createAccountBtnRmAccountCreation);

            using var webClient = new WebClient();
            var userTypesByteArray = await webClient.UploadDataTaskAsync("http://10.0.2.2:50721/Users/GetUserTypes", "POST", Encoding.Default.GetBytes(""));

            userTypesRawList = JsonConvert.DeserializeObject<List<UserTypeModel>>(Encoding.Default.GetString(userTypesByteArray));

            var userTypeList = userTypesRawList.Select(x=>x.userTypeName).ToList();

            userTypeSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, userTypeList);

            createAccountButton.Click += CreateAccountButton_Click;

            foreach (var item in userTypesRawList)
            {
                Console.WriteLine(item.userTypeName);
            }
        }

        private async void CreateAccountButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(userTypeSpinner.SelectedItem);

            

            if (CheckFields())
            {
                var currentTypeID = userTypesRawList.Where(x=>x.userTypeName.Equals(userTypeSpinner.SelectedItem.ToString())).Select(x=>x.userTypeId).First();
                var insertUser = new UserModel(userIDField.Text, usernameField.Text, passwordField.Text, currentTypeID);

                var uploadedUser = JsonConvert.SerializeObject(insertUser);
                using var webClient = new WebClient();
                webClient.Headers.Add("Content-Type","application/json");
              
                try
                {
                    var response = await webClient.UploadDataTaskAsync("http://10.0.2.2:50721/Users/CreateUser", "POST", Encoding.Default.GetBytes(uploadedUser));
                    var responseUser = JsonConvert.DeserializeObject<UserModel>(Encoding.Default.GetString(response));

                    if (responseUser.userId.Equals(insertUser.userId))
                    {
                        Toast.MakeText(this, "User created", ToastLength.Short).Show();
                        Finish();
                    }
                    else
                    {
                        Toast.MakeText(this, "ID Conflict", ToastLength.Short).Show();
                    }
                }
                catch (Exception)
                {
                    Toast.MakeText(this, "ID Conflict", ToastLength.Short).Show();
                    
                }
                
            }
        }

        private bool CheckFields()
        {
            if (!passwordField.Text.Equals(reEnterPasswordField.Text))
            {
                Toast.MakeText(this, "Passwords are not the same", ToastLength.Short).Show();
                return false;
            }

            if (usernameField.Text.Equals(string.Empty)|| userIDField.Text.Equals(string.Empty) ||
                passwordField.Text.Equals(string.Empty) || reEnterPasswordField.Equals(string.Empty))
            {
                Toast.MakeText(this, "Please fill up all the fields", ToastLength.Short).Show();
                return false;
            }

            if (userIDField.Text.Length < 8)
            {
                Toast.MakeText(this, "User ID should have a minimum of 8 characters", ToastLength.Short).Show();
                return false;

            }

            return true;
        }
    }
}