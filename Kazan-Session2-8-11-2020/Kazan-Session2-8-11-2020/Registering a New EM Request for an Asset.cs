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
    public partial class Registering_a_New_EM_Request_for_an_Asset : Form
    {
        private Session2Entities session2Entities = new Session2Entities();
        private long _assetID;

        public Registering_a_New_EM_Request_for_an_Asset(long assetID)
        {
            _assetID = assetID;
            InitializeComponent();
        }

        private void Registering_a_New_EM_Request_for_an_Asset_Load(object sender, EventArgs e)
        {
            var assetQuery = (from x in session2Entities.Assets
                              where x.ID == _assetID
                              select x).First();

            assetSN.Text = assetQuery.AssetSN;
            assetName.Text = assetQuery.AssetName;
            department.Text = assetQuery.DepartmentLocation.Department.Name;

            priorityCb.Items.AddRange(session2Entities.Priorities.Select(x => x.Name).ToArray());
            priorityCb.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var asset = session2Entities.Assets.Where(x => x.ID == _assetID).First();
            var priID = session2Entities.Priorities.Where(x => x.Name.Equals(priorityCb.SelectedItem.ToString())).Select(x => x.ID).FirstOrDefault();
            var newEmergengy = new EmergencyMaintenance
            {
                AssetID = _assetID,
                PriorityID = priID,
                DescriptionEmergency = desEM.Text,
                OtherConsiderations = otherCondEm.Text,
                EMReportDate = DateTime.Today,
                EMStartDate = null,
                EMEndDate = null,
                EMTechnicianNote = null
            };

            if (asset.EmergencyMaintenances.Count != 0 && asset.EmergencyMaintenances.Where(x => x.EMEndDate == null).Any())
            {
                MessageBox.Show("Asset Currently has an open request, cannot request again");
                return;
            }

            session2Entities.EmergencyMaintenances.Add(newEmergengy);
            session2Entities.SaveChanges();

            MessageBox.Show("Changes Saved");
            Close();
        }
    }
}