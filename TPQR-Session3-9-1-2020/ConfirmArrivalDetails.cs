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
    
    public partial class ConfirmArrivalDetails : Form
    {
        private int numberOfCars = 0;
        private int numberOf19Seat = 0;
        private int numberOf42Seat = 0;
        Session3Entities context = new Session3Entities();
        string _userID = string.Empty;
        DateTime currentDate = DateTime.Now;
        public ConfirmArrivalDetails(string userid)
        {
            _userID = userid;
            InitializeComponent();
        }

        private void ConfirmArrivalDetails_Load(object sender, EventArgs e)
        {
            if (context.Arrivals.Where(x=>x.userIdFK == _userID).Any())
            {
                var arrival = context.Arrivals.Where(x => x.userIdFK == _userID).First();
                MessageBox.Show($"You have already booked an arrival on {arrival.arrivalDate.ToShortDateString()} at {arrival.arrivalTime}.");
                Close();
            }
            RefreshTimings();
            Console.WriteLine(currentDate.ToString());
        }

        private void RefreshTimings()
        {
            timingCb.Items.Clear();
            
            if (jul22Radio.Checked)
            {
                currentDate = DateTime.Parse("22 July 2020");
                var availableTimings22 = new List<string>
                {
                    "9am", "11am", "12pm", "3pm", "4pm"
                };

                foreach (var timing in availableTimings22)
                {
                    if (!context.Arrivals.Where(x=>x.arrivalDate == currentDate && x.arrivalTime == timing).Any())
                    {
                        timingCb.Items.Add(timing);
                    }
                }
            }
            else
            {
                currentDate = DateTime.Parse("23 July 2020");
                var availableTimings23 = new List<string>
                {
                    "10am", "11am", "1pm", "2pm", "3pm"
                };

                foreach (var timing in availableTimings23)
                {
                    if (!context.Arrivals.Where(x => x.arrivalDate == currentDate && x.arrivalTime == timing).Any())
                    {
                        timingCb.Items.Add(timing);
                    }
                }
            }

            timingCb.SelectedIndex = 0;
        }

        private void RefreshAllocations()
        {
            numberOfCars = 0;
            numberOf19Seat = 0;
            numberOf42Seat = 0;
            //HOD Allocation:
            carHODLbl.Text = hodNUD.Value == 0 ? "0 Car for Head of Delegation" 
                : "1 Car for Head of Delegation";
            numberOfCars = (int)hodNUD.Value;

            //Bus Allocation:

            var totalNumber = (int)(delegatesNUD.Value + competitorsNUD.Value);

            numberOf42Seat += totalNumber / 42;
            var remainder = totalNumber % 42;

            if (remainder > 0 && remainder <= 19)
            {
                numberOf19Seat += 1;
            }
            else if (remainder > 19 && remainder <= 38)
            {
                numberOf19Seat += 2;
            }
            else
            {
                numberOf42Seat += 1;
            }

            seater19Lbl.Text =$"{numberOf19Seat} 19-seater buses";
            seater42Lbl.Text = $"{numberOf42Seat} 42-seater buses";
        }

        private void jul22Radio_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTimings();
        }

        private void jul23Radio_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTimings();
        }

        private void delegatesNUD_ValueChanged(object sender, EventArgs e)
        {
            RefreshAllocations();
        }

        private void hodNUD_ValueChanged(object sender, EventArgs e)
        {
            RefreshAllocations();
        }

        private void competitorsNUD_ValueChanged(object sender, EventArgs e)
        {
            RefreshAllocations();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(currentDate.ToString());
            var insertArrival = new Arrival
            {
                userIdFK = _userID,
                arrivalDate = currentDate,
                arrivalTime = timingCb.SelectedItem.ToString(),
                number19seat = numberOf19Seat,
                number42seat = numberOf42Seat,
                numberCars = numberOfCars,
                numberCompetitors = (int) competitorsNUD.Value,
                numberDelegate = (int) delegatesNUD.Value,
                numberHead = (int)hodNUD.Value
            };

            context.Arrivals.Add(insertArrival);
            context.SaveChanges();
            MessageBox.Show("Arrival Confirmed");
        }
    }
}
