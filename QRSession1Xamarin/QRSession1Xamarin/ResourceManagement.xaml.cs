using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRSession1Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResourceManagement : ContentPage
    {
        public ResourceManagement()
        {
            InitializeComponent();
        }

        private async void Add_Btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddResource());
        }
    }
}