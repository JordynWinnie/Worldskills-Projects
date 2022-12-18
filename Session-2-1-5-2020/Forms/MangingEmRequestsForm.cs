using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session_2_1_5_2020.Forms
{
    public partial class MangingEmRequestsForm : Form
    {
        long _EMID = -1;
        public MangingEmRequestsForm()
        {
            
            InitializeComponent();
        }

        private void MangingEmRequestsForm_Load(object sender, EventArgs e)
        {
            //Load all columns:
            List<string> columns = new List<string>
            {
                "Asset SN",
                "Asset Name",
                "Request Date",
                "Employee Full Name",
                "Department",
                "EMID (DEBUG)"
            };

            foreach (var column in columns)
            {
                assetDGV.Columns.Add(column, column);
            }

            assetDGV.Columns[5].Visible = false;



            using (var context = new Session2Entities())
            {
                var requestInformation = from x in context.EmergencyMaintenances 
                                         orderby x.PriorityID descending, x.EMReportDate descending
                                         select new
                                         {
                                             AssetSN = x.Asset.AssetSN,
                                             AssetName = x.Asset.AssetName,
                                             RequestDate = x.EMReportDate,
                                             EmployeeName = x.Asset.Employee.FirstName + " " + x.Asset.Employee.LastName,
                                             Department = x.Asset.DepartmentLocation.Department.Name,
                                             x.ID
                                         };

                foreach (var request in requestInformation)
                {
                    List<string> row = new List<string>
                    {
                        request.AssetSN,
                        request.AssetName,
                        request.RequestDate.ToString(),
                        request.EmployeeName,
                        request.Department,
                        request.ID.ToString()
                    };

                    assetDGV.Rows.Add(row.ToArray());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_EMID == -1)
            {
                MessageBox.Show("Please click on an EM");
            }
            else
            {
                (new EmRequestDetailsForm(_EMID)).ShowDialog();
            }
            
        }

        private void assetDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;

            if (rowIndex >= 0)
            {
                _EMID = Convert.ToInt64(assetDGV.Rows[rowIndex].Cells[5].Value.ToString());
            }
        }
    }
}
