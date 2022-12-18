using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Paper1_5_15_2020
{
    public partial class RMLoginForm : Form
    {
        public RMLoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                var userToValidate = context.Users.Where(x =>
                x.userId.Equals(useridTb.Text) && x.userPw.Equals(passwordTb.Text));

                if (userToValidate.Any())
                {
                    if (userToValidate.First().userTypeIdFK != 1)
                    {
                        MessageBox.Show("You are not a manager, not allowed to log in");
                    }
                    else
                    {
                        MessageBox.Show($"Welcome back, {userToValidate.First().userName}!");
                        //Open the reosurce management form
                        Hide();
                        (new ResourceManagementForm()).ShowDialog();
                        Show();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }
            }
        }
    }
}