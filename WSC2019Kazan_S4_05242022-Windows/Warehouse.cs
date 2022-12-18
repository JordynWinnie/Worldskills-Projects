using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S4_05242022_Windows
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            OrderDestinationWarehouses = new HashSet<Order>();
            OrderSourceWarehouses = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Order> OrderDestinationWarehouses { get; set; }
        public virtual ICollection<Order> OrderSourceWarehouses { get; set; }
    }
}
