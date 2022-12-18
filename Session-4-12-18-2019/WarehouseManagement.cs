using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session_4_12_18_2019
{
    public partial class WarehouseManagement : Form
    {
        long _orderItemID = -1;
        public WarehouseManagement(long orderID)
        {
            _orderItemID = orderID;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WarehouseManagement_Load(object sender, EventArgs e)
        {

            using (var context = new Session4Entities())
            {
                //Basic form functions:
                List<string> columnNames = new List<string>
            {
                "Part Name",
                "Batch Number",
                "Amount",
                "PartID (DEBUG)"

            };

                foreach (var col in columnNames)
                {
                    partsListDGV.Columns.Add(col, col);
                }

                foreach (var wareHouse in context.Warehouses.OrderBy(x => x.ID))
                {
                    sourceWarehouseCb.Items.Add(wareHouse.Name);
                    destinationWarehouseCb.Items.Add(wareHouse.Name);
                }



                if (_orderItemID == -1)
                {
                    this.Text = "New Warehouse Management";

                    //TODO: Make UI Elements for NEW Transfer
                }
                else
                {
                    this.Text = "Editing Warehouse Transaction " + _orderItemID;

                    var currentOrder = context.OrderItems.Where(x => x.ID == _orderItemID).Select(x => x).First();


                    sourceWarehouseCb.SelectedIndex = (int)(context.Orders.Where(x => x.ID == currentOrder.OrderID).Select(x => x.SourceWarehouseID).First() - 1);
                    destinationWarehouseCb.SelectedIndex = (int)(context.Orders.Where(x => x.ID == currentOrder.OrderID).Select(x => x.DestinationWarehouseID).First() - 1);

                    dateDtp.Value = currentOrder.Order.Date;

                    var currentOrderItems = context.OrderItems.Where(x => x.OrderID == currentOrder.OrderID).Select(x => x);

                    //Updates DataGridView
                    foreach (var item in currentOrderItems)
                    {
                        List<string> row = new List<string>
                        {
                            item.Part.Name,
                            item.BatchNumber,
                            item.Amount.ToString(),
                            item.PartID.ToString()
                        };

                        partsListDGV.Rows.Add(row.ToArray());
                    }

                    DataGridViewButtonColumn removeBtn = new DataGridViewButtonColumn
                    {
                        Name = "Remove",
                        HeaderText = "Action",
                        UseColumnTextForButtonValue = true,
                        Text = "Remove"
                    };
                    partsListDGV.Columns.Add(removeBtn);

                    var sourceWarehouseID = context.Orders.Where(x => x.ID == currentOrder.OrderID).Select(x => x.SourceWarehouseID).First();
                    var allPartsFromSourceW = (from x in context.OrderItems
                                               where x.Order.SourceWarehouseID == sourceWarehouseID
                                               select x.Part.Name).Distinct();


                    foreach (var item in allPartsFromSourceW)
                    {
                        partNameCb.Items.Add(item);
                    }

                    partNameCb.SelectedIndex = 0;

                    //Checks if batchCb is supposed to be disabled
                    var currentPart = context.Parts.Where(x => x.Name == partNameCb.SelectedItem.ToString()).Select(x => x.ID).First();

                    var isBatch = (from x in context.OrderItems
                                   where x.PartID == currentPart
                                   select x);

                    if (isBatch.First().Part.BatchNumberHasRequired == true)
                    {
                        batchNumberCb.Items.Clear();
                        batchNumberCb.Enabled = true;

                        foreach (var item in isBatch.Select(x => x.BatchNumber).Distinct())
                        {
                            batchNumberCb.Items.Add(item);
                        }
                    }
                    else
                    {
                        batchNumberCb.Enabled = false;
                        batchNumberCb.Items.Clear();
                    }


                }
            }
        }

        
        private void partNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (var context = new Session4Entities())
            {
                var currentPart = context.Parts.Where(x => x.Name == partNameCb.SelectedItem.ToString()).Select(x => x.ID).First();

                var isBatch = (from x in context.OrderItems
                               where x.PartID == currentPart
                               select x);

                if (isBatch.First().Part.BatchNumberHasRequired == true)
                {
                    batchNumberCb.Items.Clear();
                    batchNumberCb.Enabled = true;
                    foreach (var item in isBatch.Select(x => x.BatchNumber).Distinct())
                    {
                        batchNumberCb.Items.Add(item);
                    }
                    batchNumberCb.SelectedIndex = 0;
                }
                else
                {
                    batchNumberCb.Enabled = false;
                    batchNumberCb.Items.Clear();
                }
            }
        }

        private void sourceWarehouseCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                if (_orderItemID == -1)
                {
                    //If it's a new warehouse transfer, just ensure that selected index is null when user picks the same:
                    if (sourceWarehouseCb.SelectedItem.Equals(destinationWarehouseCb.SelectedItem))
                    {
                        MessageBox.Show("Source and Destination Warehouse cannot be the same");
                        if (sourceWarehouseCb.SelectedIndex == 0)
                        {
                            destinationWarehouseCb.SelectedIndex = 1;
                        }
                        else
                        {
                            destinationWarehouseCb.SelectedIndex = 0;
                        }
                    }
                    
                    if (sourceWarehouseCb.SelectedItem.ToString().Equals("Central Warehouse"))
                    {
                        partNameCb.Items.Clear();
                        var allPartsFromSourceW = (from x in context.OrderItems
                                                   where x.Order.SourceWarehouseID == 1
                                                   select x.Part.Name).Distinct();


                        foreach (var item in allPartsFromSourceW)
                        {
                            partNameCb.Items.Add(item);
                        }

                        partNameCb.SelectedIndex = 0;
                    }
                    else
                    {
                        partNameCb.Items.Clear();
                        var allPartsFromSourceW = (from x in context.OrderItems
                                                   where x.Order.SourceWarehouseID == 2
                                                   select x.Part.Name).Distinct();


                        foreach (var item in allPartsFromSourceW)
                        {
                            partNameCb.Items.Add(item);
                        }

                        partNameCb.SelectedIndex = 0;
                    }
                }
                else
                {
                    //Checks if SelectedItems are the same
                    if (sourceWarehouseCb.SelectedItem.Equals(destinationWarehouseCb.SelectedItem))
                    {
                        MessageBox.Show("Source and Destination Warehouse cannot be the same");
                        var currentOrder = context.OrderItems.Where(x => x.ID == _orderItemID).Select(x => x).First();
                        sourceWarehouseCb.SelectedIndex = (int)(context.Orders.Where(x => x.ID == currentOrder.OrderID).Select(x => x.SourceWarehouseID).First() - 1);
                        destinationWarehouseCb.SelectedIndex = (int)(context.Orders.Where(x => x.ID == currentOrder.OrderID).Select(x => x.DestinationWarehouseID).First() - 1);
                    }
                }
                
            }

        }

        private void destinationWarehouseCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                if (_orderItemID == -1)
                {
                    if (sourceWarehouseCb.SelectedItem.Equals(destinationWarehouseCb.SelectedItem))
                    {
                        MessageBox.Show("Source and Destination Warehouse cannot be the same");
                        if (destinationWarehouseCb.SelectedIndex == 0)
                        {
                            sourceWarehouseCb.SelectedIndex = 1;
                        }
                        else
                        {
                            sourceWarehouseCb.SelectedIndex = 0;
                        }
                    }
                }
                else
                {
                    //Checks if SelectedItems are the same
                    if (sourceWarehouseCb.SelectedItem.Equals(destinationWarehouseCb.SelectedItem))
                    {
                        MessageBox.Show("Source and Destination Warehouse cannot be the same");
                        var currentOrder = context.OrderItems.Where(x => x.ID == _orderItemID).Select(x => x).First();
                        sourceWarehouseCb.SelectedIndex = (int)(context.Orders.Where(x => x.ID == currentOrder.OrderID).Select(x => x.SourceWarehouseID).First() - 1);
                        destinationWarehouseCb.SelectedIndex = (int)(context.Orders.Where(x => x.ID == currentOrder.OrderID).Select(x => x.DestinationWarehouseID).First() - 1);
                    }
                }
                
            }
        }

        private void addToListBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                if (partNameCb.SelectedItem != null)
                {
                    var checkForBatch = context.Parts.Where(x => x.Name.Equals(partNameCb.SelectedItem.ToString())).Select(x => x).FirstOrDefault();

                    while (true)
                    {
                        //Check if list has duplicate parts
                        var isDupe = false;
                        foreach (DataGridViewRow row in partsListDGV.Rows)
                        {
                            //Checks if Batch number products have duplicates
                            if (checkForBatch.BatchNumberHasRequired == true)
                            {
                                if (row.Cells[0].Value.ToString().Equals(partNameCb.SelectedItem.ToString()) && row.Cells[1].Value.ToString().Equals(batchNumberCb.SelectedItem.ToString()))
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

                        //Checks if adding the currentPart will make sourceWarehouse Negative:


                        var tempPartName = partNameCb.SelectedItem.ToString();
                        var selectedPartId = context.Parts.Where(x => x.Name == tempPartName).First();

                        var destinationID = context.OrderItems.Where(x => x.PartID.Equals(selectedPartId.ID)).First().Order.SourceWarehouseID;



                        var destAmountOfItems = (from x in context.Orders
                                                 join y in context.OrderItems on x.ID equals y.OrderID
                                                 where y.Part.ID == selectedPartId.ID && x.SourceWarehouseID == destinationID
                                                 select y.Amount).Sum();

                        var currentAmount = Convert.ToDecimal(amountTb.Text);

                        MessageBox.Show(destAmountOfItems.ToString());

                        if ((destAmountOfItems - currentAmount) < 0)
                        {
                            MessageBox.Show("Adding this item will result in negative values for the asset in the source warehouse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                        //Closes loop after all validation, adds row.

                        if (batchNumberCb.Enabled == false)
                        {
                            List<string> newrow = new List<string>
                        {
                            partNameCb.SelectedItem.ToString(),
                            string.Empty,
                            amountTb.Text,
                            string.Empty
                        };
                            partsListDGV.Rows.Add(newrow.ToArray());
                        }
                        else
                        {
                            List<string> newrow = new List<string>
                        {
                            partNameCb.SelectedItem.ToString(),
                            batchNumberCb.SelectedItem.ToString(),
                            amountTb.Text,
                            string.Empty
                        };
                            partsListDGV.Rows.Add(newrow.ToArray());
                        }
                        break;
                    }
                }
                
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                
                if (partsListDGV.Rows.Count <= 0)
                {
                    MessageBox.Show("You need to add at least one part");
                }
                else if (_orderItemID == -1)
                {
                    //Additonal Validation checks for ADDING NEW PART:

                    while (true)
                    {
                        //check source warehouse for selected item
                        if (sourceWarehouseCb.SelectedItem == null)
                        {
                            MessageBox.Show("Please select a source warehouse");
                            break;
                        }

                        //check destination warehouse for selected item
                        if (destinationWarehouseCb.SelectedItem == null)
                        {
                            MessageBox.Show("Please select a destination warehouse");
                            break;
                        }

                        //Confirm with user if TODAY is the day they want to submit the form
                        if (dateDtp.Value == DateTime.Today)
                        {
                            var result = MessageBox.Show($"Are you sure you want the date selected to be today? ({DateTime.Today})?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            
                            if (result != DialogResult.Yes)
                            {
                                break;
                            }
                        }

                        //Submission logic for ADDING NEW PART
                        var currentOrderId = context.Orders.OrderByDescending(x => x.ID).Select(x => x.ID).First() + 1;

                        Order newOrder = new Order
                        {
                            ID = currentOrderId,
                            TransactionTypeID = 1,
                            SupplierID = null,
                            SourceWarehouseID = sourceWarehouseCb.SelectedIndex + 1,
                            DestinationWarehouseID = destinationWarehouseCb.SelectedIndex + 1,
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

                        break;

                    }

                }
                else
                {
                    //EDIT:
                    var currentOrderId = context.OrderItems.Where(x => x.ID == _orderItemID).Select(x => x.OrderID).First();

                    var currentPartsListQuery = from x in context.OrderItems
                                                where x.OrderID == currentOrderId
                                                select x;

                    foreach (var part in currentPartsListQuery)
                    {
                        context.OrderItems.Remove(part);
                    }

                    foreach (DataGridViewRow row in partsListDGV.Rows)
                    {
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

                    }

                }
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
                            MessageBox.Show("Removing this item will result in negative values for the asset in the destination warehouse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }
    }
}
