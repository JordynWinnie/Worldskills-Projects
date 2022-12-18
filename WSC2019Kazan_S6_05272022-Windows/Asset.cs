using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S6_05272022_Windows
{
    public partial class Asset
    {
        public Asset()
        {
            EmergencyMaintenances = new HashSet<EmergencyMaintenance>();
        }

        public long Id { get; set; }
        public string AssetSn { get; set; } = null!;
        public string AssetName { get; set; } = null!;
        public long DepartmentLocationId { get; set; }
        public long EmployeeId { get; set; }
        public long AssetGroupId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime? WarrantyDate { get; set; }

        public virtual DepartmentLocation DepartmentLocation { get; set; } = null!;
        public virtual ICollection<EmergencyMaintenance> EmergencyMaintenances { get; set; }
    }
}
