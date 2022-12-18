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

namespace TPQR_Session4_9_1_2020
{
    public partial class LoginForm : Form
    {
        private Session4Entities context = new Session4Entities();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void filePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog odf = new OpenFileDialog
            {
                DefaultExt = "*.csv",
                RestoreDirectory = true
            };

            if (odf.ShowDialog() == DialogResult.OK)
            {
                filePath.Text = odf.FileName;
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            var user = context.Users.Where(x => x.userId == userIdTb.Text && x.passwd == passwordTb.Text);

            if (user.Any())
            {
                if (user.First().userTypeIdFK == 1)
                {
                    //Admin
                    return;
                }

                if (user.First().userTypeIdFK == 2)
                {
                    //Expert
                    return;
                }

                if (user.First().userTypeIdFK == 3)
                {
                    //competitor:
                    return;
                }
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
                return;
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            var file = File.ReadAllLines(filePath.Text).Skip(1);
            var filesAppended = 0;
            foreach (var line in file)
            {
                var row = line.Split(',');

                var userid = row[0];
                var skillIdFk = row[1];
                var password = row[2];
                var name = row[3];
                var userTypeFK = row[4];

                if (!context.Users.Where(x => x.userId == userid).Any())
                {
                    var insertUser = new User
                    {
                        name = name,
                        passwd = password,
                        skillIdFK = int.Parse(skillIdFk),
                        userTypeIdFK = int.Parse(userTypeFK),
                        userId = userid,
                    };

                    context.Users.Add(insertUser);
                    filesAppended++;
                }
            }
            MessageBox.Show($"Uploaded to database. {filesAppended} files uploaded. {file.Count() - filesAppended} duplicates found");
            context.SaveChanges();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var timeToCompetition = DateTime.Parse("26 July 2020 9:00AM") - DateTime.Now;

            timeLbl.Text = $"{timeToCompetition.Days} days {timeToCompetition.Hours} hours and {timeToCompetition.Minutes} minutes until event starts";
        }
    }
}