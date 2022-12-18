using System;
using System.Windows.Forms;

namespace TPQR_Session5_9_9_2020
{
    public partial class AdminMainMenuForm : Form
    {
        public AdminMainMenuForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new AssignSeating().ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new EnterMarksForm().ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            new ViewResultsForm().ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            new AnalyseResultsForm().ShowDialog();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            new CalculateBonusForm().ShowDialog();
            Show();
        }
    }
}