using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session2_8_31_2020
{
    public partial class Form1 : Form
    {
        private Session2Entities context = new Session2Entities();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = context.Users.Where(x => x.userId == userIdTb.Text && x.passwd == passwordTb.Text);
            if (user.Any())
            {
                if (user.First().userTypeIdFK == 1)
                {
                    //manager:
                    Hide();
                    (new SponsorManagerMainMenu()).ShowDialog();
                    Show();
                }
                else
                {
                    //sponsor:
                    Hide();
                    (new SponsorMainMenu(user.First().userId)).ShowDialog();
                    Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            (new SponsorAccountCreation()).ShowDialog();
            Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}