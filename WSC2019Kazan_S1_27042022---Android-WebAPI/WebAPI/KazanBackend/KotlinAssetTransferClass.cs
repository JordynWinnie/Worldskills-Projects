namespace KazanBackend
{
    public class KotlinAssetTransferClass
    {
        public int id { get; set; }
        public int assetId { get; set; }
        public DateTime transferDate { get; set; }
        public string fromAssetSn { get; set; }
        public string toAssetSn { get; set; }
        public int fromDepartmentLocationId { get; set; }
        public int toDepartmentLocationId { get; set; }
        public string fromDepartment { get; set; }
        public string toDepartment { get; set; }
        public string fromLocation { get; set; }
        public string toLocation { get; set; }
    }
}
