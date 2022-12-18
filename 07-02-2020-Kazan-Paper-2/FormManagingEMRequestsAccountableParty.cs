using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07_02_2020_Kazan_Paper_2
{
    public partial class FormManagingEMRequestsAccountableParty : Form
    {
        long _employeeID = -1;
        long _assetID = -1;
        public FormManagingEMRequestsAccountableParty(long employeeID)
        {
            _employeeID = employeeID;
            InitializeComponent();
        }

        private void FormManagingEMRequestsAccountableParty_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Asset SN",
                "Asset Name",
                "Last Closed Em",
                "Number of Ems",
                "IsHighLight (DEBUG)",
                "AssetID (DEBUG)"
            };
            foreach (var item in columns)
            {
                dataGridView1.Columns.Add(item, item);
            }
            using (var context = new Session2Entities())
            {
                var assetQuery = from x in context.Assets
                                 where x.EmployeeID == _employeeID
                                 select x;

                foreach (var asset in assetQuery)
                {
                    var row = new List<string>();
                    var EMRequestUnderAsset = context.EmergencyMaintenances.Where(x => x.AssetID == asset.ID).OrderByDescending(x=>x.EMEndDate).FirstOrDefault();
                    
                    if (EMRequestUnderAsset != null)
                    {
                        var countOfEmUnderAsset = context.EmergencyMaintenances.Where(x => x.AssetID == asset.ID).Count();
                        
                        //Fill in the table WITH EM Request
                        row.Add(asset.AssetSN);
                        row.Add(asset.AssetName);
                        if (EMRequestUnderAsset.EMEndDate != null)
                        {
                            row.Add(EMRequestUnderAsset.EMEndDate.ToString());
                        }
                        else
                        {
                            row.Add("--");
                        }
                        
                        row.Add(countOfEmUnderAsset.ToString());

                        var latestEMReport = context.EmergencyMaintenances.Where(x => x.AssetID == asset.ID).Select(x => x.EMEndDate).FirstOrDefault();
                        if (latestEMReport == null)
                        {
                            row.Add("TRUE");
                        }
                        else
                        {
                            row.Add("FALSE");
                        }
                        row.Add(asset.ID.ToString());
                    }
                    else
                    {
                        //Fill in Table of asset WITHOUT request
                        row.Add(asset.AssetSN);
                        row.Add(asset.AssetName);
                        row.Add("--");
                        row.Add("0");
                        row.Add("FALSE");
                        row.Add(asset.ID.ToString());
                    }

                    dataGridView1.Rows.Add(row.ToArray());
                }
                                 
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[4].Value.Equals("TRUE"))
                {
                    row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                }
            }
            
        }

        private void sendToEmReqBtn_Click(object sender, EventArgs e)
        {
            //send to EM Request
            if (_assetID == -1)
            {
                MessageBox.Show("Please select an asset");
            }
            else
            {
                this.Hide();
                (new FormRegisteringNewEMRequestAsset(_assetID)).ShowDialog();
                this.Show();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _assetID = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
        }
    }
}
