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
    public partial class HotelSelectionForm : Form
    {
        private int numberOf19Seater;
        private int numberOf42Seater;
        private string userId;
        private DateTime dateChoosen;

        private Session3Entities context = new Session3Entities();

        public HotelSelectionForm(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void ConfirmArrivalDetails_Load(object sender, EventArgs e)
        {
            if (context.Arrivals.Where(x => x.userIdFK == userId).Any())
            {
                MessageBox.Show("Arrival confirmed before");
                Close();
                return;
            }
            RefeshTimings();
            RefreshCalculation();
        }

        private void RefreshCalculation()
        {
            carsForHOD_Lbl.Text = $"{HOD_NUD.Value} Car for Head Of Delegation";

            numberOf19Seater = 0;
            numberOf42Seater = 0;

            var totalPeople = (int)(competitors_NUD.Value + delegates_NUD.Value);

            numberOf42Seater = totalPeople / 42;
            if (totalPeople % 42 != 0)
            {
                var remainingPeople = totalPeople % 42;

                if (remainingPeople > 0 && remainingPeople <= 19)
                {
                    numberOf19Seater += 1;
                }
                else if (remainingPeople > 19 && remainingPeople <= 38)
                {
                    numberOf19Seater += 2;
                }
                else
                {
                    numberOf42Seater += 1;
                }
            }

            seat19_Lbl.Text = $"{numberOf19Seater} 19-seater buses";
            seater42_Lbl.Text = $"{numberOf42Seater} 42-seater buses";
        }

        private void RefeshTimings()
        {
            timingCb.Items.Clear();
            var jul22Timings = new List<string> { "9am", "11am", "12pm", "3pm", "4pm" };
            var jul23Timings = new List<string> { "10am", "11am", "1pm", "2pm", "3pm" };
            if (jul22radio.Checked)
            {
                timingCb.Items.AddRange(jul22Timings.ToArray());
                dateChoosen = DateTime.Parse("22 July 2020");
            }
            else
            {
                timingCb.Items.AddRange(jul23Timings.ToArray());
                dateChoosen = DateTime.Parse("23 July 2020");
            }
            timingCb.SelectedIndex = 0;
        }

        private void delegates_NUD_ValueChanged(object sender, EventArgs e)
        {
            RefreshCalculation();
        }

        private void HOD_NUD_ValueChanged(object sender, EventArgs e)
        {
            RefreshCalculation();
        }

        private void competitors_NUD_ValueChanged(object sender, EventArgs e)
        {
            RefreshCalculation();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            var insertArrival = new Arrival
            {
                arrivalDate = dateChoosen,
                arrivalTime = timingCb.SelectedItem.ToString(),
                number19seat = numberOf19Seater,
                number42seat = numberOf42Seater,
                numberCars = (int)HOD_NUD.Value,
                numberCompetitors = (int)competitors_NUD.Value,
                numberDelegate = (int)delegates_NUD.Value,
                numberHead = (int)HOD_NUD.Value,
                userIdFK = userId
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