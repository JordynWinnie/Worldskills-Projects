using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session1_9_7_2020
{
    public partial class RMAccountCreationForm : Form
    {
        private Session1Entities context = new Session1Entities();

        public RMAccountCreationForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RMAccountCreationForm_Load(object sender, EventArgs e)
        {
            userTypeCb.Items.AddRange(context.User_Type.Select(x => x.userTypeName).ToArray());
            userTypeCb.SelectedIndex = 0;
        }

        private void CreateAccBtn_Click(object sender, EventArgs e)
        {
            var selectedUserType = userTypeCb.SelectedItem.ToString();
            var userTypeId = context.User_Type.Where(x => x.userTypeName == selectedUserType).First();

            if (string.IsNullOrWhiteSpace(usernameTb.Text) || string.IsNullOrWhiteSpace(passwordTb.Text)
                || string.IsNullOrWhiteSpace(reEnterPwTb.Text) || string.IsNullOrWhiteSpace(userIdTb.Text))
            {
                MessageBox.Show("Please fill up all fields");
                return;
            }

            if (userIdTb.TextLength < 8)
            {
                MessageBox.Show("User ID should be 8 characters or more");
                return;
            }

            if (context.Users.Where(x => x.userId == userIdTb.Text).Any())
            {
                MessageBox.Show("User ID taken, please choose another");
                return;
            }

            if (!passwordTb.Text.Equals(reEnterPwTb.Text))
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            var insertUser = new User
            {
                userId = userIdTb.Text,
                userName = usernameTb.Text,
                userPw = passwordTb.Text,
                userTypeIdFK = userTypeId.userTypeId
            };

            context.Users.Add(insertUser);
            context.SaveChanges();
            MessageBox.Show("User created");
            Close();
        }
    }
}