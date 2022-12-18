using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSC2019Kazan_S5_05202022_Windows
{
    public partial class RegisteringNewEMRequest : Form
    {
        private Asset currentAsset;
        private Dictionary<string, Priority> prioritiesDict;

        public RegisteringNewEMRequest(Asset? asset)
        {
            currentAsset = asset;
            InitializeComponent();
        }

        private void RegisteringNewEMRequest_Load(object sender, EventArgs e)
        {
            using (var context = new Session2Context())
            {
                var assetDepartment = context.DepartmentLocations.Where(x=>x.Id == currentAsset.DepartmentLocationId).First();
                var department = context.Departments.Where(x=>x.Id == assetDepartment.DepartmentId).First();
                assetLbl.Text = currentAsset.AssetName;
                assetSNLbl.Text = currentAsset.AssetSn;
                departmentName.Text = department.Name;

                prioritiesDict = context.Priorities.ToDictionary(x=>x.Name);
                priorityCb.Items.AddRange(prioritiesDict.Keys.ToArray());
                priorityCb.SelectedIndex = 0;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Context())
            {
                if (context.EmergencyMaintenances.Where(x=>x.AssetId == currentAsset.Id && x.EmendDate == null).Any())
                {
                    MessageBox.Show("Emergency Request could not be sent; there is an on-going request already");
                    return;
                }
                var newEmRequest = new EmergencyMaintenance
                {
                    AssetId = currentAsset.Id,
                    OtherConsiderations = otherConsiderationsTB.Text,
                    DescriptionEmergency = descriptionTb.Text,
                    PriorityId = prioritiesDict[priorityCb.SelectedItem.ToString()].Id,
                    EmreportDate = DateTime.Now,
                    EmstartDate = null,
                    EmendDate = null
                };

                context.EmergencyMaintenances.Add(newEmRequest);
                context.SaveChanges();
            }
            Close();
        }
    }
}
