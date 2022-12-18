using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace Session_2_1_5_2020.Forms
{
    public partial class AccountablePartyForm : Form
    {
        long _employeeId;
        long _assetIdToSendOver;
        bool _allowSendOver = false;
        public AccountablePartyForm(long employeeID)
        {
            _employeeId = employeeID;
            InitializeComponent();
        }

        private void AccountablePartyForm_Load(object sender, EventArgs e)
        {
            //Populates all the columns
            List<string> columns = new List<string>
                {
                    "Asset SN",
                    "Asset Name",
                    "Last Closed EM",
                    "Number of EMs",
                    "ASSETID (DEBUG)",
                    "To be Highlighted (DEBUG)"
                };

            foreach (var column in columns)
            {
                assetDGV.Columns.Add(column, column);
            }

            assetDGV.Columns[4].Visible = false;
            assetDGV.Columns[5].Visible = false;

            RefreshGrid();
        }

        void RefreshGrid()
        {
            using (var context = new Session2Entities())
            {
                assetDGV.Rows.Clear();
                

                var rowDetails = from x in context.Assets
                                 where x.EmployeeID == _employeeId
                                 select new
                                 {
                                     AssetSN = x.AssetSN,
                                     AssetName = x.AssetName,
                                     LastClosed = x.EmergencyMaintenances.Where(y => y.AssetID == x.ID).OrderByDescending(y => y.EMEndDate).Select(y => y.EMEndDate),
                                     NumberOfEM = x.EmergencyMaintenances.Where(y => y.AssetID == x.ID).Count(),
                                     AssetId = x.ID
                                 };

                foreach (var item in rowDetails)
                {
                    List<string> row = new List<string>
                    {
                        item.AssetSN,
                        item.AssetName,
                        item.LastClosed.FirstOrDefault().ToString(),
                        item.NumberOfEM.ToString(),
                        item.AssetId.ToString()
                    };

                    var hasARequest = context.EmergencyMaintenances.Where(x => x.AssetID == item.AssetId).Select(x => x.EMEndDate).FirstOrDefault();
                    var isInEM = context.EmergencyMaintenances.Where(x => x.AssetID == item.AssetId).Count();
                    if (hasARequest == null && isInEM != 0)
                    {
                        row.Add("TRUE");
                    }
                    else
                    {
                        row.Add("FALSE");
                    }
                    assetDGV.Rows.Add(row.ToArray());
                }

                foreach (DataGridViewRow row in assetDGV.Rows)
                {
                    if (row.Cells[5].Value.ToString().Equals("TRUE"))
                    {
                        row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                    }
                }


            }
        }

        private void assetDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;

            if (rowIndex >= 0)
            {
                _assetIdToSendOver = Convert.ToInt64(assetDGV.Rows[rowIndex].Cells[4].Value.ToString());
                if (assetDGV.Rows[rowIndex].Cells[5].Value.ToString().Equals("TRUE"))
                {
                    _allowSendOver = false;
                }
                else
                {
                    _allowSendOver = true;
                }
                Console.WriteLine(_assetIdToSendOver);
                Console.WriteLine(_allowSendOver);
            }
        }

        private void emReqBtn_Click(object sender, EventArgs e)
        {
            if (_allowSendOver)
            {
                (new RegisteringNewEmRequestForm(_assetIdToSendOver)).ShowDialog();
                RefreshGrid();
            }
        }
    }
}
