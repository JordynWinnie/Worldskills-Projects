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
    public partial class ArrivalSummaryForm : Form
    {
        public ArrivalSummaryForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ArrivalSummaryForm_Load(object sender, EventArgs e)
        {
            //Uses a similar method to the one in Arrival details. But since no user input, it directly uses the column
            var columns = new List<string>
                {
                    "9am",
                    "10am",
                    "11am",
                    "12pm",
                    "1pm",
                    "2pm",
                    "3pm",
                    "4pm"
                };
            #region Population of both DGVS:
            foreach (var column in columns)
            {
                arrival22ndDGV.Columns.Add(column, column);
                arrival23rdDGV.Columns.Add(column, column);
            }

            arrival22ndDGV.ReadOnly = true;
            arrival23rdDGV.ReadOnly = true;

            arrival22ndDGV.Rows.Add(columns.ToArray());
            arrival23rdDGV.Rows.Add(columns.ToArray());

            arrival23rdDGV.CurrentCell.Selected = false;
            arrival22ndDGV.CurrentCell.Selected = false;
            #endregion

            var availableTimes22ndJuly = new List<string>
            {
                "9am","11am","12pm","3pm","4pm"
            };

            var availableTimes23rdJuly = new List<string>
            {
                "10am", "11am", "1pm", "2pm", "3pm"
            };
            //Colour the cells
            

            using (var context = new Session3Entities())
            {
                #region Get all Arrival Information
                var date22nd = DateTime.Parse("22 July");
                var date23rd = DateTime.Parse("23 July");
                var arrivalsOn22nd = from x in context.Arrivals
                                     where x.arrivalDate == date22nd
                                     select x;

                var arrivalsOn23nd = from x in context.Arrivals
                                     where x.arrivalDate == date23rd
                                     select x;
                #endregion

                //Changes wrap mode so the cell can support multiline:
                arrival22ndDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                arrival23rdDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                #region Generates the string based on number of arrivals on current day:
                foreach (var date in availableTimes22ndJuly)
                {
                    StringBuilder sb = new StringBuilder();
                    
                    sb.Append(date);
                    sb.Append("\n");
                    //Appends all arrival info based on the date:
                    foreach (var arrival in arrivalsOn22nd.Where(x=>x.arrivalTime.Equals(date)))
                    {


                        sb.Append("\n" + arrival.User.countryName);
                        
                        var totalVehicles = (arrival.number42seat + arrival.number19seat + arrival.numberCars);
                        sb.Append($"\n({totalVehicles} vehicles)");
                        sb.Append("\n");
                    }
                    //Changes the column based on date:
                    arrival22ndDGV.Rows[0].Cells[date].Value = sb.ToString();
                }

                foreach (var date in availableTimes23rdJuly)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(date);
                    sb.Append("\n");
                    foreach (var arrival in arrivalsOn23nd.Where(x => x.arrivalTime.Equals(date)))
                    {
                        sb.Append("\n" + arrival.User.countryName);

                        var totalVehicles = (arrival.number42seat + arrival.number19seat + arrival.numberCars);
                        sb.Append($"\n({totalVehicles} vehicles)");
                        sb.Append("\n");
                        
                    }
                    arrival23rdDGV.Rows[0].Cells[date].Value = sb.ToString();
                }
                #endregion
            }
            //Colours the available times black first:
            foreach (var item in availableTimes22ndJuly)
            {
                arrival22ndDGV.Columns[item].DefaultCellStyle.BackColor = Color.Black;
            }

            foreach (var item in availableTimes23rdJuly)
            {
                arrival23rdDGV.Columns[item].DefaultCellStyle.BackColor = Color.Black;
            }

            //Colours the opposite colors
            foreach (DataGridViewColumn col in arrival22ndDGV.Columns)
            {
                if (col.DefaultCellStyle.BackColor == Color.Black)
                {
                    col.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    col.DefaultCellStyle.BackColor = Color.Black;
                }
            }

            foreach (DataGridViewColumn col in arrival23rdDGV.Columns)
            {
                if (col.DefaultCellStyle.BackColor == Color.Black)
                {
                    col.DefaultCellStyle.BackColor = Color.White;

                }
                else
                {
                    col.DefaultCellStyle.BackColor = Color.Black;
                }
            }

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = DateTime.Now.ToString();
        }
    }
}
