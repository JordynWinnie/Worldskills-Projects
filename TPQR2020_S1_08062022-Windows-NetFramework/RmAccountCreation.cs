using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR2020_S1_08062022_Windows_NetFramework
{
    public partial class RmAccountCreation : Form
    {
        private Dictionary<string, User_Type> userTypes;

        public RmAccountCreation()
        {
            InitializeComponent();
        }

        private void RmAccountCreation_Load(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                userTypes = context.User_Type.ToDictionary(x=>x.userTypeName);

                userTypeCb.Items.AddRange(userTypes.Keys.ToArray());

                userTypeCb.SelectedIndex = 0;
            }
        }

        private void createAcc_Click(object sender, EventArgs e)
        {

            if (userIdTb.Text == string.Empty || usernameTb.Text == string.Empty || passwordTb.Text == string.Empty || reEnterPwTb.Text == string.Empty)
            {
                MessageBox.Show("Please fill in all the fields");
                return;
            }

            if (!passwordTb.Text.Equals(reEnterPwTb.Text))
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            if (userIdTb.TextLength < 8)
            {
                MessageBox.Show("User ID should have a minmum of 8 characters");
                return;
            }

            using (var context = new Session1Entities())
            {
                if (context.Users.Where(x=>x.userId == userIdTb.Text).Any())
                {
                    MessageBox.Show("Users cannot share the same ID");
                    return;
                }
                var userID = userTypes[userTypeCb.SelectedItem.ToString()].userTypeId;
                var newUser = new User
                {
                    userName = usernameTb.Text,
                    userPw = passwordTb.Text,
                    userTypeIdFK = userID,
                    userId = userIdTb.Text,
                };

                context.Users.Add(newUser);

                context.SaveChanges();

                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
