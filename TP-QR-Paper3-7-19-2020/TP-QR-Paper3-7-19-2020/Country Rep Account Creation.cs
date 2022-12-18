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
    public partial class Country_Rep_Account_Creation : Form
    {
        private Session3Entities context = new Session3Entities();

        public Country_Rep_Account_Creation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Country_Rep_Account_Creation_Load(object sender, EventArgs e)
        {
            var countryList = new List<string>
            {
                "Brunei", "Cambodia", "Indonesia", "Laos", "Malaysia", "Myanmar", "Philippines", "Singapore", "Thailand", "Vietnam"
            };
            var countriesQuery = context.Users.Where(x => x.userTypeIdFK != 1);

            foreach (var country in countriesQuery)
            {
                if (countryList.Contains(country.countryName))
                {
                    countryList.Remove(country.countryName);
                }
            }

            countryCombobox.Items.AddRange(countryList.ToArray());
            countryCombobox.SelectedIndex = 0;
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            if (ValidateEntries())
            {
                var insertUser = new User
                {
                    countryName = countryCombobox.SelectedItem.ToString(),
                    passwd = passwordTb.Text,
                    userId = userIDTB.Text,
                    userTypeIdFK = 2
                };

                context.Users.Add(insertUser);
                context.SaveChanges();
                MessageBox.Show("Account Created!");
                Close();
            }
        }

        private bool ValidateEntries()
        {
            if (userIDTB.TextLength < 8)
            {
                MessageBox.Show("User Id should be 8 characters or more");
                return false;
            }

            if (!rePasswordTb.Text.Equals(passwordTb.Text))
            {
                MessageBox.Show("Passwords do not match!");
                return false;
            }
            return true;
        }
    }
}