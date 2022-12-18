using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S6_05272022_Windows
{
    public partial class EmergencyMaintenance
    {
        public EmergencyMaintenance()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public long AssetId { get; set; }
        public long PriorityId { get; set; }
        public string DescriptionEmergency { get; set; } = null!;
        public string OtherConsiderations { get; set; } = null!;
        public DateTime EmrequestDate { get; set; }
        public DateTime? EmstartDate { get; set; }
        public DateTime? EmendDate { get; set; }
        public string? EmtechnicianNote { get; set; }

        public virtual Asset Asset { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
