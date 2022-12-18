using Newtonsoft.Json;
using QRSession1Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRSession1Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RMAccountCreation : ContentPage
    {
        public RMAccountCreation()
        {
            InitializeComponent();

            Init();

        }

        public async void Init()
        {
            var webClient = new WebClient();

            webClient.Headers.Add("Content-Type", "application/json");

            string path = $"http://10.0.2.2:52426/Users/GetUserTypes";
            var response = await webClient.UploadDataTaskAsync(path, "POST", Encoding.UTF8.GetBytes(""));

            
            var userTypeJson = JsonConvert.DeserializeObject<List<UserTypes>>(Encoding.UTF8.GetString(response));

            UserType_Picker.Items.Add("1");
            UserType_Picker.Items.Add("2");
           
        }

        private async void Create_Account_Btn_Clicked(object sender, EventArgs e)
        {
            while (true)
            {
                if (!Password_Entry.Text.Equals(ReEnterPassword_Entry.Text))
                {
                    await DisplayAlert("Message", "Passwords do not match", "OK");
                }

                if (UserID_Entry.Text.Length < 8)
                {
                    await DisplayAlert("Message", "User ID has to be 8 characters and above", "OK");
                }

                var insertUser = new User
                {
                    userName = Username_Entry.Text,
                    userPw = Password_Entry.Text,
                    userId = UserID_Entry.Text,
                    userTypeIdFK = Convert.ToInt32(UserType_Picker.SelectedItem)
                };

                var webClient = new WebClient();

                webClient.Headers.Add("Content-Type", "application/json");

                string path = $"http://10.0.2.2:52426/Users/Create";
                try
                {
                    var response = await webClient.UploadDataTaskAsync(path, "POST", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(insertUser)));
                    await DisplayAlert("Message", "Upload Success!", "OK");
                }
                catch (Exception)
                {
                    await DisplayAlert("Message", "Error uploading", "OK");
                    throw;
                }
               
               

                break;

            }

            
        }
    }
}