using System.Collections.Generic;
using System.Linq;

namespace QR_TP_Session1_5_3_2020
{
    public class ResourceListViewModel
    {
        public int ResourceId {get; set; }
        public string ResourceName { get; set; }

        public string ResourceType { get; set; }

        public int NumberOfSkills { get; set; }

        public List<Skill> AllocatedSkills { get; set; }

        public string AllocatedSkillString { get { return string.Join(", ", AllocatedSkills.Select(x => x.skillName)); } }

        public int Quantity { get; set; }


    }
}