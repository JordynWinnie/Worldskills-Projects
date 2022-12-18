using System;
using System.Collections.Generic;

#nullable disable

namespace TPQR_Session1_01082022_BlazorWeb
{
    public partial class ResourceAllocation
    {
        public int AllocId { get; set; }
        public int ResIdFk { get; set; }
        public int SkillIdFk { get; set; }

        public virtual Resource ResIdFkNavigation { get; set; }
        public virtual Skill SkillIdFkNavigation { get; set; }
    }
}
