using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S6_05272022_Windows
{
    public partial class Part
    {
        public Part()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? EffectiveLife { get; set; }
        public bool? BatchNumberHasRequired { get; set; }
        public decimal? MinimumQuantity { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
