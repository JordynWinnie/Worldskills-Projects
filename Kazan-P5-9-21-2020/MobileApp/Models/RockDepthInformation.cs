using System.Collections.Generic;

namespace MobileApp.Models
{
    public class RockDepthServer
    {
        public string OldWellName { get; set; }
        public string WellName { get; set; }
        public int DepthOfGas { get; set; }

        public int WellCapacity { get; set; }
        public List<RockDepthInformation> RockInfo { get; set; }

        public bool isEditMode { get; set; }
    }

    public class RockDepthInformation
    {
        public string RockName { get; set; }

        public int fromDepth { get; set; }

        public int toDepth { get; set; }
    }
}