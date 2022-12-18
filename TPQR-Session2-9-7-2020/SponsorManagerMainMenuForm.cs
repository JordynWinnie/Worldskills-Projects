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
    public partial class SponsorManagerMainMenuForm : Form
    {
        public SponsorManagerMainMenuForm()
        {
            InitializeComponent();
        }

        private void addSponsorshipPackages_Click(object sender, EventArgs e)
        {
            Hide();
            new AddPackagesForm().ShowDialog();
            Show();
        }

        private void viewSponPackageBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new ViewPackagesForm().ShowDialog();
            Show();
        }

        private void approveSponBkBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new ApproveBookingsForm().ShowDialog();
            Show();
        }

        private void viewSponSummary_Click(object sender, EventArgs e)
        {
            Hide();
            new ViewSponsorshipSummaryForm().ShowDialog();
            Show();
        }
    }
}