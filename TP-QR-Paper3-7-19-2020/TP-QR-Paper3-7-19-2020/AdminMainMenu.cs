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
    public partial class AdminMainMenu : Form
    {
        private string currentUserId;

        public AdminMainMenu(string userId)
        {
            currentUserId = userId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AdminMainMenu_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelSummaryAdmin().ShowDialog();
            Show();
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new ArrivalSummaryAdmin().ShowDialog();
            Show();
        }
    }
}