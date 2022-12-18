using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session_6_22_12_2019
{
    public partial class InventoryControl : Form
    {
        public InventoryControl()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InventoryControl_Load(object sender, EventArgs e)
        {

            
            using (var context = new Session6Entities())
            {
                //Populate the EM combobox:
                foreach (var asset in context.EmergencyMaintenances.Where(x => x.EMEndDate == null))
                {
                    assetnameCB.Items.Add(asset.Asset.AssetName + " - " + asset.ID);
                }

                //Populate the Warehouse Combobox:

                foreach (var warehouse in context.Warehouses)
                {
                    warehouseCb.Items.Add(warehouse.Name);
                }

                //Populate the Allocation Method combobox:
                List<string> allocationMethods = new List<string>
                {
                    "FIFO (First in First Out)",
                    "LIFO (Last in First Out)",
                    "Minimum First"
                };

                allocationCB.Items.AddRange(allocationMethods.ToArray());

                //Populate Columns for Allocated Parts && Assigned Parts
                List<string> assignPartsCol = new List<string>
                {
                    "Part Name",
                    "Batch Number",
                    "Unit Price",
                    "Amount",
                    "ORDERITEMSID (DEBUG)"
                };
                foreach (var column in assignPartsCol)
                {
                    allocatedPartsDGV.Columns.Add(column, column);
                    assignedPartsDGV.Columns.Add(column, column);
                }

                DataGridViewLinkColumn cell = new DataGridViewLinkColumn
                {
                    Text = "Remove",
                    HeaderText = "Action",
                    UseColumnTextForLinkValue = true,
                    Name = "Action"
                };

                assignedPartsDGV.Columns.Add(cell);


            }

            dateDtp.Value = DateTime.Parse("1/1/2017");
            stateLabel.Text = "Please select an asset name";
        }

        private void warehouseCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            allocatedPartsDGV.Rows.Clear();
            using (var context = new Session6Entities())
            {
                partNameCb.Items.Clear();
                var selectedWarehouseID = context.Warehouses.Where(x => x.Name == warehouseCb.SelectedItem.ToString()).Select(x => x.ID).FirstOrDefault();
                var availableParts = from x in context.OrderItems
                                     where x.Order.SourceWarehouseID == selectedWarehouseID && x.Order.Date <= dateDtp.Value
                                     select x;

                foreach (var item in availableParts.Select(x => x.Part.Name).Distinct())
                {
                    partNameCb.Items.Add(item);
                }
            }
        }

        private void allocationCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            allocatedPartsDGV.Rows.Clear();

        }

        private void allocateBtn_Click(object sender, EventArgs e)
        {
            //Do Proper Validation Checks:

            while (true)
            {
                //Check if all comboboxes are selected
                if (allocationCB.SelectedItem == null || warehouseCb.SelectedItem == null || partNameCb.SelectedItem == null)
                {
                    MessageBox.Show("Please fill up all the comboboxes");
                    break;
                }
                //Check if amount is in correct format:
                try
                {
                    if (Convert.ToDecimal(amountTb.Text) <= 0)
                    {
                        MessageBox.Show("The amount must be more than zero");
                        break;
                    }
                }
                catch
                {
                    MessageBox.Show("Enter a valid value for amount");
                    break;

                }

                using (var context = new Session6Entities())
                {
                    allocatedPartsDGV.Rows.Clear();

                    var selectedWarehouseID = context.Warehouses.Where(x => x.Name == warehouseCb.SelectedItem.ToString()).Select(x => x.ID).FirstOrDefault();
                    if (allocationCB.SelectedItem.ToString().Contains("FIFO"))
                    {

                        //TODO: Logic for FIFO
                        var tempAmount = Convert.ToDecimal(amountTb.Text);
                        //Check if SUM of amount is possible to reach for part:
                        var totalNumberOfPart = (from x in context.OrderItems
                                                 where x.Order.SourceWarehouseID == selectedWarehouseID && x.Part.Name == partNameCb.SelectedItem.ToString() && x.Order.Date <= dateDtp.Value
                                                 select x.Amount).Sum();

                        if (totalNumberOfPart >= tempAmount)
                        {
                            MessageBox.Show(totalNumberOfPart.ToString() + " - " + tempAmount.ToString());


                            var findFIFO = (from x in context.OrderItems
                                            orderby x.Order.Date descending
                                            where x.Order.SourceWarehouseID == selectedWarehouseID && x.Part.Name == partNameCb.SelectedItem.ToString() && x.Order.Date <= dateDtp.Value
                                            select x);

                            foreach (var item in findFIFO)
                            {
                                if (item != null)
                                {
                                    List<string> row = new List<string>
                                    {
                                        item.Part.Name,
                                        item.BatchNumber,
                                        item.UnitPrice.ToString(),
                                        item.Amount.ToString(),
                                        item.ID.ToString()
                                    };

                                    allocatedPartsDGV.Rows.Add(row.ToArray());
                                    tempAmount -= item.Amount;
                                }

                                if (tempAmount <= 0)
                                {
                                    break;
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot find part with conditions");
                        }

                    }
                    else if (allocationCB.SelectedItem.ToString().Contains("LIFO"))
                    {
                        //TODO: Logic for LIFO:
                        var tempAmount = Convert.ToDecimal(amountTb.Text);
                        //Check if SUM of amount is possible to reach for part:
                        var totalNumberOfPart = (from x in context.OrderItems
                                                 where x.Order.SourceWarehouseID == selectedWarehouseID && x.Part.Name == partNameCb.SelectedItem.ToString() && x.Order.Date <= dateDtp.Value
                                                 select x.Amount).Sum();

                        if (totalNumberOfPart >= tempAmount)
                        {
                            MessageBox.Show(totalNumberOfPart.ToString() + " - " + tempAmount.ToString());


                            var findLIFO = (from x in context.OrderItems
                                            orderby x.Order.Date
                                            where x.Order.SourceWarehouseID == selectedWarehouseID && x.Part.Name == partNameCb.SelectedItem.ToString() && x.Order.Date <= dateDtp.Value
                                            select x);

                            foreach (var item in findLIFO)
                            {
                                if (item != null)
                                {
                                    List<string> row = new List<string>
                                    {
                                        item.Part.Name,
                                        item.BatchNumber,
                                        item.UnitPrice.ToString(),
                                        item.Amount.ToString(),
                                        item.ID.ToString()
                            };

                                    allocatedPartsDGV.Rows.Add(row.ToArray());
                                    tempAmount -= item.Amount;
                                }

                                if (tempAmount <= 0)
                                {
                                    break;
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot find part with conditions");
                        }

                    }
                    else
                    {
                        //TODO: Logic for Min Amount
                        var tempAmount = Convert.ToDecimal(amountTb.Text);
                        //Check if SUM of amount is possible to reach for part:
                        var totalNumberOfPart = (from x in context.OrderItems
                                                 where x.Order.SourceWarehouseID == selectedWarehouseID && x.Part.Name == partNameCb.SelectedItem.ToString() && x.Order.Date <= dateDtp.Value
                                                 select x.Amount).Sum();

                        if (totalNumberOfPart >= tempAmount)
                        {
                            MessageBox.Show(totalNumberOfPart.ToString() + " - " + tempAmount.ToString());


                            var searchByMinimumAmount = (from x in context.OrderItems
                                                         orderby x.UnitPrice
                                                         where x.Order.SourceWarehouseID == selectedWarehouseID && x.Part.Name == partNameCb.SelectedItem.ToString() && x.Order.Date <= dateDtp.Value
                                                         select x);

                            foreach (var item in searchByMinimumAmount)
                            {
                                if (item != null)
                                {
                                    List<string> row = new List<string>
                                    {
                                        item.Part.Name,
                                        item.BatchNumber,
                                        item.UnitPrice.ToString(),
                                        item.Amount.ToString(),
                                        item.ID.ToString()
                            };

                                    allocatedPartsDGV.Rows.Add(row.ToArray());
                                    tempAmount -= item.Amount;
                                }

                                if (tempAmount <= 0)
                                {
                                    break;
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot find part with conditions");
                        }
                    }
                }

                break;
            }

        }

        private void allocatedPartGroupbox_Enter(object sender, EventArgs e)
        {

        }

        private void assetnameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateDtp.Enabled = true;

            if (dateDtp.Value == DateTime.Parse("1/1/2017"))
            {
                stateLabel.Text = "Please select a date before you get started";
            }
        }

        private void dateDtp_ValueChanged(object sender, EventArgs e)
        {
            if (dateDtp.Value < DateTime.Parse("12/31/2016"))
            {
                MessageBox.Show("There are no entries before the year 2017");
                dateDtp.Value = DateTime.Parse("1/1/2017");
            }
            else if (dateDtp.Value > DateTime.Parse("1/1/2017"))
            {
                allocatedPartGroupbox.Enabled = true;
                partSearchGroupBox.Enabled = true;
                stateLabel.Text = "";
            }
            else
            {
                stateLabel.Text = "Please select a date before you get started";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Adding to the Assigned Parts list

            //Check if any duplicates are assigned:

            bool breakpoint = true;
            while (breakpoint)
            {
                if (assignedPartsDGV.Rows.Count > 0)
                {
                    foreach (DataGridViewRow newRow in allocatedPartsDGV.Rows)
                    {
                        foreach (DataGridViewRow oldRow in assignedPartsDGV.Rows)
                        {
                            if (newRow.Cells[0].Value.Equals(oldRow.Cells[0].Value))
                            {
                                MessageBox.Show("Cannot add duplicate parts");
                                breakpoint = false;
                            }

                            if (!breakpoint)
                            {
                                break;
                            }
                        }

                        if (!breakpoint)
                        {
                            break;
                        }
                    }
                }

                if (!breakpoint)
                {
                    break;
                }

                foreach (DataGridViewRow oldRow in allocatedPartsDGV.Rows)
                {
                    List<string> row = new List<string>
                                    {
                                        oldRow.Cells[0].Value.ToString(),
                                        oldRow.Cells[1].Value.ToString(),
                                        oldRow.Cells[2].Value.ToString(),
                                        oldRow.Cells[3].Value.ToString(),
                                        oldRow.Cells[4].Value.ToString()
                                    };

                    assignedPartsDGV.Rows.Add(row.ToArray());
                }

                breakpoint = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateDtp.Value = DateTime.Parse("1/1/2019");
            warehouseCb.SelectedIndex = 0;
            
            partNameCb.SelectedIndex = 0;
            allocationCB.SelectedIndex = 0;
            amountTb.Text = "10";
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //Do validation checks
            bool breakpoint = true;
            while (breakpoint)
            {
                if (assignedPartsDGV.Rows.Count == 0)
                {
                    breakpoint = false;
                    MessageBox.Show("There needs to be at least one item in the assigned parts for submission");
                    break;
                    
                }

                if (assetnameCB.SelectedItem == null)
                {
                    breakpoint = false;
                    MessageBox.Show("Please select an asset");
                    break;
                    
                }

                //Add new Order

                using (var context = new Session6Entities())
                {
                    //get current EM number:
                    
                    var currentAssetId = Convert.ToInt64(assetnameCB.SelectedItem.ToString().Last().ToString());
                    //var currentAssetID = context.Assets.Where(x=>x.AssetName)
                    var currentEMID = context.EmergencyMaintenances.Where(x => x.AssetID == currentAssetId).Select(x => x.ID).FirstOrDefault();
                    var sourceWarehouseID = context.Warehouses.Where(x => x.Name.Contains(warehouseCb.SelectedItem.ToString())).Select(x => x.ID).FirstOrDefault();

                    var newOrderID = context.Orders.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                    //Find currentTimeSpan:
                    DateTime todayDate = DateTime.Today;
                    DateTime currentTime = DateTime.Now;

                    TimeSpan interval = currentTime - todayDate;

                    Order addOrder = new Order
                    {
                        TransactionTypeID = 3,
                        EmergencyMaintenancesID = currentEMID,
                        SourceWarehouseID = sourceWarehouseID,
                        Date = DateTime.Today,
                        Time = interval
                    };

                    context.Orders.Add(addOrder);

                    //Add all the OrderItems

                    foreach (DataGridViewRow newItem in assignedPartsDGV.Rows)
                    {
                        var partname = newItem.Cells[0].Value.ToString();
                        var currentPartID = context.Parts.Where(x => x.Name.Equals(partname)).Select(x => x.ID).FirstOrDefault();

                       
                        OrderItem newOrderItem = new OrderItem
                        {
                            OrderID = newOrderID,
                            PartID = currentPartID,
                            BatchNumber = newItem.Cells[1].Value.ToString(),
                            Amount = Convert.ToDecimal(newItem.Cells[3].Value.ToString()),
                            Stock = 0,
                            UnitPrice = Convert.ToDecimal(newItem.Cells[2].Value.ToString())
                        };

                        context.OrderItems.Add(newOrderItem);
                    }

                    //update the EM END DATE:

                    var EMToUpdate = from x in context.EmergencyMaintenances
                                     where x.ID == currentEMID
                                     select x;

                    foreach (var item in EMToUpdate)
                    {
                        item.EMEndDate = dateDtp.Value;
                    }

                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Changes saved c:");
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error has occurred, details: \n" + ex.Message);
                        throw;
                    }

                    break;

                }
            }
        }

        private void assignedPartsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == assignedPartsDGV.Columns["Action"].Index)
            {
                var result = MessageBox.Show("Confirm removal?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    assignedPartsDGV.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void partNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            allocatedPartsDGV.Rows.Clear();
        }
    }
}
