using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WSC2017_Paper1_29_10_2020
{
    public partial class AddUserForm : Form
    {
        private Session1Entities context = new Session1Entities();
        private int _userId = -1;

        public AddUserForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (_userId != -1)
            {
                var userToModify = context.Users.Where(x => x.ID == _userId).First();
                if (adminRadio.Checked)
                {
                    userToModify.RoleID = 1;
                }
                else
                {
                    userToModify.RoleID = 2;
                }
                context.SaveChanges();
                MessageBox.Show("Changes Saved");
                Close();
                return;
            }
            if (emailTb.Text.Equals("") || firstNameTb.Text.Equals("") || lastnameTb.Text.Equals("") ||
                passwordTb.Text.Equals(""))
            {
                MessageBox.Show("Not all fields are filled in");
                return;
            }

            var md5Instance = MD5.Create();

            var hash = Encoding.UTF8.GetBytes(passwordTb.Text);
            var md5Hash = md5Instance.ComputeHash(hash);

            var hashedPw = BitConverter.ToString(md5Hash).Replace("-", "");

            if (context.Users.Where(x => x.Email == emailTb.Text).Any())
            {
                MessageBox.Show("Email taken, please use another");
                return;
            }

            var officeID = context.Offices.Where(x => x.Title == officeCb.SelectedItem.ToString()).First().ID;
            var newUserId = context.Users.OrderByDescending(x => x.ID).First().ID + 1;
            var user = new User
            {
                Active = true,
                Birthdate = birthdayDTP.Value,
                Email = emailTb.Text,
                FirstName = firstNameTb.Text,
                LastName = lastnameTb.Text,
                OfficeID = officeID,
                Password = hashedPw,
                RoleID = 2,
                ID = newUserId
            };

            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("User added");
            Close();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            officeCb.Items.AddRange(context.Offices.Select(x => x.Title).ToArray());
            officeCb.SelectedIndex = 0;

            if (_userId != -1)
            {
                saveBtn.Text = "Apply";
                var user = context.Users.Where(x => x.ID == _userId).First();
                emailTb.Text = user.Email;
                firstNameTb.Text = user.FirstName;
                lastnameTb.Text = user.LastName;
                officeCb.SelectedItem = user.Office.Title;
                passwordTb.Text = user.Password;
                emailTb.Enabled = false;
                firstNameTb.Enabled = false;
                lastnameTb.Enabled = false;

                officeCb.Enabled = false;
                groupBox1.Visible = false;

                if (user.Role.Title.Equals("Administrator"))
                {
                    adminRadio.Checked = true;
                }
                else
                {
                    userRadio.Checked = true;
                }
            }
            else
            {
                groupBox2.Visible = false;
            }
        }
    }
}