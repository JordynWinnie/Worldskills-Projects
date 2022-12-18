using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WSC2017_Paper1_29_10_2020
{
    public partial class AdminMainMenu : Form
    {
        private Session1Entities context = new Session1Entities();
        private int _userId = -1;
        private int _selectedUserId = -1;

        public AdminMainMenu(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void AdminMainMenu_Load(object sender, EventArgs e)
        {
            var logs = context.Logs.Where(x => x.userIdFK == _userId).OrderByDescending(x => x.loginTime).FirstOrDefault();

            if (logs != null)
            {
                if (logs.logoutTime == null)
                {
                    (new SecurityForm(logs.loginTime, _userId)).ShowDialog();
                }
            }

            var insertLog = new Log
            {
                loginTime = DateTime.Now,
                userIdFK = _userId
            };

            context.Logs.Add(insertLog);
            context.SaveChanges();

            var officesList = new List<string> { "All Offices" };

            var columns = new List<string>
            {
                "Name", "Last Name", "Age","User Role", "Email Address", "Office","Active","userid"
            };

            foreach (var column in columns)
            {
                userDGV.Columns.Add(column, column);
            }

            officesList.AddRange(context.Offices.Select(x => x.Title));

            officeCb.Items.AddRange(officesList.ToArray());
            officeCb.SelectedIndex = 0;
            UpdateDGV();
        }

        private void UpdateDGV()
        {
            userDGV.Rows.Clear();
            using (var context = new Session1Entities())
            {
                var baseQuery = (from x in context.Users
                                 orderby x.Active descending
                                 select x).ToList();

                if (!officeCb.SelectedItem.ToString().Equals("All Offices"))
                {
                    baseQuery = baseQuery.Where(x => x.Office.Title == officeCb.SelectedItem.ToString()).ToList();
                }

                foreach (var user in baseQuery)
                {
                    var row = new List<string>
                {
                    user.FirstName,
                    user.LastName,
                    ((DateTime.Now - user.Birthdate).Value.Days / 365).ToString(),
                    user.Role.Title,
                    user.Email,
                    user.Office.Title,
                    user.Active.ToString(),
                    user.ID.ToString()
                };

                    userDGV.Rows.Add(row.ToArray());
                }

                foreach (DataGridViewRow row1 in userDGV.Rows)
                {
                    if (row1.Cells[3].Value.Equals("Administrator"))
                    {
                        row1.DefaultCellStyle.BackColor = Color.Green;
                    }

                    if (row1.Cells[6].Value.Equals("False"))
                    {
                        row1.DefaultCellStyle.BackColor = Color.Red;
                        row1.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var logs = context.Logs.Where(x => x.userIdFK == _userId).OrderByDescending(x => x.loginTime).First();

            logs.logoutTime = DateTime.Now;

            context.SaveChanges();

            Close();
        }

        private void officeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void userDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedUserId = int.Parse(userDGV[7, e.RowIndex].Value.ToString());
            Console.WriteLine(_selectedUserId);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == -1)
            {
                MessageBox.Show("Select a user");
            }
            else
            {
                var user = context.Users.Where(x => x.ID == _selectedUserId).First();
                user.Active = !user.Active;
                _selectedUserId = -1;

                context.SaveChanges();
                UpdateDGV();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == -1)
            {
                MessageBox.Show("Select a user");
            }
            else
            {
                var user = context.Users.Where(x => x.ID == _selectedUserId).First();
                (new AddUserForm(_selectedUserId)).ShowDialog();
                UpdateDGV();
            }
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            (new AddUserForm(-1)).ShowDialog();
            UpdateDGV();
        }
    }
}