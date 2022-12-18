using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session2_JordanKhong.Forms
{
    
    public partial class SponsorManagerMainMenuForm : Form
    {
        string _sponsorManagerId = "";
        public SponsorManagerMainMenuForm(string sponsorManagerId)
        {
            _sponsorManagerId = sponsorManagerId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SponsorManagerMainMenuForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                var getSponsorName = context.Users.Where(x => x.userId.Equals(_sponsorManagerId)).Select(x => x.name).First();
                this.Text = getSponsorName;
            }
            
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ViewPackagesForm()).ShowDialog();
            this.Show();
        }

        private void approveBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ApproveBookingsForm()).ShowDialog();
            this.Show();
        }

        private void addSponsorPackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new AddPackagesForm()).ShowDialog();
            this.Show();
        }

        private void viewSponsorshipSummary_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ViewSponsorshipSummaryForm()).ShowDialog();
            this.Show();
        }
    }
}
