namespace KazanS3Backend
{
    public partial class PmscheduleModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? PmscheduleTypeId { get; set; }

        public virtual PmscheduleType? PmscheduleType { get; set; }
    }
}
