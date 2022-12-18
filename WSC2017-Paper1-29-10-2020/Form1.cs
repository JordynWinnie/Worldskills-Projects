using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WSC2017_Paper1_29_10_2020
{
    public partial class Form1 : Form
    {
        private Session1Entities context = new Session1Entities();
        private int passwordFailedAttempts = 0;
        private int timerStart = 10;
        private Timer globalTimer = new Timer();
        private bool hasFailed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            passwordFailedAttempts = 0;
            globalTimer.Enabled = true;
            globalTimer.Interval = 1000;
            globalTimer.Tick += Timer_Tick;
        }

        private void LoadData()
        {
            //Usertype, email, pw, firstname, lastname, coutnry, dob, active
            var rawFile = File.ReadAllLines(@"J:\OneDrive - Temasek Polytechnic\ASEAN 2018\OneDrive_1_10-29-2020\Session1\WSC2017_TP09_M1_UserData_actual.csv");
            var md5Instance = MD5.Create();
            var id = 1;
            foreach (var line in rawFile)
            {
                var row = line.Split(',');

                var userType = row[0];
                var roleID = context.Roles.Where(x => x.Title.Equals(userType)).First().ID;
                var email = row[1];
                var password = row[2];

                var hash = md5Instance.ComputeHash(Encoding.Default.GetBytes(password));

                var hashedPassword = BitConverter.ToString(hash).Replace("-", string.Empty);

                var firstName = row[3];
                var lastName = row[4];

                var country = row[5];

                var officeID = context.Offices.Where(x => x.Title == country).First().ID;

                var dateOfBirth = DateTime.ParseExact(row[6].Trim(), "M/d/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                var isActive = row[7].Equals("1");

                var insertUser = new User
                {
                    Active = isActive,
                    Birthdate = dateOfBirth,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    OfficeID = officeID,
                    Password = hashedPassword,
                    RoleID = roleID,
                    ID = id
                };

                id++;

                context.Users.Add(insertUser);
            }

            context.SaveChanges();
            MessageBox.Show("Done");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var md5Instance = MD5.Create();

            var hash = md5Instance.ComputeHash(Encoding.Default.GetBytes(passwordTb.Text));

            var hashedPassword = BitConverter.ToString(hash).Replace("-", string.Empty);

            var user = context.Users.Where(x => x.Email == userIdtb.Text && x.Password == hashedPassword);

            if (user.Any())
            {
                //Login

                passwordFailedAttempts = 0;

                if (!(bool)user.First().Active)
                {
                    MessageBox.Show("Your account is no longer active");
                    userIdtb.Text = string.Empty;
                    passwordTb.Text = string.Empty;
                    return;
                }

                if (user.First().RoleID == 1)
                {
                    //Admin

                    Hide();
                    (new AdminMainMenu(user.First().ID)).ShowDialog();
                    userIdtb.Text = string.Empty;
                    passwordTb.Text = string.Empty;
                    Show();
                    return;
                }
                else
                {
                    //User:
                    Hide();
                    new UserForm(user.First().ID).ShowDialog();
                    userIdtb.Text = string.Empty;
                    passwordTb.Text = string.Empty;
                    Show();
                    return;
                }
            }
            else
            {
                passwordFailedAttempts++;

                if (passwordFailedAttempts >= 3)
                {
                    timerStart = 10;
                    loginGroup.Enabled = false;
                    hasFailed = true;
                }
            }
        }

        private void InitiateFailLogin()
        {
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hasFailed)
            {
                loginLbl.Text = $"Exceeded Failed Login Attempts. Time Left before next login: {timerStart}seconds";
                timerStart--;

                if (timerStart <= 0)
                {
                    loginGroup.Enabled = true;
                    loginLbl.Text = "Login";
                    hasFailed = false;
                    passwordFailedAttempts = 0;
                }
            }
        }
    }
}