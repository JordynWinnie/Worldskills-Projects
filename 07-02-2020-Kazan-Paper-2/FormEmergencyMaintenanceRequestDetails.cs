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
    public partial class FormEmergencyMaintenanceRequestDetails : Form
    {
        long _assetID = -1;
        long _EMID = -1;
        public FormEmergencyMaintenanceRequestDetails(long assetID, long EMID)
        {
            _assetID = assetID;
            _EMID = EMID;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEmergencyMaintenanceRequestDetails_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Part Name",
                "Amount",

            };

            foreach (var column in columns)
            {
                dataGridView1.Columns.Add(column, column);
            }

            DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Remove",
                Text = "Remove",
                HeaderText = "Remove",
                UseColumnTextForButtonValue = true,
            };

            dataGridView1.Columns.Add(dataGridViewButtonColumn);

            using (var context = new Session2Entities())
            {
                var assetQuery = context.Assets.Where(x => x.ID == _assetID).First();

                assetNameLbl.Text = assetQuery.AssetName;
                assetSNLbl.Text = assetQuery.AssetSN;
                departmentLbl.Text = assetQuery.DepartmentLocation.Department.Name;

                partCb.Items.AddRange(context.Parts.Select(x => x.Name).ToArray());
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void addToBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                while (true)
                {
                    var amountEntered = 0.0;
                    if (amountTb.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Please enter an amount");
                        break;
                    }

                    try
                    {
                        amountEntered = Convert.ToDouble(amountTb.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please enter a valid amount");
                        break;
                    }

                    if (amountEntered <= 0)
                    {
                        MessageBox.Show("Please enter an larger than zero");
                        break;
                    }

                    //Validation check for choosen part of same asset:
                    var sameAssetQuery = context.ChangedParts.Where(x => x.EmergencyMaintenance.AssetID == _assetID).Any();
                    
                    if (sameAssetQuery)
                    {
                        //check same previous asset
                        var sameAssetQuery2 = context.ChangedParts.Where(x => x.EmergencyMaintenance.AssetID == _assetID).Select(x=>x.EmergencyMaintenance.EMStartDate).First();


                        var currentPartFromCb = partCb.SelectedItem.ToString();
                        
                        //Check current part:
                        var currentPartSelected = context.Parts.Where(x => x.Name.Equals(currentPartFromCb)).First();

                        var checkIfPartExpired = context.ChangedParts.Where(x => x.PartID == currentPartSelected.ID);

                        var timeBetween = (DateTime.Now - sameAssetQuery2).Value.Days;

                        if (timeBetween < currentPartSelected.EffectiveLife)
                        {
                            var result = MessageBox.Show($"The service life for this part has not expired. {currentPartSelected.EffectiveLife - timeBetween} days are left until expiry." +
                                $"\n Do you still want to add this asset?","Confirm Addition?",MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                            if (result == DialogResult.No)
                            {
                                break;
                            }
                        }
                    }


                    var row = new List<string>
                    {
                        partCb.SelectedItem.ToString(),
                        amountTb.Text
                    };

                    dataGridView1.Rows.Add(row.ToArray());

                    break;
                }
            }
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                var currentEmQuery = context.EmergencyMaintenances.Where(x => x.ID == _EMID).First();
                var currentPartFromCb = partCb.SelectedItem.ToString();

                //Check current part:
                var currentPartSelected = context.Parts.Where(x => x.Name.Equals(currentPartFromCb)).First();

                while (true)
                {
                    if (startDateDtp.Value < currentEmQuery.EMReportDate)
                    {
                        MessageBox.Show("Start date must be later than report date!");
                        break;
                    }

                    //Update currentEm Request:
                    if (endDateDtp.Enabled)
                    {
                        currentEmQuery.EMEndDate = endDateDtp.Value;
                    }
                    else
                    {
                        currentEmQuery.EMEndDate = null;
                    }

                    currentEmQuery.EMTechnicianNote = technicianNoteTb.Text;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        var insertChangedPart = new ChangedPart
                        {
                            EmergencyMaintenanceID = _EMID,
                            Amount = Convert.ToDecimal(amountTb.Text),
                            PartID = currentPartSelected.ID
                        };

                        context.ChangedParts.Add(insertChangedPart);
                    }

                    context.SaveChanges();
                    MessageBox.Show("Changes saved!");

                    this.Close();
                }

            }
            
        }

        private void technicianNoteTb_TextChanged(object sender, EventArgs e)
        {
            if (technicianNoteTb.Text.Equals(string.Empty))
            {
                endDateDtp.Enabled = false ;
            }
            else
            {
                endDateDtp.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns["Remove"].Index == e.ColumnIndex)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
