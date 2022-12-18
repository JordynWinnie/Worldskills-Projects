using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session3_9_8_2020
{
    public partial class GuestsSummaryForm : Form
    {
        private Session3Entities context = new Session3Entities();

        public GuestsSummaryForm()
        {
            InitializeComponent();
        }

        private void GuestsSummaryForm_Load(object sender, EventArgs e)
        {
            guestCb.Items.Add("All");
            guestCb.Items.Add("Delegates");
            guestCb.Items.Add("Competitors");

            guestCb.SelectedIndex = 0;
            UpdateChart();
        }

        private void UpdateChart()
        {
            chart.Series.Clear();
            var arrivalQuery = from x in context.Arrivals
                               group x by x.User.countryName into y
                               select y;

            switch (guestCb.SelectedItem.ToString())
            {
                case "All":
                    chart.Series.Add("Delegates");
                    chart.Series.Add("Competitors");

                    foreach (var arrival in arrivalQuery)
                    {
                        chart.Series["Competitors"].Points.AddXY(arrival.Key, arrival.Sum(x => x.numberCompetitors));
                        chart.Series["Delegates"].Points.AddXY(arrival.Key, arrival.Sum(x => x.numberHead + x.numberDelegate));
                    }
                    break;

                case "Delegates":
                    chart.Series.Add("Delegates");

                    foreach (var arrival in arrivalQuery)
                    {
                        chart.Series["Delegates"].Points.AddXY(arrival.Key, arrival.Sum(x => x.numberHead + x.numberDelegate));
                    }
                    break;

                case "Competitors":

                    chart.Series.Add("Competitors");

                    foreach (var arrival in arrivalQuery)
                    {
                        chart.Series["Competitors"].Points.AddXY(arrival.Key, arrival.Sum(x => x.numberCompetitors));
                    }
                    break;

                default:
                    break;
            }
        }

        private void guestCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}