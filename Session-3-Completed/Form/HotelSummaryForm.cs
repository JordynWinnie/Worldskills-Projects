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
    public partial class HotelSummaryForm : Form
    {
        public HotelSummaryForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HotelSummaryForm_Load(object sender, EventArgs e)
        {
            //Population of Columns:
            var columns = new List<string>
            {
                "Country", "No. Of Single Rooms Booked", "No. Of Double Rooms Booked"
            };

            foreach (var column in columns)
            {
                hotelListDGV.Columns.Add(column, column);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = DateTime.Now.ToString();
        }

        private void ritzCaltonBtn_Click(object sender, EventArgs e)
        {
            RefreshList("Ritz-Carlton");
        }

        private void panPacBtn_Click(object sender, EventArgs e)
        {
            RefreshList("Pan Pacific Hotel");
        }

        private void intercontinentalBtn_Click(object sender, EventArgs e)
        {
            RefreshList("Intercontinental Singapore");
        }

        private void hotelGrandPacificBtn_Click(object sender, EventArgs e)
        {
            RefreshList("Hotel Grand Pacific");
        }

        private void hotelAtQueensBtn_Click(object sender, EventArgs e)
        {
            RefreshList("Hotel Royal Queens");
        }

        private void carltonHotelBtn_Click(object sender, EventArgs e)
        {
            RefreshList("Charlton Hotel");
        }

        /// <summary>
        /// Method takes in the hotel name and compares them in a generic query to get all the 
        /// hotel information
        /// </summary>
        /// <param name="hotelName"></param>
        void RefreshList(string hotelName)
        {
            
            using (var context = new Session3Entities())
            {
                var bookingInfo = from x in context.Hotel_Booking
                                  where x.Hotel.hotelName.Equals(hotelName)
                                  select new
                                  {
                                      x.Hotel.hotelName,
                                      x.User.countryName,
                                      x.numSingleRoomsRequired,
                                      x.numDoubleRoomsRequired
                                  };

                hotelListDGV.Rows.Clear();
                hotelListDGV.ReadOnly = true;

                //Populates the rows based on number of bookings
                foreach (var booking in bookingInfo)
                {
                    var row = new List<string>
                    {
                        booking.countryName,
                        booking.numSingleRoomsRequired.ToString(),
                        booking.numDoubleRoomsRequired.ToString()
                    };

                    hotelListDGV.Rows.Add(row.ToArray());
                };

                hotelNameLbl.Text = $"Hotel Name: {hotelName}";

            }
            
        }
    }
}
