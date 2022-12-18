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
    public partial class ConfirmArrivalDetailsForm : Form
    {
        private string _userId;
        private int numberOf42Buses;
        private int numberOf19Buses;
        private Session3Entities context = new Session3Entities();

        public ConfirmArrivalDetailsForm(string userid)
        {
            _userId = userid;
            InitializeComponent();
        }

        private void ConfirmArrivalDetailsForm_Load(object sender, EventArgs e)
        {
            if (context.Arrivals.Where(x => x.userIdFK == _userId).Any())
            {
                MessageBox.Show("You have already confirmed an arrival.");
                Close();
                return;
            }
            UpdateForm();
            UpdateCalculation();
        }

        private void UpdateForm()
        {
            timeCb.Items.Clear();
            if (jul22Radio.Checked)
            {
                var jul22AvailTimes = new List<string>
                {
                    "9am", "11am", "12pm", "3pm", "4pm"
                };

                foreach (var time in jul22AvailTimes)
                {
                    timeCb.Items.Add(time);
                }
            }
            else
            {
                var jul23AvailTimes = new List<string>
                {
                    "10am", "11am", "1pm", "2pm", "3pm"
                };

                foreach (var time in jul23AvailTimes)
                {
                    timeCb.Items.Add(time);
                }
            }

            timeCb.SelectedIndex = 0;
        }

        private void jul23Radio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void jul22Radio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void HOD_NUD_ValueChanged(object sender, EventArgs e)
        {
            UpdateCalculation();
        }

        private void delegatesNUD_ValueChanged(object sender, EventArgs e)
        {
            UpdateCalculation();
        }

        private void competitorsNUD_ValueChanged(object sender, EventArgs e)
        {
            UpdateCalculation();
        }

        private void UpdateCalculation()
        {
            HODLbl.Text = $"{HOD_NUD.Value} car for head of delegation";

            numberOf42Buses = 0;
            numberOf19Buses = 0;
            var totalNumberOfPeople = (int)delegatesNUD.Value + (int)competitorsNUD.Value;

            if (totalNumberOfPeople % 42 != 0)
            {
                numberOf42Buses += totalNumberOfPeople / 42;
                var remainingPeople = totalNumberOfPeople % 42;

                if (remainingPeople >= 0 && remainingPeople <= 19)
                {
                    numberOf19Buses += 1;
                }
                else if (remainingPeople > 19 && remainingPeople <= 38)
                {
                    numberOf19Buses += 2;
                }
                else
                {
                    numberOf42Buses += 1;
                }
            }
            else
            {
                numberOf42Buses += totalNumberOfPeople / 42;
            }

            seater19Lbl.Text = $"Number of 19-seater buses: {numberOf19Buses}";
            seater42Lbl.Text = $"Number of 42-seater buses: {numberOf42Buses}";
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            var date = new DateTime();
            if (jul22Radio.Checked)
            {
                date = DateTime.Parse("22 July 2020");
            }
            else
            {
                date = DateTime.Parse("23 July 2020");
            }
            var insertArrival = new Arrival
            {
                arrivalDate = date,
                arrivalTime = timeCb.SelectedItem.ToString(),
                number19seat = numberOf19Buses,
                number42seat = numberOf42Buses,
                numberCars = (int)HOD_NUD.Value,
                numberCompetitors = (int)competitorsNUD.Value,
                numberDelegate = (int)delegatesNUD.Value,
                numberHead = (int)HOD_NUD.Value,
                userIdFK = _userId
            };

            context.Arrivals.Add(insertArrival);
            context.SaveChanges();
            MessageBox.Show("Arrival Confirmed");
            Close();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}