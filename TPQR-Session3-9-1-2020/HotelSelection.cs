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
    public partial class HotelSelection : Form
    {
        private string _userID;

        public HotelSelection(string userid)
        {
            _userID = userid;
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void royalQueensBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBooking(6, _userID).ShowDialog();
            Show();
        }

        private void intercontinentalBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBooking(4, _userID).ShowDialog();
            Show();
        }

        private void grandPacificButton_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBooking(5, _userID).ShowDialog();
            Show();
        }

        private void carltonHotelBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBooking(3, _userID).ShowDialog();
            Show();
        }

        private void panPacBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBooking(2, _userID).ShowDialog();
            Show();
        }

        private void ritzCarltonBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBooking(1, _userID).ShowDialog();
            Show();
        }

        private void HotelSelection_Load(object sender, EventArgs e)
        {

        }
    }
}
