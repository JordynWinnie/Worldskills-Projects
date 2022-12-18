using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSC2019Kazan_S4_05242022_Windows
{
    
    public partial class WarehouseManagement : Form
    {
        public Order? currentOrder;
        private Dictionary<string, Warehouse> warehouseList;

        public WarehouseManagement(Order? currentOrder = null)
        {
            InitializeComponent();
            this.currentOrder = currentOrder;
        }

        private void WarehouseManagement_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Part Name", "Batch Number", "Amount"
            };

            columns.ForEach(x=> partsDGV.Columns.Add(x,x));

            using (var context = new Session4Context())
            {
                warehouseList = context.Warehouses.ToDictionary(x=>x.Name);

                sourceCb.Items.AddRange(warehouseList.Keys.ToArray());
                destinationCb.Items.AddRange(warehouseList.Keys.ToArray());

                sourceCb.SelectedIndex = 0;
                destinationCb.SelectedIndex = 1;

                

                if (currentOrder != null)
                {
                    var sourceWarehouse = context.Warehouses.Where(x=>x.Id == currentOrder.SourceWarehouseId).First().Name;    
                    var destinationWarehouse = context.Warehouses.Where(x=>x.Id == currentOrder.DestinationWarehouseId).First().Name;    
                    sourceCb.Enabled = false;
                    sourceCb.SelectedItem = sourceWarehouse;
                    destinationCb.Enabled = false;
                    destinationCb.SelectedItem = destinationWarehouse;

                    purchaseDate.Value = currentOrder.Date;

                    var orders = context.OrderItems.Where(x=>x.OrderId == currentOrder.Id).ToList();

                    foreach (var item in orders)
                    {
                        var part = context.Parts.Where(x=>x.Id == item.PartId).First();
                        var row = new List<string>
                        {
                            part.Name,
                            item.BatchNumber,
                            item.Amount.ToString()
                        };

                        partsDGV.Rows.Add(row.ToArray());
                    }
                }
            }

            partsDGV.Columns.Add(
                new DataGridViewLinkColumn
                {
                    UseColumnTextForLinkValue = true,
                    HeaderText = "Action",
                    Text = "Remove"
                }
            );
        }

        private void sourceCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session4Context())
            {
                var warehouse = warehouseList[sourceCb.SelectedItem.ToString()];

                var orders = context.Orders.Where(x=>x.SourceWarehouseId == warehouse.Id).ToList();
                var parts = new HashSet<string>();

                foreach (var order in orders)
                {
                    var orderItems = context.OrderItems.Where(x=>x.OrderId == order.Id).ToList();
                    foreach (var item in orderItems)
                    {
                        var part = context.Parts.Where(x=>x.Id == item.PartId).First();
                        parts.Add(part.Name);
                    }
                }

                partsCb.Items.Clear();
                partsCb.Items.AddRange(parts.ToArray());
                partsCb.SelectedIndex = 0;
            }
        }

        private void partsCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session4Context())
            {
                var warehouse = warehouseList[sourceCb.SelectedItem.ToString()];

                var orders = context.Orders.Where(x => x.SourceWarehouseId == warehouse.Id).ToList();
                
                var selectedPart = context.Parts.Where(x=>x.Name == partsCb.SelectedItem.ToString()).First().Id;
                var parts = new HashSet<string>();

                foreach (var order in orders)
                {
                    var orderItems = context.OrderItems.Where(x => x.OrderId == order.Id && selectedPart == x.PartId).ToList();
                    foreach (var item in orderItems)
                    {
                        parts.Add(item.BatchNumber);
                    }
                }

                batchCb.Items.Clear();
                batchCb.Items.AddRange(parts.ToArray());

                if (parts.Count != 0)
                {
                    batchCb.SelectedIndex = 0;
                }
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (sourceCb.SelectedIndex == destinationCb.SelectedIndex) {
                MessageBox.Show("Source and Destination Warehouses cannot be the same");
                return;
            }

            if (partsDGV.Rows.Count == 0)
            {
                MessageBox.Show("At least one part has to be added");
                return;
            }

            using (var context = new Session4Context())
            {
                
                //Checking Only:
                foreach (DataGridViewRow row in partsDGV.Rows)
                {
                    var cells = row.Cells;
                    var rowPartName = cells[0].Value.ToString();
                    var rowBatchNumber = cells[1].Value.ToString();
                    var rowAmount = decimal.Parse(cells[2].Value.ToString()!);
                    var part = context.Parts.Where(x=>x.Name == rowPartName).First().Id;
                    var warehouseId = warehouseList[sourceCb.SelectedItem.ToString()!].Id;
                    var stock = CalculateStockForPart(warehouseId, part, rowBatchNumber);

                    if (stock - rowAmount < 0)
                    {
                        MessageBox.Show("Stock will be negative with this transfer");
                        return;
                    }
                }

                var sourceWarehouseId = warehouseList[sourceCb.SelectedItem.ToString()!].Id;
                var destinationWarehouseId = warehouseList[destinationCb.SelectedItem.ToString()!].Id;

                var orderId = 0L;
                if (currentOrder != null)
                {
                    var changeOrder = context.Orders.Where(x=>x.Id == currentOrder.Id).First();
                    changeOrder.Date = purchaseDate.Value;
                    orderId = changeOrder.Id;
                }
                else
                {
                    var newOrder = new Order
                    {
                        TransactionTypeId = 1, 
                        SupplierId = null,
                        SourceWarehouseId = sourceWarehouseId,
                        DestinationWarehouseId = destinationWarehouseId,
                        Date = purchaseDate.Value,
                    };

                    context.Orders.Add(newOrder);
                    context.SaveChanges();

                    orderId = newOrder.Id;
                }

                // Uploading To Database

                // Delete existing Order Items:
                var existingOrderItems = context.OrderItems.Where(x=>x.OrderId == orderId);

                foreach (var order in existingOrderItems)
                {
                    context.OrderItems.Remove(order);
                }

                foreach (DataGridViewRow row in partsDGV.Rows)
                {
                    var cells = row.Cells;
                    var rowPartName = cells[0].Value.ToString();
                    var rowBatchNumber = cells[1].Value.ToString();
                    var rowAmount = decimal.Parse(cells[2].Value.ToString()!);
                    var part = context.Parts.Where(x => x.Name == rowPartName).First().Id;
                    var sourceWarehouseID = warehouseList[sourceCb.SelectedItem.ToString()!].Id;
                    var destinationWarehouseID = warehouseList[destinationCb.SelectedItem.ToString()!].Id;
                    
                    var newOrderItem = new OrderItem
                    {
                        OrderId = orderId,
                        PartId = part,
                        BatchNumber = rowBatchNumber,
                        Amount = rowAmount,
                    };

                    context.OrderItems.Add(newOrderItem);
                }

                context.SaveChanges();
            }

            Close();
        }

        private decimal CalculateStockForPart(long warehouseId, long partId, string batchNumber)
        {
            var stock = 0.0M;
            using (var context = new Session4Context())
            {
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new Session4Context())
            {
                foreach (DataGridViewRow item in partsDGV.Rows)
                {
                    var cells = item.Cells;
                    var rowPartName = cells[0].Value.ToString();
                    var rowBatchNumber = cells[1].Value.ToString();

                    if (rowPartName == partsCb.SelectedItem.ToString() && batchCb.SelectedItem.ToString() == rowBatchNumber)
                    {
                        MessageBox.Show("Cannot add duplicate part");
                        return;
                    }
                }

                var row = new List<string>
                {
                    partsCb.SelectedItem.ToString(),
                };

                if (batchCb.SelectedItem.ToString() != string.Empty)
                {
                    row.Add(batchCb.SelectedItem.ToString());
                }
                else
                {
                    row.Add(string.Empty);
                }

                row.Add(amountUpDown.Value.ToString());

                partsDGV.Rows.Add(row.ToArray());
            }
        }

        private void partsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) partsDGV.Rows.RemoveAt(e.RowIndex);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
