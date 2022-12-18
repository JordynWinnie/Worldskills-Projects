using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace QR_TP_Session2_5_28_2020.Models
{
    public class UserModel
    {
        public string userId { get; set; }
        public string name { get; set; }
        public string passwd { get; set; }
        public int userTypeIdFK { get; set; }
    }
}