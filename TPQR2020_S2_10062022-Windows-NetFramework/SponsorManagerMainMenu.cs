using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR2020_S2_10062022_Windows_NetFramework
{
    public partial class SponsorManagerMainMenu : Form
    {
        public SponsorManagerMainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bookSponsorPackBtn_Click(object sender, EventArgs e)
        {
            var form = new ViewSponsorshipPackages();
            Hide();
            form.ShowDialog();
            Show();
        }

        private void updateSposorBookingBtn_Click(object sender, EventArgs e)
        {
            var form = new AddPackagesForm();
            Hide();
            form.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new ApproveBookings();
            Hide();
            form.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new ViewSponsorshipSummary();
            Hide();
            form.ShowDialog();
            Show();
        }
    }
}
