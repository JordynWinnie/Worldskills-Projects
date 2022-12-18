using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S5_05202022_Windows
{
    public partial class Priority
    {
        public Priority()
        {
            EmergencyMaintenances = new HashSet<EmergencyMaintenance>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<EmergencyMaintenance> EmergencyMaintenances { get; set; }
    }
}
