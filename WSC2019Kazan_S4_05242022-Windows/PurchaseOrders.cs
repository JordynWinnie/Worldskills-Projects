using System.Diagnostics;

namespace WSC2019Kazan_S4_05242022_Windows
{
    public partial class PurchaseOrders : Form
    {
        private Order? currentOrder = null;
        private Dictionary<string, Supplier> suppliersList;
        private Dictionary<string, Warehouse> warehouseList;
        private Dictionary<string, Part> partsList;

        public PurchaseOrders(Order? currentOrder = null)
        {
            InitializeComponent();
            this.currentOrder = currentOrder;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PurchaseOrders_Load(object sender, EventArgs e)
        {
            using (var context = new Session4Context())
            {
                var columns = new List<string>
                {
                    "Part Name", "Batch Number", "Amount", "PartId", "OrderItemId"
                };
                columns.ForEach(x => dataGridView1.Columns.Add(x,x));
                dataGridView1.Columns.Add(
                    new DataGridViewLinkColumn(
                        )
                    {
                        UseColumnTextForLinkValue = true,
                        HeaderText = "Action",
                        Text = "Remove"
                    });
                suppliersList = context.Suppliers.ToDictionary(x=>x.Name);
                warehouseList = context.Warehouses.ToDictionary(x=>x.Name);
                partsList = context.Parts.ToDictionary(x=>x.Name);

                supplierCb.Items.AddRange(suppliersList.Keys.ToArray());
                warehouseCb.Items.AddRange(warehouseList.Keys.ToArray());
                partsCb.Items.AddRange(partsList.Keys.ToArray());

                supplierCb.SelectedIndex = 0;
                warehouseCb.SelectedIndex = 0;
                partsCb.SelectedIndex = 0;

                if (currentOrder != null)
                {
                    warehouseCb.Enabled = false;
                    var supplier = context.Suppliers.Where(x=>x.Id == currentOrder.SupplierId).First();

                    supplierCb.SelectedItem = supplier.Name;
                    purchaseDate.Value = currentOrder.Date;

                    var currentPurchases = context.OrderItems.Where(x=>x.OrderId == currentOrder.Id).ToList();

                    foreach (var purchase in currentPurchases)
                    {
                        var part = context.Parts.Where(x=>x.Id == purchase.PartId).FirstOrDefault();
                        var row = new List<string>
                        {
                            part.Name,
                            purchase.BatchNumber,
                            purchase.Amount.ToString(),
                            part.Id.ToString(),
                            purchase.Id.ToString()
                        };

                        dataGridView1.Rows.Add(row.ToArray());
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedPart = partsList[partsCb.SelectedItem.ToString()];

            var rowList = new List<string>() { selectedPart.Name };
            var batchNumberToConfirm = batchNumber.Text;
            if (selectedPart.BatchNumberHasRequired.Value)
            {
                if (batchNumber.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Batch number is required for this part");
                    return;
                }
                rowList.Add(batchNumberToConfirm);
            }
            else
            {
                rowList.Add(string.Empty);
                batchNumberToConfirm = string.Empty;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cells = row.Cells;
                var partName = cells[0].Value.ToString();
                var rowBatchNumber = cells[1].Value.ToString();

                if (partName == selectedPart.Name && batchNumberToConfirm == rowBatchNumber)
                {
                    MessageBox.Show("Duplicate parts cannot be added");
                    return;
                }
            }
            
            rowList.Add(amountUpDown.Value.ToString());
            dataGridView1.Rows.Add(rowList.ToArray());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (currentOrder != null)
            {
                var partid = long.Parse( dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                var orderItemId = long.Parse( dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                var amount = decimal.Parse( dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                
                var stock = CalculateStockForPart(currentOrder.DestinationWarehouseId.Value, partid, orderItemId);

                if (stock - amount < 0)
                {
                    MessageBox.Show("Removing this will cause negative stock");
                    return;
                }
            }
            if (e.ColumnIndex == 5) dataGridView1.Rows.RemoveAt(e.RowIndex);
        }

        private decimal CalculateStockForPart(long warehouseId, long partId, long orderItemId)
        {
            var stock = 0.0M;
            using (var context = new Session4Context())
            {
                var batchNumber = context.OrderItems.Where(x => x.Id == orderItemId).First().BatchNumber;

                var ordersFromWareHouse = context.Orders.Where(x => x.DestinationWarehouseId == warehouseId).ToList();

                foreach (var order in ordersFromWareHouse)
                {
                    var orderItems = context.OrderItems.Where(x => x.OrderId == order.Id && x.PartId == partId && x.BatchNumber == batchNumber);

                    foreach (var orderItem in orderItems)
                    {
                        stock += orderItem.Amount;
                    }
                }

                var transfersFromWarehouse = context.Orders.Where(x => x.SourceWarehouseId == warehouseId).ToList();

                foreach (var transfer in transfersFromWarehouse)
                {
                    var transferredOrderItems = context.OrderItems.Where(x => x.OrderId == transfer.Id && x.PartId == partId && x.BatchNumber == batchNumber);

                    foreach (var transferItem in transferredOrderItems)
                    {
                        stock -= transferItem.Amount;
                    }
                }
            }

            return stock;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("At least one part should be added");
                return;
            }

            var orderId = 0L;
            using (var context = new Session4Context())
            {
                var supplierId = suppliersList[supplierCb.SelectedItem.ToString()].Id;
                var destinationWarehouseId = warehouseList[warehouseCb.SelectedItem.ToString()].Id;
                if (currentOrder != null)
                {
                    var orderToModify = context.Orders.Where(x=>x.Id == currentOrder.Id).First();

                    orderToModify.SupplierId = supplierId;
                    orderToModify.Date = purchaseDate.Value;

                    var orderItems = context.OrderItems.Where(x=>x.OrderId == currentOrder.Id).ToList();

                    foreach (var order in orderItems)
                    {
                        context.OrderItems.Remove(order);
                    }
                    orderId = currentOrder.Id;
                } 
                else
                {
                    var newOrder = new Order
                    {
                        TransactionTypeId = 1,
                        SupplierId = supplierId,
                        DestinationWarehouseId = destinationWarehouseId,
                        Date = purchaseDate.Value,
                    };

                    context.Orders.Add(newOrder);
                    context.SaveChanges();

                    orderId = newOrder.Id;
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var cells = row.Cells;
                    var partName = cells[0].Value.ToString();
                    var part = partsList[partName];
                    var amount = decimal.Parse(cells[2].Value.ToString());

                    var orderItem = new OrderItem
                    {
                        OrderId = orderId,
                        PartId = part.Id,
                        Amount = amount,
                        BatchNumber = cells[1].Value.ToString()
                    };

                    context.OrderItems.Add(orderItem);
                    
                }
                context.SaveChanges();
            }
            
            Close();
        }

        private void supplierCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session4Context())
            {
                
            }
        }
    }
}
