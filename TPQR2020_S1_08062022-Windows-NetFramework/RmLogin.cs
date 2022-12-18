using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR2020_S1_08062022_Windows_NetFramework
{
    public partial class RmLogin : Form
    {
        public RmLogin()
        {
            InitializeComponent();
        }

        private void createAcc_Click(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                var user = context.Users.Where(x=>x.userPw == passwordTb.Text && x.userId == usernameTb.Text).FirstOrDefault();

                if (user != null)
                {
                    if (user.userTypeIdFK == 1)
                    {
                        var form = new ResourceManagement();
                        Hide();
                        form.ShowDialog();
                        Show();
                    }
                    else
                    {
                        MessageBox.Show("Admins are not allowed to log in");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
