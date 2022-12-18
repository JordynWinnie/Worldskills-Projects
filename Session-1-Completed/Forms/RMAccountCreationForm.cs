using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session1_JordanKhong.Forms
{
    public partial class RMAccountCreationForm : Form
    {
        

        public RMAccountCreationForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RMLoginForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                //FILL UP COMBOBOX
                //Query to get ALL user types, and fills up the combobox with all the types.
                var userTypes = context.User_Type.Select(x => x.userTypeName);
                userTypeCombo.Items.AddRange(userTypes.ToArray());
                userTypeCombo.SelectedIndex = 0;
            }
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                
                //DO ALL VALIDATION:
                while (true)
                {
                    #region Validation Logic
                    //check if username is blank
                    if (userNameTb.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Username should not be blank");
                        break;
                    }

                    //CheckUserId min 8 characters
                    if (userIdTb.Text.Length < 8)
                    {
                        MessageBox.Show("User Id must be AT LEAST 8 characters");
                        
                        break;
                    }

                    //Check if password fields are the same

                    if (!passwordTb.Text.Equals(reEnterPwTb.Text))
                    {
                        MessageBox.Show("Passwords do not match");
                        
                        break;
                    }

                    //Check for same user id, based on user table:
                    var sameUserIdCheck = context.Users.Where(x => x.userId.Equals(userIdTb.Text)).FirstOrDefault();

                    if (sameUserIdCheck != null)
                    {
                        MessageBox.Show("The user id has been taken, please choose another");

                        break;
                    }

                    #endregion

                    #region Insertion Logic
                    //Register user as new user:

                    //Gets currently selected item as a string, then quries for the ID of the userType from user_Type table.
                    var currentComboBoxSelected = userTypeCombo.SelectedItem.ToString();
                    var getUserType = context.User_Type.Where(x => x.userTypeName.Equals(currentComboBoxSelected)).Select(x => x.userTypeId).First();
                    
                    User insertUser = new User
                    {
                        userId = userIdTb.Text,
                        userName = userNameTb.Text,
                        userPw = passwordTb.Text,
                        userTypeIdFK = getUserType
                    };

                    try
                    {
                        //Save user into database:
                        context.Users.Add(insertUser);
                        context.SaveChanges();

                        MessageBox.Show("User created c:");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        //Tell the user if error:
                        MessageBox.Show("An error occurred making a user. Details: \n" + ex.Message);
                        throw;
                    }

                    break;

                    #endregion
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
