﻿using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S5_05202022_Windows
{
    public partial class DepartmentLocation
    {
        public DepartmentLocation()
        {
            Assets = new HashSet<Asset>();
        }

        public long Id { get; set; }
        public long DepartmentId { get; set; }
        public long LocationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
