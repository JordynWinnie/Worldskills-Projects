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
    public partial class SponsorAccountCreationForm : Form
    {
        public SponsorAccountCreationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createAccBtn_Click(object sender, EventArgs e)
        {
            if (companyNameTB.Text == String.Empty || passwordTb.Text == String.Empty 
                || reEnterPassTb.Text == String.Empty || userIdTb.Text == String.Empty)
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }

            if (userIdTb.TextLength < 8)
            {
                MessageBox.Show("User ID should be 8 characters or more");
                return;
            }

            if (!passwordTb.Text.Equals(reEnterPassTb.Text))
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            using (var context = new Session2Entities())
            {
                if (context.Users.Where(x=>x.userId == userIdTb.Text).Any())
                {
                    MessageBox.Show("User ID has been taken");
                    return;
                }

                var newAccount = new User
                {
                    userTypeIdFK = 2,
                    name = companyNameTB.Text,
                    passwd = passwordTb.Text,
                    userId = userIdTb.Text
                };

                context.Users.Add(newAccount);
                context.SaveChanges();

                MessageBox.Show("Sponsor Account Created");
                Close();
            }
        }
    }
}
