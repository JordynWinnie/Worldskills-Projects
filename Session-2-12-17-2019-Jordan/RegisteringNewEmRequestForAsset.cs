using System;
using System.Linq;
using System.Windows.Forms;

namespace Session2__17_12_2019
{
    public partial class RegisteringNewEmRequestForAsset : Form
    {
        long _assetID = -1;
        public RegisteringNewEmRequestForAsset(long assetID)
        {
            _assetID = assetID;
            InitializeComponent();
        }

        private void RegisteringNewEmRequestForAsset_Load(object sender, EventArgs e)
        {
            
            using (var context = new Session2Entities())
            {
                //Asset SN, Asset Name, Department, Priority, 
                //Description of Emergency, Other Considerations

                var assetQuery = from x in context.Assets
                                 join y in context.DepartmentLocations on x.DepartmentLocationID equals y.ID
                                 join z in context.Departments on y.DepartmentID equals z.ID
                                 where x.ID == 2
                                 select new
                                 {
                                     x,
                                     y,
                                     z
                                 };
                                 
                foreach (var item in assetQuery)
                {
                    assetNameLbl.Text = item.x.AssetName;
                    assetSNLbl.Text = item.x.AssetSN;
                    departmentLbl.Text = item.z.Name;
                }

                var priorityQuery = from x in context.Priorities
                                    orderby x.ID
                                    select x.Name;

                foreach (var item in priorityQuery)
                {
                    priorityCb.Items.Add(item);
                }

                priorityCb.SelectedIndex = 0;
            }

            
            //MessageBox.Show(priorityCb.SelectedItem.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                string selectedItem = priorityCb.SelectedItem.ToString();
                long priorityQuery = (from x in context.Priorities
                                     where x.Name.Equals(selectedItem)
                                     select x.ID).First();


                if (descEmTb.Text.Equals(string.Empty) || otherCondTb.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Please fill in Description and Other Considerations");
                }
                else
                {
                    EmergencyMaintenance em = new EmergencyMaintenance
                    {
                        AssetID = _assetID,
                        PriorityID = priorityQuery,
                        DescriptionEmergency = descEmTb.Text,
                        OtherConsiderations = otherCondTb.Text,
                        EMReportDate = DateTime.Now,
                        EMStartDate = null,
                        EMEndDate = null,
                        EMTechnicianNote = null
                    };

                    try
                    {
                        context.EmergencyMaintenances.Add(em);

                        context.SaveChanges();

                        MessageBox.Show("Changes saved successfully");
                        this.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("An error occurred while saving. Details:\n" + ex.Message);
                    }
                }
               
            }
        }
    }
}
