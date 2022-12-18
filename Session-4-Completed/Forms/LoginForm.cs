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

namespace Session_4_JordanKhong
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Get competition date and deduct with system time to produce the bottom message:
            var CompetitonDate = DateTime.Parse("26 July 2020 09:00:00");

            Console.WriteLine(CompetitonDate.Hour);
            var currentTime = DateTime.Now;

            var timeBetween = CompetitonDate - currentTime;

            timerLabel.Text = $"{timeBetween.Days} days, {timeBetween.Hours} hours and {timeBetween.Minutes} minutes until event starts!";
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            #region Login Logic:
            using (var context = new Session4Entities())
            {
                if (context.Users.Where(x=>x.userId.Equals(userIdTb.Text) && x.passwd.Equals(passwordTb.Text)).Any())
                {
                    var userId = context.Users.Where(x => x.userId.Equals(userIdTb.Text) && x.passwd.Equals(passwordTb.Text)).Select(x => x.userTypeIdFK).First();
                    if (userId == 1)
                    {
                        Console.WriteLine("Admin");
                        this.Hide();
                        (new AdminMainMenuForm(userIdTb.Text)).ShowDialog();
                        this.Show();
                    }
                    else if (userId == 2)
                    {
                        Console.WriteLine("Expert");
                        this.Hide();
                        (new ExpertMainMenuForm(userIdTb.Text)).ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        Console.WriteLine("Competitor");
                        this.Hide();
                        (new CompetitorMenu()).ShowDialog();
                        this.Show();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Wrong username or password!");
                }
            }
            #endregion
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            //Uses a file dialog to look for the .csv file:
            OpenFileDialog op = new OpenFileDialog
            {
                DefaultExt = ".csv",
                Title = "Select File"
            };

            var result = op.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBox1.Text = op.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Generates a list userId:
            var userIdList = new List<string>();

            using (var context = new Session4Entities())
            {
                var filePath = textBox1.Text;
                
                #region Reading logic:
                if (!filePath.Equals(string.Empty))
                {
                    using (var stream = new StreamReader(filePath))
                    {
                        //Skips a line of columns
                        stream.ReadLine();
                        while (!stream.EndOfStream)
                        {

                            var line = stream.ReadLine();

                            //Splits the line with a ',' to get an array of information
                            var split = line.Split(',');
                            Console.WriteLine(split[0]);

                            userIdList.Add(split[0].Trim());

                            //Inserts user:
                            User insertUser = new User
                            {
                                userId = split[0].Trim(),
                                skillIdFK = Convert.ToInt32(split[1].Trim()),
                                passwd = split[2].Trim(),
                                name = split[3].Trim(),
                                userTypeIdFK = Convert.ToInt32(split[4].Trim())
                            };

                            //Checks if user is already in db:
                            var userID = split[0].Trim();
                            var userIdConflictCheck = context.Users.Where(x => x.userId.Equals(userID)).Any();

                            //Adds user to db if not in:
                            if (!userIdConflictCheck)
                            {
                                context.Users.Add(insertUser);
                            }

                            
                        }
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Data appended c:");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error uploading data. Details: \n" + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid file");
                }
                #endregion
            }

        }
    }
}
