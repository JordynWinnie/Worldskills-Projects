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
    public partial class OverallTrainingProgressForm : Form
    {
        private Session4Entities context = new Session4Entities();

        public OverallTrainingProgressForm()
        {
            InitializeComponent();
        }

        private void OverallTrainingProgressForm_Load(object sender, EventArgs e)
        {
            skillCb.Items.AddRange(context.Skills.Where(x => x.skillName != "Admin").Select(x => x.skillName).ToArray());
            skillCb.SelectedIndex = 0;

            UpdateForms();
        }

        private void UpdateForms()
        {
            var selectedSkill = skillCb.SelectedItem.ToString();

            var trainingQuery = (from x in context.Assign_Training
                                 where x.Training_Module.Skill.skillName == selectedSkill
                                 select x).ToList();
            var trainingQuery1 = from x in trainingQuery
                                 group x by x.startDate.ToString("Y") into y
                                 select y;

            traineeCatDGV.Columns.Clear();
            traineeCatDGV.Rows.Clear();
            expertsDGV.Columns.Clear();
            expertsDGV.Rows.Clear();
            competitorsDGV.Columns.Clear();
            competitorsDGV.Rows.Clear();

            traineeCatDGV.Columns.Add("Trainee Category", "Trainee Category");

            var competitorRow = new List<string> { "Competitor" };
            var expertRow = new List<string> { "Expert" };
            foreach (var item in trainingQuery1)
            {
                traineeCatDGV.Columns.Add(item.Key, item.Key);

                competitorRow.Add(item.Where(x => x.User.User_Type.userTypeName == "Competitor").Select(x => x.moduleIdFK).Distinct().Count().ToString());
                expertRow.Add(item.Where(x => x.User.User_Type.userTypeName == "Expert").Select(x => x.moduleIdFK).Distinct().Count().ToString());
            }

            traineeCatDGV.Rows.Add(competitorRow.ToArray());
            traineeCatDGV.Rows.Add(expertRow.ToArray());

            var expertStatus = from x in context.Assign_Training
                               where x.Training_Module.Skill.skillName == selectedSkill && x.User.User_Type.userTypeName == "Expert"
                               group x by x.Training_Module.moduleName into y
                               select y;

            expertsDGV.Columns.Add("Status (Experts)", "Status (Experts)");

            var expertCompletedRow = new List<string> { "Completed" };
            var expertInProgressRow = new List<string> { "In Progress" };
            var expertNotStartedRow = new List<string> { "Not Started" };
            foreach (var item in expertStatus)
            {
                expertsDGV.Columns.Add(item.Key, item.Key);
                expertCompletedRow.Add(item.Where(x => x.progress == 100).Count().ToString());
                expertInProgressRow.Add(item.Where(x => x.progress > 0 && x.progress < 99).Count().ToString());
                expertNotStartedRow.Add(item.Where(x => x.progress == 0).Count().ToString());
            }

            expertsDGV.Rows.Add(expertCompletedRow.ToArray());
            expertsDGV.Rows.Add(expertInProgressRow.ToArray());
            expertsDGV.Rows.Add(expertNotStartedRow.ToArray());

            var competitorStatus = from x in context.Assign_Training
                                   where x.Training_Module.Skill.skillName == selectedSkill && x.User.User_Type.userTypeName == "Competitor"
                                   group x by x.Training_Module.moduleName into y
                                   select y;

            competitorsDGV.Columns.Add("Status (Competitor)", "Status (Competitor)");

            var competitorCompletedRow = new List<string> { "Completed" };
            var competitorInProgressRow = new List<string> { "In Progress" };
            var competitorNotStartedRow = new List<string> { "Not Started" };
            foreach (var item in competitorStatus)
            {
                competitorsDGV.Columns.Add(item.Key, item.Key);
                competitorCompletedRow.Add(item.Where(x => x.progress == 100).Count().ToString());
                competitorInProgressRow.Add(item.Where(x => x.progress > 0 && x.progress < 99).Count().ToString());
                competitorNotStartedRow.Add(item.Where(x => x.progress == 0).Count().ToString());
            }

            competitorsDGV.Rows.Add(competitorCompletedRow.ToArray());
            competitorsDGV.Rows.Add(competitorInProgressRow.ToArray());
            competitorsDGV.Rows.Add(competitorNotStartedRow.ToArray());

            var chartQuery = from x in context.Assign_Training
                             where x.Training_Module.Skill.skillName == selectedSkill && x.User.User_Type.userTypeName == "Competitor"
                             group x by x.Training_Module.moduleName into y
                             select y;
            chart.Series.Clear();
            chart.Series.Add("Completed");
            chart.Series.Add("In Progress");
            chart.Series.Add("Not Started");
            foreach (var item in chartQuery)
            {
                chart.Series["Completed"].Points.AddXY(item.Key, item.Where(x => x.progress == 100).Count());
                chart.Series["In Progress"].Points.AddXY(item.Key, (item.Where(x => x.progress > 0 && x.progress < 99).Count()));
                chart.Series["Not Started"].Points.AddXY(item.Key, item.Where(x => x.progress == 0).Count());
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateForms();
        }
    }
}