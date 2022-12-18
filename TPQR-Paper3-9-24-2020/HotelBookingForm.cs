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
    public partial class HotelBookingForm : Form
    {
        private string _userId;
        private int _hotelId;
        private Session3Entities context = new Session3Entities();
        private int numberOfSingleRoomsRequired;
        private int numberOfDoubleRoomsRequired;
        private object _oldValue;

        public HotelBookingForm(string userId, int hotelId)
        {
            _userId = userId;
            _hotelId = hotelId;
            InitializeComponent();
        }

        private void HotelBookingForm_Load(object sender, EventArgs e)
        {
            if (!context.Arrivals.Where(x => x.userIdFK == _userId).Any())
            {
                MessageBox.Show("Please confirm an arrival first");
                Close();
                return;
            }

            if (context.Hotel_Booking.Where(x => x.userIdFK == _userId).Any())
            {
                MessageBox.Show("Booking already confirmed");
                Close();
                return;
            }

            var hotelInformation = context.Hotels.Where(x => x.hotelId == _hotelId).First();
            var arrivalInformation = context.Arrivals.Where(x => x.userIdFK == _userId).First();
            hotelNameLbl.Text = $"Hotel Name: {hotelInformation.hotelName}";

            noOfPaxLbl.Text = $"No Of Pax: {arrivalInformation.numberDelegate} delegates (excluding head)";
            competitors_Lbl.Text = $"{arrivalInformation.numberCompetitors} competitors";

            var columns = new List<string>
            {
                "Room Type", "Room Rate/Night ($)", "Available No of Rooms", "Rooms Required", "Sub-Total"
            };

            foreach (var column in columns)
            {
                roomDGV.Columns.Add(column, column);
            }

            numberOfSingleRoomsRequired = 0;
            numberOfDoubleRoomsRequired = 0;

            numberOfSingleRoomsRequired += arrivalInformation.numberDelegate;

            if (arrivalInformation.numberCompetitors % 2 == 0)
            {
                numberOfDoubleRoomsRequired += arrivalInformation.numberCompetitors / 2;
            }
            else
            {
                numberOfDoubleRoomsRequired += arrivalInformation.numberCompetitors / 2;
                numberOfSingleRoomsRequired += 1;
            }

            string[] singleRow = { "Single", $"{hotelInformation.singleRate}",
                $"{hotelInformation.numSingleRoomsTotal - hotelInformation.numSingleRoomsBooked}", $"{numberOfSingleRoomsRequired}",
                $"{hotelInformation.singleRate * numberOfSingleRoomsRequired}"};
            string[] doubleRow = { "Double", $"{hotelInformation.doubleRate}",
                $"{hotelInformation.numDoubleRoomsTotal - hotelInformation.numDoubleRoomsBooked}", $"{numberOfDoubleRoomsRequired}" ,
                $"{hotelInformation.doubleRate * numberOfDoubleRoomsRequired}"};

            roomDGV.Rows.Add(singleRow);
            roomDGV.Rows.Add(doubleRow);

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            var total = 0.0;
            foreach (DataGridViewRow row in roomDGV.Rows)
            {
                var hotelRate = double.Parse(row.Cells[1].Value.ToString());
                var numberBook = double.Parse(row.Cells[3].Value.ToString());

                row.Cells[4].Value = hotelRate * numberBook;

                var val = double.Parse(row.Cells[4].Value.ToString());
                total += val;
            }

            totalVal_Lbl.Text = $"Total: ${total}";
        }

        private void book_Btn_Click(object sender, EventArgs e)
        {
            var numberOfAvailableSingleRooms = int.Parse(roomDGV[2, 0].Value.ToString());
            var numberOfAvailableDoubleRooms = int.Parse(roomDGV[2, 1].Value.ToString());

            var numberofSingleRoomsToBook = int.Parse(roomDGV[3, 0].Value.ToString());
            var numberofDoubleRoomsToBook = int.Parse(roomDGV[3, 1].Value.ToString());

            if (numberofSingleRoomsToBook > numberOfAvailableSingleRooms || numberofDoubleRoomsToBook > numberOfAvailableDoubleRooms)
            {
                MessageBox.Show("Insufficient rooms for booking");
                return;
            }
            var capacity = numberofSingleRoomsToBook + (numberofDoubleRoomsToBook * 2);
            var requiredCapacity = numberOfSingleRoomsRequired + (numberOfDoubleRoomsRequired * 2);
            if (requiredCapacity > capacity)
            {
                MessageBox.Show("Insufficient rooms for current arrival information");
                return;
            }

            var hotelBooking = new Hotel_Booking
            {
                hotelIdFK = _hotelId,
                numDoubleRoomsRequired = (int)numberofDoubleRoomsToBook,
                numSingleRoomsRequired = (int)numberofSingleRoomsToBook,
                userIdFK = _userId,
            };

            var hotelInformation = context.Hotels.Where(x => x.hotelId == _hotelId).First();

            hotelInformation.numSingleRoomsBooked += numberofSingleRoomsToBook;
            hotelInformation.numDoubleRoomsBooked += numberofDoubleRoomsToBook;

            context.Hotel_Booking.Add(hotelBooking);
            context.SaveChanges();
            MessageBox.Show("Booking confirmed");
            Close();
        }

        private void roomDGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _oldValue = roomDGV[e.ColumnIndex, e.RowIndex].Value;
        }

        private void roomDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!double.TryParse(roomDGV[e.ColumnIndex, e.RowIndex].Value.ToString(), out _))
            {
                roomDGV[e.ColumnIndex, e.RowIndex].Value = _oldValue;
            }
            else
            {
                CalculateTotal();
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}