using System;
using System.Collections.Generic;

namespace Kazan_P1_9_14_2020.Models
{
    internal class AssetModel
    {
        public class AssetListViewModel
        {
            public string AssetName { get; set; }
            public string DepartmentName { get; set; }
            public string AssetSN { get; set; }
            public int ID { get; set; }
            public DateTime? WarrantyDate { get; set; }

            public List<AssetPhotoModel> AssetPhotos { get; set; }
        }

        public class CreateAsset
        {
            public long ID { get; set; }
            public string AssetSN { get; set; }
            public string AssetName { get; set; }
            public long DepartmentLocationID { get; set; }
            public long EmployeeID { get; set; }
            public long AssetGroupID { get; set; }
            public string Description { get; set; }
            public Nullable<System.DateTime> WarrantyDate { get; set; }

            public List<AssetPhotoModel> AssetPhotos { get; set; }
        }

        public class EditAssetModel
        {
            public long ID { get; set; }
            public string AssetName { get; set; }
            public string EmployeeName { get; set; }
            public string LocationName { get; set; }
            public string DepartmentName { get; set; }
            public string AssetSN { get; set; }
            public DateTime? WarrantyDate { get; set; }

            public string Description { get; set; }

            public string AssetGroup { get; set; }
            public AssetPhotoModel[] AssetPhotos { get; set; }
        }
    }
}