using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session2_8_31_2020
{
    public partial class SponsorAccountCreation : Form
    {
        private Session2Entities context = new Session2Entities();
        public SponsorAccountCreation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Verification())
            {
                var insertUser = new User
                {
                    name = companyNameTb.Text,
                    passwd = passwordTb.Text,
                    userId =useridTb.Text,
                    userTypeIdFK = 2
                };

                context.Users.Add(insertUser);
                context.SaveChanges();
                MessageBox.Show("Account Created");
                Close();
            }
        }

        private bool Verification()
        {
            if (useridTb.Text.Equals(string.Empty) || passwordTb.Text.Equals(string.Empty) ||
                rePwTb.Text.Equals(string.Empty) || companyNameTb.Text.Equals(string.Empty))
            {
                MessageBox.Show("One or more fields are not filled in");
                return false;
            }
            if (!passwordTb.Text.Equals(rePwTb.Text))
            {
                MessageBox.Show("Passwords do not match");
                return false;
            }

            if (useridTb.Text.Length < 8)
            {
                MessageBox.Show("User Id must be 8 charatcers or longer");
                return false;
            }

            if (context.Users.Where(x=>x.userId == useridTb.Text).Any())
            {
                MessageBox.Show("User Id taken, please choose another");
                return false;
            }

            if (context.Users.Where(x=>x.name.ToLower() == companyNameTb.Text.ToLower()).Any())
            {
                MessageBox.Show("One Company can only have one account");
                return false;
            }

            return true;
        }
    }
}
