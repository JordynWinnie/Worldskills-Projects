using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S5_05202022_Windows
{
    public partial class AssetGroup
    {
        public AssetGroup()
        {
            Assets = new HashSet<Asset>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Asset> Assets { get; set; }
    }
}
