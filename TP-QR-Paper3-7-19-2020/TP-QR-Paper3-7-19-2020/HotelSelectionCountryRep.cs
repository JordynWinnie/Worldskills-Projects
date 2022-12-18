using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_QR_Paper3_7_19_2020
{
    public partial class HotelSelectionCountryRep : Form
    {
        private string currentUserId;

        public HotelSelectionCountryRep(string userId)
        {
            currentUserId = userId;
            InitializeComponent();
        }

        private void HotelRoyalQueens_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(currentUserId, 6).ShowDialog();
            Show();
        }

        private void HotelGrandPacific_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(currentUserId, 5).ShowDialog();
            Show();
        }

        private void InterContinentalSG_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(currentUserId, 4).ShowDialog();
            Show();
        }

        private void CarltonHotel_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(currentUserId, 3).ShowDialog();
            Show();
        }

        private void PanPacificSG_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(currentUserId, 2).ShowDialog();
            Show();
        }

        private void RitzCarltonSG_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelBookingForm(currentUserId, 1).ShowDialog();
            Show();
        }

        private void HotelSelectionCountryRep_Load(object sender, EventArgs e)
        {
        }
    }
}