using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Session_4_12_18_2019
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<string> columnNames = new List<string>
                {
                    "Part Name",
                    "Transaction Type",
                    "Date",
                    "Amount",
                    "Source",
                    "Destination",
                    "OrderItemID (DEBUG)"
                };

            foreach (var col in columnNames)
            {
                currentInventoryDGV.Columns.Add(col, col);
            }

            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn
            {
                Name = "Edit",
                Text = "Edit",
                HeaderText = "Edit",
                UseColumnTextForButtonValue = true
            };

            DataGridViewButtonColumn removeButton = new DataGridViewButtonColumn
            {
                Name = "Remove",
                Text = "Remove",
                HeaderText = "Remove",
                UseColumnTextForButtonValue = true,
            };

            currentInventoryDGV.Columns.Add(editButton);
            currentInventoryDGV.Columns.Add(removeButton);


            GridRefresh();
        }

        void GridRefresh()
        {
            currentInventoryDGV.Rows.Clear();

            using (var context = new Session4Entities())
            {

                var orderItemsQuery = (from x in context.OrderItems
                                       orderby x.Order.Date descending
                                       select x).ThenBy(x => x.Order.TransactionTypeID);

                foreach (var orderItem in orderItemsQuery)
                {
                    List<string> rows = new List<string>();

                    rows.Add(orderItem.Part.Name);

                    var transactionTypeName = context.TransactionTypes.Where(x => x.ID == orderItem.Order.TransactionTypeID).Select(x => x).FirstOrDefault();

                    rows.Add(transactionTypeName.Name);

                    var date = context.Orders.Where(x => x.ID == orderItem.OrderID).Select(x => x).FirstOrDefault();

                    rows.Add(date.Date.ToString("yyyy-MM-dd"));

                    rows.Add(orderItem.Amount.ToString());

                    var sourceWarehouse = context.Warehouses.Where(x => x.ID == orderItem.Order.SourceWarehouseID).Select(x => x).FirstOrDefault();
                    var destinationWareHouse = context.Warehouses.Where(x => x.ID == orderItem.Order.DestinationWarehouseID).Select(x => x).FirstOrDefault();

                    if (sourceWarehouse != null)
                    {
                        rows.Add(sourceWarehouse.Name);
                    }
                    else
                    {
                        rows.Add("");
                    }

                    if (destinationWareHouse != null)
                    {
                        rows.Add(destinationWareHouse.Name);
                    }
                    else
                    {
                        rows.Add("");
                    }

                    rows.Add(orderItem.ID.ToString());

                    currentInventoryDGV.Rows.Add(rows.ToArray());

                }

                foreach (DataGridViewRow row in currentInventoryDGV.Rows)
                {
                    if (row.Cells[1].Value.ToString().Contains("Purchase"))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }



            }
        }

        private void currentInventoryDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var context = new Session4Entities())
            {
                var row = e.RowIndex;
                if (row >= 0)
                {
                    if (currentInventoryDGV.Rows[e.RowIndex].Cells[1].Value.ToString().Equals("Purchase Order"))
                    {
                        if (e.ColumnIndex == currentInventoryDGV.Columns["Remove"].Index)
                        {
                            var tempDestID = currentInventoryDGV.Rows[e.RowIndex].Cells[5].Value.ToString();
                            var tempPartName = currentInventoryDGV.Rows[e.RowIndex].Cells[0].Value.ToString();

                            var destinationID = context.Warehouses.Where(x => x.Name.Equals(tempDestID)).First();
                            var selectedPartId = context.Parts.Where(x => x.Name == tempPartName).First();
                            /*var DestinationAmountOfItems = context.Orders.Where(x => x.DestinationWarehouseID == destinationID.ID
                            && x.OrderItems.Where(y => y.PartID == selectedPartId.ID).FirstOrDefault().ID == selectedPartId.ID).Count();*/

                            var destAmountOfItems = (from x in context.Orders
                                                     join y in context.OrderItems on x.ID equals y.OrderID
                                                     where y.Part.ID == selectedPartId.ID
                                                     select y.Amount).Sum();



                            var currentAmount = Convert.ToDecimal(currentInventoryDGV.Rows[e.RowIndex].Cells[3].Value.ToString());
                            MessageBox.Show(destAmountOfItems.ToString());
                            if ((destAmountOfItems - currentAmount) >= selectedPartId.MinimumAmount)
                            {
                                var result = MessageBox.Show("Confirm removal?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                if (result == DialogResult.Yes)
                                {
                                    var orderID = Convert.ToDecimal(currentInventoryDGV.Rows[e.RowIndex].Cells[6].Value.ToString());
                                    var removedOrderItem = context.OrderItems.Where(x => x.ID == orderID).Select(x => x).First();

                                    context.OrderItems.Remove(removedOrderItem);
                                    try
                                    {
                                        context.SaveChanges();
                                        GridRefresh();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("An error has occurred while removing. Details: " + ex.Message);

                                    }

                                }

                            }
                            else
                            {
                                MessageBox.Show("Removing this item will result in negative values for the asset in the warehouse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (e.ColumnIndex == currentInventoryDGV.Columns["Edit"].Index)
                        {
                            MessageBox.Show("Edit button clicked! (PO)");
                            var current = Convert.ToInt64(currentInventoryDGV.Rows[e.RowIndex].Cells[6].Value.ToString());
                            (new PurchaseOrders(current)).ShowDialog();
                            GridRefresh();
                        }
                    }
                    else
                    {
                        if (e.ColumnIndex == currentInventoryDGV.Columns["Remove"].Index)
                        {
                            //MessageBox.Show("Remove button clicked! (EO Order)");

                            var tempDestID = currentInventoryDGV.Rows[e.RowIndex].Cells[5].Value.ToString();
                            var tempPartName = currentInventoryDGV.Rows[e.RowIndex].Cells[0].Value.ToString();

                            var destinationID = context.Warehouses.Where(x => x.Name.Equals(tempDestID)).First();
                            var selectedPartId = context.Parts.Where(x => x.Name == tempPartName).First();
                            /*var DestinationAmountOfItems = context.Orders.Where(x => x.DestinationWarehouseID == destinationID.ID
                            && x.OrderItems.Where(y => y.PartID == selectedPartId.ID).FirstOrDefault().ID == selectedPartId.ID).Count();*/

                            var destAmountOfItems = (from x in context.Orders
                                                     join y in context.OrderItems on x.ID equals y.OrderID
                                                     where y.Part.ID == selectedPartId.ID
                                                     select y.Amount).Sum();



                            var currentAmount = Convert.ToDecimal(currentInventoryDGV.Rows[e.RowIndex].Cells[3].Value.ToString());
                            //MessageBox.Show(destAmountOfItems.ToString());
                            if ((destAmountOfItems - currentAmount) >= selectedPartId.MinimumAmount)
                            {
                                var result = MessageBox.Show("Confirm removal?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                if (result == DialogResult.Yes)
                                {
                                    var orderID = Convert.ToDecimal(currentInventoryDGV.Rows[e.RowIndex].Cells[6].Value.ToString());
                                    var removedOrderItem = context.OrderItems.Where(x => x.ID == orderID).Select(x => x).First();

                                    context.OrderItems.Remove(removedOrderItem);
                                    try
                                    {
                                        context.SaveChanges();
                                        GridRefresh();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("An error has occurred while removing. Details: " + ex.Message);

                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Removing this item will result in negative values for the asset in the warehouse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }

                        else if (e.ColumnIndex == currentInventoryDGV.Columns["Edit"].Index)
                        {
                            var current = Convert.ToInt64(currentInventoryDGV.Rows[e.RowIndex].Cells[6].Value.ToString());
                            
                            (new WarehouseManagement(current)).ShowDialog();
                            GridRefresh();
                        }
                    }
                }
                
            }


        }

        private void purchaseOrderMgBtn_Click(object sender, EventArgs e)
        {
            (new PurchaseOrders(-1)).ShowDialog();
            GridRefresh();
        }

        private void warehouseMngBtn_Click(object sender, EventArgs e)
        {
            (new WarehouseManagement(-1)).ShowDialog();
            GridRefresh();
        }

        private void inventReportBtn_Click(object sender, EventArgs e)
        {
            (new InventoryReport()).ShowDialog();
            GridRefresh();
        }
    }
}
