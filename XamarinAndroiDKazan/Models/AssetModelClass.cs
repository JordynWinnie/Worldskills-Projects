using System;

namespace XamarinSampleAndroid.Models
{
    public class AssetModelClass
    {
        public long ID { get; set; }
        public string AssetSN { get; set; }
        public string AssetName { get; set; }
        public long DepartmentLocationID { get; set; }
        public long EmployeeID { get; set; }
        public long AssetGroupID { get; set; }
        public string Description { get; set; }
        public DateTime? WarrantyDate { get; set; }


    }
}