using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session3_Jordan_Khong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                #region Login Logic:
                if (context.Users.Where(x=>x.userId.Equals(userIDTb.Text) && x.passwd.Equals(passwordTb.Text)).Any())
                {
                    if (context.Users.Where(x => x.userId.Equals(userIDTb.Text) && x.passwd.Equals(passwordTb.Text)).Select(x=>x.userTypeIdFK).First() == 1)
                    {
                        //Login as admin
                        this.Hide();
                        (new AdministratorMainMenuForm()).ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        //Login as Country Rep
                        this.Hide();
                        (new CountryRepMainMenuForm(userIDTb.Text)).ShowDialog();
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong username or password!");
                }
                #endregion
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            this.Hide();

            (new CreateCountryRepForm()).ShowDialog();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
