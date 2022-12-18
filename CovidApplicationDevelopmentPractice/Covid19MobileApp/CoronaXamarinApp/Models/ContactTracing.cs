using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaXamarinApp.Models
{
    public class ContactTracing
    {
        public long ID { get; set; }
        public Nullable<long> FTE_ID { get; set; }
        public long LocationID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public decimal Temp { get; set; }
        public System.DateTime RegisterDateTime { get; set; }
        public Nullable<System.DateTime> ExitDateTime { get; set; }
    }
}
