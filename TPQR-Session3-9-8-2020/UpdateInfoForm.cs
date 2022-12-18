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
    public partial class UpdateInfoForm : Form
    {
        private string _userId;
        private Session3Entities context = new Session3Entities();
        private int singleRoomsReq;
        private int doubleRoomsReq;
        private object _oldValue;

        public UpdateInfoForm(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateInfoForm_Load(object sender, EventArgs e)
        {
            if (!context.Arrivals.Where(x => x.userIdFK == _userId).Any())
            {
                MessageBox.Show("Please confirm arrival first");
                Close();
                return;
            }

            if (!context.Hotel_Booking.Where(x => x.userIdFK == _userId).Any())
            {
                MessageBox.Show("Please confirm hotel booking first");
                Close();
                return;
            }

            var columns = new List<string>
            {
                "Room Type", "Room Rate/Night ($)", "Available No. Of Rooms", "Rooms Booked", "New Rooms Required", "Sub-Total"
            };

            foreach (var column in columns)
            {
                hotelDGV.Columns.Add(column, column);
            }

            foreach (DataGridViewColumn col in hotelDGV.Columns)
            {
                col.ReadOnly = true;
            }

            hotelDGV.Columns[4].ReadOnly = false;

            var arrivalInformation = context.Arrivals.Where(x => x.userIdFK == _userId).First();
            var hotelId = context.Hotel_Booking.Where(x => x.userIdFK == arrivalInformation.userIdFK).First().hotelIdFK;
            var hotelInformation = context.Hotels.Where(x => x.hotelId == hotelId).First();
            var hotelBookingInformation = context.Hotel_Booking.Where(x => x.userIdFK == arrivalInformation.userIdFK).First();
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
                hotelBookingInformation.numSingleRoomsRequired.ToString(), hotelBookingInformation.numSingleRoomsRequired.ToString(),
                (singleRoomsReq * hotelInformation.singleRate).ToString()
            };

            var doubleRow = new List<string>
            {
                "Double", hotelInformation.doubleRate.ToString(),
                (hotelInformation.numDoubleRoomsTotal - hotelInformation.numDoubleRoomsBooked).ToString(),
                hotelBookingInformation.numDoubleRoomsRequired.ToString(), hotelBookingInformation.numDoubleRoomsRequired.ToString(),
                (doubleRoomsReq * hotelInformation.doubleRate).ToString()
            };

            hotelDGV.Rows.Add(singleRow.ToArray());
            hotelDGV.Rows.Add(doubleRow.ToArray());
            var total = doubleRoomsReq * hotelInformation.doubleRate + singleRoomsReq * hotelInformation.singleRate;
            totalValLBl.Text = $"Total: {total}";

            HOD_NUD.Value = arrivalInformation.numberHead;
            delegatesNUD.Value = arrivalInformation.numberDelegate;
            competitorsNUD.Value = arrivalInformation.numberCompetitors;
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                var arrivalInformation = context.Arrivals.Where(x => x.userIdFK == _userId).First();
                var hotelId = context.Hotel_Booking.Where(x => x.userIdFK == arrivalInformation.userIdFK).First().hotelIdFK;
                var hotelInformation = context.Hotels.Where(x => x.hotelId == hotelId).First();
                var hotelBookingInformation = context.Hotel_Booking.Where(x => x.userIdFK == arrivalInformation.userIdFK).First();

                var singleRoomsToBook = int.Parse(hotelDGV[3, 0].Value.ToString());
                var doubleRoomsToBook = int.Parse(hotelDGV[3, 1].Value.ToString());

                var newSingleRoomsToBook = int.Parse(hotelDGV[4, 0].Value.ToString());
                var newDoubleRoomsToBook = int.Parse(hotelDGV[4, 1].Value.ToString());

                var hotelSingleCapacity = hotelInformation.numSingleRoomsTotal - hotelInformation.numSingleRoomsBooked;
                var hotelDoubleCapacity = hotelInformation.numDoubleRoomsTotal - hotelInformation.numDoubleRoomsBooked;

                var totalCapacity = newSingleRoomsToBook + (newDoubleRoomsToBook * 2);

                if (totalCapacity < (competitorsNUD.Value + delegatesNUD.Value))
                {
                    MessageBox.Show("Not enough rooms for all members");
                    return;
                }

                if ((newSingleRoomsToBook - singleRoomsToBook) > hotelSingleCapacity)
                {
                    MessageBox.Show("Hotel has insufficient single rooms");
                    return;
                }

                if ((newDoubleRoomsToBook - doubleRoomsToBook) > hotelDoubleCapacity)
                {
                    MessageBox.Show("Hotel has insufficient double rooms");
                    return;
                }

                hotelInformation.numSingleRoomsBooked += newSingleRoomsToBook - singleRoomsToBook;
                hotelInformation.numDoubleRoomsBooked += newDoubleRoomsToBook - doubleRoomsToBook;

                hotelBookingInformation.numSingleRoomsRequired += newSingleRoomsToBook - singleRoomsToBook;
                hotelBookingInformation.numDoubleRoomsRequired += newDoubleRoomsToBook - doubleRoomsToBook;

                arrivalInformation.numberCompetitors = (int)competitorsNUD.Value;
                arrivalInformation.numberDelegate = (int)delegatesNUD.Value;
                arrivalInformation.numberHead = (int)HOD_NUD.Value;

                context.SaveChanges();
                MessageBox.Show("Booking confirmed");
                Close();
            }
        }

        private void hotelDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _oldValue = hotelDGV[e.ColumnIndex, e.RowIndex].Value;
        }

        private void hotelDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int newValue = 0;
            if (int.TryParse(hotelDGV[e.ColumnIndex, e.RowIndex].Value.ToString(), out newValue))
            {
                hotelDGV[e.ColumnIndex, e.RowIndex].Value = newValue;
                hotelDGV[5, e.RowIndex].Value = newValue * int.Parse(hotelDGV[1, e.RowIndex].Value.ToString());
            }
            else
            {
                hotelDGV[e.ColumnIndex, e.RowIndex].Value = _oldValue;
            }

            var total = int.Parse(hotelDGV[5, 0].Value.ToString()) + int.Parse(hotelDGV[5, 1].Value.ToString());
            totalValLBl.Text = $"Total: {total}";
        }
    }
}