using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session5_9_9_2020
{
    public partial class LoginForm : Form
    {
        private Session5Entities context = new Session5Entities();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var user = context.Users.Where(x => x.userId == userIdTb.Text && x.passwd == passwordTb.Text);
            if (user.Any())
            {
                //Login:
                Hide();
                new AdminMainMenuForm().ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }
    }
}