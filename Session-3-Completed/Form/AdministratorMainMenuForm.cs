using System;
using System.Windows.Forms;

namespace Session3_Jordan_Khong
{
    public partial class AdministratorMainMenuForm : Form
    {
        public AdministratorMainMenuForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = DateTime.Now.ToString();
           }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void arrivalSummaryBtn_Click(object sender, EventArgs e)
        {
            //Opens arrival summary
            this.Hide();
            (new ArrivalSummaryForm()).ShowDialog();
            this.Show();
        }

        private void hotelSummarybtn_Click(object sender, EventArgs e)
        {
            //Opens Hotel Summary:
            this.Hide();
            (new HotelSummaryForm()).ShowDialog();
            this.Show();
        }

        private void guestsSummaryBtn_Click(object sender, EventArgs e)
        {
           //Opens guest summary
            this.Hide();
            (new GuestsSummaryForm()).ShowDialog();
            this.Show();
        }
    }
}
