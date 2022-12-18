using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSC2017_Paper1_29_10_2020
{
    public partial class SecurityForm : Form
    {
        private DateTime _reportTime;
        private int _userId;
        private Session1Entities context = new Session1Entities();

        public SecurityForm(DateTime reportTime, int userId)
        {
            InitializeComponent();
            _reportTime = reportTime;
            _userId = userId;
        }

        private void SecurityForm_Load(object sender, EventArgs e)
        {
            loginLbl.Text = $"No Logout was detected for your last login on {_reportTime.Date.ToShortDateString()} at {_reportTime.ToShortTimeString()}";
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            var logs = context.Logs.Where(x => x.userIdFK == _userId).OrderByDescending(x => x.loginTime).First();

            if (softwareCrashRadio.Checked)
            {
                logs.failureShortReason = "Software Crashed";
            }
            else
            {
                logs.failureShortReason = "System Crashed";
            }

            logs.logoutTime = DateTime.Now;
            logs.failureLongReason = reasonTb.Text;

            context.SaveChanges();
            Close();
        }
    }
}