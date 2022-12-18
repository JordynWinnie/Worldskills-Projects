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
    public partial class HotelSummary : Form
    {
        Session3Entities context = new Session3Entities();
        public HotelSummary()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HotelSummary_Load(object sender, EventArgs e)
        {
            hotelCb.Items.AddRange(context.Hotels.Select(x=>x.hotelName).ToArray());
           

            string[] columns = {"Country", "Number of Single Rooms booked", "Number of double rooms booked" };

            foreach (var column in columns)
            {
                hotelDGV.Columns.Add(column,column);
            }
             hotelCb.SelectedIndex = 0;
            RefreshTable();
        }

        private void RefreshTable()
        {
            hotelDGV.Rows.Clear();
            var hotelSummary = from x in context.Hotel_Booking
                               where x.Hotel.hotelName == hotelCb.SelectedItem.ToString()
                               select x;

            foreach (var summary in hotelSummary)
            {
                var row = new List<string>
                {
                    summary.User.countryName,
                    summary.numSingleRoomsRequired.ToString(),
                    summary.numDoubleRoomsRequired.ToString()
                };

                hotelDGV.Rows.Add(row.ToArray());
            }
        }

        private void hotelCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTable();
        }
    }
}
