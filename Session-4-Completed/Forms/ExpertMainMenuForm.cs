using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session_4_JordanKhong
{
    public partial class ExpertMainMenuForm : Form
    {
        string currentUserId = "";
        public ExpertMainMenuForm(string userID)
        {
            currentUserId = userID;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackCompetitorTraingBtn_Click(object sender, EventArgs e)
        {
            //Shows Competitor training Progress:
            this.Hide();
            (new TrackCompetitorTrainingProgressForm(currentUserId)).ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Shows update for competitor training records:
            this.Hide();
            (new UpdateExpertTrainingRecords()).ShowDialog();
            this.Show();
        }

        private void ExpertMainMenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
