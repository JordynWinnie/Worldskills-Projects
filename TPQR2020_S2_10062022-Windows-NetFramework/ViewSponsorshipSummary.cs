using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR2020_S2_10062022_Windows_NetFramework
{
    public partial class ViewSponsorshipSummary : Form
    {
        public ViewSponsorshipSummary()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ViewSponsorshipSummary_Load(object sender, EventArgs e)
        {
            var tierList = new List<string>
            {
                "All Tiers", "Gold", "Silver", "Bronze"
            };

            tierCb.Items.AddRange(tierList.ToArray());
            tierCb.SelectedIndex = 0;

            
            
        }

        void RefreshChart()
        {
            using (var context = new Session2Entities())
            {
                piechart.Series["Series1"].Points.Clear();
                var approvedBookings = context.Bookings.Where(x => x.status == "Approved").ToList();

                if (tierCb.SelectedItem.ToString() != "All Tiers")
                {
                    approvedBookings = approvedBookings.Where(x => x.Package.packageTier == tierCb.SelectedItem.ToString()).ToList();
                }

                var groupings = approvedBookings.GroupBy(x => x.Package.packageName);

                var total = 0L;
                foreach (var group in groupings)
                {
                    piechart.Series["Series1"].Points.AddXY(group.Key, group.Sum(x => x.quantityBooked));
                    total += group.Sum(x=>x.quantityBooked * x.Package.packageValue);
                }

                totalValueLbl.Text = total.ToString();
            }
        }

        private void tierCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshChart();
        }
    }
}
