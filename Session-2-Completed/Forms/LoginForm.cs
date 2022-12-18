using Session2_JordanKhong.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session2_JordanKhong
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                //Login Logic:
                if (context.Users.Where(x=>x.userId.Equals(userTb.Text) && x.passwd.Equals(passwordTb.Text)).Select(x=>x).FirstOrDefault() == null)
                {
                    MessageBox.Show("Wrong username or password!");
                }
                else
                {
                    var userType = context.Users.Where(x => x.userId.Equals(userTb.Text) && x.passwd.Equals(passwordTb.Text)).Select(x => x.userTypeIdFK).FirstOrDefault();
                    var getUserId = context.Users.Where(x => x.userId.Equals(userTb.Text) && x.passwd.Equals(passwordTb.Text)).Select(x => x.userId).FirstOrDefault();
                    if (userType == 1)
                    {
                        //Login Manager
                        this.Hide();
                        (new SponsorManagerMainMenuForm(getUserId)).ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        //Login Sponsor
                        this.Hide();
                        (new SponsorMainMenuForm(getUserId)).ShowDialog();
                        this.Show();
                    }
                }
            }
        }

        private void createNewAccountBtn_Click(object sender, EventArgs e)
        {
            //show account creation form:
            this.Hide();
            (new SponsorAccountCreationForm()).ShowDialog();
            this.Show();
        }
    }
}
