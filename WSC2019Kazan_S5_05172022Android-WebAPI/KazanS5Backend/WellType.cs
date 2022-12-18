using System;
using System.Collections.Generic;

namespace KazanS5Backend
{
    public partial class WellType
    {
        public WellType()
        {
            Wells = new HashSet<Well>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Well> Wells { get; set; }
    }
}
