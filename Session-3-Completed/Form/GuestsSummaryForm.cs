using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session3_Jordan_Khong
{
    public partial class GuestsSummaryForm : Form
    {
        public GuestsSummaryForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = DateTime.Now.ToString();
        }

        private void GuestsSummaryForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                //Prepopulates the list with pre-entered values:
                guestsComboBox.Items.Add("All guests");
                guestsComboBox.SelectedIndex = 0;

                guestsComboBox.Items.Add("Competitors");
                guestsComboBox.Items.Add("Delegates");
            }
        }

        private void guestsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                //Generic query to group all countries together:
                var guestQuery = from x in context.Arrivals
                                 orderby x.User.countryName
                                 group x by x.User.countryName into y
                                 select new
                                 {
                                     y.Key,
                                     NumberOfDelegates = y.Sum(x => x.numberDelegate + x.numberHead),
                                     NumberOfCompetitors = y.Sum(x => x.numberCompetitors)
                                 };

                guestSummaryChart.Series.Clear();

                //Checks which item is selected:
                if (guestsComboBox.SelectedItem.Equals("All guests"))
                {
                    #region Chart Population, Delegates and Competitors
                    guestSummaryChart.Series.Add("Delegates");
                    guestSummaryChart.Series.Add("Competitors");

                    guestSummaryChart.Series["Delegates"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                    guestSummaryChart.Series["Competitors"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;

                    guestSummaryChart.Series["Delegates"].IsValueShownAsLabel = true;
                    guestSummaryChart.Series["Competitors"].IsValueShownAsLabel = true;

                    foreach (var country in guestQuery)
                    {
                        guestSummaryChart.Series["Delegates"].Points.AddXY(country.Key, country.NumberOfDelegates);
                        guestSummaryChart.Series["Competitors"].Points.AddXY(country.Key, country.NumberOfCompetitors);
                    }
                    #endregion
                }
                else if (guestsComboBox.SelectedItem.Equals("Competitors"))
                {
                    #region Chart Population, Competitors only
                    guestSummaryChart.Series.Add("Competitors");

                    guestSummaryChart.Series["Competitors"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                    guestSummaryChart.Series["Competitors"].IsValueShownAsLabel = true;

                    foreach (var country in guestQuery)
                    {
                        guestSummaryChart.Series["Competitors"].Points.AddXY(country.Key, country.NumberOfCompetitors);
                    }
                    #endregion
                }
                else if (guestsComboBox.SelectedItem.Equals("Delegates"))
                {
                    #region Chart Population, Delegates only
                    guestSummaryChart.Series.Add("Delegates");

                    guestSummaryChart.Series["Delegates"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                    guestSummaryChart.Series["Delegates"].IsValueShownAsLabel = true;

                    foreach (var country in guestQuery)
                    {
                        guestSummaryChart.Series["Delegates"].Points.AddXY(country.Key, country.NumberOfDelegates);
                    }
                    #endregion
                }
            }
        }
    }
}
