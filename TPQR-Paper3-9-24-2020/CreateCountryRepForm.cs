using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Paper3_9_24_2020
{
    public partial class CreateCountryRepForm : Form
    {
        private Session3Entities context = new Session3Entities();

        public CreateCountryRepForm()
        {
            InitializeComponent();
        }

        private void CreateCountryRepForm_Load(object sender, EventArgs e)
        {
            var countryList = new List<string>
            {
                "Brunei", "Cambodia",
                "Indonesia", "Laos", "Malaysia", "Myanmar", "Philippines", "Singapore", "Thailand", "Vietnam"
            };

            var finalCountry = new List<string>();

            foreach (var country in countryList)
            {
                if (!context.Users.Where(x => x.countryName == country && x.userTypeIdFK == 2).Any())
                {
                    finalCountry.Add(country);
                }
            }

            countryCb.Items.AddRange(finalCountry.ToArray());
            countryCb.SelectedIndex = 0;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (userIdTb.TextLength < 8)
            {
                MessageBox.Show("User ID must be 8 charatcers or longer");
                return;
            }

            if (!passwordTb.Text.Equals(rePwTb.Text))
            {
                MessageBox.Show("Password do not match");
                return;
            }

            if (string.IsNullOrEmpty(userIdTb.Text) || string.IsNullOrEmpty(passwordTb.Text))
            {
                MessageBox.Show("Please fill in all the fields");
                return;
            }

            var insertUser = new User
            {
                userId = userIdTb.Text,
                countryName = countryCb.SelectedItem.ToString(),
                passwd = passwordTb.Text,
                userTypeIdFK = 2,
            };

            context.Users.Add(insertUser);
            context.SaveChanges();

            MessageBox.Show("User Created");
            Close();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}