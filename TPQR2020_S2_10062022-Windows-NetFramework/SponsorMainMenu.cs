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
    public partial class SponsorMainMenu : Form
    {
        private User currentUser;
        public SponsorMainMenu(User user)
        {
            this.currentUser = user;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SponsorMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void bookSponsorPackBtn_Click(object sender, EventArgs e)
        {
            var form = new BookPackage(currentUser);
            Hide();
            form.ShowDialog();
            Show();
        }

        private void updateSposorBookingBtn_Click(object sender, EventArgs e)
        {
            var form = new UpdateSponsorshipBookings(currentUser);
            Hide();
            form.ShowDialog();
            Show();
        }
    }
}
