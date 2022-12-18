using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TPQR_Session5_9_4_2020
{
    public partial class LoginForm : Form
    {
        private Session5Entities context = new Session5Entities();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var user = context.Users.Where(x => x.userId == userIdtb.Text && x.passwd == passwordTb.Text);

            if (user.Any())
            {
                //Open Menu:
                Hide();
                new AdminMainMenu().ShowDialog();
                Show();
            }
        }
    }
}