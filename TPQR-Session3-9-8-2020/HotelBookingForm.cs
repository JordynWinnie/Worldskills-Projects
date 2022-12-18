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
    public partial class HotelBookingForm : Form
    {
        private int _hotelId;
        private string _userId;
        private Session3Entities context = new Session3Entities();
        private int singleRoomsReq;
        private int doubleRoomsReq;
        private object _oldValue;

        public HotelBookingForm(int hotelId, string userId)
        {
            _hotelId = hotelId;
            _userId = userId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HotelBookingForm_Load(object sender, EventArgs e)
        {
            var hotelInformation = context.Hotels.Where(x => x.hotelId == _hotelId).First();

            if (!context.Arrivals.Where(x => x.userIdFK == _userId).Any())
            {
                MessageBox.Show("Please confirm arrival details first");
                Close();
            }

            if (context.Hotel_Booking.Where(x => x.userIdFK == _userId).Any())
            {
                MessageBox.Show("You have already booked");
                Close();
            }

            var arrivalInformation = context.Arrivals.Where(x => x.userIdFK == _userId).First();
            hotelNameLbl.Text = $"Hotel Name: {hotelInformation.hotelName}";
            delegatesLbl.Text = $"{arrivalInformation.numberDelegate} delegates (exl. Head)";
            competitorLbl.Text = $"{arrivalInformation.numberCompetitors} competitors";

            var columns = new List<string>
            {
                "Room Type", "Room Rate/Night ($)", "Available No. Of Rooms", "Rooms Required", "Sub-Total"
            };

            foreach (var column in columns)
            {
                hotelDGV.Columns.Add(column, column);
            }

            foreach (DataGridViewColumn col in hotelDGV.Columns)
            {
                col.ReadOnly = true;
            }

            hotelDGV.Columns[3].ReadOnly = false;

            singleRoomsReq = 0;
            doubleRoomsReq = 0;

            singleRoomsReq += arrivalInformation.numberDelegate;
            doubleRoomsReq += arrivalInformation.numberCompetitors / 2;

            if (arrivalInformation.numberCompetitors % 2 != 0)
            {
                singleRoomsReq += 1;
            }

            var singleRow = new List<string>
            {
                "Single", hotelInformation.singleRate.ToString(),
                (hotelInformation.numSingleRoomsTotal - hotelInformation.numSingleRoomsBooked).ToString(),
                singleRoomsReq.ToString(), (singleRoomsReq * hotelInformation.singleRate).ToString()
            };

            var doubleRow = new List<string>
            {
                "Double", hotelInformation.doubleRate.ToString(),
                (hotelInformation.numDoubleRoomsTotal - hotelInformation.numDoubleRoomsBooked).ToString(),
                doubleRoomsReq.ToString(), (doubleRoomsReq * hotelInformation.doubleRate).ToString()
            };

            hotelDGV.Rows.Add(singleRow.ToArray());
            hotelDGV.Rows.Add(doubleRow.ToArray());
            var total = doubleRoomsReq * hotelInformation.doubleRate + singleRoomsReq * hotelInformation.singleRate;
            totalValLBl.Text = $"Total: {total}";

            
        }

        private void hotelDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int newValue = 0;
            if (int.TryParse(hotelDGV[e.ColumnIndex, e.RowIndex].Value.ToString(), out newValue))
            {
                hotelDGV[e.ColumnIndex, e.RowIndex].Value = newValue;
                hotelDGV[4, e.RowIndex].Value = newValue * int.Parse(hotelDGV[1, e.RowIndex].Value.ToString());
            }
            else
            {
                hotelDGV[e.ColumnIndex, e.RowIndex].Value = _oldValue;
            }

            var total = int.Parse(hotelDGV[4, 0].Value.ToString()) + int.Parse(hotelDGV[4, 1].Value.ToString());
            totalValLBl.Text = $"Total: {total}";
        }

        private void hotelDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _oldValue = hotelDGV[e.ColumnIndex, e.RowIndex].Value;
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                var arrivalInformation = context.Arrivals.Where(x => x.userIdFK == _userId).First();
                var hotelInformation = context.Hotels.Where(x => x.hotelId == _hotelId).First();

                var singleRoomsToBook = int.Parse(hotelDGV[3, 0].Value.ToString());
                var doubleRoomsToBook = int.Parse(hotelDGV[3, 1].Value.ToString());

                var hotelSingleCapacity = hotelInformation.numSingleRoomsTotal - hotelInformation.numSingleRoomsBooked;
                var hotelDoubleCapacity = hotelInformation.numDoubleRoomsTotal - hotelInformation.numDoubleRoomsBooked;

                var totalCapacity = singleRoomsToBook + (doubleRoomsToBook * 2);

                if (totalCapacity < (arrivalInformation.numberDelegate + arrivalInformation.numberCompetitors))
                {
                    MessageBox.Show("Not enough rooms for all members");
                    return;
                }

                if (singleRoomsToBook > hotelSingleCapacity)
                {
                    MessageBox.Show("Hotel has insufficient single rooms");
                    return;
                }

                if (doubleRoomsToBook > hotelDoubleCapacity)
                {
                    MessageBox.Show("Hotel has insufficient double rooms");
                    return;
                }

                var insertBooking = new Hotel_Booking
                {
                    hotelIdFK = _hotelId,
                    userIdFK = _userId,
                    numDoubleRoomsRequired = doubleRoomsToBook,
                    numSingleRoomsRequired = singleRoomsToBook,
                };

                hotelInformation.numSingleRoomsBooked += singleRoomsToBook;
                hotelInformation.numDoubleRoomsBooked += doubleRoomsToBook;

                context.Hotel_Booking.Add(insertBooking);
                context.SaveChanges();
                MessageBox.Show("Booking confirmed");
                Close();
            }
        }
    }
}