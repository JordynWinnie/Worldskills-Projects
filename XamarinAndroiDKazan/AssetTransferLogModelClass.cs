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

namespace XamarinSampleAndroid
{
    public class AssetTransferLogModelClass
    {
        public long ID { get; set; }
        public long AssetID { get; set; }
        public DateTime TransferDate { get; set; }
        public string FromAssetSN { get; set; }
        public string ToAssetSN { get; set; }
        public long FromDepartmentLocationID { get; set; }
        public long ToDepartmentLocationID { get; set; }

        public string OldDepartmentName { get; set; }
        public string NewDepartmentName { get; set; }
}
}