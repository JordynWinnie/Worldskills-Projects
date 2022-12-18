using Session_2_1_5_2020.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session_2_1_5_2020
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                if (context.Employees.Where(x=>x.Username.Equals(UsernameTb.Text) && x.Password.Equals(PasswordTb.Text)).FirstOrDefault() != null)
                {
                    var employeeId = context.Employees.Where(x => x.Username.Equals(UsernameTb.Text) && x.Password.Equals(PasswordTb.Text)).Select(x => x.ID).FirstOrDefault();
                    if (context.Employees.Where(x => x.Username.Equals(UsernameTb.Text) && x.Password.Equals(PasswordTb.Text)).Select(x=>x.isAdmin).FirstOrDefault() == true)
                    {
                        //ADMIN LOGIN
                        MessageBox.Show("Logged in as admin");
                        (new MangingEmRequestsForm()).ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Logged in as non admin");
                        //NON ADMIN LOGIN
                        (new AccountablePartyForm(employeeId)).ShowDialog();
                    }
                }
                else
                {
                    //WRONG PASSWORD
                    MessageBox.Show("Wrong username or password!");
                }
            }
        }
    }
}
