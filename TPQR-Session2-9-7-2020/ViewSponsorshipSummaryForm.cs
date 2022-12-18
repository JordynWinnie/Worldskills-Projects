using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session2_9_7_2020
{
    public partial class ViewSponsorshipSummaryForm : Form
    {
        private Session2Entities context = new Session2Entities();

        public ViewSponsorshipSummaryForm()
        {
            InitializeComponent();
        }

        private void ViewSponsorshipSummaryForm_Load(object sender, EventArgs e)
        {
            tierCb.Items.Add("All");
            tierCb.Items.AddRange(context.Packages.Select(x => x.packageTier).Distinct().ToArray());
            tierCb.SelectedIndex = 0;

            UpdateTable();
        }

        private void UpdateTable()
        {
            pieChart.Series[0].Points.Clear();
            var selectedTier = tierCb.SelectedItem.ToString();
            var chartQuery = from x in context.Bookings
                             where x.status == "Approved"
                             select x;

            if (!selectedTier.Equals("All"))
            {
                chartQuery = chartQuery.Where(x => x.Package.packageTier == selectedTier);
            }

            var finalQuery = from x in chartQuery
                             group x by x.Package.packageName into y
                             select y;

            long totalVal = 0;
            foreach (var item in finalQuery)
            {
                var idx = pieChart.Series[0].Points.AddY(item.Sum(x => x.quantityBooked));
                pieChart.Series[0].Points[idx].Label = item.Key;

                totalVal += item.Sum(x => x.Package.packageValue);
            }

            totalValue.Text = $"Total Value: ${totalVal}";
        }

        private void tierCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}