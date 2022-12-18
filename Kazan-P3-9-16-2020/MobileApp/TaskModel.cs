using System;

namespace MobileApp
{
    internal class TaskModel
    {
        public int? ScheduleKilometer { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public string AssetName { get; set; }
        public string AssetSN { get; set; }
        public string TaskName { get; set; }
        public string ScheduleTypeName { get; set; }
        public bool TaskDone { get; set; }
        public int TaskID { get; set; }

        public int ID { get; set; }
    }
}