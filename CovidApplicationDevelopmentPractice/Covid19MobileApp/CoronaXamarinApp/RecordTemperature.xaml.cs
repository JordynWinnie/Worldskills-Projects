using CoronaXamarinApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoronaXamarinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordTemperature : ContentPage
    {
        FTE _fte = new FTE();
        long _locationID = -1;
        public RecordTemperature(FTE fte)
        {
            _fte = fte;
            InitializeComponent();
        }

        private async void Record_Temp_Btn_Clicked(object sender, EventArgs e)
        {
            var webClient = new WebClient();

            var path = $"http://10.0.2.2:54846/ContactTracings/Create";
            webClient.Headers.Add("Content-Type", "application/json");

            try
            {

                var insertContactTrace = new ContactTracing
                {
                    FTE_ID = _fte.ID,
                    FullName = _fte.FullName,
                    Email = _fte.Email,
                    Contact = _fte.Contact,
                    Temp = Convert.ToDecimal(temperature_Entry.Text),
                    RegisterDateTime = DateTime.Now,
                    LocationID = _locationID
                };

                var response = await webClient.UploadDataTaskAsync(path, "POST", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(insertContactTrace)));

                await DisplayAlert("Message", "Temperature recorded!", "Ok");
            }
            
            catch (FormatException)
            {
                
                await DisplayAlert("Error", "Please enter a proper decimal for temperature", "Ok");

            }catch (Exception ex)
            {
                await DisplayAlert("Error", "Upload to database failed, details:\n" + ex.Message, "Ok");
            }
        }

        private async void floorNumber_picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roomNumber_Picker.SelectedIndex != -1)
            {
                var webClient = new WebClient();

                var path = $"http://10.0.2.2:54846/ContactTracings/GetLocationID?floorNumber={floorNumber_picker.SelectedItem}&unitNumber={roomNumber_Picker.SelectedItem}";
                webClient.Headers.Add("Content-Type", "application/json");

                var response =  await webClient.UploadDataTaskAsync(path, "POST", Encoding.UTF8.GetBytes(""));

                var jsonResult = JsonConvert.DeserializeObject<Location>(Encoding.Default.GetString(response));

                location_Label.Text = $"Selected Location: {jsonResult.LocationName} ({jsonResult.ID})";
                _locationID = jsonResult.ID;
            }
        }

        private async void roomNumber_Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (floorNumber_picker.SelectedIndex != -1)
            {
                var webClient = new WebClient();

                var path = $"http://10.0.2.2:54846/ContactTracings/GetLocationID?floorNumber={floorNumber_picker.SelectedItem}&unitNumber={roomNumber_Picker.SelectedItem}";
                webClient.Headers.Add("Content-Type", "application/json");

                var response = await webClient.UploadDataTaskAsync(path, "POST", Encoding.UTF8.GetBytes(""));

                var jsonResult = JsonConvert.DeserializeObject<Location>(Encoding.Default.GetString(response));

                location_Label.Text = $"Selected Location: {jsonResult.LocationName} ({jsonResult.ID})";
                _locationID = jsonResult.ID;
            }
        }
    }
}