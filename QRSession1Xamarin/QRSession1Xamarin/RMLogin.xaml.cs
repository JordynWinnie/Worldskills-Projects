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
    public partial class RMLogin : ContentPage
    {
        public RMLogin()
        {
            InitializeComponent();
        }

        private async void Login_Btn_Clicked(object sender, EventArgs e)
        {
            string path = $"http://10.0.2.2:52426/Users/Login?userid={UserID_Entry.Text}&password={Password_Entry.Text}";
            var webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/json");

            try
            {
                var response = await webClient.UploadDataTaskAsync(path, "POST", Encoding.UTF8.GetBytes(""));
                var userJson = JsonConvert.DeserializeObject<User>(Encoding.Default.GetString(response));

                await DisplayAlert("Message", $"Login Successful. Welcome, {userJson.userName}", "Ok");
                await Navigation.PushAsync(new ResourceManagement());

            }
            catch (Exception)
            {
                await DisplayAlert("Message", "Error Logging in", "Ok");
                throw;
            }
            


        }
    }
}