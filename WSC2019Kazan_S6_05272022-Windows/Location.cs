﻿using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S6_05272022_Windows
{
    public partial class Location
    {
        public Location()
        {
            DepartmentLocations = new HashSet<DepartmentLocation>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<DepartmentLocation> DepartmentLocations { get; set; }
    }
}
