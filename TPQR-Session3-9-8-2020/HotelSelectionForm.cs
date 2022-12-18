using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session3_9_8_2020
{
    public partial class HotelSelectionForm : Form
    {
        private string _userId;

        public HotelSelectionForm(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void interContBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(4, _userId).ShowDialog();
            Show();
        }

        private void hotelRoyalBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(6, _userId).ShowDialog();
            Show();
        }

        private void hotelGrandBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(5, _userId).ShowDialog();
            Show();
        }

        private void carltonHotelBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(3, _userId).ShowDialog();
            Show();
        }

        private void panPacBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(2, _userId).ShowDialog();
            Show();
        }

        private void ritzCartonBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(1, _userId).ShowDialog();
            Show();
        }

        private void HotelSelectionForm_Load(object sender, EventArgs e)
        {
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}