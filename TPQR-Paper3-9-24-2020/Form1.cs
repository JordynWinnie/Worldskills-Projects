using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Paper3_9_24_2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void passwordTb_TextChanged(object sender, EventArgs e)
        {
        }

        private void userIdTb_TextChanged(object sender, EventArgs e)
        {
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                var user = context.Users.Where(x => x.userId == userIdTb.Text && x.passwd == passwordTb.Text);
                if (user.Any())
                {
                    if (user.First().userTypeIdFK == 1)
                    {
                        //Admin
                        Hide();
                        new AdminMainMenuForm(user.First().userId).ShowDialog();
                        Show();
                    }
                    else if (user.First().userTypeIdFK == 2)
                    {
                        //Country Rep
                        Hide();
                        new CountryRepMainMenuForm(user.First().userId).ShowDialog();
                        Show();
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new CreateCountryRepForm().ShowDialog();
            Show();
        }
    }
}