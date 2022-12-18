using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSC2019Kazan_S5_05202022_Windows
{
    public partial class ManagingEMRequestsAccountableParty : Form
    {
        private Asset? currentSelectedAsset = null;
        private List<Asset> assetList;
        public ManagingEMRequestsAccountableParty()
        {
            InitializeComponent();
        }

        private void ManagingEMRequestsAccountableParty_Load(object sender, EventArgs e)
        {
            var columns = new List<string>()
            {
                "Asset SN", 
                "Asset Name", 
                "Last Closed EM",
                "Number of EMs"
            };

            columns.ForEach(x=> mainDGV.Columns.Add(x,x));
            
            RefreshList();
        }

        void RefreshList()
        {
            mainDGV.Rows.Clear();
            using (var context = new Session2Context())
            {
                assetList = context.Assets.ToList();
                var data = context.EmergencyMaintenances.AsEnumerable().GroupBy(x => x.AssetId);

                foreach (var asset in data)
                {
                    var assetInfo = context.Assets.Where(x => x.Id == asset.Key).First();
                    var numberOfEms = asset.Where(x => x.EmendDate != null).Count();
                    var openRequest = asset.Where(x => x.EmendDate == null).Any();
                    var lastClosedEm = asset.OrderByDescending(x => x.EmendDate).FirstOrDefault();
                    var row = new string[]
                    {
                        assetInfo.AssetSn,
                        assetInfo.AssetName,
                        lastClosedEm?.EmendDate is null ? "--" : lastClosedEm.EmendDate.Value.ToShortDateString(),
                        numberOfEms.ToString()
                    };

                    var idx = mainDGV.Rows.Add(row);
                    if (openRequest) mainDGV.Rows[idx].DefaultCellStyle.BackColor = Color.HotPink;
                }
            }
        }

        private void mainDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var cellName = mainDGV[0, e.RowIndex].Value.ToString();
            currentSelectedAsset = assetList.Where(x=>x.AssetSn == cellName).First();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var newForm = new RegisteringNewEMRequest(currentSelectedAsset!);
            newForm.ShowDialog();
            RefreshList();
            Show();
        }
    }
}
