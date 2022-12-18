using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_QR_Paper2_5_29_2020
{
    public partial class SponsorMainMenu : Form
    {
        private string _currentUserID;

        public SponsorMainMenu(string userIDFK)
        {
            _currentUserID = userIDFK;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bookSponsorShipBtn_Click(object sender, EventArgs e)
        {
            Hide();
            (new BookPackages(_currentUserID)).ShowDialog();
            Show();
        }

        private void SponsorMainMenu_Load(object sender, EventArgs e)
        {
        }

        private void updateSponsorshipBtn_Click(object sender, EventArgs e)
        {
            Hide();
            (new UpdateBooking(_currentUserID)).ShowDialog();
            Show();
        }
    }
}