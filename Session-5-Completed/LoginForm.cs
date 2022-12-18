using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session5
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session5Entities())
            {
                if (context.Users.Where(x=>x.userId.Equals(userIDTb.Text) && x.passwd.Equals(passwordTb.Text)).Any())
                { this.Hide();
                    (new AdminMainMenu()).ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Wrong username or password!");
                }
            }
        }
    }
}
