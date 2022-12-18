using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kazan_Session2_8_11_2020
{
    public partial class Managing_EM_Requests_by_Maintenance_Manager : Form
    {
        private Session2Entities session2Entities = new Session2Entities();
        private long _emID = -1;

        public Managing_EM_Requests_by_Maintenance_Manager()
        {
            InitializeComponent();
        }

        private void Managing_EM_Requests_by_Maintenance_Manager_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Asset SN", "Asset Name", "Request Date", "Employee Full Name", "Department", "reqID"
            };

            foreach (var column in columns)
            {
                assetDGV.Columns.Add(column, column);
            }

            var emRequestQuery = (from x in session2Entities.EmergencyMaintenances
                                  orderby x.PriorityID descending, x.EMEndDate descending
                                  select x);

            foreach (var emRequest in emRequestQuery)
            {
                var row = new List<string>
                {
                    emRequest.Asset.AssetSN, emRequest.Asset.AssetName, emRequest.EMReportDate.ToShortDateString(),
                    emRequest.Asset.Employee.FirstName + " " + emRequest.Asset.Employee.LastName,
                    emRequest.Asset.DepartmentLocation.Department.Name,
                    emRequest.ID.ToString()
                };

                assetDGV.Rows.Add(row.ToArray());
            }

            assetDGV.Columns[5].Visible = false;
        }

        private void assetDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _emID = long.Parse(assetDGV[5, e.RowIndex].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_emID == -1)
            {
                MessageBox.Show("Please select an item");
            }
            else
            {
                Hide();
                (new Emergency_Maintenance_Request_Details(_emID)).ShowDialog();
                Show();
            }
        }
    }
}