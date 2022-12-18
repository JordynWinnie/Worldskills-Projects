using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S5_05202022_Windows
{
    public partial class ChangedPart
    {
        public long Id { get; set; }
        public long EmergencyMaintenanceId { get; set; }
        public long PartId { get; set; }
        public decimal Amount { get; set; }

        public virtual EmergencyMaintenance EmergencyMaintenance { get; set; } = null!;
        public virtual Part Part { get; set; } = null!;
    }
}
