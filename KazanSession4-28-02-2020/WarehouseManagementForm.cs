﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace KazanSession4_28_02_2020
{
    public partial class WarehouseManagementForm : Form
    {
        long _orderItemID = -1;
        public WarehouseManagementForm(long orderItemId)
        {
            _orderItemID = orderItemId;
            InitializeComponent();
        }

        private void WarehouseManagementForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                sourceNameCb.Items.AddRange(context.Warehouses.Select(x => x.Name).ToArray());
                partNameCb.Items.AddRange(context.Parts.Select(x => x.Name).ToArray());
                destinationNameCb.Items.AddRange(context.Warehouses.Select(x => x.Name).ToArray());

               
                partNameCb.SelectedIndex = 0;
                sourceNameCb.SelectedIndex = 0;
                destinationNameCb.SelectedIndex = 1;

                var columns = new List<string>
                {
                    "Part Name",
                    "Batch Number",
                    "Amount"
                };

                foreach (var column in columns)
                {
                    partsListDGV.Columns.Add(column, column);
                }

                var removeColumnButton = new DataGridViewButtonColumn
                {
                    HeaderText = "Action",
                    Name = "Remove",
                    Text = "Remove",
                    UseColumnTextForButtonValue = true
                };

                partsListDGV.Columns.Add(removeColumnButton);

                if (_orderItemID != -1)
                {
                    //Fill in Information for form
                    var orderItemInformation = context.Orders.Where(x => x.ID == _orderItemID).First();

                    var sourceWarehouseInfo = context.Warehouses.Where(x => x.ID == orderItemInformation.SourceWarehouseID).First();
                    var destWarehouseInfo = context.Warehouses.Where(x => x.ID == orderItemInformation.DestinationWarehouseID).First();

                    sourceNameCb.SelectedItem = sourceWarehouseInfo.Name;
                    destinationNameCb.SelectedItem = destWarehouseInfo.Name;
                    dateDP.Value = orderItemInformation.Date;

                    foreach (var item in orderItemInformation.OrderItems)
                    {
                        var row = new List<string>
                        {
                            item.Part.Name,
                            item.BatchNumber,
                            item.Amount.ToString()
                        };

                        partsListDGV.Rows.Add(row.ToArray());
                    }
                }

            }
        }

        private void addToListBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                var partNameFromCb = partNameCb.SelectedItem.ToString();
                var batchNoRequired = context.Parts.Where(x => x.Name.Equals(partNameFromCb)).Select(x => x.BatchNumberHasRequired).First();

                var tempBatchNo = "";
                var validation = true;
                while (validation)
                {
                    if ((bool)batchNoRequired)
                    {
                        if (batchNoTb.Text.Equals(string.Empty))
                        {
                            MessageBox.Show("Please enter a batch number");
                            break;
                        }
                        else
                        {
                            tempBatchNo = batchNoTb.Text;
                        }
                    }

                    if (!decimal.TryParse(amountTb.Text, out _))
                    {
                        MessageBox.Show("Please enter a valid amount");
                        break;
                    }

                    if (decimal.Parse(amountTb.Text) <= 0)
                    {
                        MessageBox.Show("Please enter positive amount");
                        break;
                    }

                    foreach (DataGridViewRow row in partsListDGV.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Equals(partNameFromCb)
                            && row.Cells[1].Value.ToString().Equals(tempBatchNo))
                        {
                            MessageBox.Show("Parts cannot be repeated");
                            validation = false;
                            break;
                        }
                    }



                    var itemRow = new List<string>
                    {
                        partNameCb.Text,
                        tempBatchNo,
                        amountTb.Text
                    };


                    if (validation == false)
                    {
                        break;
                    }
                    MessageBox.Show("Vat Checks Passed");

                    partsListDGV.Rows.Add(itemRow.ToArray());
                    break;
                }

            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                if (_orderItemID == -1)
                {
                    //Adding of order
                    MessageBox.Show("Beginning Add Order");

                    while (true)
                    {
                        if (partsListDGV.Rows.Count == 0)
                        {
                            MessageBox.Show("At least one part is required to add an order");
                            break;
                        }

                        var supplierFromCb = sourceNameCb.SelectedItem.ToString();
                        var destinationWarehouseFromCb = destinationNameCb.SelectedItem.ToString();

                        if (supplierFromCb.Equals(destinationWarehouseFromCb))
                        {
                            MessageBox.Show("Source and Destination cannot be the same");
                            break;
                        }

                        //Creation of new order:
                        var insertOrder = new Order
                        {
                            TransactionTypeID = 2,
                            DestinationWarehouseID = context.Warehouses.Where(x => x.Name.Equals(destinationWarehouseFromCb)).Select(x => x.ID).FirstOrDefault(),
                            SourceWarehouseID = context.Warehouses.Where(x => x.Name.Equals(supplierFromCb)).Select(x => x.ID).FirstOrDefault(),
                            Date = dateDP.Value
                        };

                        context.Orders.Add(insertOrder);
                        context.SaveChanges();
                        var tempOrderID = context.Orders.OrderByDescending(x => x.ID).Select(x => x.ID).First();
                        foreach (DataGridViewRow row in partsListDGV.Rows)
                        {
                            var partName = row.Cells[0].Value.ToString();
                            var insertOrderItem = new OrderItem
                            {
                                Amount = decimal.Parse(row.Cells[2].Value.ToString()),
                                BatchNumber = row.Cells[1].Value.ToString(),
                                PartID = context.Parts.Where(x => x.Name.Equals(partName)).Select(x => x.ID).FirstOrDefault(),
                                OrderID = tempOrderID
                            };

                            context.OrderItems.Add(insertOrderItem);
                        }

                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Changes saved");
                            this.Close();
                        }
                        catch (Exception ex)
                        {

                            throw;
                        }
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Beginning Edit Order");
                    //Implement edit order

                    while (true)
                    {
                        if (partsListDGV.Rows.Count == 0)
                        {
                            MessageBox.Show("At least one part is required to add an order");
                            break;
                        }

                        var currentOrderItems = context.OrderItems.Where(x => x.OrderID == _orderItemID);

                        foreach (var item in currentOrderItems)
                        {
                            context.OrderItems.Remove(item);
                        }

                        var supplierFromCb = sourceNameCb.SelectedItem.ToString();
                        var destinationWarehouseFromCb = destinationNameCb.SelectedItem.ToString();

                        if (supplierFromCb.Equals(destinationWarehouseFromCb))
                        {
                            MessageBox.Show("Source and Destination cannot be the same");
                            break;
                        }
                        //Creation of new order:
                        var insertOrder = new Order
                        {
                            TransactionTypeID = 2,
                            DestinationWarehouseID = context.Warehouses.Where(x => x.Name.Equals(destinationWarehouseFromCb)).Select(x => x.ID).FirstOrDefault(),
                            SourceWarehouseID = context.Warehouses.Where(x => x.Name.Equals(supplierFromCb)).Select(x => x.ID).FirstOrDefault(),
                            Date = dateDP.Value
                        };

                        context.Orders.Add(insertOrder);
                        context.SaveChanges();
                        var tempOrderID = context.Orders.OrderByDescending(x => x.ID).Select(x => x.ID).First();

                        foreach (DataGridViewRow row in partsListDGV.Rows)
                        {
                            var partName = row.Cells[0].Value.ToString();
                            var insertOrderItem = new OrderItem
                            {
                                Amount = decimal.Parse(row.Cells[2].Value.ToString()),
                                BatchNumber = row.Cells[1].Value.ToString(),
                                PartID = context.Parts.Where(x => x.Name.Equals(partName)).Select(x => x.ID).FirstOrDefault(),
                                OrderID = tempOrderID
                            };

                            context.OrderItems.Add(insertOrderItem);
                        }

                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Edits Change saved");
                            this.Close();
                        }
                        catch (Exception ex)
                        {

                            throw;
                        }
                        break;
                    }


                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void partsListDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (partsListDGV.Columns["Remove"].Index == e.ColumnIndex)
            {
                partsListDGV.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
