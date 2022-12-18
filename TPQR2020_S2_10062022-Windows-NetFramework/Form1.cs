using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR2020_S2_10062022_Windows_NetFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                var user = context.Users.Where(x=>x.userId == userIdTb.Text && x.passwd == passwordTb.Text).FirstOrDefault();

                if (user != null)
                {
                    if (user.userTypeIdFK == 1)
                    {
                        Hide();
                        var form = new SponsorManagerMainMenu();
                        form.ShowDialog();
                        Show();
                    }

                    if (user.userTypeIdFK == 2)
                    {
                        Hide();
                        var form = new SponsorMainMenu(user);
                        form.ShowDialog();
                        Show();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }
            }
        }

        private void createSponsorBtn_Click(object sender, EventArgs e)
        {
            var form = new SponsorAccountCreationForm();
            Hide();
            form.ShowDialog();
            Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
