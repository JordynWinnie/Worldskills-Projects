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
    public partial class SponsorManagerMainMenu : Form
    {
        public SponsorManagerMainMenu(string userId)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void viewSponsorshipBtn_Click(object sender, EventArgs e)
        {
            Hide();
            (new ViewPackages()).ShowDialog();
            Show();
        }

        private void approveSponsorshipBtn_Click(object sender, EventArgs e)
        {
            Hide();
            (new ApproveSponsorshipBooking()).ShowDialog();
            Show();
        }
    }
}