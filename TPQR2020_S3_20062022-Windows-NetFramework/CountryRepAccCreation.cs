using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR2020_S3_20062022_Windows_NetFramework
{
    public partial class CountryRepAccCreation : Form
    {
        public CountryRepAccCreation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CountryRepAccCreation_Load(object sender, EventArgs e)
        {
            var countries = new List<string>
            {
                "Brunei", "Cambodia", "Indonesia", 
                "Laos", "Malaysia", "Myanmar", 
                "Philippines", "Singapore", "Thailand", "Vietnam"
            };

            using (var context = new Session3Entities())
            {
                var countriesWithAccount = context.Users.Where(x=>x.userTypeIdFK != 1).Select(x=>x.countryName);

                countries = countries.Where(x=> !countriesWithAccount.Contains(x)).ToList();
            }

            countryCb.Items.AddRange(countries.ToArray());
            countryCb.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (useridTb.TextLength < 8)
            {
                MessageBox.Show("User Id should be 8 characters or more");
                return;
            }

            var allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            if (useridTb.Text.Where(x=> !allowedChars.Contains(x)).Any())
            {
                MessageBox.Show("User ID should only contain Upper Case charatcers, Lower Case characters, and numbers");
                return;
            }

            if (rePwTb.Text == string.Empty || passwordTb.Text == string.Empty)
            {
                MessageBox.Show("Fill in all the fields");
                return;
            }

            if (!rePwTb.Text.Equals(passwordTb.Text))
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            using (var context = new Session3Entities())
            {
                var newUser = new User
                {
                    userTypeIdFK = 2,
                    countryName = countryCb.SelectedItem.ToString(),
                    passwd = passwordTb.Text,
                    userId = useridTb.Text
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                MessageBox.Show("User has been created");

                Close();
            }
        }
    }
}
