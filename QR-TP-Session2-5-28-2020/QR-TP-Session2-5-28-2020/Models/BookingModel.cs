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
    public class BookingModel
    {
        public int bookingId { get; set; }
        public string userIdFK { get; set; }
        public int packageIdFK { get; set; }
        public int quantityBooked { get; set; }
        public string status { get; set; }
        public string companyName { get; set; }
        public string packageName { get; set; }
        public string packageTier { get; set; }
        public int packageValue { get; set; }
    }
}