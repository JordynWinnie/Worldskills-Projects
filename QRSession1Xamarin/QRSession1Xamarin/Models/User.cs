using System;
using System.Collections.Generic;
using System.Text;

namespace QRSession1Xamarin.Models
{
    public class User
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string userPw { get; set; }
        public int userTypeIdFK { get; set; }
    }
}
