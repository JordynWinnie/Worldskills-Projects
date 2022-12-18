using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S5_05202022_Windows
{
    public partial class Part
    {
        public Part()
        {
            ChangedParts = new HashSet<ChangedPart>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? EffectiveLife { get; set; } 

        public virtual ICollection<ChangedPart> ChangedParts { get; set; }
    }
}
