using System;
using System.Collections.Generic;
using System.Text;

namespace QRSession1Xamarin.Models
{
    public class ResourceAllocation
    {
        public int? allocId { get; set; }
        public int resIdFK { get; set; }
        public int skillIdFK { get; set; }

    }
}
