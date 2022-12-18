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
    public partial class Emergency_Maintenance_Request_Details : Form
    {
        private Session2Entities session2Entities = new Session2Entities();
        private long _emID = -1;

        public Emergency_Maintenance_Request_Details(long emID)
        {
            _emID = emID;
            InitializeComponent();
        }

        private void Emergency_Maintenance_Request_Details_Load(object sender, EventArgs e)
        {
            var columns = new List<string> { "Part Name", "Amount" };
            foreach (var column in columns)
            {
                partDGV.Columns.Add(column, column);
            }
            DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn
            {
                Text = "Remove",
                HeaderText = "Action",
                UseColumnTextForButtonValue = true
            };

            partDGV.Columns.Add(dataGridViewButtonColumn);
            var assetQuery = (from x in session2Entities.EmergencyMaintenances
                              where x.ID == _emID
                              select x).First();

            if (assetQuery.EMEndDate != null)
            {
                //Add Data:
                replacementPartGroupBox.Enabled = false;
                selectedAssetGroupBox.Enabled = false;

                startDate.Value = (DateTime)assetQuery.EMStartDate;
                endDate.Value = (DateTime)assetQuery.EMEndDate;

                foreach (var part in assetQuery.ChangedParts)
                {
                    var row = new List<string> { part.Part.Name, part.Amount.ToString() };
                    partDGV.Rows.Add(row.ToArray());
                }

                technicianNote.Text = assetQuery.EMTechnicianNote;
            }

            assetSN.Text = assetQuery.Asset.AssetSN;
            assetName.Text = assetQuery.Asset.AssetName;
            department.Text = assetQuery.Asset.DepartmentLocation.Department.Name;

            partNameCb.Items.AddRange(session2Entities.Parts.Select(x => x.Name).ToArray());
            partNameCb.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addToListBtn_Click(object sender, EventArgs e)
        {
            if (amountNUD.Value <= 0)
            {
                MessageBox.Show("Please select a value more than zero");
                return;
            }
            var assetQuery = (from x in session2Entities.EmergencyMaintenances
                              where x.ID == _emID
                              select x).First();

            var part = session2Entities.Parts.Where(x => x.Name.Equals(partNameCb.SelectedItem.ToString())).First();

            var allPastEMFromAsset = from x in session2Entities.EmergencyMaintenances
                                     where x.AssetID == assetQuery.AssetID
                                     select x;

            //Console.WriteLine(allPastEMFromAsset.Count());

            foreach (var em in allPastEMFromAsset)
            {
                if (part.ChangedParts.Where(x => x.EmergencyMaintenanceID == em.ID).Any())
                {
                    if (((DateTime)em.EMStartDate - DateTime.Today).TotalDays <= part.EffectiveLife)
                    {
                        MessageBox.Show("Used part has yet to expire");
                    }
                }
            }

            var row = new List<string> { part.Name, amountNUD.Value.ToString() };
            partDGV.Rows.Add(row.ToArray());
        }

        private void partDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                partDGV.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                var assetQuery = (from x in session2Entities.EmergencyMaintenances
                                  where x.ID == _emID
                                  select x).First();

                assetQuery.EMStartDate = startDate.Value;
                if (endDate.Checked)
                {
                    assetQuery.EMEndDate = endDate.Value;
                    assetQuery.EMTechnicianNote = technicianNote.Text;
                }

                foreach (DataGridViewRow row in partDGV.Rows)
                {
                    var partName = row.Cells[0].Value.ToString();
                    var amount = decimal.Parse(row.Cells[1].Value.ToString());
                    var partId = session2Entities.Parts.Where(x => x.Name.Equals(partName)).First().ID;
                    var changedPart = new ChangedPart
                    {
                        Amount = amount,
                        EmergencyMaintenanceID = _emID,
                        PartID = partId
                    };
                    session2Entities.ChangedParts.Add(changedPart);
                }
                session2Entities.SaveChanges();
                MessageBox.Show("Changes Saved");
            }
        }

        private bool ValidateInput()
        {
            var assetQuery = (from x in session2Entities.EmergencyMaintenances
                              where x.ID == _emID
                              select x).First();
            if (startDate.Value < assetQuery.EMReportDate)
            {
                MessageBox.Show("Cannot start request before requested date");
                return false;
            }

            if (endDate.Checked)
            {
                if (technicianNote.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Technician note cannot be empty");
                    return false;
                }
            }

            return true;
        }
    }
}