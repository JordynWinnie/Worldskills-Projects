using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session3_9_8_2020
{
    public partial class LoginForm : Form
    {
        private Session3Entities context = new Session3Entities();

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
                    Hide();
                    new AdminMainMenuForm().ShowDialog();
                    Show();
                    //Admin;
                    return;
                }

                if (user.First().userTypeIdFK == 2)
                {
                    //Country Rep
                    Hide();
                    new CountryRepMainMenu(user.First().userId).ShowDialog();
                    Show();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Username or password is wrong!");
            }
        }

        private void creatAccBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new CountryRepAccountCreationForm().ShowDialog();
            Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }
}