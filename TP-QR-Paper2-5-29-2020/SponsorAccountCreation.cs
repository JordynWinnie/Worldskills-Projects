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
    public partial class SponsorAccountCreation : Form
    {
        public SponsorAccountCreation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createAccBtn_Click(object sender, EventArgs e)
        {
            if (CanLogin())
            {
                MessageBox.Show("User Created!");
                Close();
            }
            else
            {
                MessageBox.Show("Error creating user");
            }
        }

        private bool CanLogin()
        {
            if (userIdTb.Text.Length < 8)
            {
                MessageBox.Show("User ID must have 8 characters or more");
                return false;
            }

            using (var context = new Session2Entities())
            {
                if (context.Users.Where(x => x.userId.Equals(userIdTb.Text)).Any())
                {
                    MessageBox.Show("User ID taken. Please choose another");
                    return false;
                }

                try
                {
                    var user = new User
                    {
                        name = companyNameTb.Text,
                        userId = userIdTb.Text,
                        passwd = passwordTb.Text,
                        userTypeIdFK = 2
                    };

                    context.Users.Add(user);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error creating user");
                    throw;
                }
            }

            return true;
        }
    }
}