using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S4_05242022_Windows
{
    public partial class Supplier
    {
        public Supplier()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
