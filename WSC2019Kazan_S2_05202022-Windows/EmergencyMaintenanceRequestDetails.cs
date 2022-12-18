using System.Data;
using System.Diagnostics;

namespace WSC2019Kazan_S5_05202022_Windows
{
    public partial class EmergencyMaintenanceRequestDetails : Form
    {
        private Asset currentAsset;
        private EmergencyMaintenance currentEmergency;
        private Dictionary<string, Part> parts;
        private List<Part> partList = new List<Part>();
        public EmergencyMaintenanceRequestDetails(Asset asset, EmergencyMaintenance em)
        {
            InitializeComponent();
            currentEmergency = em;
            currentAsset = asset;
        }

        private void EmergencyMaintenanceRequestDetails_Load(object sender, EventArgs e)
        {
            assetSNLbl.Text = currentAsset.AssetSn;
            assetLbl.Text = currentAsset.AssetName;
            var columns = new List<string>()
            {
                "Part Name",
                "Amount",
            };
            columns.ForEach(x => partsDGV.Columns.Add(x,x));

            partsDGV.Columns.Add(new DataGridViewLinkColumn
            {
                UseColumnTextForLinkValue = true,
                HeaderText = "Action",
                Text = "Remove",  
            });


            using (var context = new Session2Context())
            {
                var departmentId = context.DepartmentLocations.Where(x=>x.Id == currentAsset.DepartmentLocationId).First();
                var department = context.Departments.Where(x => x.Id == departmentId.DepartmentId).First();

                departmentName.Text = department.Name;

                parts = context.Parts.ToDictionary(x=>x.Name);

                partsCb.Items.AddRange(parts.Keys.ToArray());
                partsCb.SelectedIndex = 0;
                technicianNoteTb.Text = currentEmergency.EmtechnicianNote;
                var currentEmergencies = context.ChangedParts.Where(x=>x.EmergencyMaintenanceId == currentEmergency.Id).ToList();

                foreach (var item in currentEmergencies)
                {
                    var partName = context.Parts.Where(x=>x.Id == item.PartId).First();
                    partsDGV.Rows.Add(partName.Name, item.Amount.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedPart = parts[partsCb.SelectedItem.ToString()!];
            using (var context = new Session2Context())
            {
                var changedPart = context.ChangedParts.Where(x=>x.PartId == selectedPart.Id).ToList();

                foreach (var part in changedPart)
                {
                    Debug.Print(part.EmergencyMaintenanceId.ToString());
                    Debug.Print(currentAsset.Id.ToString());
                    
                    var emergencyFromPart = 
                        context.EmergencyMaintenances
                            .Where(x=>x.Id == part.EmergencyMaintenanceId && x.AssetId == currentAsset.Id)
                            .FirstOrDefault();

                    if (emergencyFromPart != null)
                    {
                        var daysBetween = (DateTime.Now - emergencyFromPart.EmendDate)!.Value.TotalDays;
                        if (daysBetween > selectedPart.EffectiveLife)
                        {
                            MessageBox.Show("Service life for this part has not expired as part of another request");
                        }
                    }
                    
                }
            }
            foreach (DataGridViewRow item in partsDGV.Rows)
            {
                var name = item.Cells[0].Value.ToString();

                if (name == selectedPart.Name) 
                {
                    MessageBox.Show("Cannot duplicate parts");
                    return;
                }
            }
            
            partsDGV.Rows.Add(selectedPart.Name, numberToAdd.Value.ToString());

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (startDateCb.Value < currentEmergency.EmreportDate)
            {
                MessageBox.Show("Start date cannot be before report date");
                return;
            }

            if (endDateCb.Checked && technicianNoteTb.Text == string.Empty)
            {
                MessageBox.Show("Technician note required since end date is provided");
                return;
            }

            using (var context = new Session2Context())
            {
                var emergencyToModify = context.EmergencyMaintenances.Where(x=>x.Id == currentEmergency.Id).First();

                emergencyToModify.EmtechnicianNote = technicianNoteTb.Text;
                emergencyToModify.EmstartDate = startDateCb.Value;
                if (endDateCb.Checked)
                {
                    emergencyToModify.EmendDate = endDateCb.Value;
                }

                var allParts = context.ChangedParts.Where(x=>x.EmergencyMaintenanceId == currentEmergency.Id).ToList();

                foreach (var part in allParts)
                {
                    context.ChangedParts.Remove(part);
                }

                foreach (DataGridViewRow row in partsDGV.Rows)
                {
                    var part = parts[row.Cells[0].Value.ToString()];
                    var amount = decimal.Parse(row.Cells[1].Value.ToString());
                    var newAddedPart = new ChangedPart
                    {
                        PartId = part.Id,
                        EmergencyMaintenanceId = currentEmergency.Id,
                        Amount = amount
                    };

                    context.ChangedParts.Add(newAddedPart); 
                }
                context.SaveChanges();
            }

            Close();
            
        }

        private void partsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2) return;
            partsDGV.Rows.RemoveAt(e.RowIndex);
            //RefreshList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
