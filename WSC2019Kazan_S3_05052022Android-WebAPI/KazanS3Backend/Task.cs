namespace KazanS3Backend
{
    public partial class Task
    {
        public Task()
        {
            Pmtasks = new HashSet<Pmtask>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Pmtask> Pmtasks { get; set; }
    }
}
