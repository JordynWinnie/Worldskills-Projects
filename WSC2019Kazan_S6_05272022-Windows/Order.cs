using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S6_05272022_Windows
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public long Id { get; set; }
        public long TransactionTypeId { get; set; }
        public long? SupplierId { get; set; }
        public long? EmergencyMaintenancesId { get; set; }
        public long? SourceWarehouseId { get; set; }
        public long? DestinationWarehouseId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? Time { get; set; }

        public virtual Warehouse? DestinationWarehouse { get; set; }
        public virtual EmergencyMaintenance? EmergencyMaintenances { get; set; }
        public virtual Warehouse? SourceWarehouse { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual TransactionType TransactionType { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
