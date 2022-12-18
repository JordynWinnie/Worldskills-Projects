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
    public partial class CountryRepMainMenu : Form
    {
        private string currentUserId;

        public CountryRepMainMenu(string userId)
        {
            currentUserId = userId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CountryRepMainMenu_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new ConfirmArrivalCountryRep(currentUserId).ShowDialog();
            Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }
    }
}