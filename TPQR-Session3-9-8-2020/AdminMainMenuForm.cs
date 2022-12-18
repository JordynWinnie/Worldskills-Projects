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
    public partial class AdminMainMenuForm : Form
    {
        public AdminMainMenuForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void arrSummary_Click(object sender, EventArgs e)
        {
            Hide();
            new AdminArrivalSummaryForm().ShowDialog();
            Show();
        }

        private void hotelBookingBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelSummaryForm().ShowDialog();
            Show();
        }

        private void updateInfoBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new GuestsSummaryForm().ShowDialog();
            Show();
        }
    }
}