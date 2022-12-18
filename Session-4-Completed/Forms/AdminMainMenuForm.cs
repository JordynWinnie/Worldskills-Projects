using Session_4_JordanKhong.Forms;
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
    public partial class AdminMainMenuForm : Form
    {

        public AdminMainMenuForm(string _userId)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Shows Assign training form:
            this.Hide();
            (new AdminAssignTrainingForm()).ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Shows overall progress form:
            this.Hide();
            (new OverallProgressForm()).ShowDialog();
            this.Show();
        }
    }
}
