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
    public partial class CountryRepMainMenu : Form
    {
        private string _userId;

        public CountryRepMainMenu(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void confirmArrDetails_Click(object sender, EventArgs e)
        {
            Hide();
            new ConfirmArrivalDetailsForm(_userId).ShowDialog();
            Show();
        }

        private void hotelBookingBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelSelectionForm(_userId).ShowDialog();
            Show();
        }

        private void updateInfoBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new UpdateInfoForm(_userId).ShowDialog();
            Show();
        }
    }
}