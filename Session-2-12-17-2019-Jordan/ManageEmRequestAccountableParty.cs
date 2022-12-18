using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Session2__17_12_2019
{
    public partial class ManageEmRequestAccountableParty : Form
    {
        long _employeeID = 8;
        long _selectedAssetID = -1;
        bool _isAllowedToModify = false;
        bool _isAdmin = false;
        public ManageEmRequestAccountableParty(long employeeID)
        {
            _employeeID = employeeID;
            InitializeComponent();
        }

        private void ManageEmRequestAccountableParty_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        void RefreshGrid()
        {
            //Requirements:
            //Asset SN, Asset Name, Last Closed EM, Number of EMs

            using (var context = new Session2Entities())
            {
                var isAdminQuery = context.Employees.Where(x => x.ID == _employeeID).Select(x => x.isAdmin).First();

                if (isAdminQuery == true)
                {
                    this.Text = "Emergency Maintence Management (ADMIN)";
                    _isAdmin = true;
                    label1.Text = "List of Assets Requesting EM";
                    sendToEmBtn.Text = "Manage Request";

                    //Asset Sn, AssetName, Report Date, Employee Fullname, Department
                    List<string> columnNames = new List<string>
                {
                    "Asset SN",
                    "Asset Name",
                    "Report Date",
                    "Employee Full Name",
                    "Department",
                    "EMid (DEBUG)"
                };

                    

                    foreach (var col in columnNames)
                    {
                        assetDGV.Columns.Add(col, col);
                    }

                    var adminAssetListQuery = (from x in context.EmergencyMaintenances
                                               join y in context.Assets on x.AssetID equals y.ID
                                               join z in context.Employees on y.EmployeeID equals z.ID
                                               join a in context.DepartmentLocations on y.DepartmentLocationID equals a.ID
                                               join b in context.Departments on a.DepartmentID equals b.ID

                                               select new { x, y, z, b }).OrderByDescending(x => x.x.PriorityID)
                                              .ThenByDescending(x => x.x.EMReportDate);

                    //Checks if employee currently has any assets under him, if not, close app
                    if (!adminAssetListQuery.Any())
                    {
                        MessageBox.Show("Sorry, you do not currently manage any assets under the company. The Application will now close");
                        this.Close();
                    }

                    foreach (var asset in adminAssetListQuery)
                    {
                        List<string> rows = new List<string>
                        {
                            asset.y.AssetSN,
                            asset.y.AssetName,
                            asset.x.EMReportDate.ToString(),
                            asset.z.FirstName + " " + asset.z.LastName,
                            asset.b.Name,
                            asset.x.ID.ToString()
                        };

                        assetDGV.Rows.Add(rows.ToArray());
                    }
                }
                else
                {
                    this.Text = "Emergency Maintence Management";
                    var assetListQuery = from x in context.Assets
                                         orderby x.ID
                                         where x.EmployeeID == _employeeID
                                         select x;

                    //Checks if employee currently has any assets under him, if not, close app
                    if (!assetListQuery.Any())
                    {
                        MessageBox.Show("Sorry, you do not currently manage any assets under the company. The Application will now close");
                        this.Close();
                    }

                    List<string> columnNames = new List<string>
                {
                    "Asset SN",
                    "Asset Name",
                    "Last Closed EM",
                    "Number of EMs",
                    "isHighLighted? (DEBUG)",
                    "AssetID(DEBUG)"
                };
                    foreach (var col in columnNames)
                    {
                        assetDGV.Columns.Add(col, col);
                    }
                    assetDGV.Columns[4].Visible = false;
                    assetDGV.Columns[5].Visible = false;

                    //Updating the rows based on conditions
                    foreach (var asset in assetListQuery)
                    {
                        List<string> rows = new List<string>
                    {
                        asset.AssetSN,
                        asset.AssetName,
                    };

                        var lastClosedEMDate = context.EmergencyMaintenances.
                            Where(x => x.AssetID == asset.ID && x.EMEndDate != null)
                            .OrderByDescending(x => x.EMEndDate)
                            .Select(x => x.EMEndDate).FirstOrDefault();

                        if (lastClosedEMDate == null)
                        {
                            rows.Add("-");
                        }
                        else
                        {
                            rows.Add(lastClosedEMDate.ToString());
                        }

                        var numberOfEMs = context.EmergencyMaintenances.
                            Where(x => x.AssetID == asset.ID && x.EMEndDate == null)
                            .Select(x => x).Count();

                        rows.Add(numberOfEMs.ToString());

                        var openRequests = context.EmergencyMaintenances.
                            Where(x => x.AssetID == asset.ID && x.EMEndDate == null)
                            .Select(x => x).FirstOrDefault();

                        if (openRequests == null)
                        {
                            rows.Add("FALSE");
                        }
                        else
                        {
                            rows.Add("TRUE");
                        }

                        rows.Add(asset.ID.ToString());
                        assetDGV.Rows.Add(rows.ToArray());
                    }

                    foreach (DataGridViewRow row in assetDGV.Rows)
                    {
                        if (row.Cells[4].Value.Equals("TRUE"))
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }

                    }




                }
            }
        }

        private void sendToEmBtn_Click(object sender, EventArgs e)
        {
            if (_isAdmin)
            {
                (new EmergencyRequestDetails(_selectedAssetID)).ShowDialog();
            }
            else
            {
                if (_isAllowedToModify)
                {
                    (new RegisteringNewEmRequestForAsset(_selectedAssetID)).ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sorry, you are not allowed to modify an EM with an open request");
                }
            }

        }

        private void assetDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            if (_isAdmin)
            {
                if (rowIndex >= 0)
                {
                    _selectedAssetID = Convert.ToInt64(assetDGV.Rows[rowIndex].Cells[5].Value.ToString());
                }
                else
                {
                    if (rowIndex >= 0)
                    {
                        _selectedAssetID = Convert.ToInt64(assetDGV.Rows[rowIndex].Cells[5].Value.ToString());
                        if (assetDGV.Rows[rowIndex].Cells[4].Value.ToString().Equals("TRUE"))
                        {
                            _isAllowedToModify = false;
                        }
                        else
                        {
                            _isAllowedToModify = true;
                        }
                    }
                }

            }
        }
    }
}
