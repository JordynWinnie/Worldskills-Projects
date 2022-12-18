using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session4_9_8_2020
{
    public partial class CompetitorProgressTrackingForm : Form
    {
        private string _userId = string.Empty;

        private Session4Entities context = new Session4Entities();

        public CompetitorProgressTrackingForm(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CompetitorProgressTrackingForm_Load(object sender, EventArgs e)
        {
            var userInfo = context.Users.Where(x => x.userId == _userId).First();
            var trainingProgress = from x in context.Assign_Training
                                   where x.User.userTypeIdFK == 3 && x.Training_Module.skillIdFK == userInfo.skillIdFK
                                   orderby x.Training_Module.moduleName
                                   group x by x.Training_Module.moduleName into y
                                   select y;

            var trainingProgress1 = from x in context.Assign_Training
                                    where x.User.userTypeIdFK == 3 && x.Training_Module.skillIdFK == userInfo.skillIdFK
                                    group x by x.User.name into y
                                    select y;
            skillLbl.Text = $"Skill: {userInfo.Skill.skillName}";

            progressDGV.Columns.Add("Name of Competitor", "Name of Competitor");
            foreach (var item in trainingProgress)
            {
                progressDGV.Columns.Add(item.Key, item.Key);
            }

            foreach (var user in trainingProgress1)
            {
                var row = new List<string> { user.Key };

                foreach (var item in trainingProgress)
                {
                    var prog = user.Where(x => x.Training_Module.moduleName == item.Key).First();
                    row.Add(prog.progress.ToString());
                }
                progressDGV.Rows.Add(row.ToArray());
            }

            foreach (DataGridViewColumn col in progressDGV.Columns)
            {
                foreach (DataGridViewRow row in progressDGV.Rows)
                {
                    if (progressDGV[col.Index, row.Index].Value.ToString().Equals("0"))
                    {
                        progressDGV[col.Index, row.Index].Style.BackColor = Color.Red;
                    }
                }
            }
        }
    }
}