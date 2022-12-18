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
    public partial class HotelSummaryAdmin : Form
    {
        private Session3Entities context = new Session3Entities();

        public HotelSummaryAdmin()
        {
            InitializeComponent();
        }

        private void HotelSummaryAdmin_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Country", "No Of Single Rooms Booked", "No Of Double Rooms Booked"
            };

            foreach (var column in columns)
            {
                dataGridView1.Columns.Add(column, column);
            }
            hotelCb.Items.AddRange(context.Hotels.Select(x => x.hotelName).ToArray());
            hotelCb.SelectedIndex = 0;
        }

        private void hotelCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var hotelName = hotelCb.SelectedItem.ToString();
            var hotelBookings = context.Hotel_Booking.Where(x => x.Hotel.hotelName.Equals(hotelName));

            foreach (var booking in hotelBookings)
            {
                var row = new List<string>
                {
                    booking.User.countryName,
                    booking.numSingleRoomsRequired.ToString(),
                    booking.numDoubleRoomsRequired.ToString()
                };
                dataGridView1.Rows.Add(row.ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}