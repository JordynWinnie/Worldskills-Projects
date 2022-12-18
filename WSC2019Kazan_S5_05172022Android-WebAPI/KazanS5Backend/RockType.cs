using System;
using System.Collections.Generic;

namespace KazanS5Backend
{
    public partial class RockType
    {
        public RockType()
        {
            WellLayers = new HashSet<WellLayer>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string BackgroundColor { get; set; } = null!;

        public virtual ICollection<WellLayer> WellLayers { get; set; }
    }
}
