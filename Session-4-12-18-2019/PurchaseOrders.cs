using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session_4_12_18_2019
{
    public partial class PurchaseOrders : Form
    {

        long _orderItemsID = 1;
        public PurchaseOrders(long orderItemsID)
        {
            _orderItemsID = orderItemsID;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void GridRefresh()
        {
            partsListDGV.Rows.Clear();

            List<string> columnName = new List<string>
            {
                "Part Name",
                "Batch Number",
                "Amount",
                "PartID (DEBUG)",
                "OrderItemsID (DEBUG)"
            };

            //partsListDGV.Columns[3].Visible = false;
            foreach (var col in columnName)
            {
                partsListDGV.Columns.Add(col, col);
            }

            DataGridViewButtonColumn remove = new DataGridViewButtonColumn
            {
                Name = "Remove",
                HeaderText = "Remove",
                Text = "Remove",
                UseColumnTextForButtonValue = true
            };

            partsListDGV.Columns.Add(remove);

            using (var context = new Session4Entities())
            {
                foreach (var supplier in context.Suppliers.OrderBy(x => x.ID))
                {
                    supplierCb.Items.Add(supplier.Name);
                }

                foreach (var warehouse in context.Warehouses.OrderBy(x => x.ID))
                {
                    warehouseCb.Items.Add(warehouse.Name);
                }
                foreach (var part in context.Parts.OrderBy(x => x.ID))
                {
                    partNameCb.Items.Add(part.Name);
                }

                partNameCb.SelectedIndex = 0;
                supplierCb.SelectedIndex = 0;
                warehouseCb.SelectedIndex = 0;


            }


        }

        private void PurchaseOrders_Load(object sender, EventArgs e)
        {
            GridRefresh();

            if (_orderItemsID == -1)
            {
                this.Text = "NEW PURCHASE ORDER";
            }
            else
            {
                this.Text = "EDITING ORDER: " + _orderItemsID;

                using (var context = new Session4Entities())
                {
                    var orderIdFromOrderItems = context.OrderItems.Where(x => x.ID == _orderItemsID).Select(x => x).First();
                    var currentPartsInOrder = from x in context.OrderItems
                                              where x.OrderID == orderIdFromOrderItems.OrderID
                                              select x;

                    foreach (var part in currentPartsInOrder)
                    {
                        List<string> row = new List<string>
                        {
                            part.Part.Name,
                            part.BatchNumber,
                            part.Amount.ToString(),
                            part.PartID.ToString(),
                            part.ID.ToString()
                        };

                        partsListDGV.Rows.Add(row.ToArray());
                    }

                    supplierCb.SelectedIndex = ((int)orderIdFromOrderItems.Order.SupplierID - 1);
                    warehouseCb.SelectedIndex = ((int)orderIdFromOrderItems.Order.DestinationWarehouseID - 1);

                    dateDtp.Value = orderIdFromOrderItems.Order.Date;
                }
            }

        }

        private void supplierCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(supplierCb.ValueMember.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {

                var checkForBatch = context.Parts.Where(x => x.Name.Equals(partNameCb.SelectedItem.ToString())).Select(x => x).FirstOrDefault();

                while (true)
                {
                    //Check if BatchNo is blank
                    if (checkForBatch.BatchNumberHasRequired == true && batchnotb.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Batch number is required to add this part", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else if (checkForBatch.BatchNumberHasRequired == false && !batchnotb.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("This part can't have a batch number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }


                    //Check if list has duplicate parts
                    var isDupe = false;
                    foreach (DataGridViewRow row in partsListDGV.Rows)
                    {
                        //Checks if Batch number products have duplicates
                        if (checkForBatch.BatchNumberHasRequired == true)
                        {
                            if (row.Cells[0].Value.ToString().Equals(partNameCb.SelectedItem.ToString()) && row.Cells[1].Value.ToString().Equals(batchnotb.Text))
                            {
                                MessageBox.Show("Duplicate Item cannot be added");
                                isDupe = true;
                                break;
                            }
                            
                        }
                        else
                        {
                            if (row.Cells[0].Value.ToString().Equals(partNameCb.SelectedItem.ToString()))
                            {
                                MessageBox.Show("Duplicate Item cannot be added");
                                isDupe = true;
                                break;
                            }
                        }
                    }
                    if (isDupe)
                    {
                        break;
                    }
                    //Checks if amount is positive:

                    if (amountTb.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Please Enter an amount");
                        break;
                    }
                    else
                    {
                        try
                        {
                            if (!(Convert.ToDecimal(amountTb.Text) > 0))
                            {
                                MessageBox.Show("Amount must be above zero");
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Please enter a valid value in the amount box");
                            break;
                        }

                    }


                    //Closes loop after all validation, adds row.


                    List<string> newrow = new List<string>
                        {
                            partNameCb.SelectedItem.ToString(),
                            batchnotb.Text,
                            amountTb.Text,
                            string.Empty,
                            string.Empty
                        };

                    partsListDGV.Rows.Add(newrow.ToArray());
                    break;
                }
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //Check for ATLEAST one part:
            

            if (partsListDGV.Rows.Count == 0)
            {
                MessageBox.Show("You need to add AT LEAST one part");
            }
            else if (_orderItemsID == -1)
            {
                using (var context = new Session4Entities())
                {
                    //Adding new Part
                    var currentOrderId = context.Orders.OrderByDescending(x => x.ID).Select(x => x.ID).First() + 1;

                    Order newOrder = new Order
                    {
                        ID = currentOrderId,
                        TransactionTypeID = 1,
                        SupplierID = supplierCb.SelectedIndex + 1,
                        SourceWarehouseID = null,
                        DestinationWarehouseID = warehouseCb.SelectedIndex + 1,
                        Date = DateTime.Now
                    };

                    context.Orders.Add(newOrder);

                    foreach (DataGridViewRow row in partsListDGV.Rows)
                    {
                        var currentOrderItemId = context.OrderItems.OrderByDescending(x => x.ID).Select(x => x.ID).First() + 1;
                        var currentPartName = row.Cells[0].Value.ToString();
                        var currentPartId = context.Parts.Where(x => x.Name == currentPartName).Select(x => x.ID).First();
                        var amount = Convert.ToDecimal(row.Cells[2].Value.ToString());



                        OrderItem newItem = new OrderItem
                        {
                            OrderID = currentOrderId,
                            PartID = currentPartId,
                            Amount = amount
                        };

                        if (row.Cells[1].Value.ToString().Equals(string.Empty))
                        {
                            newItem.BatchNumber = null;
                        }
                        else
                        {
                            newItem.BatchNumber = row.Cells[1].Value.ToString();
                        }

                        context.OrderItems.Add(newItem);
                    }
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Saved Successfully :)");
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving to database. Details: \n" + ex.Message);
                        throw ex;
                    }
                }
            }
            else
            {
                using (var context = new Session4Entities())
                {
                    var currentOrderId = context.OrderItems.Where(x => x.ID == _orderItemsID).Select(x => x.OrderID).First();

                    var currentPartsListQuery = from x in context.OrderItems
                                                where x.OrderID == currentOrderId
                                                select x;

                    foreach (var part in currentPartsListQuery)
                    {
                        context.OrderItems.Remove(part);
                    }

                    foreach (DataGridViewRow row in partsListDGV.Rows)
                    {
                        //var currentOrderItemsID = context.OrderItems.OrderByDescending(x => x.ID).Select(x => x.ID).First() + 1;
                        var currentPartName = row.Cells[0].Value.ToString();
                        var currentPartId = context.Parts.Where(x => x.Name == currentPartName).Select(x => x.ID).First();
                        var amount = Convert.ToDecimal(row.Cells[2].Value.ToString());

                        OrderItem newItem = new OrderItem
                        {
                            //ID = currentOrderItemsID,
                            OrderID = currentOrderId,
                            PartID = currentPartId,
                            Amount = amount
                        };

                        if (row.Cells[1].Value.ToString().Equals(string.Empty))
                        {
                            newItem.BatchNumber = null;
                        }
                        else
                        {
                            newItem.BatchNumber = row.Cells[1].Value.ToString();
                        }

                        context.OrderItems.Add(newItem);
                    }
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Saved Successfully :)");
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving to database. Details: \n" + ex.Message);

                    }
                }
            }
            {

            }




        }

        private void partsListDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var context = new Session4Entities())
            {

                if (e.ColumnIndex == partsListDGV.Columns["Remove"].Index)
                {
                    if (partsListDGV.Rows[e.RowIndex].Cells[3].Value.ToString().Equals(string.Empty))
                    {
                        var result = MessageBox.Show("Confirm removal?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            partsListDGV.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                    else
                    {
                        //Check DestinationWarehouse amount of items:

                        var tempPartName = partsListDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
                        var selectedPartId = context.Parts.Where(x => x.Name == tempPartName).First();

                        var destinationID = context.OrderItems.Where(x => x.PartID.Equals(selectedPartId.ID)).First().Order.DestinationWarehouseID;



                        var destAmountOfItems = (from x in context.Orders
                                                 join y in context.OrderItems on x.ID equals y.OrderID
                                                 where y.Part.ID == selectedPartId.ID && x.DestinationWarehouseID == destinationID
                                                 select y.Amount).Sum();

                        var currentAmount = Convert.ToDecimal(partsListDGV.Rows[e.RowIndex].Cells[2].Value.ToString());

                        MessageBox.Show(destAmountOfItems.ToString());

                        if ((destAmountOfItems - currentAmount) >= 0)
                        {
                            var result = MessageBox.Show("Confirm removal?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (result == DialogResult.Yes)
                            {
                                partsListDGV.Rows.RemoveAt(e.RowIndex);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Removing this item will result in negative values for the asset in the warehouse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }


        }
    }
}

