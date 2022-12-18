using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session2__17_12_2019
{
    public partial class EmergencyRequestDetails : Form
    {
        List<TableItems> allItems = new List<TableItems>();
        long _EMid;
        public EmergencyRequestDetails(long emID)

        {
            _EMid = emID;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EmergencyRequestDetails_Load(object sender, EventArgs e)
        {
            allItems.Clear();

            using (var context = new Session2Entities())
            {
                var adminAssetListQuery = (from x in context.EmergencyMaintenances
                                           join y in context.Assets on x.AssetID equals y.ID
                                           join z in context.Employees on y.EmployeeID equals z.ID
                                           join a in context.DepartmentLocations on y.DepartmentLocationID equals a.ID
                                           join b in context.Departments on a.DepartmentID equals b.ID
                                           where x.ID == _EMid
                                           select new { x, y, z, b });

                foreach (var asset in adminAssetListQuery)
                {
                    assetNameLbl.Text = asset.y.AssetName;
                    assetSnLbl.Text = asset.y.AssetSN;
                    departmentLbl.Text = asset.b.Name;
                    
                }

                var partsList = from x in context.Parts
                                select x.Name;

                foreach (var part in partsList)

                {
                    partNameCb.Items.Add(part);
                }

                partNameCb.SelectedIndex = 0;

                List<string> columnNames = new List<string>
                {
                    "Part Name",
                    "Amount"
                    
                };

                foreach (var col in columnNames)
                {
                    assetViewDGV.Columns.Add(col, col);
                }

                var existingPartsQuery = from x in context.ChangedParts
                                         join z in context.Parts on x.PartID equals z.ID
                                         where x.EmergencyMaintenanceID == _EMid
                                         select new
                                         {
                                             x,
                                             z
                                         };

                foreach (var item in existingPartsQuery)
                {
                    List<string> newRow = new List<string>
                    {
                        item.z.Name,
                        item.x.Amount.ToString(),    
                    };
                    allItems.Add(new TableItems { itemName = item.z.Name, itemAmount = Convert.ToDecimal(item.x.Amount) });
                    assetViewDGV.Rows.Add(newRow.ToArray());
                }

                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                {
                    button.Name = "Action";
                    button.HeaderText = "Action";
                    button.Text = "Remove";
                    button.UseColumnTextForButtonValue = true; //dont forget this line
                    this.assetViewDGV.Columns.Add(button);
                }
            }
            
        }

        private void addToListBtn_Click(object sender, EventArgs e)
        {
            

            try
            {
                List<string> newRow = new List<string>
            {
                partNameCb.SelectedItem.ToString(),
                amountTb.Text
            };
                allItems.Add(new TableItems { itemName = partNameCb.SelectedItem.ToString(), itemAmount = Convert.ToDecimal(amountTb.Text) });
                assetViewDGV.Rows.Add(newRow.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a number for the Amount Box");
            }
            
            
        }

        class TableItems
        {
            public string itemName { get; set; }
            public decimal itemAmount { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in allItems)
            {
                sb.Append(item.itemName + " " + item.itemAmount);   
            }

            label4.Text = sb.ToString();
        }

        private void assetViewDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == assetViewDGV.Columns["Action"].Index)
            {
                
                try
                {
                    MessageBox.Show("Removing item:" + assetViewDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
                    

                    TableItems temp = new TableItems
                    {
                        itemName = assetViewDGV.Rows[e.RowIndex].Cells[0].Value.ToString(),
                        itemAmount = Convert.ToDecimal(assetViewDGV.Rows[e.RowIndex].Cells[1].Value.ToString())
                    };
                    assetViewDGV.Rows.RemoveAt(e.RowIndex);
                    allItems.Remove(temp);
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
        }
    }
}
