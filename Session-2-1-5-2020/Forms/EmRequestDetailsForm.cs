using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session_2_1_5_2020.Forms
{
    public partial class EmRequestDetailsForm : Form
    {
        long _EMID;
        public EmRequestDetailsForm(long EMID)
        {
            _EMID = EMID;
            InitializeComponent();
        }

        private void EmRequestDetailsForm_Load(object sender, EventArgs e)
        {
            

            startDateDtp.Value = DateTime.Parse("1/1/2017");
            endDateDtp.Value = DateTime.Parse("1/1/2017");
            using (var context = new Session2Entities())
            {
                //POPULATE COLUMNS:
                List<string> columns = new List<string>
                {
                    "Part Name",
                    "Amount",
                };

                foreach (var column in columns)
                {
                    dataGridView1.Columns.Add(column, column);
                }
                if (context.EmergencyMaintenances.Where(x=>x.ID == _EMID).Select(x=>x.EMEndDate).FirstOrDefault() != null)
                {
                    
                    this.Text = "EM PREVIEW";
                    startDateDtp.Value = (DateTime) context.EmergencyMaintenances.Where(x => x.ID == _EMID).Select(x => x.EMStartDate).FirstOrDefault();
                    endDateDtp.Value = (DateTime)context.EmergencyMaintenances.Where(x => x.ID == _EMID).Select(x => x.EMEndDate).FirstOrDefault();
                    technicianNoteTb.Text = context.EmergencyMaintenances.Where(x => x.ID == _EMID).Select(x => x.EMTechnicianNote).FirstOrDefault();

                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    

                    foreach (var part in context.ChangedParts.Where(x=>x.EmergencyMaintenanceID == _EMID))
                    {
                        List<string> row = new List<string>
                        {
                            part.Part.Name,
                            part.Amount.ToString()
                        };

                        dataGridView1.Rows.Add(row.ToArray());
                    }
                    submitBtn.Visible = false;
                }
                else
                {
                    assetSnLbl.Text = context.EmergencyMaintenances.Where(x => x.ID == _EMID).First().Asset.AssetSN;
                    assetNameLbl.Text = context.EmergencyMaintenances.Where(x => x.ID == _EMID).First().Asset.AssetName;
                    departmentLbl.Text = context.EmergencyMaintenances.Where(x => x.ID == _EMID).First().Asset.DepartmentLocation.Department.Name;

                    //POPULATE COMBOBOX:
                    partNameCb.Items.AddRange(context.Parts.Select(x => x.Name).ToArray());
                    partNameCb.SelectedIndex = 0;





                    DataGridViewLinkColumn dataGridViewLinkColumn = new DataGridViewLinkColumn
                    {
                        Name = "Action",
                        HeaderText = "Action",
                        UseColumnTextForLinkValue = true,
                        Text = "Remove"

                    };

                    dataGridView1.Columns.Add(dataGridViewLinkColumn);


                }
            }  
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addToListBtn_Click(object sender, EventArgs e)
        {
            //ADD ROW:

            //TODO: VALIDATION:

            while (true)
            {
                if (amountTb.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter an amount");
                    break;
                }

                try
                {
                    if (Convert.ToDecimal(amountTb.Text) <= 0)
                    {
                        MessageBox.Show("Amount must be more than 0");
                        break;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Enter valid amount");
                    break;
                }

                //CHECK FOR PART USED:
                using (var context = new Session2Entities())
                {
                    var assetId = context.EmergencyMaintenances.Where(x => x.ID == _EMID).First().Asset.ID;
                    var partIDChoose = context.Parts.Where(x => x.Name == partNameCb.SelectedItem.ToString()).Select(x => x.ID).FirstOrDefault();
                    Console.WriteLine(partIDChoose);
                    var allRelatedEMS = context.EmergencyMaintenances.Where(x => x.AssetID == assetId);

                    foreach (var item in allRelatedEMS)
                    {
                        var isUsedInPreviousEM = context.ChangedParts.Where(x => x.PartID == partIDChoose && x.EmergencyMaintenanceID == item.ID).FirstOrDefault();

                        if (isUsedInPreviousEM != null)
                        {
                            var getEMEndDate = context.EmergencyMaintenances.Where(x => x.ID == item.ID).Select(x => x.EMEndDate).First();

                            var getDaysFromLastEM = (DateTime.Today - getEMEndDate).Value.TotalDays;
                            var getShelfLife = context.Parts.Where(x => x.ID == partIDChoose).Select(x => x.EffectiveLife).FirstOrDefault();

                            if (getDaysFromLastEM < getShelfLife)
                            {
                                MessageBox.Show($"This part has been used, but shelf life has not expired. Days till expiry: {getShelfLife - getDaysFromLastEM}");
                            }
                            
                            Console.WriteLine("Is used before");
                        }
                        
                    }
                }


                List<string> row = new List<string>
                {
                    partNameCb.SelectedItem.ToString(),
                    amountTb.Text
                };

                dataGridView1.Rows.Add(row.ToArray());
                break;

            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Action"].Index)
            {
                Console.WriteLine(e.RowIndex);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                var EMToModify = context.EmergencyMaintenances.Where(x => x.ID == _EMID).Select(x => x).First(); 
                //VALIDATION:
                while (true)
                {
                    if (technicianNoteTb.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Please enter technician note");
                        break;
                    }
                    if (startDateDtp.Value == DateTime.Parse("1/1/2017"))
                    {
                        MessageBox.Show("Please enter a start date");
                        break;
                    }

                    var registrationDate = context.EmergencyMaintenances.Where(x => x.ID == _EMID).Select(x => x.EMReportDate).FirstOrDefault();

                    if (registrationDate > startDateDtp.Value)
                    {
                        MessageBox.Show("Start date must be after report date");

                        Console.WriteLine(registrationDate);
                        break;
                    }

                    EMToModify.EMStartDate = startDateDtp.Value;
                    EMToModify.EMTechnicianNote = technicianNoteTb.Text;

                    //Add Parts
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        var partNameFromRow = row.Cells[0].Value.ToString();
                        var partId = context.Parts.Where(x => x.Name.Equals(partNameFromRow)).Select(x => x.ID).FirstOrDefault();

                        var amt = Convert.ToDecimal(row.Cells[1].Value.ToString());
                        ChangedPart insertPart = new ChangedPart
                        {
                            EmergencyMaintenanceID = _EMID,
                            PartID = partId,
                            Amount = amt
                        };

                        Console.WriteLine(partId);

                        context.ChangedParts.Add(insertPart);
                    }

                    if (endDateDtp.Value == DateTime.Parse("1/1/2017"))
                    {
                        var result = MessageBox.Show("You have not added an end date, would you still like to submit?", "Warning", MessageBoxButtons.YesNo);

                        if (result == DialogResult.No)
                        {
                            break;
                        }
                        else
                        {
                            EMToModify.EMEndDate = null;
                        }
                    }
                    else
                    {
                        EMToModify.EMEndDate = endDateDtp.Value;
                    }

                    context.SaveChanges();
                    break;
                }
            }
           
        }
    }
}
