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
    public partial class UpdateBooking : Form
    {
        private Session3Entities context = new Session3Entities();
        private string _userId;
        private object _oldValue;
        private int numberOfSingleRoomsRequired;
        private int numberOfDoubleRoomsRequired;

        public UpdateBooking(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void UpdateBooking_Load(object sender, EventArgs e)
        {
            var arrivalInformationCheck = context.Arrivals.Where(x => x.userIdFK == _userId).Any();
            var hotelBookingInformationCheck = context.Hotel_Booking.Where(x => x.userIdFK == _userId).Any();
            if (!arrivalInformationCheck)
            {
                MessageBox.Show("Please confirm an arrival first");
                Close();
                return;
            }

            if (!hotelBookingInformationCheck)
            {
                MessageBox.Show("Please confirm an hotel booking first");
                Close();
                return;
            }

            var arrivalInformation = context.Arrivals.Where(x => x.userIdFK == _userId).First();
            var hotelBookingInformation = context.Hotel_Booking.Where(x => x.userIdFK == _userId).First();
            var hotelInformation = context.Hotels.Where(x => x.hotelId == hotelBookingInformation.hotelIdFK).First();

            HOD_NUD.Value = arrivalInformation.numberHead;
            delegate_NUD.Value = arrivalInformation.numberDelegate;
            competitors_NUD.Value = arrivalInformation.numberCompetitors;

            var columns = new List<string>
            {
                "Room Type", "Room Rate/Night ($)", "Available No of Rooms", "Rooms Booked", "New Number of Rooms", "Sub-Total"
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
                $"{hotelInformation.numSingleRoomsTotal - hotelInformation.numSingleRoomsBooked}", $"{hotelBookingInformation.numSingleRoomsRequired}",
                 $"{hotelBookingInformation.numSingleRoomsRequired}", $"{hotelInformation.singleRate * hotelBookingInformation.numSingleRoomsRequired}"};
            string[] doubleRow = { "Double", $"{hotelInformation.doubleRate}",
                $"{hotelInformation.numDoubleRoomsTotal - hotelInformation.numDoubleRoomsBooked}", $"{hotelBookingInformation.numDoubleRoomsRequired}" ,
                $"{hotelBookingInformation.numDoubleRoomsRequired}",
                $"{hotelInformation.doubleRate * hotelBookingInformation.numDoubleRoomsRequired}"};

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
                var numberBook = double.Parse(row.Cells[4].Value.ToString());

                row.Cells[5].Value = hotelRate * numberBook;

                var val = double.Parse(row.Cells[5].Value.ToString());
                total += val;
            }

            numberOfSingleRoomsRequired = 0;
            numberOfDoubleRoomsRequired = 0;

            numberOfSingleRoomsRequired += (int)delegate_NUD.Value;

            if ((int)competitors_NUD.Value % 2 == 0)
            {
                numberOfDoubleRoomsRequired += (int)competitors_NUD.Value / 2;
            }
            else
            {
                numberOfDoubleRoomsRequired += (int)competitors_NUD.Value / 2;
                numberOfSingleRoomsRequired += 1;
            }

            totalVal_Lbl.Text = $"Total: ${total}";
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

        private void update_Btn_Click(object sender, EventArgs e)
        {
            var arrivalInformation = context.Arrivals.Where(x => x.userIdFK == _userId).First();
            var hotelBookingInformation = context.Hotel_Booking.Where(x => x.userIdFK == _userId).First();
            var hotelInformation = context.Hotels.Where(x => x.hotelId == hotelBookingInformation.hotelIdFK).First();

            var numberOfAvailableSingleRooms = int.Parse(roomDGV[2, 0].Value.ToString());
            var numberOfAvailableDoubleRooms = int.Parse(roomDGV[2, 1].Value.ToString());

            var oldNumberofSingleRoomsToBook = int.Parse(roomDGV[3, 0].Value.ToString());
            var oldNumberofDoubleRoomsToBook = int.Parse(roomDGV[3, 1].Value.ToString());

            var numberofSingleRoomsToBook = int.Parse(roomDGV[4, 0].Value.ToString());
            var numberofDoubleRoomsToBook = int.Parse(roomDGV[4, 1].Value.ToString());

            if ((numberofSingleRoomsToBook - oldNumberofSingleRoomsToBook) > numberOfAvailableSingleRooms
                || (numberofDoubleRoomsToBook - oldNumberofDoubleRoomsToBook) > numberOfAvailableDoubleRooms)
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

            hotelInformation.numSingleRoomsBooked += numberofSingleRoomsToBook - oldNumberofSingleRoomsToBook;
            hotelInformation.numDoubleRoomsBooked += numberofDoubleRoomsToBook - oldNumberofDoubleRoomsToBook;

            hotelBookingInformation.numSingleRoomsRequired = numberofSingleRoomsToBook;
            hotelBookingInformation.numDoubleRoomsRequired = numberofDoubleRoomsToBook;

            arrivalInformation.numberCompetitors = (int)competitors_NUD.Value;
            arrivalInformation.numberDelegate = (int)delegate_NUD.Value;
            arrivalInformation.numberHead = (int)HOD_NUD.Value;

            context.SaveChanges();
            MessageBox.Show("Booking updated");
            Close();
        }

        private void delegate_NUD_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void HOD_NUD_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void competitors_NUD_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}