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
    public partial class HotelBooking : Form
    {
        int _hotelId = 0;
        string _userId = string.Empty;
        Session3Entities context = new Session3Entities();
        int singleRoomsRequired = 0;
        int doubleRoomsRequired = 0;
        private int numberOfSingleRmToBook = 0;
        private int numberOfDoubleRmToBook = 0;

        public HotelBooking(int hotelid, string userId)
        {
            _hotelId = hotelid;
            _userId = userId;
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HotelBooking_Load(object sender, EventArgs e)
        {
            
            var arrivalInformation = context.Arrivals.Where(x=>x.userIdFK == _userId).FirstOrDefault();
            var hotelInformation = context.Hotels.Where(x=>x.hotelId == _hotelId).FirstOrDefault();
            if (arrivalInformation == null)
            {
                MessageBox.Show("Please confirm an arrival before booking a hotel");
                Close();
            }
            var bookingInfo = context.Hotel_Booking.Where(x => x.userIdFK == _userId);
            if (bookingInfo.Any())
            {
                MessageBox.Show($"You already booked an arrangement at {bookingInfo.First().Hotel.hotelName}, you may not book another.");
               Close();
               
            }
            hotelNameLbl.Text = $"Hotel Name: {hotelInformation.hotelName}";
            numberOfCompLBl.Text = $"{arrivalInformation.numberCompetitors} competitors";
            numberOfDeleLbl.Text = $"{arrivalInformation.numberDelegate} delegates";

            string[] columns = {"Room Type", "Room Rate/Night", "Available Rooms", "Required Rooms", "Sub Total" };

            foreach (var column in columns)
            {
                roomDGV.Columns.Add(column, column);
            }
            
            singleRoomsRequired += arrivalInformation.numberDelegate;
            doubleRoomsRequired += arrivalInformation.numberCompetitors / 2;

            if (arrivalInformation.numberCompetitors % 2 != 0)
            {
                singleRoomsRequired += 1;
            }

            foreach (DataGridViewColumn item in roomDGV.Columns)
            {
                item.ReadOnly = true;
            }

            roomDGV.Columns[3].ReadOnly = false;
            string[] singleRow = {"Single", hotelInformation.singleRate.ToString(),
                (hotelInformation.numSingleRoomsTotal - hotelInformation.numSingleRoomsBooked).ToString(),
                singleRoomsRequired.ToString(), 
                (hotelInformation.singleRate * singleRoomsRequired).ToString()};

            string[] doubleRow = {"Double", hotelInformation.doubleRate.ToString(),
                (hotelInformation.numDoubleRoomsTotal - hotelInformation.numDoubleRoomsBooked).ToString(),
                doubleRoomsRequired.ToString(),
                (hotelInformation.doubleRate * doubleRoomsRequired).ToString()};

            roomDGV.Rows.Add(singleRow);
            roomDGV.Rows.Add(doubleRow);
            var total = int.Parse(roomDGV[4, 0].Value.ToString()) + int.Parse(roomDGV[4, 1].Value.ToString());
            totalValueLbl.Text = $"Total: ${total}";
        }

        private void roomDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
            var hotelInformation = context.Hotels.Where(x => x.hotelId == _hotelId).FirstOrDefault();
            
            //SingleRoom Subtotal:
            roomDGV[4, 0].Value = int.Parse(roomDGV[3, 0].Value.ToString()) * hotelInformation.singleRate;

            //DoubleRoom Subtotal:
            roomDGV[4, 1].Value = int.Parse(roomDGV[3, 1].Value.ToString()) * hotelInformation.doubleRate;

           var total= int.Parse(roomDGV[4, 0].Value.ToString()) + int.Parse(roomDGV[4, 1].Value.ToString());
            totalValueLbl.Text = $"Total: ${total}";
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                var hotelInformation = context.Hotels.Where(x => x.hotelId == _hotelId).FirstOrDefault();
                var insertBooking = new Hotel_Booking
                {
                    hotelIdFK = hotelInformation.hotelId,
                    numDoubleRoomsRequired = numberOfDoubleRmToBook,
                    numSingleRoomsRequired = numberOfSingleRmToBook,
                    userIdFK = _userId
                };

                hotelInformation.numDoubleRoomsBooked += numberOfDoubleRmToBook;
                hotelInformation.numSingleRoomsBooked += numberOfSingleRmToBook;

                context.Hotel_Booking.Add(insertBooking);
                context.SaveChanges();
                MessageBox.Show("Booking done");
            }
        }

        private bool Validation()
        {
            var hotelInformation = context.Hotels.Where(x => x.hotelId == _hotelId).FirstOrDefault();
            numberOfSingleRmToBook = int.Parse(roomDGV[3, 0].Value.ToString());
            numberOfDoubleRmToBook = int.Parse(roomDGV[3, 1].Value.ToString());


            var remainingDouble = hotelInformation.numDoubleRoomsTotal - hotelInformation.numDoubleRoomsBooked;
            var remainingSingle = hotelInformation.numSingleRoomsTotal - hotelInformation.numSingleRoomsBooked;
            if (numberOfDoubleRmToBook < doubleRoomsRequired || numberOfSingleRmToBook < singleRoomsRequired)
            {
                MessageBox.Show("Not enough rooms are booked for all participants");
                return false;
            }

            if (numberOfDoubleRmToBook > remainingDouble)
            {
                MessageBox.Show("Not enough double rooms available for booking");
                return false;
            }

            if (numberOfSingleRmToBook > remainingSingle)
            {
                MessageBox.Show("Not enough single rooms available for booking");
                return false;
            }

            return true;
        }
    }
}
