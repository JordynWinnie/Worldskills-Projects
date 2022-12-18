using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S6_05272022_Windows
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
