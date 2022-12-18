using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session3_Jordan_Khong
{
    public partial class CountryRepMainMenuForm : Form
    {
        string currentUserId = "";
        public CountryRepMainMenuForm(string _userid)
        {
            currentUserId = _userid;
            InitializeComponent();
            timer1.Start();
        }

        private void CountryRepMainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = DateTime.Now.ToString();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hotelBookingBtn_Click(object sender, EventArgs e)
        {
            //Opens hotel selection
            this.Hide();
            (new HotelSelectionForm(currentUserId)).ShowDialog();
            this.Show();
        }

        private void confirmArrivalBtn_Click(object sender, EventArgs e)
        {
            //Opens Arrival Detail Confirmation
            this.Hide();
            (new ConfirmArrivalDetails(currentUserId)).ShowDialog();
            this.Show();
        }

        private void UpdateBookingBtn_Click(object sender, EventArgs e)
        {
            //Opens update Booking/Info form
            this.Hide();
            (new UpdateInfoForm(currentUserId)).ShowDialog();
            this.Show();
        }
    }
}
