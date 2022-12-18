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

namespace Session3_Jordan_Khong
{
    public partial class CreateCountryRepForm : Form
    {
        public CreateCountryRepForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = DateTime.Now.ToString();
        }

        private void CreateCountryRepForm_Load(object sender, EventArgs e)
        {
            //Generate a pre-defined list of Asean Countries, and sort them:
            List<string> aseanCountries = new List<string>
            {
                "Brunei",
                "Cambodia",
                "Singapore",
                "Indonesia",
                "Laos",
                "Malaysia",
                "Myanmar",
                "Philippines",
                "Thailand",
                "Vietnam"
            };

            aseanCountries.Sort();

            //Define a new list to add countries with no accounts
            List<string> countryWithNoAccounts = new List<string>();

            using (var context = new Session3Entities())
            {
                foreach (var item in aseanCountries)
                {
                    //check if country account exists:
                    var checkForCountry = context.Users.Where(x => x.countryName.Equals(item) && x.userTypeIdFK == 2).Any();

                    if (!checkForCountry)
                    {
                        countryWithNoAccounts.Add(item);
                    }
                }
                //Populate countryComboBox:
                countryComboBox.Items.AddRange(countryWithNoAccounts.ToArray());
                countryComboBox.SelectedIndex = 0;
            }
            
        }

        private void CreateAccBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                #region Validation Checks
                //RegEx to check for only alphanumeric pw:
                string regExPattern = @"[^A-Za-z0-9]+";

                Regex rg = new Regex(regExPattern);

                if (rg.IsMatch(userIdTb.Text))
                {
                    MessageBox.Show("UserId should contain only uppercase letters, lowercase letters and numbers");
                    break;
                }

                //Checks length
                if (userIdTb.Text.Length < 8)
                {
                    MessageBox.Show("UserId should have at least 8 characters");
                    break;
                }

                //Checks password match
                if (!passwordTb.Text.Equals(reEnterPwTb.Text))
                {
                    MessageBox.Show("Passwords do not match");
                    break;
                }

                //Checks for empty fields
                if (userIdTb.Text.Equals(string.Empty) || passwordTb.Text.Equals(string.Empty) || reEnterPwTb.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Please fill up all the fields");
                    break;
                }

                #endregion

                //Registers user:
                User insertUser = new User
                {
                    userId = userIdTb.Text,
                    countryName = countryComboBox.SelectedItem.ToString(),
                    passwd = passwordTb.Text,
                    userTypeIdFK = 2
                };

                using (var context = new Session3Entities())
                {
                    context.Users.Add(insertUser);

                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Account created c:");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving changes. Details: \n" + ex.Message);
                        
                        throw;
                    }
                }
                break;
            }
        }
    }
}
