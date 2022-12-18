using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session2_9_7_2020
{
    public partial class LoginForm : Form
    {
        private Session2Entities context = new Session2Entities();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var user = context.Users.Where(x => x.userId == userIdTb.Text && x.passwd == passwordTb.Text);

            if (user.Any())
            {
                if (user.First().userTypeIdFK == 1)
                {
                    //Manager
                    Hide();
                    new SponsorManagerMainMenuForm().ShowDialog();
                    Show();
                    return;
                }

                if (user.First().userTypeIdFK == 2)
                {
                    //Sponsor
                    Hide();
                    new SponsorMainMenuForm(user.First().userId).ShowDialog();
                    Show();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Username or password is wrong");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new NewSponsorAccountCreationForm().ShowDialog();
            Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }
}