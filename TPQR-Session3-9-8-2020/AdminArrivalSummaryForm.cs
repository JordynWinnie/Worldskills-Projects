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
    public partial class AdminArrivalSummaryForm : Form
    {
        private Session3Entities context = new Session3Entities();

        public AdminArrivalSummaryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AdminArrivalSummaryForm_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "9am", "10am", "11am", "12pm", "1pm", "2pm", "3pm", "4pm"
            };

            var jul22AvailTimes = new List<string>
            {
                "9am", "11am", "12pm", "3pm", "4pm"
            };

            var jul23AvailTimes = new List<string>
            {
                "10am", "11am", "1pm", "2pm", "3pm"
            };

            for (int i = 0; i < columns.Count; i++)
            {
                var colText = columns[i];
                jul22DGV.Columns.Add(colText, colText);

                if (!jul22AvailTimes.Contains(colText))
                {
                    jul22DGV.Columns[i].DefaultCellStyle.BackColor = Color.Black;
                }
                jul23DGV.Columns.Add(colText, colText);

                if (!jul23AvailTimes.Contains(colText))
                {
                    jul23DGV.Columns[i].DefaultCellStyle.BackColor = Color.Black;
                }
            }

            var jul22Date = DateTime.Parse("22 July 2020");
            var jul23Date = DateTime.Parse("23 July 2020");

            var jul22Row = new List<string>();
            var jul23Row = new List<string>();
            foreach (var item in columns)
            {
                var arrivalQuery22 = from x in context.Arrivals
                                     where x.arrivalDate == jul22Date && x.arrivalTime == item
                                     group x by x.User.countryName into y
                                     select y;

                if (arrivalQuery22.Any())
                {
                    var tempString = "";
                    foreach (var country in arrivalQuery22)
                    {
                        tempString += $"{country.Key}\n({country.Sum(x => x.number19seat + x.number42seat + x.numberCars)})\n";
                    }
                    jul22Row.Add(tempString);
                }
                else
                {
                    jul22Row.Add("-");
                }
            }

            foreach (var item in columns)
            {
                var arrivalQuery23 = from x in context.Arrivals
                                     where x.arrivalDate == jul23Date && x.arrivalTime == item
                                     group x by x.User.countryName into y
                                     select y;

                if (arrivalQuery23.Any())
                {
                    var tempString = "";
                    foreach (var country in arrivalQuery23)
                    {
                        tempString += $"{country.Key}\n({country.Sum(x => x.number19seat + x.number42seat + x.numberCars)})\n";
                    }
                    jul23Row.Add(tempString);
                }
                else
                {
                    jul23Row.Add("-");
                }
            }

            jul22DGV.Rows.Add(jul22Row.ToArray());
            jul23DGV.Rows.Add(jul23Row.ToArray());
        }
    }
}