namespace KazanS3Backend
{
    public partial class Asset
    {
        public Asset()
        {
            AssetOdometers = new HashSet<AssetOdometer>();
            Pmtasks = new HashSet<Pmtask>();
        }

        public long Id { get; set; }
        public string AssetSn { get; set; } = null!;
        public string AssetName { get; set; } = null!;
        public long DepartmentLocationId { get; set; }
        public long EmployeeId { get; set; }
        public long AssetGroupId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime? WarrantyDate { get; set; }

        public virtual ICollection<AssetOdometer> AssetOdometers { get; set; }
        public virtual ICollection<Pmtask> Pmtasks { get; set; }
    }
}
