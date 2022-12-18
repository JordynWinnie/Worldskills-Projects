using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session3_9_1_2020
{
    public partial class LoginForm : Form
    {
        Session3Entities context = new Session3Entities();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var user = context.Users.Where(x=>x.userId == userIDTb.Text && x.passwd == passwordTb.Text);

            if (user.Any())
            {
                if (user.First().userTypeIdFK == 1)
                {
                    //Admin
                    Hide();
                    new AdminMainMenu().ShowDialog();
                    Show();
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
                MessageBox.Show("Wrong username or password!");
            }
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new NewCountryRepAccountCreation().ShowDialog();
            Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
