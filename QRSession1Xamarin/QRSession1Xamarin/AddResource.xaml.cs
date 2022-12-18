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
    public partial class AddResource : ContentPage
    {
        public AddResource()
        {
            InitializeComponent();
        }

        private async void Add_Resource_Btn_Clicked(object sender, EventArgs e)
        {
            var webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/json");
            var insertResource = new Resource
            {
                remainingQuantity = Convert.ToInt32(Quantity_Entry.Text),
                resName = Resource_Name_Entry.Text
            };
            var uploadResource = await webClient.UploadDataTaskAsync($"http://10.0.2.2:52426/Resources/Create?resType={Resouce_Type_Picker.SelectedItem.ToString()}",
                "POST", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(insertResource)));

            var resourceJson = JsonConvert.DeserializeObject<Resource>(Encoding.UTF8.GetString(uploadResource));

            var getResources = await webClient.UploadDataTaskAsync("http://10.0.2.2:52426/Resources/", "POST", Encoding.UTF8.GetBytes(""));

            Console.WriteLine(Encoding.UTF8.GetString(getResources));
            Console.WriteLine("ResourceID" + resourceJson.resId);

            if (CyberSec_Cb.IsChecked)
            {
                var insertAllocation = new ResourceAllocation
                {
                    resIdFK = resourceJson.resId,
                    skillIdFK = 1
                };

                var jsonByte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(insertAllocation));
                var uploadAllocation = await webClient.UploadDataTaskAsync("http://10.0.2.2:52426/Resource_Allocation/Create", "POST", jsonByte);
            }

            if (Networking_Cb.IsChecked)
            {
                var insertAllocation = new ResourceAllocation
                {
                    resIdFK = resourceJson.resId,
                    skillIdFK = 4
                };
                var jsonByte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(insertAllocation));
                Console.WriteLine(JsonConvert.SerializeObject(insertAllocation));
                var uploadAllocation = await webClient.UploadDataTaskAsync("http://10.0.2.2:52426/Resource_Allocation/Create", "POST", jsonByte);
            }

            if (SoftwareSln_Cb.IsChecked)
            {
                var insertAllocation = new ResourceAllocation
                {
                    resIdFK = resourceJson.resId,
                    skillIdFK = 2
                };
                var jsonByte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(insertAllocation));
                var uploadAllocation = await webClient.UploadDataTaskAsync("http://10.0.2.2:52426/Resource_Allocation/Create", "POST", jsonByte);
            }

            if (WebTech_Cb.IsChecked)
            {
                var insertAllocation = new ResourceAllocation
                {
                    resIdFK = resourceJson.resId,
                    skillIdFK = 3
                };
                var jsonByte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(insertAllocation));
                var uploadAllocation = await webClient.UploadDataTaskAsync("http://10.0.2.2:52426/Resource_Allocation/Create", "POST", jsonByte);
            }
        }
    }
}