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
    public partial class HotelBookingForm : Form
    {
        private Session3Entities context = new Session3Entities();
        private string currentUserId;
        private int currentHotelId;
        private Hotel hotelInfo;
        private Arrival userArrivalInfo;
        private int numberOfSingleRooms;
        private int numberOfDoubleRooms;

        public HotelBookingForm(string userId, int hotelId)
        {
            currentUserId = userId;
            currentHotelId = hotelId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HotelBookingForm_Load(object sender, EventArgs e)
        {
            hotelInfo = context.Hotels.Where(x => x.hotelId == currentHotelId).First();
            hotelNameLabel.Text = $"Hotel Name: {hotelInfo.hotelName}";

            userArrivalInfo = context.Arrivals.Where(x => x.userIdFK == currentUserId).FirstOrDefault();

            delegatesNumber.Text = $"{userArrivalInfo.numberDelegate} delegates (Excluding Head)";
            competitorNumber.Text = $"{userArrivalInfo.numberCompetitors} competitors";

            var columns = new List<string>
            {
                "Room Type", "Room Rate/Night ($)", "Available Rooms", "Rooms Required", "Subtotal ($)"
            };

            foreach (var column in columns)
            {
                hotelBookingDGV.Columns.Add(column, column);
            }
            hotelBookingDGV.Rows.Clear();
            var singleRoomRow = new List<string>
            {
                "Single",hotelInfo.singleRate.ToString(),
                (hotelInfo.numSingleRoomsTotal - hotelInfo.numSingleRoomsBooked).ToString(),
            };

            var doubleRoomRow = new List<string>
            {
                "Double",hotelInfo.doubleRate.ToString(),
                (hotelInfo.numDoubleRoomsTotal - hotelInfo.numDoubleRoomsBooked).ToString(),
            };

            if (userArrivalInfo.numberCompetitors % 2 == 0)
            {
                //Even Number of Competitors
                singleRoomRow.Add(userArrivalInfo.numberDelegate.ToString());
                doubleRoomRow.Add((userArrivalInfo.numberCompetitors / 2).ToString());
            }
            else
            {
                //Odd Number of Competitors
                singleRoomRow.Add((userArrivalInfo.numberDelegate + 1).ToString());
                doubleRoomRow.Add((userArrivalInfo.numberCompetitors / 2).ToString());
            }

            hotelBookingDGV.Rows.Add(singleRoomRow.ToArray());
            hotelBookingDGV.Rows.Add(doubleRoomRow.ToArray());
            CalculateSubtotals();
        }

        private void CalculateSubtotals()
        {
            int.TryParse(hotelBookingDGV.Rows[0].Cells[3].Value.ToString(), out numberOfSingleRooms);

            int.TryParse(hotelBookingDGV.Rows[1].Cells[3].Value.ToString(), out numberOfDoubleRooms);

            var costOfSingle = numberOfSingleRooms * hotelInfo.singleRate;
            var costOfDouble = numberOfDoubleRooms * hotelInfo.doubleRate;

            hotelBookingDGV.Rows[0].Cells[4].Value = costOfSingle;
            hotelBookingDGV.Rows[1].Cells[4].Value = costOfDouble;

            totalValueLbl.Text = $"TOTAL ($): {costOfSingle + costOfDouble}";
        }

        private void hotelBookingDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateSubtotals();
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            if (ValidationChecks())
            {
                var insertBooking = new Hotel_Booking
                {
                    hotelIdFK = currentHotelId,
                    userIdFK = currentUserId,
                    numSingleRoomsRequired = numberOfSingleRooms,
                    numDoubleRoomsRequired = numberOfDoubleRooms
                };

                hotelInfo.numSingleRoomsBooked += numberOfSingleRooms;
                hotelInfo.numDoubleRoomsBooked += numberOfDoubleRooms;

                context.Hotel_Booking.Add(insertBooking);
                context.SaveChanges();
                MessageBox.Show("Changes saved");
                Close();
            }
        }

        private bool ValidationChecks()
        {
            var noOfSingleRoomsLeft = hotelInfo.numSingleRoomsTotal - hotelInfo.numSingleRoomsBooked;
            var noOfDoubleRoomsLeft = hotelInfo.numDoubleRoomsTotal - hotelInfo.numDoubleRoomsBooked;

            var totalCapacityReq = userArrivalInfo.numberCompetitors + userArrivalInfo.numberDelegate;
            if (noOfSingleRoomsLeft < numberOfSingleRooms)
            {
                MessageBox.Show("Insufficient Single rooms");
                return false;
            }

            if (noOfDoubleRoomsLeft < numberOfDoubleRooms)
            {
                MessageBox.Show("Insufficient Double rooms");
                return false;
            }

            if (totalCapacityReq > (numberOfSingleRooms + numberOfDoubleRooms * 2))
            {
                MessageBox.Show("No enough rooms booked for your members");
                return false;
            }
            return true;
        }
    }
}