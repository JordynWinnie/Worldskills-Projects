using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Paper3_9_24_2020
{
    public partial class GuestSummaryForm : Form
    {
        private Session3Entities context = new Session3Entities();

        public GuestSummaryForm()

        {
            InitializeComponent();
        }

        private void GuestSummaryForm_Load(object sender, EventArgs e)
        {
            var typeOfGuests = new List<string>
            {
                "All","Competitors", "Delegates"
            };

            hotelCb.Items.AddRange(typeOfGuests.ToArray());
            hotelCb.SelectedIndex = 0;
        }

        private void hotelCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var baseQuery = from x in context.Arrivals
                            group x by x.User.countryName into y
                            select y;

            guestSummaryChart.Series.Clear();
            switch (hotelCb.SelectedItem.ToString())
            {
                case "All":
                    guestSummaryChart.Series.Add("Delegates");
                    guestSummaryChart.Series.Add("Competitors");

                    foreach (var country in baseQuery)
                    {
                        var pointIdx = guestSummaryChart.Series["Delegates"].Points.AddXY(country.Key, country.Sum(x => x.numberDelegate + x.numberHead));
                        var pointIdx1 = guestSummaryChart.Series["Competitors"].Points.AddXY(country.Key, country.Sum(x => x.numberCompetitors));

                        guestSummaryChart.Series["Delegates"].Points[pointIdx].Label = country.Sum(x => x.numberDelegate + x.numberHead).ToString();
                        guestSummaryChart.Series["Competitors"].Points[pointIdx1].Label = country.Sum(x => x.numberCompetitors).ToString();
                    }
                    break;

                case "Competitors":
                    guestSummaryChart.Series.Add("Competitors");
                    foreach (var country in baseQuery)
                    {
                        var pointIdx = guestSummaryChart.Series["Competitors"].Points.AddXY(country.Key, country.Sum(x => x.numberCompetitors));
                        guestSummaryChart.Series["Competitors"].Points[pointIdx].Label = country.Sum(x => x.numberCompetitors).ToString();
                    }

                    break;

                case "Delegates":
                    guestSummaryChart.Series.Add("Delegates");

                    foreach (var country in baseQuery)
                    {
                        var pointIdx = guestSummaryChart.Series["Delegates"].Points.AddXY(country.Key, country.Sum(x => x.numberDelegate + x.numberHead));
                        guestSummaryChart.Series["Delegates"].Points[pointIdx].Label = country.Sum(x => x.numberDelegate + x.numberHead).ToString();
                    }
                    break;

                default:
                    break;
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}