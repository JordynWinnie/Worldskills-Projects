using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session4_9_8_2020
{
    public partial class AdminMainMenuForm : Form
    {
        public AdminMainMenuForm()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void asgnTrainingBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new AdminAssignTrainingForm().ShowDialog();
            Show();
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new OverallTrainingProgressForm().ShowDialog();
            Show();
        }
    }
}