using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session5
{
    class CustomResultClass
    {
        // Custom class made for easy grouping of competitors:
        public string CompetitorName { get; set; }
        public string Country { get; set; }
        public double TotalMarks { get; set; }
        public int TotalSessionMarks { get; set; }
        public string Medal { get; set; }
    }
}
