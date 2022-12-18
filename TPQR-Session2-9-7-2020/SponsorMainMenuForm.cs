using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session2_9_7_2020
{
    public partial class SponsorMainMenuForm : Form
    {
        private string _userid;

        public SponsorMainMenuForm(string userId)
        {
            _userid = userId;
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bookSponsorshipPackage_Click(object sender, EventArgs e)
        {
            Hide();
            new BookPackagesSponsorForm(_userid).ShowDialog();
            Show();
        }

        private void updateSponsorshipBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new UpdateSponsorshipBookingsForm(_userid).ShowDialog();
            Show();
        }
    }
}