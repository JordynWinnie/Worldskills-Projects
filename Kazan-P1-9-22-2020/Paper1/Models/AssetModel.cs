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

namespace Paper1.Models
{
    public class AssetModel
    {
        public string AssetGroupName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime? WarrantyDate { get; set; }
        public string AssetName { get; set; }
        public string AssetSN { get; set; }
        public string AssetDescription { get; set; }
        public int ID { get; set; }
    }
}