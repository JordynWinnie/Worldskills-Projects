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

namespace KazanSession1_17_02_2020.Models
{
    public class DepartmentLocationModel
    {
        public long ID { get; set; }
        public long DepartmentID { get; set; }
        public long LocationID { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }

        public long DepartmentLocationID { get; set; }

        public string DepartmentName { get; set; }

        public string LocationName { get; set; }
    }
}