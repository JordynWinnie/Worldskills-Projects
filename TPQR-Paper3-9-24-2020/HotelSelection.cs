using System;
using System.Windows.Forms;

namespace TPQR_Paper3_9_24_2020
{
    public partial class HotelSelection : Form
    {
        private string _userId;

        public HotelSelection(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void panpacBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(_userId, 2).ShowDialog();
            Show();
        }

        private void hotelGrandPacific_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(_userId, 5).ShowDialog();
            Show();
        }

        private void interContHotelBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(_userId, 4).ShowDialog();
            Show();
        }

        private void carltonHotel_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(_userId, 3).ShowDialog();
            Show();
        }

        private void hotelRoyalQueensBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(_userId, 6).ShowDialog();
            Show();
        }

        private void ritzCarlton_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(_userId, 1).ShowDialog();
            Show();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}