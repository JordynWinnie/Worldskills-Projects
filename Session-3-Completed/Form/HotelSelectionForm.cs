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
    public partial class HotelSelectionForm : Form
    {
        string currentUserId = "";
        public HotelSelectionForm(string _userId)
        {
            currentUserId = _userId;
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
        /// <summary>
        /// All the "points" in the map are essentially pictureboxes with a red backcolor
        /// and a click event that opens the HotelBookingForm with the correct hotel ID
        /// </summary>
        
        private void hotelRoyalQueens_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new HotelBookingForm(6, currentUserId)).ShowDialog();
            this.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new HotelBookingForm(5, currentUserId)).ShowDialog();
            this.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new HotelBookingForm(4, currentUserId)).ShowDialog();
            this.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new HotelBookingForm(3, currentUserId)).ShowDialog();
            this.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new HotelBookingForm(2, currentUserId)).ShowDialog();
            this.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new HotelBookingForm(1, currentUserId)).ShowDialog();
            this.Show();
        }

        private void HotelSelectionForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_SizeChanged(object sender, EventArgs e)
        {
            if (pictureBox3.Width == pictureBox3.Height) return;

            if (pictureBox3.Width > pictureBox3.Height)
            {
                pictureBox3.Height = pictureBox3.Width;
            }
            else
            {
                pictureBox3.Width = pictureBox3.Height;
            }
        }
    }
}
