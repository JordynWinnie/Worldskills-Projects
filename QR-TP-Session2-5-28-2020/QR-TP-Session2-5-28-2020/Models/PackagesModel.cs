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
    public class PackagesModel
    {
        public int PackageID { get; set; }
        public string Tier { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int Quantity { get; set; }
        public bool isOnline { get; set; }
        public bool isFlyer { get; set; }
        public bool isBanner { get; set; }
    }
}