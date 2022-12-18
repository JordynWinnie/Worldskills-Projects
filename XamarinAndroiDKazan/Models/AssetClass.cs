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

namespace XamarinSampleAndroid.Models
{
    public class AssetClass
    {
        public string AssetName { get; set; }
        public string DepartmentName { get; set; }
        public string AssetGroupName { get; set; }
        public DateTime? WarrantyDate { get; set; }
        public long AssetGroupID { get; set; }
        public long DepartmentID { get; set; }
        public string AssetSN { get; set; }
        public long UUID { get; set; }
        public string Description { get; set; }
        public string LocationName { get; set; }
        public List<AssetPhotoModel> AssetPhotos { get; set; }
        public string EmployeeFullName { get { return $"{EmployeeFirstName} {EmployeeLastName}"; } }
        public long DepartmentLocationID { get; set; }

        public long EmployeeID { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
    }
}