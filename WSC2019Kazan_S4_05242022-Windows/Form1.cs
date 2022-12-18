using System.Diagnostics;
using System.Reflection;

namespace WSC2019Kazan_S4_05242022_Windows
{
    public partial class Form1 : Form
    {
        private List<TransactionType> transactionTypesList;
        private List<Supplier> suppliersList;
        private List<Warehouse> warehousesList;
        private List<Part> partsList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            var columns = new List<string>()
            {
                "Part Name", "Transaction Type", "Date", "Amount", "Source", 
                "Destination"
            };

            columns.ForEach(x => dataDGV.Columns.Add(x,x));

            dataDGV.Columns.Add("OrderItemId", "OrderItemId");
            dataDGV.Columns.Add("OrderPartId", "OrderPartId");

            

            dataDGV.Columns.Add(new DataGridViewLinkColumn
            {
                Text = "Edit",
                UseColumnTextForLinkValue = true,
                HeaderText = "Edit"
            });

            dataDGV.Columns.Add(new DataGridViewLinkColumn
            {
                Text = "Remove",
                UseColumnTextForLinkValue = true,
                HeaderText = "Remove"
            });

            RefreshList();
        }

        void RefreshList()
        {
            dataDGV.Rows.Clear();
            using (var context = new Session4Context())
            {
                transactionTypesList = context.TransactionTypes.ToList();
                suppliersList = context.Suppliers.ToList();
                warehousesList = context.Warehouses.ToList();
                partsList = context.Parts.ToList();


                var orders = context.Orders.OrderBy(x => x.Date).ThenBy(x => x.TransactionTypeId).ToList();

                foreach (var order in orders)
                {

                    var orderParts = context.OrderItems.Where(x => x.OrderId == order.Id).ToList();

                    foreach (var orderPart in orderParts)
                    {
                        var row = new List<string>();
                        var part = context.Parts.Where(x => x.Id == orderPart.PartId).First();
                        row.Add(part.Name);
                        var transactionType = transactionTypesList.Where(x => x.Id == order.TransactionTypeId).First();

                        row.Add(transactionType.Name);
                        row.Add(order.Date.ToShortDateString());
                        row.Add(orderPart.Amount.ToString());

                        if (order.SupplierId != null)
                        {
                            var supplier = suppliersList.Where(x => x.Id == order.SupplierId).First();

                            row.Add(supplier.Name);
                        }
                        else
                        {
                            var sourceWarehouse = warehousesList.Where(x => x.Id == order.SourceWarehouseId).First();
                            row.Add(sourceWarehouse.Name);
                        }

                        var destinationWarehouse = warehousesList.Where(x => x.Id == order.DestinationWarehouseId).First();
                        row.Add(destinationWarehouse.Name);
                        row.Add(order.Id.ToString());
                        row.Add(orderPart.Id.ToString());
                        var idx = dataDGV.Rows.Add(row.ToArray());

                        var rowCells = dataDGV.Rows[idx].Cells[3];

                        if (order.TransactionType.Name == "Purchase Order") rowCells.Style.BackColor = Color.GreenYellow;
                    }
                }


            }
        }

        private void dataDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var warehouseName = dataDGV[5, e.RowIndex].Value.ToString();
            var warehouseId = warehousesList.Where(x=>x.Name == warehouseName).First().Id;

            var partName = dataDGV[0, e.RowIndex].Value.ToString();
            var partId = partsList.Where(x => x.Name == partName).First().Id;

            var amount = decimal.Parse(dataDGV[3, e.RowIndex].Value.ToString()!);
            var orderItemId = long.Parse(dataDGV[7, e.RowIndex].Value.ToString()!);
            var orderId = long.Parse(dataDGV[6, e.RowIndex].Value.ToString()!);
            var order = new Order();
            using (var context = new Session4Context())
            {
                order = context.Orders.Where(x => x.Id == orderId).First();
            }
            // Edit:
            if (e.ColumnIndex == 8) {
                if (order.SupplierId != null)
                {
                    Hide();
                    var newForm = new PurchaseOrders(order);
                    newForm.ShowDialog();
                    Show();
                    return;
                }
                else
                {
                    Hide();
                    var newForm = new WarehouseManagement(order);
                    newForm.ShowDialog();
                    Show();
                    return;
                }
                
            }

            // Remove:
            if (e.ColumnIndex == 9) 
            {
                var currentStock = CalculateStockForPart(warehouseId, partId, orderItemId);

                if ((currentStock - amount) < 0) 
                {  
                    MessageBox.Show("You may not remove this item as it would cause negative stock");   
                    return;
                }

                var confirm = MessageBox.Show("Are you sure you want to remove?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (var context = new Session4Context())
                    {
                        var orderItem = context.OrderItems.Where(x=>x.Id == orderItemId).FirstOrDefault();
                        context.OrderItems.Remove(orderItem);   
                        context.SaveChanges();
                        RefreshList();
                    }
                }
                return;
            }
        }

        private decimal CalculateStockForPart(long warehouseId, long partId, long orderItemId)
        {
            var stock = 0.0M;
            using (var context = new Session4Context())
            {
                var batchNumber = context.OrderItems.Where(x=>x.Id == orderItemId).First().BatchNumber;

                var ordersFromWareHouse = context.Orders.Where(x=>x.DestinationWarehouseId == warehouseId).ToList();

                foreach (var order in ordersFromWareHouse)
                {
                    var orderItems = context.OrderItems.Where(x=>x.OrderId == order.Id && x.PartId == partId && x.BatchNumber == batchNumber);

                    foreach (var orderItem in orderItems)
                    {
                        stock += orderItem.Amount;
                    }
                }

                var transfersFromWarehouse = context.Orders.Where(x=>x.SourceWarehouseId == warehouseId).ToList();

                foreach (var transfer in transfersFromWarehouse)
                {
                    var transferredOrderItems = context.OrderItems.Where(x=>x.OrderId == transfer.Id && x.PartId == partId && x.BatchNumber == batchNumber);

                    foreach (var transferItem in transferredOrderItems)
                    {
                        stock -= transferItem.Amount;
                    }
                }
            }

            return stock;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void warehouseManagement_Click(object sender, EventArgs e)
        {
            Hide();
            var newForm = new WarehouseManagement();
            newForm.ShowDialog();
            Show();
        }

        private void inventoryReport_Click(object sender, EventArgs e)
        {
            Hide();
            var newForm = new InventoryReport();
            newForm.ShowDialog();
            Show();
        }
    }
}