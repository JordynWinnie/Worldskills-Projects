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
    public partial class ArrivalSummary : Form
    {
        Session3Entities context = new Session3Entities();
        public ArrivalSummary()
        {
            InitializeComponent();
        }

        private void ArrivalSummary_Load(object sender, EventArgs e)
        {
            string[] timings = { "9am", "10am", "11am", "12pm", "1pm", "2pm", "3pm", "4pm"};

            string[] jul22DisallowedTimings = {"10am", "1pm", "2pm", "3pm" };

            string[] jul23DisallowedTimings = { "9am", "12pm", "4pm" };

            var jul22Date = DateTime.Parse("22 July 2020");
            var jul23Date = DateTime.Parse("23 July 2020");
            var jul22Row = new List<string>();
            var jul23Row = new List<string>();

            for (int i = 0; i < timings.Length; i++)
            {
                jul22DGV.Columns.Add(timings[i], timings[i]);

                if (jul22DisallowedTimings.Contains(timings[i]))
                {
                    jul22DGV.Columns[i].DefaultCellStyle.BackColor = Color.Black;
                    
                }

                var currentTime = timings[i];

                var jul22Arrivals = context.Arrivals.Where(x=>x.arrivalDate == jul22Date && x.arrivalTime == currentTime);
                if (jul22Arrivals.Any())
                {
                    var sb = new StringBuilder();
                    foreach (var arrival in jul22Arrivals)
                    {
                        sb.Append( $"{arrival.User.countryName} ({arrival.number19seat + arrival.number42seat + arrival.numberCars} vehicles)"); 
                        sb.AppendLine();
                        sb.AppendLine();
                    }

                    jul22Row.Add(sb.ToString());
                }
                else
                {
                    jul22Row.Add("No Arrivals");
                }

                jul23DGV.Columns.Add(timings[i], timings[i]);

                if (jul23DisallowedTimings.Contains(timings[i]))
                {
                    jul23DGV.Columns[i].DefaultCellStyle.BackColor = Color.Black;
                   
                }
                var jul23Arrivals = context.Arrivals.Where(x => x.arrivalDate == jul23Date && x.arrivalTime == currentTime);
                if (jul23Arrivals.Any())
                {
                    var tempString = string.Empty;
                    foreach (var arrival in jul23Arrivals)
                    {
                        tempString = $"{arrival.User.countryName} ({arrival.number19seat + arrival.number42seat + arrival.numberCars} vehicles)";
                        tempString += "\n";
                    }

                    jul23Row.Add(tempString);
                }
                else
                {
                    jul23Row.Add("No Arrivals");
                }
            }

            jul22DGV.Rows.Add(jul22Row.ToArray());
            jul23DGV.Rows.Add(jul23Row.ToArray());
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
