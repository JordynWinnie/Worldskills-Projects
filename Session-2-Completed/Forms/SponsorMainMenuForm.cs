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
    public partial class SponsorMainMenuForm : Form
    {
        string _sponsorID = "";
        public SponsorMainMenuForm(string sponsorID)
        {
            _sponsorID = sponsorID;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SponsorMainMenuForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                var getSponsorName = context.Users.Where(x => x.userId.Equals(_sponsorID)).Select(x => x.name).First();
                this.Text = getSponsorName;
            }
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            //open booking form with sponsorID:
            this.Hide();
            (new BookPackageForm(_sponsorID)).ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //open booking form with sponsorID:
            this.Hide();
            (new UpdateBookingForm(_sponsorID)).ShowDialog();
            this.Show();
        }
    }
}
