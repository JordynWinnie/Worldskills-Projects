using System;
using System.Windows.Forms;

namespace TPQR_Session5_9_4_2020
{
    public partial class AdminMainMenu : Form
    {
        public AdminMainMenu()
        {
            InitializeComponent();
        }

        private void viewResultsBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new ViewResults().ShowDialog();
            Show();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void assignSeatingBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new AssignSeatingForm().ShowDialog();
            Show();
        }

        private void enterMarksBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new EnterMarks().ShowDialog();
            Show();
        }

        private void analyseResultsBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new AnalyseResults().ShowDialog();
            Show();
        }

        private void calculateBonusBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new CalculateBonus().ShowDialog();
            Show();
        }
    }
}