using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Paper5_9_23_2020
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

        private void assignSeating_Click(object sender, EventArgs e)
        {
            Hide();
            (new AssignSeating()).ShowDialog();
            Show();
        }

        private void enterMarksBtn_Click(object sender, EventArgs e)
        {
            Hide();
            (new EnterMarksForm()).ShowDialog();
            Show();
        }

        private void viewResults_Click(object sender, EventArgs e)
        {
            Hide();
            (new ViewResultsForm()).ShowDialog();
            Show();
        }
    }
}