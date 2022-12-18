using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WSC2017_Paper1_29_10_2020
{
    public partial class UserForm : Form
    {
        private Session1Entities context = new Session1Entities();
        private int _userId = -1;

        public UserForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void UserForm_Load(object sender, EventArgs e)
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

            var columns = new List<string>
            {
                "Date", "Login Time", "Logout Time", "Time Spent On System", "Unsuccessful Logout Reason"
            };

            foreach (var column in columns)
            {
                logDGV.Columns.Add(column, column);
            }

            using (var context = new Session1Entities())
            {
                var user = context.Users.Where(x => x.ID == _userId).First();
                var dataQuery = (from x in context.Logs
                                 where x.userIdFK == _userId
                                 orderby x.loginTime descending
                                 select x).Skip(1).ToList();

                var dataQuery1 = (from x in context.Logs
                                  where x.userIdFK == _userId && x.failureShortReason == null
                                  orderby x.loginTime descending
                                  select x).Skip(1).ToList();

                var dataQuery2 = (from x in context.Logs
                                  where x.userIdFK == _userId && x.failureShortReason != null
                                  orderby x.loginTime descending
                                  select x).ToList();

                welcomeLbl.Text = $"Hi, {user.FirstName}, Welcome to AMONIC Airlines";
                var timeSpentHours = dataQuery1.Sum(x => ((DateTime)x.logoutTime - x.loginTime).Hours).ToString("00");
                var timeSpentMinutes = (dataQuery1.Sum(x => ((DateTime)x.logoutTime - x.loginTime).Minutes) % 60).ToString("00");
                var timeSpentSeconds = (dataQuery1.Sum(x => ((DateTime)x.logoutTime - x.loginTime).Seconds) % 60).ToString("00");
                timeSpentLbl.Text = $"Time spent on system: {timeSpentHours}:{timeSpentMinutes}:{timeSpentSeconds}";
                numberCrashes.Text = $"Number of crashes: {dataQuery2.Count()}";
                foreach (var log in dataQuery)
                {
                    var row = new List<string>
                {
                    log.loginTime.Date.ToShortDateString(),
                    log.loginTime.ToShortTimeString()
                };

                    if (log.failureShortReason != null)
                    {
                        row.Add("**");
                        row.Add("**");
                        if (log.failureLongReason.Equals(string.Empty))
                        {
                            row.Add("Reason was not provided");
                        }
                        else
                        {
                            row.Add(log.failureLongReason);
                        }
                    }
                    else
                    {
                        row.Add(log.logoutTime.Value.ToShortTimeString());
                        var timeTaken = log.logoutTime.Value - log.loginTime;
                        row.Add($"{timeTaken.Hours.ToString("00")}:{timeTaken.Minutes.ToString("00")}");
                        row.Add("-");
                    }

                    logDGV.Rows.Add(row.ToArray());
                }

                foreach (DataGridViewRow row1 in logDGV.Rows)
                {
                    if (!row1.Cells[4].Value.ToString().Equals("-"))
                    {
                        row1.DefaultCellStyle.BackColor = Color.Red;
                        row1.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            var logs = context.Logs.Where(x => x.userIdFK == _userId).OrderByDescending(x => x.loginTime).First();

            logs.logoutTime = DateTime.Now;

            context.SaveChanges();

            Close();
        }
    }
}