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
    public partial class AdminMainMenuForm : Form
    {
        private string userId;

        public AdminMainMenuForm(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new ArrivalSummaryForm().ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new HotelSummaryForm().ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new GuestSummaryForm().ShowDialog();
            Show();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AdminMainMenuForm_Load(object sender, EventArgs e)
        {
        }
    }
}