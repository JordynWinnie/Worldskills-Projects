using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session3_9_1_2020
{
    
    public partial class GuestSummary : Form
    {
        Session3Entities context = new Session3Entities();
        public GuestSummary()
        {
            InitializeComponent();
        }

        private void GuestSummary_Load(object sender, EventArgs e)
        {
            string[] guestType = {"All", "Delegates", "Competitors" };
            guestCb.Items.AddRange(guestType);
            

            RefreshChart();
            guestCb.SelectedIndex = 0;
        }

        private void RefreshChart()
        {
            chart.Series.Clear();
            var guestQuery = from x in context.Arrivals
                             group x by x.User.countryName into y
                             select y;
            switch (guestCb.SelectedIndex)
            {
                case 0:
                    chart.Series.Add("Delegates");
                    chart.Series.Add("Competitors");
                    foreach (var item in guestQuery)
                    {
                        chart.Series["Delegates"].Points.AddXY(item.Key, item.Sum(x => x.numberDelegate + x.numberHead));
                        chart.Series["Competitors"].Points.AddXY(item.Key, item.Sum(x => x.numberCompetitors));
                    }
                    break;
                case 1:
                    chart.Series.Add("Delegates");

                    foreach (var item in guestQuery)
                    {
                        chart.Series["Delegates"].Points.AddXY(item.Key, item.Sum(x => x.numberDelegate + x.numberHead));
                    }
                    break;
                case 2:
                    chart.Series.Add("Competitors");
                    foreach (var item in guestQuery)
                    {
                        chart.Series["Competitors"].Points.AddXY(item.Key, item.Sum(x => x.numberCompetitors));
                    }
                    break;
                default:
                    break;
            }
        }

        private void guestCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshChart();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
