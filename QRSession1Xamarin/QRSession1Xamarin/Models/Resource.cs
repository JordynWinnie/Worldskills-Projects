using System;
using System.Collections.Generic;
using System.Text;

namespace QRSession1Xamarin.Models
{
    public class Resource
    {
        public int resId { get; set; }
        public string resName { get; set; }
        public int resTypeIdFK { get; set; }
        public int remainingQuantity { get; set; }
    }
}
