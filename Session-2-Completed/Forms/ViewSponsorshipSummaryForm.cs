using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session2_JordanKhong.Forms
{
    public partial class ViewSponsorshipSummaryForm : Form
    {
        public ViewSponsorshipSummaryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewSponsorshipSummaryForm_Load(object sender, EventArgs e)
        {
            
            using (var context = new Session2Entities())
            {
                //Populate Tier Combobox:
                tierCb.Items.Add("All Tiers");
                tierCb.Items.AddRange(context.Packages.Select(x => x.packageTier).Distinct().ToArray());
                tierCb.SelectedIndex = 0;
            }
        }

        private void tierCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                //Clear all points:
                summaryChart.Series[0].Points.Clear();

                //Query for all approved bookings:
                var mainChartQuery = (from x in context.Bookings
                                      where x.status.Equals("Approved")
                                      group x by x.Package.packageName into y
                                      select new
                                      {
                                          Name = y.Key,
                                          Value = y.Sum(x => x.Package.packageValue * x.quantityBooked),
                                          Quantity = y.Sum(x => x.quantityBooked)
                                      });

                //if selected index == 0, means ALL tiers are shown:
                if (tierCb.SelectedIndex == 0)
                {
                    #region Graph Point Allocation Logic:
                    foreach (var item in mainChartQuery)
                    {
                        var idx = summaryChart.Series[0].Points.AddXY(item.Quantity,item.Value);
                        summaryChart.Series[0].Points[idx].AxisLabel = item.Name;
                    }
                    if (mainChartQuery.Any())
                    {
                        totalLbl.Text = mainChartQuery.Sum(x => x.Value).ToString();
                    }
                    else
                    {
                        totalLbl.Text = "0";
                    }
                    #endregion
                }
                else
                {
                    //Compares with approved bookings and where the tier is the same as the one in the combobox:
                    var selectedTierFilter = tierCb.SelectedItem.ToString();
                    var filteredChartQuery = (from x in context.Bookings
                                              where x.status.Equals("Approved") && x.Package.packageTier.Equals(selectedTierFilter)
                                              group x by x.Package.packageName into y
                                              select new
                                              {
                                                  Name = y.Key,
                                                  Value = y.Sum(x => x.Package.packageValue * x.quantityBooked),
                                                  Quantity = y.Sum(x => x.quantityBooked)
                                              });

                    #region Graph Point Allocation Logic:
                    foreach (var item in filteredChartQuery)
                    {
                        var idx = summaryChart.Series[0].Points.AddXY(item.Quantity,item.Value);
                        summaryChart.Series[0].Points[idx].AxisLabel = item.Name;
                    }

                    if (filteredChartQuery.Any())
                    {
                        totalLbl.Text = filteredChartQuery.Sum(x => x.Value).ToString();
                    }
                    else
                    {
                        totalLbl.Text = "0";
                    }

                    #endregion

                }


            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
