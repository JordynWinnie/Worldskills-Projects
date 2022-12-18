using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kazan_Session2_8_11_2020
{
    public partial class Managing_EM_Requests_by_Accountable_Party : Form
    {
        private long _employeeID;
        private long _selectedAssetID = -1;

        public Managing_EM_Requests_by_Accountable_Party(long employeeID)
        {
            _employeeID = employeeID;
            InitializeComponent();
        }

        private void Managing_EM_Requests_by_Accountable_Party_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Asset SN", "Asset Name", "Last Closed EM", "Number of EMs", "IsHighlight", "Id"
            };

            foreach (var column in columns)
            {
                assetDGV.Columns.Add(column, column);
            }

            RefreshDGV();
        }

        private void RefreshDGV()
        {
            assetDGV.Rows.Clear();
            using (var session2Entities = new Session2Entities())
            {
                var assetQuery = from x in session2Entities.Assets
                                 where x.EmployeeID == _employeeID
                                 select x;

                foreach (var asset in assetQuery)
                {
                    var row = new List<string>
                {
                    asset.AssetSN,
                    asset.AssetName
                };

                    var lastClosedEm = asset.EmergencyMaintenances.Where(x => x.EMEndDate != null).Select(x => x.EMEndDate);

                    if (lastClosedEm.Any())
                    {
                        row.Add(((DateTime)lastClosedEm.First()).ToShortDateString());
                    }
                    else
                    {
                        row.Add("--");
                    }
                    row.Add(asset.EmergencyMaintenances.Count.ToString());

                    if (asset.EmergencyMaintenances.Count != 0 && asset.EmergencyMaintenances.Where(x => x.EMEndDate == null).Any())
                    {
                        row.Add("true");
                    }
                    else
                    {
                        row.Add("false");
                    }

                    row.Add(asset.ID.ToString());
                    assetDGV.Rows.Add(row.ToArray());
                }

                foreach (DataGridViewRow row in assetDGV.Rows)
                {
                    if (row.Cells[4].Value.ToString().Equals("true"))
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }

                assetDGV.Columns[4].Visible = false;
                assetDGV.Columns[5].Visible = false;
            }
        }

        private void assetDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedAssetID = long.Parse(assetDGV[5, e.RowIndex].Value.ToString());
            Console.WriteLine(_selectedAssetID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_selectedAssetID == -1)
            {
                MessageBox.Show("Please select an asset");
            }
            else
            {
                Hide();
                (new Registering_a_New_EM_Request_for_an_Asset(_selectedAssetID)).ShowDialog();
                RefreshDGV();
                Show();
            }
        }
    }
}