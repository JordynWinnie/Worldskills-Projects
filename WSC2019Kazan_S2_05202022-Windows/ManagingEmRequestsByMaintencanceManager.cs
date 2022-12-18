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
    public partial class ManagingEmRequestsByMaintencanceManager : Form
    {
        private Asset? currentSelectedAsset = null;
        private EmergencyMaintenance? currentEmergencyMaintenance = null;
        private List<Asset> assetList;
        private List<EmergencyMaintenance> emergencyList;

        public ManagingEmRequestsByMaintencanceManager()
        {
            InitializeComponent();
        }

        private void ManagingEmRequestsByMaintencanceManager_Load(object sender, EventArgs e)
        {
            using (var context = new Session2Context())
            {
                assetList = context.Assets.ToList();
                var columns = new List<string>
                {
                    "Asset SN",
                    "Asset Name",
                    "Request Date",
                    "Employee Full Name",
                    "Department",
                    "id"
                };
                
                columns.ForEach(x => mainDGV.Columns.Add(x,x));
                mainDGV.Columns[5].Visible = false;
                RefreshList();
            }
        }

        void RefreshList()
        {
            using (var context = new Session2Context())
            {
                mainDGV.Rows.Clear();
                emergencyList = context.EmergencyMaintenances
                   .Where(x => x.EmendDate == null)
                   .OrderByDescending(x => x.Priority)
                   .ThenByDescending(x => x.EmreportDate)
                   .ToList();

                foreach (var emRequest in emergencyList)
                {
                    var asset = context.Assets.Where(x => x.Id == emRequest.AssetId).FirstOrDefault();
                    var employee = context.Employees.Where(x => x.Id == asset.EmployeeId).FirstOrDefault();
                    var departmentId = context.DepartmentLocations.Where(x => x.Id == asset.DepartmentLocationId).First().DepartmentId;
                    var department = context.Departments.Where(x => x.Id == departmentId).FirstOrDefault();

                    var row = new List<string>
                    {
                        asset.AssetSn,
                        asset.AssetName,
                        emRequest.EmreportDate.ToShortDateString(),
                        $"{employee.FirstName} {employee.LastName}",
                        department.Name,
                        emRequest.Id.ToString(),
                    };

                    mainDGV.Rows.Add(row.ToArray());
                }

            }
        }
        private void mainDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var cellName = mainDGV[0, e.RowIndex].Value.ToString();
            var emID = int.Parse(mainDGV[5, e.RowIndex].Value.ToString());
            currentSelectedAsset = assetList.Where(x => x.AssetSn == cellName).First();
            currentEmergencyMaintenance = emergencyList.Where(x=>x.Id == emID).First();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newForm = new EmergencyMaintenanceRequestDetails(currentSelectedAsset, currentEmergencyMaintenance);
            Hide();
            newForm.ShowDialog();
            RefreshList();
            Show();
        }
    }
}
