using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session_2_1_5_2020.Forms
{
    public partial class RegisteringNewEmRequestForm : Form
    {
        long _assetId;
        public RegisteringNewEmRequestForm(long assetId)
        {
            _assetId = assetId;
            InitializeComponent();
        }

        private void RegisteringNewEmRequestForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                //ASSET SN, Asset Name, Department
                lblAssetSN.Text = context.Assets.Where(x => x.ID == _assetId).Select(x => x.AssetSN).FirstOrDefault();
                lblAssetName.Text = context.Assets.Where(x => x.ID == _assetId).Select(x => x.AssetName).FirstOrDefault();
                lblDepartment.Text = context.Assets.Where(x => x.ID == _assetId).First().DepartmentLocation.Department.Name;

                //Populating Priorities:
                //var priorities = context.Priorities.Select(x => x.Name).ToArray();

                PriorityCb.Items.AddRange(context.Priorities.Select(x => x.Name).ToArray());
                PriorityCb.SelectedIndex = 0;
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {

                if (!(DescriptionOfEMTb.Text.Equals(string.Empty) && OtherConsiderationsTb.Text.Equals(string.Empty)))
                {
                    EmergencyMaintenance insertEm = new EmergencyMaintenance();

                    //Get Priority ID: 
                    var priorityID = context.Priorities.Where(x => x.Name.Equals(PriorityCb.SelectedItem.ToString())).Select(x => x.ID).First();
                    Console.WriteLine(priorityID);

                    insertEm.AssetID = _assetId;
                    insertEm.PriorityID = priorityID;
                    insertEm.DescriptionEmergency = DescriptionOfEMTb.Text;
                    insertEm.OtherConsiderations = OtherConsiderationsTb.Text;
                    insertEm.EMReportDate = DateTime.Now;
                    insertEm.EMStartDate = DateTime.Now;

                    context.EmergencyMaintenances.Add(insertEm);

                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Changes saved. c:", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving. Details: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill up all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
            
        }
    }
}
