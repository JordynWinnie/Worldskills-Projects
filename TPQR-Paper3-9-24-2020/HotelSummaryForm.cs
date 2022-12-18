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
    public partial class HotelSummaryForm : Form
    {
        private Session3Entities context = new Session3Entities();

        public HotelSummaryForm()
        {
            InitializeComponent();
        }

        private void HotelSummaryForm_Load(object sender, EventArgs e)
        {
            hotelCb.Items.AddRange(context.Hotels.Select(x => x.hotelName).ToArray());
            hotelCb.SelectedIndex = 0;

            var columns = new List<string>
            {
                "Country", "No Of Single Rooms Booked", "No Of Double Rooms Booked"
            };
            foreach (var column in columns)
            {
                hotelDGV.Columns.Add(column, column);
            }
        }

        private void hotelCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            hotelDGV.Rows.Clear();
            var hotelBookingInfo = from x in context.Hotel_Booking
                                   where x.Hotel.hotelName == hotelCb.SelectedItem.ToString()
                                   select x;

            foreach (var hotel in hotelBookingInfo)
            {
                var row = new List<string>
                {
                    hotel.User.countryName,
                    hotel.numSingleRoomsRequired.ToString(),
                    hotel.numDoubleRoomsRequired.ToString()
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