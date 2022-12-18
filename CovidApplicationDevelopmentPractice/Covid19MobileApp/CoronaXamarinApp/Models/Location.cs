using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaXamarinApp.Models
{
    public class Location
    {
        public long ID { get; set; }
        public string LocationName { get; set; }
        public byte LocationFloor { get; set; }
        public string LocationBuildingName { get; set; }
        public byte LocationUnitNumber { get; set; }
    }
}
