using System;
using System.Collections.Generic;

namespace KazanS5Backend
{
    public partial class Well
    {
        public Well()
        {
            WellLayers = new HashSet<WellLayer>();
        }

        public long Id { get; set; }
        public long WellTypeId { get; set; }
        public string WellName { get; set; } = null!;
        public long GasOilDepth { get; set; }
        public long Capacity { get; set; }

        public virtual WellType WellType { get; set; } = null!;
        public virtual ICollection<WellLayer> WellLayers { get; set; }
    }
}
