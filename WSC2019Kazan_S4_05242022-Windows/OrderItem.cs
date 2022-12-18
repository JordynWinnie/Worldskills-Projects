using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S4_05242022_Windows
{
    public partial class OrderItem
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long PartId { get; set; }
        public string? BatchNumber { get; set; }
        public decimal Amount { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Part Part { get; set; } = null!;
    }
}
