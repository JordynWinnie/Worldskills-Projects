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
    public partial class AdminMainMenu : Form
    {
        public AdminMainMenu()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void arrivalSummaryBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new ArrivalSummary().ShowDialog();
            Show();
        }

        private void hotelSummaryBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelSummary().ShowDialog();
            Show();
        }

        private void guestSummaryBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new GuestSummary().ShowDialog();
            Show();
        }
    }
}
