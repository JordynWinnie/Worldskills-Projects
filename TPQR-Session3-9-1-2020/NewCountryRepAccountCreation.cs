using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session3_9_1_2020
{
    public partial class NewCountryRepAccountCreation : Form
    {
        Session3Entities context = new Session3Entities();
        public NewCountryRepAccountCreation()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                var insertUser = new User
                {
                    countryName = countryCb.SelectedItem.ToString(),
                    passwd = passwordTb.Text,
                    userId = userIDTb.Text,
                    userTypeIdFK = 2
                };

                context.Users.Add(insertUser);
                context.SaveChanges();
                MessageBox.Show("User Registered");
                Close();
            }
        }

        private bool Validation()
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9]*$");
            
            if (regex.Match(userIDTb.Text).Value.Length == 0)
            {
                MessageBox.Show("User ID should only contain upper/lower case letters and numbers");
                return false;
            }
            if (userIDTb.TextLength < 8)
            {
                MessageBox.Show("User ID should contain 8 or more characters");
                return false;
            }

            if (!passwordTb.Text.Equals(rePwTb.Text))
            {
                MessageBox.Show("Passwords do not match");
                return false;
            }

            if (string.IsNullOrEmpty(userIDTb.Text) || string.IsNullOrEmpty(passwordTb.Text)
                || string.IsNullOrEmpty(rePwTb.Text))
            {
                MessageBox.Show("One or more fields are empty");
                return false;
            }

            return true;
        }

        private void NewCountryRepAccountCreation_Load(object sender, EventArgs e)
        {
            string[] countries ={"Brunei", "Cambodia",
"Indonesia", "Laos", "Malaysia", "Myanmar", "Philippines", "Singapore", "Thailand", "Vietnam"};

            var finalCountryList = new List<string>();
            foreach (var country in countries)
            {
                if (!context.Users.Where(x => x.countryName == country && x.userTypeIdFK == 2).Any())
                {
                    finalCountryList.Add(country);
                } 
            }

            countryCb.Items.AddRange(finalCountryList.ToArray());
            countryCb.SelectedIndex = 0;
        }
    }
}
