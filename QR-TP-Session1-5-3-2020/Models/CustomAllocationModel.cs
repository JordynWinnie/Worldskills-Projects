using System.Collections.Generic;

namespace QR_TP_Session1_5_3_2020
{
    public class CustomAllocation
    {
        public CustomAllocation(string resourceName, int resourceTypeId, int quantity, List<Skill> skills)
        {
            ResourceName = resourceName;
            ResourceTypeId = resourceTypeId;
            Quantity = quantity;
            Skills = skills;
        }

        public string ResourceName { get; set; }
        public int ResourceTypeId { get; set; }
        public int Quantity { get; set; }
        public List<Skill> Skills { get; set; }
    }
}