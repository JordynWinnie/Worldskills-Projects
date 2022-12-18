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
    public partial class HotelSummaryForm : Form
    {
        private Session3Entities context = new Session3Entities();

        public HotelSummaryForm()
        {
            InitializeComponent();
        }

        private void HotelSummaryForm_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Country", "Single Rooms Booked", "Double Rooms Booked"
            };

            foreach (var column in columns)
            {
                hotelDGV.Columns.Add(column, column);
            }
            hotelCb.Items.AddRange(context.Hotels.Select(x => x.hotelName).ToArray());
            hotelCb.SelectedIndex = 0;
        }

        private void hotelCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            hotelDGV.Rows.Clear();
            var selectedHotel = hotelCb.SelectedItem.ToString();

            var hotelQuery = context.Hotel_Booking.Where(x => x.Hotel.hotelName == selectedHotel);

            foreach (var booking in hotelQuery)
            {
                var row = new List<string>
                {
                    booking.User.countryName,
                    booking.numSingleRoomsRequired.ToString(),
                    booking.numDoubleRoomsRequired.ToString()
                };

                hotelDGV.Rows.Add(row.ToArray());
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}