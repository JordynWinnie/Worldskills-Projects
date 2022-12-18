using System;
using System.Collections.Generic;

#nullable disable

namespace TPQR_Session1_01082022_BlazorWeb
{
    public partial class Resource
    {
        public Resource()
        {
            ResourceAllocations = new HashSet<ResourceAllocation>();
        }

        public int ResId { get; set; }
        public string ResName { get; set; }
        public int ResTypeIdFk { get; set; }
        public int RemainingQuantity { get; set; }

        public virtual ResourceType ResTypeIdFkNavigation { get; set; }
        public virtual ICollection<ResourceAllocation> ResourceAllocations { get; set; }
    }
}
