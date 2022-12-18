
using System;
using System.Collections.Generic;

#nullable disable

namespace TPQR_Session1_01082022_BlazorWeb
{
    public partial class Skill
    {
        public Skill()
        {
            ResourceAllocations = new HashSet<ResourceAllocation>();


        }

        public int SkillId { get; set; }
        public string SkillName { get; set; }

        public virtual ICollection<ResourceAllocation> ResourceAllocations { get; set; }
    }
}
