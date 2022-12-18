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
    public partial class CountryRepMainMenu : Form
    {
        private string _userId;

        public CountryRepMainMenu(string userid)
        {
            _userId = userid;
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void hotelBookingBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelSelection(_userId).ShowDialog();
            Show();
        }

        private void confirmArrivalBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new ConfirmArrivalDetails(_userId).ShowDialog();
            Show();
        }

        private void updateInfoBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new UpdateInfoBooking(_userId).ShowDialog();
            Show();
        }
    }
}
