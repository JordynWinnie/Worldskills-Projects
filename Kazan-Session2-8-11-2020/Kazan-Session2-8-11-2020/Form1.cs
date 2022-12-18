using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kazan_Session2_8_11_2020
{
    public partial class Form1 : Form
    {
        private Session2Entities Session2Entities = new Session2Entities();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = Session2Entities.Employees.Where(x => x.Username == usernameTb.Text && x.Password == passwordTb.Text);
            if (user.Any())
            {
                if (user.First().Username == null)
                {
                    MessageBox.Show("No username, you may not log in");
                    return;
                }

                if (user.First().isAdmin != null)
                {
                    //Login to admin board:
                    Hide();
                    (new Managing_EM_Requests_by_Maintenance_Manager()).ShowDialog();
                    Show();
                }
                else
                {
                    Hide();
                    (new Managing_EM_Requests_by_Accountable_Party(user.First().ID)).ShowDialog();
                    Show();
                    //Login to user board:
                }
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}