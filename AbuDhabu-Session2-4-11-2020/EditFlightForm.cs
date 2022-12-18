using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbuDhabu_Session2_4_11_2020
{
    public partial class EditFlightForm : Form
    {
        private int _flightId = -1;

        public EditFlightForm(int flightId)
        {
            _flightId = flightId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                var flight = context.Schedules.Where(x => x.ID == _flightId).First();

                flight.Date = dateDTP.Value;
                flight.Time = timeDTP.Value.TimeOfDay;

                flight.EconomyPrice = economicPriceNUD.Value;
                context.SaveChanges();
                MessageBox.Show("Updated");
                Close();
            }
        }

        private void EditFlightForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                var flight = context.Schedules.Where(x => x.ID == _flightId).First();
                fromLbl.Text = $"From: {flight.Route.Airport.IATACode}";
                toLbl.Text = $"To: {flight.Route.Airport1.IATACode}";
                aircraftLbl.Text = $"Aircraft: {flight.Aircraft.Name}";

                dateDTP.Value = flight.Date;
                timeDTP.Value = DateTime.Parse("1 Dec 2020 12:00 AM").AddHours(flight.Time.Hours).AddMinutes(flight.Time.Minutes);
                economicPriceNUD.Value = flight.EconomyPrice;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}