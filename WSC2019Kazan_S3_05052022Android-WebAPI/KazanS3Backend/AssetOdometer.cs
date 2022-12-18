namespace KazanS3Backend
{
    public partial class AssetOdometer
    {
        public long Id { get; set; }
        public long AssetId { get; set; }
        public DateTime ReadDate { get; set; }
        public long OdometerAmount { get; set; }

        public virtual Asset Asset { get; set; } = null!;
    }
}
