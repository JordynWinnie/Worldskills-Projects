namespace KazanS3Backend
{
    public partial class PmscheduleType
    {
        public PmscheduleType()
        {
            PmscheduleModels = new HashSet<PmscheduleModel>();
            Pmtasks = new HashSet<Pmtask>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<PmscheduleModel> PmscheduleModels { get; set; }
        public virtual ICollection<Pmtask> Pmtasks { get; set; }
    }
}
