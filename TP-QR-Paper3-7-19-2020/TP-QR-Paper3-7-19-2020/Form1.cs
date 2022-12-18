using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_QR_Paper3_7_19_2020
{
    public partial class Form1 : Form
    {
        private Session3Entities context = new Session3Entities();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new Country_Rep_Account_Creation().ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userToValidate = context.Users.Where(x => x.userId == userIdTb.Text && x.passwd == passwordTb.Text);

            if (userToValidate.Any())
            {
                switch (userToValidate.First().userTypeIdFK)
                {
                    case 1:
                        //Admin
                        Hide();
                        new AdminMainMenu(userToValidate.First().userId).ShowDialog();
                        Show();
                        break;

                    case 2:
                        //Country Rep
                        Hide();
                        new CountryRepMainMenu(userToValidate.First().userId).ShowDialog();
                        Show();
                        break;

                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Username or password is wrong!");
            }
        }
    }
}