using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session4_9_8_2020
{
    public partial class LoginForm : Form
    {
        private Session4Entities context = new Session4Entities();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void filePathTb_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                RestoreDirectory = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePathTb.Text = ofd.FileName;
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            if (filePathTb.Text.Length == 0)
            {
                MessageBox.Show("Select a file");
                return;
            }

            if (!filePathTb.Text.Contains(".csv"))
            {
                MessageBox.Show("Only .csv files are supported");
                return;
            }
            try
            {
                var file = File.ReadAllLines(filePathTb.Text).Skip(1);

                foreach (var line in file)
                {
                    var row = line.Split(',');

                    var userId = row[0];
                    var skillId = int.Parse(row[1]);
                    var password = row[2];
                    var name = row[3];
                    var userType = int.Parse(row[4]);

                    if (!context.Users.Where(x => x.userId == userId).Any())
                    {
                        var user = new User
                        {
                            name = name,
                            passwd = password,
                            skillIdFK = skillId,
                            userId = userId,
                            userTypeIdFK = userType
                        };

                        context.Users.Add(user);
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Changes appended");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var user = context.Users.Where(x => x.userId == userIDTb.Text && x.passwd == passwordTb.Text);

            if (user.Any())
            {
                if (user.First().userTypeIdFK == 1)
                {
                    Hide();
                    new AdminMainMenuForm().ShowDialog();
                    Show();
                    //Admin:
                    return;
                }

                if (user.First().userTypeIdFK == 2)
                {
                    Hide();
                    new ExpertMainMenuForm(user.First().userId).ShowDialog();
                    Show();
                    //Expert:
                    return;
                }

                if (user.First().userTypeIdFK == 3)
                {
                    //Competitor:
                    Hide();
                    new UpdateCompetitorTrainingRecordsForm().ShowDialog();
                    Show();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }
    }
}