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

namespace KazanP1_7_31_2020_Mobile.Models
{
    internal class AssetItem
    {
        public Asset asset { get; set; }
        public string DepartmentName { get; set; }
        public string AssetGroupName { get; set; }

        public string LocationName { get; set; }

        public class Asset
        {
            public int ID { get; set; }
            public string AssetSN { get; set; }
            public string AssetName { get; set; }
            public int DepartmentLocationID { get; set; }
            public int EmployeeID { get; set; }
            public int AssetGroupID { get; set; }
            public string Description { get; set; }
            public DateTime? WarrantyDate { get; set; }
        }
    }
}