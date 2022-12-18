using System;

namespace KazanQR_Paper1_7_24_2020.Models
{
    public class AssetModel
    {
        public string AssetName { get; set; }
        public string DepartmentName { get; set; }
        public string AssetSN { get; set; }
        public string AssetGroupName { get; set; }
        public DateTime? WarrantyDate { get; set; }
    }
}