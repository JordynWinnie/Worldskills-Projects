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
    public partial class ExpertMainMenuForm : Form
    {
        private string _userId;

        public ExpertMainMenuForm(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateRecBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new UpdateExpertTrainingForm().ShowDialog();
            Show();
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new CompetitorProgressTrackingForm(_userId).ShowDialog();
            Show();
        }
    }
}