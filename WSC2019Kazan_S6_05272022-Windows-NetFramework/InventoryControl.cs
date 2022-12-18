using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSC2019Kazan_S6_05272022_Windows_NetFramework
{
    public partial class InventoryControl : Form
    {
        private Dictionary<long, EmergencyMaintenance> emWorkOrders;
        private Dictionary<string, Warehouse> warehouseList;
        private Dictionary<string, Part> partList;
        private Dictionary<string, decimal> partStockDictionary;

        public InventoryControl()
        {
            InitializeComponent();
        }

        private void InventoryControl_Load(object sender, EventArgs e)
        {
            using (var context = new Session6Entities())
            {
                emWorkOrders = context.EmergencyMaintenances.Where(x=>x.EMEndDate == null).ToDictionary(x=>x.ID);

                foreach (var item in emWorkOrders)
                {
                    assetEMCb.Items.Add($"{item.Value.Asset.AssetName} ({item.Key})");
                }
                assetEMCb.SelectedIndex = 0;
                warehouseList = context.Warehouses.ToDictionary(x=>x.Name);
                partList = context.Parts.ToDictionary(x=>x.Name);

                warehouseCb.Items.AddRange(warehouseList.Select(x=>x.Key).ToArray());
                

                warehouseCb.SelectedIndex = 0;
                allocMethodCb.Items.AddRange(new string[] { "FIFO", "LIFO", "Minimum First" } );
                allocMethodCb.SelectedIndex = 0;    

                var allocColumns = new List<string>
                {
                    "Part Name", "Batch Number", "Unit Price", "Amount", "ID"
                };

                allocColumns.ForEach(x => allocatedPartsDGV.Columns.Add(x, x));
                allocColumns.ForEach(x => assignedPartsDGV.Columns.Add(x, x));

                assignedPartsDGV.Columns.Add(new DataGridViewLinkColumn 
                { 
                    Text = "Remove",
                    UseColumnTextForLinkValue = true,
                    HeaderText = "Action"
                });
            }
        }


        void RefreshPartsList()
        {
            using (var context = new Session6Entities())
            {
                var selectedWarehouseId = warehouseList[warehouseCb.SelectedItem.ToString()].ID;

                var transactedOrders = context.OrderItems
                    .Where(x => x.Order.SourceWarehouseID == null
                        && x.Order.DestinationWarehouseID == selectedWarehouseId
                        && x.Order.Date >= currentlySelectedDate.Value);

                var sourceTransferOrders = context.OrderItems.
                    Where(x => x.Order.SourceWarehouseID == selectedWarehouseId
                        && x.Order.Date >= currentlySelectedDate.Value);

                partStockDictionary = new Dictionary<string, decimal>();

                foreach (var item in transactedOrders)
                {
                    if (partStockDictionary.ContainsKey(item.Part.Name)) partStockDictionary[item.Part.Name] += item.Stock.Value;
                    else partStockDictionary[item.Part.Name] = item.Stock.Value;
                }
               
                foreach (var item in sourceTransferOrders)
                {
                    if (partStockDictionary.ContainsKey(item.Part.Name)) partStockDictionary[item.Part.Name] -= item.Stock.Value;
                }
                


                foreach (var item in partStockDictionary)
                {
                    Console.WriteLine($"{item.Key} {item.Value}");
                }

                var inStockParts = partStockDictionary.Where(x => x.Value > 0);

                partNameCb.Items.Clear();
                partNameCb.Items.AddRange(inStockParts.Select(x => x.Key).ToArray());

                if (partNameCb.Items.Count > 0)
                {
                    partNameCb.SelectedIndex = 0;
                }
            }
        }
        private void warehouseCb_SelectedIndexChanged(object sender, EventArgs e)
        {
           RefreshPartsList();
        }

        private void currentlySelectedDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshPartsList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Allocate Button:
            using (var context = new Session6Entities())
            {
                allocatedPartsDGV.Rows.Clear();
                var selectedWarehouseId = warehouseList[warehouseCb.SelectedItem.ToString()].ID;
                var stock = partStockDictionary[partNameCb.SelectedItem.ToString()];

                if (stock < amountUpDown.Value)
                {
                    MessageBox.Show("Not enough stock for this part");
                    return;
                }

                var transactedOrders = context.OrderItems
                   .Where(x => x.Order.SourceWarehouseID == null
                       && x.Order.DestinationWarehouseID == selectedWarehouseId
                       && x.Order.Date >= currentlySelectedDate.Value);

                switch (allocMethodCb.SelectedItem.ToString())
                {
                    case "FIFO":
                        transactedOrders = transactedOrders.OrderBy(x=>x.Order.Date).ThenBy(x=>x.Order.Time);
                        break;
                    case "LIFO":
                        transactedOrders = transactedOrders.OrderByDescending(x => x.Order.Date).ThenByDescending(x => x.Order.Time);
                        break;
                    case "Minimum First":
                        transactedOrders = transactedOrders.OrderBy(x => x.UnitPrice);
                        break;
                    default:                       
                        break;
                }
                var tempValue = amountUpDown.Value;
                var selectedPart = context.Parts.Where(x=>x.Name == partNameCb.SelectedItem.ToString()).First().ID;
                var orderItems = new List<OrderItem>();
                foreach (var item in transactedOrders)
                {
                    if (item.PartID == selectedPart && item.Stock.Value > 0)
                    {
                        
                        Console.WriteLine($"Name: {item.Part.Name} ID: {item.ID} Stock: {item.Stock} Price: {item.UnitPrice} Date: {item.Order.Date}");
                        orderItems.Add(item);

                        var row = new List<string>();

                        row.Add(item.Part.Name);
                        row.Add(item.BatchNumber);
                        row.Add(item.UnitPrice.ToString());
                       

                        if (tempValue - item.Stock.Value < 0) row.Add(tempValue.ToString());
                        else row.Add(item.Stock.ToString());

                        row.Add(item.ID.ToString());

                        tempValue -= item.Stock.Value;
                        allocatedPartsDGV.Rows.Add(row.ToArray());
                    }

                    if (tempValue <= 0)
                    {
                        break;
                    }
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow allocatedRow in allocatedPartsDGV.Rows)
            {
                var allocatedCells = allocatedRow.Cells;
                var allocatedPartName = allocatedCells[0].Value.ToString();
                var allocatedBatchNo = allocatedCells[1].Value.ToString();

                foreach (DataGridViewRow assignedRow in assignedPartsDGV.Rows)
                {
                    var assignedCells = assignedRow.Cells;
                    var assignedPartName = assignedCells[0].Value.ToString();
                    var assignedBatchNo = assignedCells[1].Value.ToString();

                    if (allocatedPartName == assignedPartName && allocatedBatchNo == assignedBatchNo)
                    {
                        MessageBox.Show("You may not assign duplicate parts");
                        return;
                    }
                }
            }

            foreach (DataGridViewRow allocatedRow in allocatedPartsDGV.Rows)
            {
                var cells = allocatedRow.Cells;
                var row = new List<string>
                {
                    cells[0].Value.ToString(),  
                    cells[1].Value.ToString(),
                    cells[2].Value.ToString(),
                    cells[3].Value.ToString(),
                    cells[4].Value.ToString(),
                };
                assignedPartsDGV.Rows.Add(row.ToArray());
            }
        }

        private void assignedPartsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5) assignedPartsDGV.Rows.RemoveAt(e.RowIndex);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (assignedPartsDGV.Rows.Count == 0)
            {
                MessageBox.Show("There must at least be one part");
                return;
            }
            var sourceWarehouseId = warehouseList[warehouseCb.SelectedItem.ToString()].ID;
            var emergencyId = emWorkOrders.Values.ElementAt(assetEMCb.SelectedIndex).ID;
            
            var newOrder = new Order
            {
                TransactionTypeID = 3, 
                SupplierID = null,
                SourceWarehouseID = sourceWarehouseId,
                EmergencyMaintenancesID = emergencyId,
                Date = DateTime.Now,
                Time = DateTime.Now.TimeOfDay
            };

            using (var context = new Session6Entities())
            {
                context.Orders.Add(newOrder);
                context.SaveChanges();

                var orderId = newOrder.ID;

                foreach (DataGridViewRow row in assignedPartsDGV.Rows)
                {
                    var cells = row.Cells;
                    var amount = decimal.Parse(cells[3].Value.ToString());
                    var batchNo = cells[1].Value.ToString();
                    var partName = cells[0].Value.ToString();
                    var orderItemId = int.Parse(cells[4].Value.ToString());
                    var unitPrice = decimal.Parse(cells[2].Value.ToString());

                    var orderItem = context.OrderItems.First(x=>x.ID == orderItemId);

                    orderItem.Stock -= amount;

                    var partId = context.Parts.Where(x=>x.Name == partName).First();
                    var newOrderItem = new OrderItem
                    {
                        OrderID = orderId,
                        BatchNumber = batchNo,
                        UnitPrice = unitPrice,
                        Amount = amount,
                        Stock = 0,
                        PartID = partId.ID
                    };

                    context.OrderItems.Add(newOrderItem);
                }


                context.SaveChanges();
                Close();
            }
    
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
