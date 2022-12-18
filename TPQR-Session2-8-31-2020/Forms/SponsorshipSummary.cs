using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session2_8_31_2020
{
    public partial class SponsorshipSummary : Form
    {
        private Session2Entities context = new Session2Entities();

        public SponsorshipSummary()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SponsorshipSummary_Load(object sender, EventArgs e)
        {
            string[] tierList = { "All Tiers", "Gold", "Silver", "Bronze" };
            tierCb.Items.AddRange(tierList);
            tierCb.SelectedIndex = 0;
            RefreshChart();
        }

        private void RefreshChart()
        {
            chartSummary.Series[0].Points.Clear();
            var tier = tierCb.SelectedItem.ToString();
            var packages = from x in context.Bookings
                           where x.status == "Approved"
                           select x;
            if (!tier.Equals("All Tiers"))
            {
                packages = packages.Where(x => x.Package.packageTier == tier);
            }

            var finalPackagesQuery = from x in packages
                                     group x by x.Package.packageName into y
                                     select y;
            long total = 0;
            foreach (var package in finalPackagesQuery)
            {
                Console.WriteLine(package.Key);

                Console.WriteLine("\t" + package.Sum(x => x.quantityBooked));

                chartSummary.Series[0].Points.AddXY(package.Key, package.Sum(x => x.quantityBooked));

                total += package.Sum(x => x.quantityBooked * x.Package.packageValue);
            }

            totalValue.Text = $"${total}";
        }

        private void tierCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshChart();
        }
    }
}