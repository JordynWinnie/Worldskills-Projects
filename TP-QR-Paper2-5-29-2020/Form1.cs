using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_QR_Paper2_5_29_2020
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
                var user = context.Users.Where(x => x.userId.Equals(userIDTb.Text)
                && x.passwd.Equals(passwordTb.Text));
                if (user.Any())
                {
                    if (user.First().userTypeIdFK == 1)
                    {
                        //Manager
                        Hide();
                        (new SponsorManagerMainMenu(user.First().userId)).ShowDialog();
                        Show();
                    }
                    else if (user.First().userTypeIdFK == 2)
                    {
                        //Sponsor
                        Hide();
                        (new SponsorMainMenu(user.First().userId)).ShowDialog();
                        Show();
                    }
                    else
                    {
                        //Unauthorised user
                        MessageBox.Show("Only sponsors or sponsor managers can login");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong username or password!");
                }
            }
        }

        private void createNewSponsorAccountBtn_Click(object sender, EventArgs e)
        {
            Hide();
            (new SponsorAccountCreation()).ShowDialog();
            Show();
        }
    }
}