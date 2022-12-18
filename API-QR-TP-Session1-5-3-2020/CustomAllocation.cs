using System.Collections.Generic;

namespace API_QR_TP_Session1_5_3_2020
{
    public class CustomAllocation
    {
        public string ResourceName { get; set; }
        public int ResourceTypeId { get; set; }
        public int Quantity { get; set; }

        public List<Skill> Skills { get; set; }
    }
}