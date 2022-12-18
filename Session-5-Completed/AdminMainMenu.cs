using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session5
{
    public partial class AdminMainMenu : Form
    {
        public AdminMainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Enter Marks Form:
            this.Hide();
            (new EnterMarksForm()).ShowDialog();
            this.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Analyse Results Form:
            this.Hide();
            (new AnalyzeResultsForm()).ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ViewResultsForm()).ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new CalculateBonusForm()).ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new AssignSeatingForm()).ShowDialog();
            this.Show();
        }
    }
}
