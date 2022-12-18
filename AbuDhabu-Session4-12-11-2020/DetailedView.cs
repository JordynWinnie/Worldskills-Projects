using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbuDhabu_Session4_12_11_2020
{
    public partial class DetailedView : Form
    {
        private Session4Entities1 context = new Session4Entities1();

        public DetailedView()
        {
            InitializeComponent();
        }

        private void DetailedView_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "RatingName", "Total", "Male", "Female", "18-24", "25-39", "40-59", "60+", "Economy", "Business", "First", "AUH", "BAH", "DOH", "RYU", "CAI"
            };

            var genders = new List<string>
            {
                "All Genders", "Male", "Female"
            };

            var ages = new List<string>
            {
                "All Ages", "18-24", "25-39", "40-59", "60+"
            };

            var queryCache = context.AnswerTables.ToList();
            foreach (var column in columns)
            {
                q1DGV.Columns.Add(column, column);
                q2DGV.Columns.Add(column, column);
                q3DGV.Columns.Add(column, column);
                q4DGV.Columns.Add(column, column);
            }
            timePeriodCb.Items.Add("All");
            var periods = from x in queryCache
                          group x by new { Date = x.dateOfAnswer.Value.ToString("MMMM yyyy") } into y
                          select y;
            timePeriodCb.Items.AddRange(periods.Select(x => x.Key.Date).ToArray());

            timePeriodCb.SelectedIndex = 0;
            genderCb.Items.AddRange(genders.ToArray());
            genderCb.SelectedIndex = 0;

            ageCb.Items.AddRange(ages.ToArray());
            ageCb.SelectedIndex = 0;
            RefreshDGV();
        }

        private void RefreshDGV()
        {
            q1DGV.Rows.Clear();
            q2DGV.Rows.Clear();
            q3DGV.Rows.Clear();
            q4DGV.Rows.Clear();

            var queryCache = context.AnswerTables.ToList();

            if (timePeriodCb.SelectedIndex != 0)
            {
                var dateTime = DateTime.Parse(timePeriodCb.SelectedItem.ToString());
                queryCache = queryCache.Where(x => x.dateOfAnswer.Value == dateTime).ToList();
            }

            var groupQuery1 = from x in queryCache
                              orderby x.RatingTable.ratingId
                              group x by x.RatingTable.ratingName into y
                              select y;

            var groupQuery2 = from x in queryCache
                              orderby x.RatingTable1.ratingId
                              group x by x.RatingTable1.ratingName into y
                              select y;

            var groupQuery3 = from x in queryCache
                              orderby x.RatingTable2.ratingId
                              group x by x.RatingTable2.ratingName into y
                              select y;

            var groupQuery4 = from x in queryCache
                              orderby x.RatingTable3.ratingId
                              group x by x.RatingTable3.ratingName into y
                              select y;
            chart1.Series.Clear();
            chart2.Series.Clear();
            chart3.Series.Clear();
            chart4.Series.Clear();
            chart5.Series.Clear();
            foreach (var group in groupQuery1)
            {
                chart5.Series.Add(group.Key);
                chart5.ChartAreas[0].Visible = false;
                chart1.Series.Add(group.Key);
                chart1.Series[group.Key].Points.AddXY("Rating", group.Count());
                chart1.Series[group.Key].IsVisibleInLegend = false;
                chart1.ChartAreas[0].AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
                chart1.ChartAreas[0].AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
                chart1.Series[group.Key].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100;
                var row = new List<string>
                {
                    group.Key,
                    group.Count().ToString(),
                    group.Where(x=>x.gender == "M").Count().ToString(),
                    group.Where(x=>x.gender == "F").Count().ToString(),
                    group.Where(x=>x.age >= 18 && x.age <= 24).Count().ToString(),
                    group.Where(x=>x.age >= 25 && x.age <= 39).Count().ToString(),
                    group.Where(x=>x.age >= 40 && x.age <= 59).Count().ToString(),
                    group.Where(x=>x.age >= 60).Count().ToString(),
                    group.Where(x=>x.CabinType.cabinTypeName == "Economy").Count().ToString(),
                    group.Where(x=>x.CabinType.cabinTypeName == "Business").Count().ToString(),
                    group.Where(x=>x.CabinType.cabinTypeName == "First").Count().ToString(),
                    group.Where(x=>x.depature == "AUH").Count().ToString(),
                    group.Where(x=>x.depature == "BAH").Count().ToString(),
                    group.Where(x=>x.depature == "DOH").Count().ToString(),
                    group.Where(x=>x.depature == "RYU").Count().ToString(),
                    group.Where(x=>x.depature == "CAI").Count().ToString()
                };

                q1DGV.Rows.Add(row.ToArray());
            }

            foreach (var group in groupQuery2)
            {
                chart2.Series.Add(group.Key);
                chart2.Series[group.Key].Points.AddXY("Rating", group.Count());
                chart2.Series[group.Key].IsVisibleInLegend = false;
                chart2.ChartAreas[0].AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
                chart2.ChartAreas[0].AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
                chart2.Series[group.Key].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100;
                var row = new List<string>
                {
                    group.Key,
                    group.Count().ToString(),
                    group.Where(x=>x.gender == "M").Count().ToString(),
                    group.Where(x=>x.gender == "F").Count().ToString(),
                    group.Where(x=>x.age >= 18 && x.age <= 24).Count().ToString(),
                    group.Where(x=>x.age >= 25 && x.age <= 39).Count().ToString(),
                    group.Where(x=>x.age >= 40 && x.age <= 59).Count().ToString(),
                    group.Where(x=>x.age >= 60).Count().ToString(),
                    group.Where(x=>x.CabinType.cabinTypeName == "Economy").Count().ToString(),
                    group.Where(x=>x.CabinType.cabinTypeName == "Business").Count().ToString(),
                    group.Where(x=>x.CabinType.cabinTypeName == "First").Count().ToString(),
                    group.Where(x=>x.depature == "AUH").Count().ToString(),
                    group.Where(x=>x.depature == "BAH").Count().ToString(),
                    group.Where(x=>x.depature == "DOH").Count().ToString(),
                    group.Where(x=>x.depature == "RYU").Count().ToString(),
                    group.Where(x=>x.depature == "CAI").Count().ToString()
                };

                q2DGV.Rows.Add(row.ToArray());
            }

            foreach (var group in groupQuery3)
            {
                chart3.Series.Add(group.Key);
                chart3.Series[group.Key].Points.AddXY("Rating", group.Count());
                chart3.Series[group.Key].IsVisibleInLegend = false;
                chart3.ChartAreas[0].AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
                chart3.ChartAreas[0].AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
                chart3.Series[group.Key].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100;
                var row = new List<string>
                {
                    group.Key,
                    group.Count().ToString(),
                    group.Where(x=>x.gender == "M").Count().ToString(),
                    group.Where(x=>x.gender == "F").Count().ToString(),
                    group.Where(x=>x.age >= 18 && x.age <= 24).Count().ToString(),
                    group.Where(x=>x.age >= 25 && x.age <= 39).Count().ToString(),
                    group.Where(x=>x.age >= 40 && x.age <= 59).Count().ToString(),
                    group.Where(x=>x.age >= 60).Count().ToString(),
                    group.Where(x=>x.CabinType.cabinTypeName == "Economy").Count().ToString(),
                    group.Where(x=>x.CabinType.cabinTypeName == "Business").Count().ToString(),
                    group.Where(x=>x.CabinType.cabinTypeName == "First").Count().ToString(),
                    group.Where(x=>x.depature == "AUH").Count().ToString(),
                    group.Where(x=>x.depature == "BAH").Count().ToString(),
                    group.Where(x=>x.depature == "DOH").Count().ToString(),
                    group.Where(x=>x.depature == "RYU").Count().ToString(),
                    group.Where(x=>x.depature == "CAI").Count().ToString()
                };

                q3DGV.Rows.Add(row.ToArray());
            }

            foreach (var group in groupQuery4)
            {
                chart4.Series.Add(group.Key);
                chart4.Series[group.Key].Points.AddXY("Rating", group.Count());
                chart4.Series[group.Key].IsVisibleInLegend = false;
                chart4.ChartAreas[0].AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
                chart4.ChartAreas[0].AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
                chart4.Series[group.Key].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100;
                var row = new List<string>
                {
                    group.Key,
                    group.Count().ToString(),
                    group.Where(x=>x.gender == "M").Count().ToString(),
                    group.Where(x=>x.gender == "F").Count().ToString(),
                    group.Where(x=>x.age >= 18 && x.age <= 24).Count().ToString(),
                    group.Where(x=>x.age >= 25 && x.age <= 39).Count().ToString(),
                    group.Where(x=>x.age >= 40 && x.age <= 59).Count().ToString(),
                    group.Where(x=>x.age >= 60).Count().ToString(),
                    group.Where(x=>x.CabinType.cabinTypeName == "Economy").Count().ToString(),
                    group.Where(x=>x.CabinType.cabinTypeName == "Business").Count().ToString(),
                    group.Where(x=>x.CabinType.cabinTypeName == "First").Count().ToString(),
                    group.Where(x=>x.depature == "AUH").Count().ToString(),
                    group.Where(x=>x.depature == "BAH").Count().ToString(),
                    group.Where(x=>x.depature == "DOH").Count().ToString(),
                    group.Where(x=>x.depature == "RYU").Count().ToString(),
                    group.Where(x=>x.depature == "CAI").Count().ToString()
                };

                q4DGV.Rows.Add(row.ToArray());
            }

            for (int i = 0; i < q1DGV.Rows.Count; i++)
            {
                if (i % 2 != 0)
                {
                    q1DGV.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                    q2DGV.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                    q3DGV.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                    q4DGV.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                }

                var total1 = 0;
                var total2 = 0;
                var total3 = 0;
                var total4 = 0;
                for (int j = 2; j < q1DGV.Columns.Count; j++)
                {
                    if (q1DGV.Columns[j].Visible)
                    {
                        total1 += int.Parse(q1DGV[j, i].Value.ToString());
                        total2 += int.Parse(q2DGV[j, i].Value.ToString());
                        total3 += int.Parse(q3DGV[j, i].Value.ToString());
                        total4 += int.Parse(q4DGV[j, i].Value.ToString());
                    }
                }
                q1DGV[1, i].Value = total1;
                q2DGV[1, i].Value = total2;
                q3DGV[1, i].Value = total3;
                q4DGV[1, i].Value = total4;
            }
        }

        private void timePeriodCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        private void genderCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleAllColumnVisibility(2, true);
            ToggleAllColumnVisibility(3, true);
            switch (genderCb.SelectedIndex)
            {
                case 1:
                    //Male Selected
                    ToggleAllColumnVisibility(2, true);
                    ToggleAllColumnVisibility(3, false);
                    break;

                case 2:
                    //Female Selected
                    ToggleAllColumnVisibility(2, false);
                    ToggleAllColumnVisibility(3, true);
                    break;

                default:
                    ToggleAllColumnVisibility(2, true);
                    ToggleAllColumnVisibility(3, true);
                    break;
            }

            RefreshDGV();
        }

        private void ToggleAllColumnVisibility(int columnIdx, bool visibility)
        {
            q1DGV.Columns[columnIdx].Visible = visibility;
            q2DGV.Columns[columnIdx].Visible = visibility;
            q3DGV.Columns[columnIdx].Visible = visibility;
            q4DGV.Columns[columnIdx].Visible = visibility;
        }

        private void genderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            genderCb.Enabled = !genderCb.Enabled;
            genderCb.SelectedIndex = 0;
            ToggleAllColumnVisibility(2, true);
            ToggleAllColumnVisibility(3, true);
            if (genderCheckBox.Checked)
            {
                ToggleAllColumnVisibility(2, true);
                ToggleAllColumnVisibility(3, true);
            }
            else
            {
                ToggleAllColumnVisibility(2, false);
                ToggleAllColumnVisibility(3, false);
            }

            RefreshDGV();
        }

        private void ageCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleAllColumnVisibility(4, true);
            ToggleAllColumnVisibility(5, true);
            ToggleAllColumnVisibility(6, true);
            ToggleAllColumnVisibility(7, true);

            switch (ageCb.SelectedIndex)
            {
                case 1:
                    //Male Selected
                    ToggleAllColumnVisibility(4, true);
                    ToggleAllColumnVisibility(5, false);
                    ToggleAllColumnVisibility(6, false);
                    ToggleAllColumnVisibility(7, false);
                    break;

                case 2:
                    //Female Selected
                    ToggleAllColumnVisibility(4, false);
                    ToggleAllColumnVisibility(5, true);
                    ToggleAllColumnVisibility(6, false);
                    ToggleAllColumnVisibility(7, false);
                    break;

                case 3:
                    ToggleAllColumnVisibility(4, false);
                    ToggleAllColumnVisibility(5, false);
                    ToggleAllColumnVisibility(6, true);
                    ToggleAllColumnVisibility(7, false);
                    break;

                case 4:
                    ToggleAllColumnVisibility(4, false);
                    ToggleAllColumnVisibility(5, false);
                    ToggleAllColumnVisibility(6, false);
                    ToggleAllColumnVisibility(7, true);
                    break;

                default:
                    ToggleAllColumnVisibility(4, true);
                    ToggleAllColumnVisibility(5, true);
                    ToggleAllColumnVisibility(6, true);
                    ToggleAllColumnVisibility(7, true);
                    break;
            }

            RefreshDGV();
        }

        private void ageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ageCb.Enabled = !ageCb.Enabled;
            ageCb.SelectedIndex = 0;
            ToggleAllColumnVisibility(4, true);
            ToggleAllColumnVisibility(5, true);
            ToggleAllColumnVisibility(6, true);
            ToggleAllColumnVisibility(7, true);
            if (ageCheckBox.Checked)
            {
                ToggleAllColumnVisibility(4, true);
                ToggleAllColumnVisibility(5, true);
                ToggleAllColumnVisibility(6, true);
                ToggleAllColumnVisibility(7, true);
            }
            else
            {
                ToggleAllColumnVisibility(4, false);
                ToggleAllColumnVisibility(5, false);
                ToggleAllColumnVisibility(6, false);
                ToggleAllColumnVisibility(7, false);
            }

            RefreshDGV();
        }

        private void chart5_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}