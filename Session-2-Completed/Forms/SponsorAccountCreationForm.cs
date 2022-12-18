using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session2_JordanKhong.Forms
{
    public partial class SponsorAccountCreationForm : Form
    {
        public SponsorAccountCreationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SponsorAccountCreationForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                
                while (true)
                {
                    #region Validation Checks:
                    
                    //Check if userID is 8 characters:
                    if (userIdTb.Text.Length < 8)
                    {
                        MessageBox.Show("UserID must be at least 8 characters!");
                        break;
                    }

                    //Check if userID has been taken:
                    var checkForSameId = context.Users.Where(x => x.userId.Equals(userIdTb.Text)).FirstOrDefault();

                    if (checkForSameId != null)
                    {
                        MessageBox.Show("UserID has been taken, please choose another");
                        break;
                    }

                    //Check if passwords match:
                    if (!passwordTb.Text.Equals(reEnterPwTb.Text))
                    {
                        MessageBox.Show("Passwords do not match");
                        break;
                    }

                    //Check is all the fields are all filled in
                    if (companyNameTb.Text.Equals(string.Empty) || passwordTb.Text.Equals(string.Empty) || reEnterPwTb.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Please fill up all the fields.");
                        break;
                    }

                    #endregion

                    #region Save to Database:
                    //Add new user with all the information:
                    User insertUser = new User
                    {
                        userId = userIdTb.Text,
                        name = companyNameTb.Text,
                        passwd = passwordTb.Text,
                        userTypeIdFK = 2
                    };

                    try
                    {
                        context.Users.Add(insertUser);
                        context.SaveChanges();

                        MessageBox.Show("Account created c:");

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Account creation failed. Details: \n" + ex.Message);
                    }

                    break;

                    #endregion
                }
            }
        }
    }
}
