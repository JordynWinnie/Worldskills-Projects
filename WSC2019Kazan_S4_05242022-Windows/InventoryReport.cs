using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSC2019Kazan_S4_05242022_Windows
{
    public partial class InventoryReport : Form
    {
        private Dictionary<string, Warehouse> warehouseList;
        private List<OrderItem> orderItems;

        public InventoryReport()
        {
            InitializeComponent();
        }

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            using (var context = new Session4Context())
            {
                warehouseList = context.Warehouses.ToDictionary(x=>x.Name);
                warehouseCb.Items.AddRange(warehouseList.Keys.ToArray());
                warehouseCb.SelectedIndex = 0;
            }
        }

        private void warehouseCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        void RefreshList()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            using (var context = new Session4Context())
            {
                var warehouseId = warehouseList[warehouseCb.SelectedItem.ToString()!].Id;
                orderItems = new List<OrderItem>();
                var rows = new List<List<string>>();
                var columns = new List<string>
                {
                    "Part Name"
                };
                if (currentStock.Checked)
                {
                    columns.Add("Current Stock");

                    var orders = context.Orders.Where(x=>x.DestinationWarehouseId == warehouseId && x.SourceWarehouseId == null).ToList();

                    foreach (var order in orders)
                    {
                        orderItems.AddRange(context.OrderItems.Where(x=>x.OrderId == order.Id));
                    }

                    var givingAway = context.Orders.Where(x => x.SourceWarehouseId == warehouseId).ToList();

                    foreach (var order in givingAway)
                    {
                        foreach (var orderItem in context.OrderItems.Where(x => x.OrderId == order.Id).ToList())
                        {
                            orderItem.Amount = -orderItem.Amount;
                            orderItems.Add(orderItem);
                        }
                    }
                    var recievedOrders = context.Orders.Where(x => x.DestinationWarehouseId == warehouseId && x.SourceWarehouseId != null).ToList();

                    foreach (var order in recievedOrders)
                    {
                        orderItems.AddRange(context.OrderItems.Where(x => x.OrderId == order.Id));
                    }

                    foreach (var item in orderItems.GroupBy(x=>x.PartId))
                    {
                        var part = context.Parts.Where(x => x.Id == item.Key).First();
                        var row = new List<string>();
                        if (item.Where(x=>x.BatchNumber == string.Empty).Count() > 0)
                        { 
                            row.Add(part.Name);
                            row.Add(item.Sum(x=>x.Amount).ToString());
                            row.Add(string.Empty);
                        }
                        else
                        {
                            row.Add(part.Name);
                            row.Add(item.Sum(x => x.Amount).ToString());
                            row.Add("View Batch Numbers");
                        }
                        rows.Add(row);
                    }
                }

                if (recievedStock.Checked)
                {
                    columns.Add("Received Stock");

                    var orders = context.Orders.Where(x => x.DestinationWarehouseId == warehouseId && x.SourceWarehouseId != null).ToList();

                    foreach (var order in orders)
                    {
                        orderItems.AddRange(context.OrderItems.Where(x => x.OrderId == order.Id));
                    }

                    foreach (var item in orderItems.GroupBy(x => x.PartId))
                    {
                        var part = context.Parts.Where(x => x.Id == item.Key).First();

                        var row = new List<string>();
                        if (item.Where(x => x.BatchNumber == string.Empty).Count() > 0)
                        {
                            row.Add(part.Name);
                            row.Add(item.Sum(x => x.Amount).ToString());
                            row.Add(string.Empty);
                        }
                        else
                        {
                            row.Add(part.Name);
                            row.Add(item.Sum(x => x.Amount).ToString());
                            row.Add("View Batch Numbers");
                        }

                        rows.Add(row);
                    }
                }

                if (outofstock.Checked)
                {
                    //Purchases:
                    var orders = context.Orders.Where(x => x.DestinationWarehouseId == warehouseId && x.SourceWarehouseId == null).ToList();

                    foreach (var order in orders)
                    {
                        orderItems.AddRange(context.OrderItems.Where(x => x.OrderId == order.Id));
                    }

                    var recievedOrders = context.Orders.Where(x => x.DestinationWarehouseId == warehouseId && x.SourceWarehouseId != null).ToList();

                    foreach (var order in recievedOrders)
                    {
                        orderItems.AddRange(context.OrderItems.Where(x => x.OrderId == order.Id));
                    }
                    

                    var givingAway = context.Orders.Where(x=>x.SourceWarehouseId == warehouseId).ToList();

                    foreach (var order in givingAway)
                    {
                        foreach (var orderItem in context.OrderItems.Where(x => x.OrderId == order.Id).ToList())
                        {
                            orderItem.Amount = -orderItem.Amount;
                            orderItems.Add(orderItem);
                        }
                    }

                    foreach (var item in orderItems.GroupBy(x=>x.PartId))
                    {
                        var part = context.Parts.Where(x => x.Id == item.Key).First();

                        if (item.Sum(x=>x.Amount) == 0)
                        {
                            var row = new List<string>();
                            if (item.Where(x => x.BatchNumber == string.Empty).Count() > 0)
                            {
                                row.Add(part.Name);
                                row.Add(string.Empty);
                            }
                            else
                            {
                                row.Add(part.Name);
                                row.Add("View Batch Numbers");
                            }
                            rows.Add(row);
                        }
                    }
                }

                
                columns.ForEach(x=> dataGridView1.Columns.Add(x,x));
                dataGridView1.Columns.Add (
                    new DataGridViewLinkColumn
                    {
                        HeaderText = "Action",
                    }
                    );
                rows.ForEach(x=> dataGridView1.Rows.Add(x.ToArray()));

            }
        }

        private void currentStock_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void recievedStock_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void outofstock_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns.Count - 1 == e.ColumnIndex)
            {
                var partName = dataGridView1[0, e.RowIndex].Value.ToString();
                using (var context = new Session4Context())
                {
                    var part = context.Parts.Where(x=>x.Name == partName).First();
                    var group = orderItems.Where(x=>x.PartId == part.Id).GroupBy(x=>x.BatchNumber);
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in group)
                    {
                        sb.AppendLine($"{item.Key} - {item.Sum(x=>x.Amount)}");
                    }

                    MessageBox.Show(sb.ToString());
                }
            }
        }
    }
}
