using System;
using System.Collections.Generic;

#nullable disable

namespace TPQR_Session1_01082022_BlazorWeb
{
    public partial class ResourceType
    {
        public ResourceType()
        {
            Resources = new HashSet<Resource>();
        }

        public int ResTypeId { get; set; }
        public string ResTypeName { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
