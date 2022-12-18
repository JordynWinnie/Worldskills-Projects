using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S5_05202022_Windows
{
    public partial class EmergencyMaintenance
    {
        public EmergencyMaintenance()
        {
            ChangedParts = new HashSet<ChangedPart>();
        }

        public long Id { get; set; }
        public long AssetId { get; set; }
        public long PriorityId { get; set; }
        public string DescriptionEmergency { get; set; } = null!;
        public string OtherConsiderations { get; set; } = null!;
        public DateTime EmreportDate { get; set; }
        public DateTime? EmstartDate { get; set; }
        public DateTime? EmendDate { get; set; }
        public string? EmtechnicianNote { get; set; }

        public virtual Asset Asset { get; set; } = null!;
        public virtual Priority Priority { get; set; } = null!;
        public virtual ICollection<ChangedPart> ChangedParts { get; set; }
    }
}
