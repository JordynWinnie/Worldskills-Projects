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

namespace TPQR_Session3_9_8_2020
{
    public partial class CountryRepAccountCreationForm : Form
    {
        private Session3Entities context = new Session3Entities();

        public CountryRepAccountCreationForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void CountryRepAccountCreationForm_Load(object sender, EventArgs e)
        {
            var countryList = new List<string>
            {
                "Indonesia", "Thailand",
                "Singapore", "Malaysia", "Philippines"
                , "Vietnam", "Brunei", "Myanmar", "Cambodia", "Laos"
            };
            var finalCountryList = new List<string>();
            foreach (var country in countryList)
            {
                if (!context.Users.Where(x => x.countryName == country && x.userTypeIdFK == 2).Any())
                {
                    finalCountryList.Add(country);
                }
            }
            countryCb.Items.AddRange(finalCountryList.ToArray());
            countryCb.SelectedIndex = 0;
        }

        private void createAccBtn_Click(object sender, EventArgs e)
        {
            var regEx = new Regex(@"^[A-Za-z0-9]+$");

            if (!regEx.Match(userIdTb.Text).Success)
            {
                MessageBox.Show("ID should only have upper case, lower case and numbers");
                return;
            }
            if (string.IsNullOrEmpty(userIdTb.Text) || string.IsNullOrEmpty(passwordTb.Text) ||
                string.IsNullOrEmpty(confirmPwTb.Text))
            {
                MessageBox.Show("All fields should be filled");
                return;
            }

            if (userIdTb.TextLength < 8)
            {
                MessageBox.Show("Username or password should be 8 charatcers or longer");
                return;
            }

            if (!passwordTb.Text.Equals(confirmPwTb.Text))
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            var insertUser = new User
            {
                countryName = countryCb.SelectedItem.ToString(),
                passwd = passwordTb.Text,
                userId = userIdTb.Text,
                userTypeIdFK = 2,
            };

            context.Users.Add(insertUser);
            context.SaveChanges();

            MessageBox.Show("User created");

            Close();
        }
    }
}