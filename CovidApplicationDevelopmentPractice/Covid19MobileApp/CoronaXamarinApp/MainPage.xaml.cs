using CoronaXamarinApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoronaXamarinApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void Login_Btn_Clicked(object sender, EventArgs e)
        {
            var webClient = new WebClient();
            var path = $"http://10.0.2.2:54846/ContactTracings/Login?username={username_Entry.Text}&password={password_Entry.Text}";
            webClient.Headers.Add("Content-Type", "application/json");

            try
            {
                var response = await webClient.UploadDataTaskAsync(path, "POST", Encoding.UTF8.GetBytes(""));

                var json = JsonConvert.DeserializeObject<FTE>(Encoding.Default.GetString(response));

                await DisplayAlert("Sucess!", $"Welcome, {json.FullName}", "Ok");
                username_Entry.Text = "";
                password_Entry.Text = "";
                await Navigation.PushAsync(new RecordTemperature(json));
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Wrong username or password", "Ok");
               
            }
            

           

        }
    }
}
