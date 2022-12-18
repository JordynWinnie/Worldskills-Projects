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
    public partial class FormManagingEMRequestsMaintenanceManager : Form
    {
        long _employeeID = -1;
        long _assetID = -1;
        long _EMID = -1;
        public FormManagingEMRequestsMaintenanceManager(long employeeID)
        {
            _employeeID = employeeID;
            InitializeComponent();
        }

        private void FormManagingEMRequestsMaintenanceManager_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Asset SN",
                "Asset Name",
                "Request Date",
                "Employee Full Name",
                "Department",
                "AssetID (DEBUG)",
                "EMID (DEBUG)"
            };

            foreach (var column in columns)
            {
                dataGridView1.Columns.Add(column, column);
            }

            using (var context = new Session2Entities())
            {
                var EMRequestQuery = (from x in context.EmergencyMaintenances 
                                      where x.EMEndDate == null
                                     select x).OrderBy(x=>x.PriorityID).ThenByDescending(x=>x.EMReportDate);

                foreach (var request in EMRequestQuery)
                {
                    var row = new List<string>();

                    row.Add(request.Asset.AssetSN);
                    row.Add(request.Asset.AssetName);
                    row.Add(request.EMReportDate.ToString());
                    row.Add($"{request.Asset.Employee.FirstName} {request.Asset.Employee.LastName}");
                    row.Add(request.Asset.DepartmentLocation.Department.Name);
                    row.Add(request.AssetID.ToString());
                    row.Add(request.ID.ToString());
                    dataGridView1.Rows.Add(row.ToArray());
                }


            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _assetID = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            _EMID = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
        }

        private void manageRequestBtn_Click(object sender, EventArgs e)
        {
            if (_assetID == -1 || _EMID == -1)
            {
                MessageBox.Show("Please select an asset");
            }
            else
            {
                (new FormEmergencyMaintenanceRequestDetails(_assetID, _EMID)).ShowDialog();
            }
        }
    }
}
