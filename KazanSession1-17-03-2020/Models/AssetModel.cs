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
    public class AssetModel
    {
        public long UUID { get; set; }
        public string AssetSN { get; set; }
        public string AssetName { get; set; }
        public long DepartmentLocationID { get; set; }
        public long EmployeeID { get; set; }
        public long AssetGroupID { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> WarrantyDate { get; set; }
        public string DepartmentName { get; set; }
        public string AssetGroupName { get; set; }
        public string LocationName { get; set; }

        public List<AssetPhotoModel> AssetPhotos { get; set; }
       
    }
}