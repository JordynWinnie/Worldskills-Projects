using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session5_9_9_2020
{
    public partial class CalculateBonusForm : Form
    {
        private Session5Entities context = new Session5Entities();

        public CalculateBonusForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CalculateBonusForm_Load(object sender, EventArgs e)
        {
            var columns = new List<string> { "Question", "Marks Recieved", "Max Possible Marks", "Amount Recieved" };

            foreach (var column in columns)
            {
                marksDGV.Columns.Add(column, column);
            }
            skilCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
            skilCb.SelectedIndex = 0;

            UpdateCompetitorName();
        }

        private void UpdateCompetitorName()
        {
            competitorNameCb.Items.Clear();
            var selectedSkills = skilCb.SelectedItem.ToString();

            competitorNameCb.Items.AddRange(context.Competitors.Where(x => x.Skill.skillName == selectedSkills).Select(x => x.competitorName).ToArray());
            competitorNameCb.SelectedIndex = 0;
        }

        private void competitorNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSkills = skilCb.SelectedItem.ToString();
            var competitorName = competitorNameCb.SelectedItem.ToString();
            var columns = new List<string> { "Question", "Marks Recieved", "Max Possible Marks", "Amount Recieved" };
            marksDGV.Rows.Clear();

            var resultQuery = from x in context.Results
                              where x.Competition.Skill.skillName == selectedSkills && x.Competitor.competitorName == competitorName
                              group x by x.Competition.sessionNo into y
                              select y;
            var bonus = 0.0;
            var totalMarkedEarnedOverall = 0.0;
            var totalMoneyEarned = 0.0;
            foreach (var groupResult in resultQuery)
            {
                var row = new string[4];
                var totalMarksEarned = groupResult.Sum(x => x.q1Marks + x.q2Marks + x.q3Marks + x.q4Marks);
                var totalSessionMarks = groupResult.Sum(x => x.Competition.q1MaxMarks + x.Competition.q2MaxMarks + x.Competition.q3MaxMarks + x.Competition.q4MaxMarks);
                row[0] = $"Session {groupResult.Key} ({totalMarksEarned}/{totalSessionMarks})";

                totalMarkedEarnedOverall += totalMarksEarned;

                marksDGV.Rows.Add(row);

                if (totalMarksEarned / totalSessionMarks >= 0.75)
                {
                    bonus += 5;
                }
                foreach (var result in groupResult)
                {
                    if (result.q1Marks != 0)
                    {
                        row[0] = "Question 1";
                        row[1] = result.q1Marks.ToString();
                        row[2] = result.Competition.q1MaxMarks.ToString();
                        row[3] = ((result.q1Marks / totalSessionMarks) * 100).ToString();

                        totalMoneyEarned += (result.q1Marks / totalSessionMarks) * 100;
                        marksDGV.Rows.Add(row);
                    }

                    if (result.q2Marks != 0)
                    {
                        row[0] = "Question 2";
                        row[1] = result.q2Marks.ToString();
                        row[2] = result.Competition.q2MaxMarks.ToString();
                        row[3] = ((result.q2Marks / totalSessionMarks) * 100).ToString();
                        totalMoneyEarned += (result.q2Marks / totalSessionMarks) * 100;
                        marksDGV.Rows.Add(row);
                    }

                    if (result.q3Marks != 0)
                    {
                        row[0] = "Question 3";
                        row[1] = result.q3Marks.ToString();
                        row[2] = result.Competition.q3MaxMarks.ToString();
                        row[3] = ((result.q3Marks / totalSessionMarks) * 100).ToString();
                        totalMoneyEarned += (result.q3Marks / totalSessionMarks) * 100;
                        marksDGV.Rows.Add(row);
                    }

                    if (result.q4Marks != 0)
                    {
                        row[0] = "Question 4";
                        row[1] = result.q4Marks.ToString();
                        row[2] = result.Competition.q4MaxMarks.ToString();
                        row[3] = ((result.q4Marks / totalSessionMarks) * 100).ToString();
                        totalMoneyEarned += (result.q4Marks / totalSessionMarks) * 100;
                        marksDGV.Rows.Add(row);
                    }
                }
            }

            var median = context.Skills.Where(x => x.skillName == selectedSkills).First().expectedMedianMark;
            if (totalMarkedEarnedOverall / resultQuery.Count() >= median)
            {
                bonus += 10;
            }

            totalMoneyEarned += bonus;

            totalBonusLbl.Text = $"Total Bonus Recieved: ${bonus}";
            amountRecievedLbl.Text = $"Total Amount Recieved: ${totalMoneyEarned}";
        }

        private void skilCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCompetitorName();
        }
    }
}