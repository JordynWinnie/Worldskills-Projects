using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Paper3_9_24_2020
{
    public partial class CountryRepMainMenuForm : Form
    {
        private string userId;

        public CountryRepMainMenuForm(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelSelectionForm(userId).ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelSelection(userId).ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new UpdateBooking(userId).ShowDialog();
            Show();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CountryRepMainMenuForm_Load(object sender, EventArgs e)
        {
        }
    }
}