using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session_4_12_18_2019
{
    public partial class InventoryReport : Form
    {
        public InventoryReport()
        {
            InitializeComponent();
        }

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            List<string> columnNames = new List<string>
            {
                "Part Name",
                "Current Stock",
                "Recieved Stock",
                "Action"
            };

            foreach (var col in columnNames)
            {
                resultDGV.Columns.Add(col, col);
            }





            using (var context = new Session4Entities())
            {
                foreach (var warehouse in context.Warehouses.OrderBy(x => x.ID))
                {
                    warehouseCb.Items.Add(warehouse.Name);
                }
            }

        }

        void GridRefresh()
        {
            using (var context = new Session4Entities())
            {

                if (warehouseCb.SelectedItem != null)
                {

                    resultDGV.Rows.Clear();
                    var currentWarehouseId = context.Warehouses.Where(x => x.Name.Equals(warehouseCb.SelectedItem.ToString())).Select(x => x.ID).First();

                    if (currentStockRadio.Checked)
                    {
                        //Received Stock:
                        var currentStockList = (from x in context.OrderItems
                                                where x.Order.SourceWarehouseID == currentWarehouseId
                                                select x);

                        foreach (var item in currentStockList.Select(x => x.Part.Name).Distinct())
                        {
                            List<string> rows = new List<string>
                            {
                                item
                            };
                            var partID = context.Parts.Where(x => x.Name == item).First();

                            var currentStockCount = context.OrderItems.Where(x => x.PartID == partID.ID && x.Order.SourceWarehouseID == currentWarehouseId).Select(x => x.Amount).Sum();

                            rows.Add(currentStockCount.ToString());

                            resultDGV.Rows.Add(rows.ToArray());
                        }

                        resultDGV.Columns[2].Visible = false;
                        resultDGV.Columns[1].Visible = true;
                        resultDGV.Columns[3].Visible = true;

                    }
                    else if (ReceivedStockRadio.Checked)
                    {
                        //Received Stock:
                        var receievedStockList = (from x in context.OrderItems
                                                  where x.Order.DestinationWarehouseID == currentWarehouseId
                                                  select x);

                        foreach (var item in receievedStockList.Select(x => x.Part.Name).Distinct())
                        {
                            List<string> rows = new List<string>
                            {
                                item
                            };
                            rows.Add("");
                            var partID = context.Parts.Where(x => x.Name == item).First();

                            var currentStockCount = context.OrderItems.Where(x => x.PartID == partID.ID && x.Order.DestinationWarehouseID == currentWarehouseId).Select(x => x.Amount).Sum();

                            rows.Add(currentStockCount.ToString());

                            resultDGV.Rows.Add(rows.ToArray());
                        }

                        resultDGV.Columns[2].Visible = true;
                        resultDGV.Columns[1].Visible = false;
                        resultDGV.Columns[3].Visible = true;
                    }
                    else
                    {
                        var outofStockList = (from x in context.OrderItems
                                              select x);

                        foreach (var item in outofStockList.Select(x => x.Part.Name).Distinct())
                        {
                            List<string> row = new List<string>();

                            var partID = context.Parts.Where(x => x.Name == item).First();
                            if (context.OrderItems.Where(x=>x.PartID == partID.ID && x.Order.SourceWarehouseID == currentWarehouseId).FirstOrDefault() != null)
                            {
                                var currentStockCount = context.OrderItems.Where(x => x.PartID == partID.ID && x.Order.SourceWarehouseID == currentWarehouseId).Select(x => x.Amount).Sum();
                                var outofStock = context.OrderItems.Where(x => x.PartID == partID.ID && x.Order.DestinationWarehouseID == currentWarehouseId).Select(x => x.Amount).Sum();
                                
                                if ((currentStockCount - outofStock) <= 0)
                                {
                                    row.Add(item);
                                    resultDGV.Rows.Add(row.ToArray());
                                }
                            }
                            resultDGV.Columns[2].Visible = false;
                            resultDGV.Columns[1].Visible = false;
                            resultDGV.Columns[3].Visible = false;


                        }

                    }

                    foreach (DataGridViewRow row in resultDGV.Rows)
                    {
                        var currentRowPartName = row.Cells[0].Value.ToString();

                        if (!(resultDGV.Rows.Count <= 0))
                        {
                            if (context.Parts.Where(x => x.Name == currentRowPartName).Select(x => x.BatchNumberHasRequired).First() == true)
                            {
                                DataGridViewLinkCell buttonCell = new DataGridViewLinkCell
                                {
                                    Value = "View Batch Numbers",
                                    UseColumnTextForLinkValue = false,
                                };

                                resultDGV.Rows[row.Index].Cells[3] = buttonCell;
                            }
                            else
                            {
                                resultDGV.Rows[row.Index].Cells[3].Value = "";
                            }
                        }

                    }

                }

            }
        }

        private void currentStockRadio_CheckedChanged(object sender, EventArgs e)
        {
            GridRefresh();
        }

        private void ReceivedStockRadio_CheckedChanged(object sender, EventArgs e)
        {
            GridRefresh();
        }

        private void OutofStockRadio_CheckedChanged(object sender, EventArgs e)
        {
            GridRefresh();
        }

        private void warehouseCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridRefresh();
        }

        private void resultDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == resultDGV.Columns["Action"].Index && resultDGV.Rows[e.RowIndex].Cells[3].Value.ToString() == "View Batch Numbers")
            {
                var nameOfPart = resultDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
                var warehouseName = warehouseCb.SelectedItem.ToString();
                MessageBox.Show(nameOfPart);

                if (currentStockRadio.Checked)
                {
                    (new BatchNumberView(nameOfPart,warehouseName, 1)).ShowDialog();
                }
                else if (ReceivedStockRadio.Checked)
                {
                    (new BatchNumberView(nameOfPart, warehouseName, 2)).ShowDialog();
                }
                else
                {
                    (new BatchNumberView(nameOfPart, warehouseName, 3)).ShowDialog();
                }
            }
        }
    }
}
