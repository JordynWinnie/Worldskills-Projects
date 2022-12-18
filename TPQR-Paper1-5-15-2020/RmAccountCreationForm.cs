using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Paper1_5_15_2020
{
    public partial class RmAccountCreationForm : Form
    {
        public RmAccountCreationForm()
        {
            InitializeComponent();
        }

        private void RmAccountCreationForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                userTypeComboBox.Items.AddRange(context.User_Type.Select(x => x.userTypeName).ToArray());
                userTypeComboBox.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {
            if (AllValid())
            {
                MessageBox.Show("User registered!");
                Close();
            }
        }

        private bool AllValid()
        {
            using (var context = new Session1Entities())
            {
                if (useridTb.Text.Length < 8)
                {
                    MessageBox.Show("User Id must be 8 characters or longer");
                    return false;
                }

                if (context.Users.Where(x => x.userId.Equals(useridTb.Text)).Any())
                {
                    MessageBox.Show("User Id taken, please choose another");
                    return false;
                }

                if (usernameTb.Text.Equals(string.Empty) || useridTb.Text.Equals(string.Empty)
                    || passwordTb.Text.Equals(string.Empty) || reEnterPwTb.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Please fill up all the fields");
                    return false;
                }

                if (!passwordTb.Text.Equals(reEnterPwTb.Text))
                {
                    MessageBox.Show("Passwords do not match");
                    return false;
                }

                try
                {
                    var userTypeFromComboBox = userTypeComboBox.SelectedItem.ToString();
                    var userTypeId = context.User_Type.Where(x => x.userTypeName.Equals(userTypeFromComboBox)).Select(x => x.userTypeId).First();
                    var user = new User
                    {
                        userId = useridTb.Text,
                        userName = usernameTb.Text,
                        userPw = passwordTb.Text,
                        userTypeIdFK = userTypeId
                    };

                    context.Users.Add(user);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error saving to database.");
                    return false;
                    throw;
                }
            }

            return true;
        }
    }
}