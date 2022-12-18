using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session2_9_7_2020
{
    public partial class NewSponsorAccountCreationForm : Form
    {
        public NewSponsorAccountCreationForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void userIdTb_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                if (userIdTb.TextLength < 8)
                {
                    MessageBox.Show("User Id should be 8 characters or longer");
                    return;
                }

                if (context.Users.Where(x => x.userId == userIdTb.Text).Any())
                {
                    MessageBox.Show("User Id taken, please choose another");
                    return;
                }

                if (context.Users.Where(x => x.name == companyNameTb.Text).Any())
                {
                    MessageBox.Show("One company can only have one account");
                    return;
                }

                if (!passwordTb.Text.Equals(rePasswordTb.Text))
                {
                    MessageBox.Show("Passwords do not match");
                    return;
                }

                if (string.IsNullOrWhiteSpace(userIdTb.Text) || string.IsNullOrWhiteSpace(passwordTb.Text) || string.IsNullOrWhiteSpace(rePasswordTb.Text)
                    || string.IsNullOrWhiteSpace(companyNameTb.Text))
                {
                    MessageBox.Show("Please fill up all fields");
                    return;
                }

                var insertUser = new User
                {
                    name = companyNameTb.Text,
                    userId = userIdTb.Text,
                    passwd = passwordTb.Text,
                    userTypeIdFK = 2
                };

                context.Users.Add(insertUser);
                context.SaveChanges();
            }

            MessageBox.Show("User created");
            Close();
        }

        private void NewSponsorAccountCreationForm_Load(object sender, EventArgs e)
        {
        }
    }
}