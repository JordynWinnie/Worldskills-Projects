using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_QR_Paper3_7_19_2020
{
    public partial class ConfirmArrivalCountryRep : Form
    {
        private Session3Entities context = new Session3Entities();
        private int numberOf19Req;
        private int numberOf42Req;
        private DateTime dateToCompare;
        private string currentUserId;

        public ConfirmArrivalCountryRep(string userId)
        {
            currentUserId = userId;
            InitializeComponent();
        }

        private void ConfirmArrivalCountryRep_Load(object sender, EventArgs e)
        {
            july22Radio.Checked = true;
            arrivalTimeCb.Items.Clear();
            var arrivalTimeList = new List<string>
            {
                "9am","11am","12pm","3pm","4pm"
            };
            dateToCompare = DateTime.Parse("22 July 2020");

            arrivalTimeCb.Items.AddRange(arrivalTimeList.ToArray());
            arrivalTimeCb.SelectedIndex = 0;
        }

        private void july22Radio_CheckedChanged(object sender, EventArgs e)
        {
            arrivalTimeCb.Items.Clear();
            var arrivalTimeList = new List<string>
            {
                "9am","11am","12pm","3pm","4pm"
            };
            dateToCompare = DateTime.Parse("22 July 2020");

            arrivalTimeCb.Items.AddRange(arrivalTimeList.ToArray());
            arrivalTimeCb.SelectedIndex = 0;
        }

        private void july23Radio_CheckedChanged(object sender, EventArgs e)
        {
            arrivalTimeCb.Items.Clear();
            var arrivalTimeList = new List<string>
            {
                "10am","11am","1pm","2pm","3pm"
            };
            dateToCompare = DateTime.Parse("23 July 2020");

            arrivalTimeCb.Items.AddRange(arrivalTimeList.ToArray());
            arrivalTimeCb.SelectedIndex = 0;
        }

        private void delegatesNUD_ValueChanged(object sender, EventArgs e)
        {
            AllocateBuses();
        }

        private void headOfDelegrationNUD_ValueChanged(object sender, EventArgs e)
        {
            AllocateBuses();
        }

        private void competitorsNUD_ValueChanged(object sender, EventArgs e)
        {
            AllocateBuses();
        }

        private void AllocateBuses()
        {
            headOfDeleLabel.Text = $"{headOfDelegrationNUD.Value} Cars for Head of Delegation";

            var totalPeople = (int)(delegatesNUD.Value + competitorsNUD.Value);
            numberOf19Req = 0;
            numberOf42Req = 0;
            if (totalPeople <= 19)
            {
                numberOf19Req = 1;
            }

            if (totalPeople > 19 && totalPeople <= 42)
            {
                numberOf42Req = 1;
            }

            if (totalPeople > 42)
            {
                var remainderAfterDivision = totalPeople % 42;

                if (remainderAfterDivision <= 19)
                {
                    numberOf19Req = 1;
                    numberOf42Req = totalPeople / 42;
                }

                if (remainderAfterDivision > 19 && remainderAfterDivision <= 42)
                {
                    numberOf42Req = (totalPeople / 42) + 1;
                }
            }

            seater19Label.Text = $"{numberOf19Req} 19-Seater Buses";
            seater42Label.Text = $"{numberOf42Req} 42-Seater Buses";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var insertArrival = new Arrival
            {
                arrivalDate = dateToCompare,
                arrivalTime = arrivalTimeCb.SelectedItem.ToString(),
                numberHead = (int)headOfDelegrationNUD.Value,
                number19seat = numberOf19Req,
                number42seat = numberOf42Req,
                numberCars = (int)headOfDelegrationNUD.Value,
                numberCompetitors = (int)competitorsNUD.Value,
                numberDelegate = (int)delegatesNUD.Value,
                userIdFK = currentUserId
            };

            context.Arrivals.Add(insertArrival);
            context.SaveChanges();
            MessageBox.Show("Changes Saved!");
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}