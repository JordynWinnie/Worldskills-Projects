using System;

namespace Kazan_P1_9_14_2020.Models
{
    internal class TransferHistoryModel
    {
        public string OldDep { get; set; }
        public string NewDep { get; set; }
        public string FromAssetSN { get; set; }
        public string ToAssetSN { get; set; }
        public DateTime TransferDate { get; set; }
    }
}