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
    public partial class UpdateInfoBooking : Form
    {
        Session3Entities context = new Session3Entities();
        string _userId = string.Empty;
        private int numberOfSingleRmToBook;
        private int numberOfDoubleRmToBook;

        public UpdateInfoBooking(string userid)
        {
            _userId = userid;
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateInfoBooking_Load(object sender, EventArgs e)
        {
            string[] columns = { "Room Type", "Room Rate/Night", "Available Rooms", "Rooms Booked","New No Of Rooms", "Sub Total" };

            foreach (var column in columns)
            {
                hotelDGV.Columns.Add(column,column);
            }

            foreach (DataGridViewColumn item in hotelDGV.Columns)
            {
                item.ReadOnly = true;
            }

            hotelDGV.Columns[4].ReadOnly = false;
            var arrivalDetails = context.Arrivals.Where(x=>x.userIdFK == _userId).First();
            var hotelInformation = context.Hotel_Booking.Where(x=>x.userIdFK == _userId).First();
            hodNUD.Value = arrivalDetails.numberHead;
            competitorsNUD.Value = arrivalDetails.numberCompetitors;
            delegatesNUD.Value = arrivalDetails.numberDelegate;

            string[] singleRow = {"Single", hotelInformation.Hotel.singleRate.ToString(),
                (hotelInformation.Hotel.numSingleRoomsTotal - hotelInformation.Hotel.numSingleRoomsBooked).ToString(),
                hotelInformation.numSingleRoomsRequired.ToString(), hotelInformation.numSingleRoomsRequired.ToString(),
                (hotelInformation.Hotel.singleRate * hotelInformation.numSingleRoomsRequired).ToString()};

            string[] doubleRow = {"Double", hotelInformation.Hotel.doubleRate.ToString(),
                (hotelInformation.Hotel.numDoubleRoomsTotal - hotelInformation.Hotel.numDoubleRoomsBooked).ToString(),
                hotelInformation.numDoubleRoomsRequired.ToString(), hotelInformation.numDoubleRoomsRequired.ToString(),
                (hotelInformation.Hotel.doubleRate *  hotelInformation.numDoubleRoomsRequired).ToString()};

            hotelDGV.Rows.Add(singleRow);
            hotelDGV.Rows.Add(doubleRow);

            var total = int.Parse(hotelDGV[5, 0].Value.ToString()) + int.Parse(hotelDGV[5, 1].Value.ToString());
            totalValueLbl.Text = $"Total: ${total}";
        }

        private void hotelDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var hotelInformation = context.Hotel_Booking.Where(x => x.userIdFK == _userId).First();

            //SingleRoom Subtotal:
            hotelDGV[5, 0].Value = int.Parse(hotelDGV[4, 0].Value.ToString()) * hotelInformation.Hotel.singleRate;

            //DoubleRoom Subtotal:
            hotelDGV[5, 1].Value = int.Parse(hotelDGV[4, 1].Value.ToString()) * hotelInformation.Hotel.doubleRate;

            var total = int.Parse(hotelDGV[5, 0].Value.ToString()) + int.Parse(hotelDGV[5, 1].Value.ToString());
            totalValueLbl.Text = $"Total: ${total}";
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                var hotelInformation = context.Hotel_Booking.Where(x => x.userIdFK == _userId).FirstOrDefault();
                var hotelToChange = context.Hotels.Where(x => x.hotelId == hotelInformation.hotelIdFK).FirstOrDefault();
                var arrivalInformation = context.Arrivals.Where(x => x.userIdFK == _userId).FirstOrDefault();

                arrivalInformation.numberCompetitors = (int)competitorsNUD.Value;
                arrivalInformation.numberDelegate = (int)delegatesNUD.Value;
                arrivalInformation.numberHead = (int)hodNUD.Value;

                hotelToChange.numDoubleRoomsBooked += numberOfDoubleRmToBook - hotelInformation.numDoubleRoomsRequired;
                hotelToChange.numSingleRoomsBooked += numberOfSingleRmToBook - hotelInformation.numSingleRoomsRequired;

                hotelInformation.numDoubleRoomsRequired = numberOfDoubleRmToBook;
                hotelInformation.numSingleRoomsRequired = numberOfSingleRmToBook;

                context.SaveChanges();
                MessageBox.Show("Booking Updated");
                Close();
            }
        }

        private bool Validation()
        {
            
            int singleRoomsRequired = (int)delegatesNUD.Value;
            int doubleRoomsRequired = ((int)competitorsNUD.Value) / 2;

            if (((int)competitorsNUD.Value) % 2 != 0)
            {
                singleRoomsRequired += 1;
            }

            var hotelInformation = context.Hotel_Booking.Where(x => x.userIdFK == _userId).FirstOrDefault();
            numberOfSingleRmToBook = int.Parse(hotelDGV[4, 0].Value.ToString());
            numberOfDoubleRmToBook = int.Parse(hotelDGV[4, 1].Value.ToString());


            var remainingDouble = hotelInformation.Hotel.numDoubleRoomsTotal - hotelInformation.Hotel.numDoubleRoomsBooked;
            var remainingSingle = hotelInformation.Hotel.numSingleRoomsTotal - hotelInformation.Hotel.numSingleRoomsBooked;
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
