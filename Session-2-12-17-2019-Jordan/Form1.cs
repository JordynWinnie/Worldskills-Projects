using System;
using System.Linq;
using System.Windows.Forms;

namespace Session2__17_12_2019
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                var userCheck = context.Employees.Where(x => x.Username.Equals(usernameTb.Text.Trim())).Select(x => x.Password).First();

                var isAdminCheck = context.Employees.Where(x => x.Username.Equals(usernameTb.Text.Trim())).Select(x => x.isAdmin).First();

                var employeeID = context.Employees.Where(x => x.Username.Equals(usernameTb.Text.Trim())).Select(x => x.ID).First();

                if (userCheck.Equals(passwordTb.Text))
                {
                    if (isAdminCheck == true)
                    {
                        MessageBox.Show("Logged in with Admin");
                        (new ManageEmRequestAccountableParty(employeeID)).ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Logged in without Admin");
                        (new ManageEmRequestAccountableParty(employeeID)).ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Username or password incorrect!");
                }

           
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            usernameTb.Text = "lyn";
            passwordTb.Text = "1234";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            usernameTb.Text = "josefa";
            passwordTb.Text = "1324";
        }
    }
}
