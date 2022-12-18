using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_4_JordanKhong
{
    class TrainingRecordsTemplate
    {
        public string ModuleName { get; set; }
        public int DurationInDays { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EstimatedEndTime { get; set; }
        public int Progress { get; set; }
    }
}
