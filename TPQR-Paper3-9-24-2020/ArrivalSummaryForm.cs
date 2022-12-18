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
    public partial class ArrivalSummaryForm : Form
    {
        private Session3Entities context = new Session3Entities();

        public ArrivalSummaryForm()
        {
            InitializeComponent();
        }

        private void ArrivalSummaryForm_Load(object sender, EventArgs e)
        {
            var jul22Date = DateTime.Parse("22 July 2020");
            var jul23Date = DateTime.Parse("23 July 2020");

            var jul22Timings = new List<string> { "9am", "11am", "12pm", "3pm", "4pm" };
            var jul23Timings = new List<string> { "10am", "11am", "1pm", "2pm", "3pm" };

            var timings = new List<string>
            {
                "9am", "10am", "11am", "12pm", "1pm", "2pm", "3pm", "4pm"
            };

            foreach (var timing in timings)
            {
                jul22DGV.Columns.Add(timing, timing);
                jul23DGV.Columns.Add(timing, timing);
            }

            for (int i = 0; i < timings.Count; i++)
            {
                if (!jul22Timings.Contains(timings[i]))
                {
                    jul22DGV.Columns[i].DefaultCellStyle.BackColor = Color.Black;
                }

                if (!jul23Timings.Contains(timings[i]))
                {
                    jul23DGV.Columns[i].DefaultCellStyle.BackColor = Color.Black;
                }
            }

            var jul22Arrivals = from x in context.Arrivals
                                where x.arrivalDate == jul22Date
                                group x by x.arrivalTime into y
                                select y;
            var jul22Row = new List<string>();
            var jul23Row = new List<string>();
            foreach (var timing in timings)
            {
                var arrivalTimingGroup = jul22Arrivals.Where(x => x.Key == timing);
                var tempString = string.Empty;
                foreach (var arrivalGroup in arrivalTimingGroup)
                {
                    foreach (var arrival in arrivalGroup)
                    {
                        tempString += $"{arrival.User.countryName} ({arrival.number19seat + arrival.number42seat + arrival.numberCars} vehicles)";
                    }
                }
                jul22Row.Add(tempString);
            }

            var jul23Arrivals = from x in context.Arrivals
                                where x.arrivalDate == jul23Date
                                group x by x.arrivalTime into y
                                select y;

            foreach (var timing in timings)
            {
                var arrivalTimingGroup = jul23Arrivals.Where(x => x.Key == timing);
                var tempString = string.Empty;
                foreach (var arrivalGroup in arrivalTimingGroup)
                {
                    foreach (var arrival in arrivalGroup)
                    {
                        tempString += $"{arrival.User.countryName} ({arrival.number19seat + arrival.number42seat + arrival.numberCars} vehicles)\n";
                    }
                }
                jul23Row.Add(tempString);
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