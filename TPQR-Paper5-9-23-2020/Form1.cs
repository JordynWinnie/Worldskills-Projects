using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Paper5_9_23_2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session5Entities())
            {
                var user = context.Users.Where(x => x.userId == userIdTb.Text && x.passwd == x.passwd);

                if (user.Any())
                {
                    Hide();
                    (new AdminMainMenuForm()).ShowDialog();
                    Show();
                }
                else
                {
                    MessageBox.Show("Username or password is wrong!");
                    return;
                }
            }
        }
    }
}