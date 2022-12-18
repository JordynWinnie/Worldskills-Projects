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
    public partial class FormRegisteringNewEMRequestAsset : Form
    {
        long _assetID = -1;
        public FormRegisteringNewEMRequestAsset(long assetID)
        {
            _assetID = assetID;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRegisteringNewEMRequestAsset_Load(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                var assetQuery = context.Assets.Where(x => x.ID == _assetID).First();

                assetNameLbl.Text = assetQuery.AssetName;
                assetSNLbl.Text = assetQuery.AssetSN;
                departmentLbl.Text = assetQuery.DepartmentLocation.Department.Name;

                priorityCB.Items.AddRange(context.Priorities.Select(x => x.Name).ToArray());
                priorityCB.SelectedIndex = 0;
            }


        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {

                while (true)
                {
                    if (emergencyDesTb.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Please fill up emergency description");
                        break;
                    }
                    if (otherConsiderationsTB.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Please fill up other considerations");
                        break;
                    }


                    var assetQuery = context.Assets.Where(x => x.ID == _assetID).First();
                    var priorityInCb = priorityCB.SelectedItem.ToString();
                    var priorityQuery = context.Priorities.Where(x => x.Name.Equals(priorityInCb)).Select(x => x.ID).FirstOrDefault();
                    var insertRequest = new EmergencyMaintenance
                    {
                        AssetID = assetQuery.ID,
                        PriorityID = priorityQuery,
                        DescriptionEmergency = emergencyDesTb.Text,
                        OtherConsiderations = otherConsiderationsTB.Text,
                        EMStartDate = null,
                        EMReportDate = DateTime.Now,
                        EMEndDate = null,
                        EMTechnicianNote = null
                    };

                    try
                    {
                        context.EmergencyMaintenances.Add(insertRequest);
                        context.SaveChanges();
                        MessageBox.Show("Changes Saved!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving changes. Details:\n" + ex.Message);
                    }
                    break;
                }

                
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
