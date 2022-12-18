using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TPQR_Session5_9_4_2020
{
    public partial class CalculateBonus : Form
    {
        private Session5Entities context = new Session5Entities();

        public CalculateBonus()
        {
            InitializeComponent();
        }

        private void CalculateBonus_Load(object sender, EventArgs e)
        {
            string[] columns = { "Question", "Marks Recieved", "Max Possible Marks", "Amount Recieved" };
            foreach (var column in columns)
            {
                moneyDGV.Columns.Add(column, column);
            }
            skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
            skillCb.SelectedIndex = 0;
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            competitorNameCb.Items.Clear();
            var selectedSkill = skillCb.SelectedItem.ToString();

            competitorNameCb.Items.AddRange(context.Competitors.Where(x => x.Skill.skillName == selectedSkill).Select(x => x.competitorName).ToArray());
            competitorNameCb.SelectedIndex = 0;
        }

        private void competitorNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            moneyDGV.Rows.Clear();
            var competitorName = competitorNameCb.SelectedItem.ToString();
            var selectedSkill = skillCb.SelectedItem.ToString();
            var groupQuery = from x in context.Results
                             where x.Competitor.competitorName == competitorName && x.Competition.Skill.skillName == selectedSkill
                             group x by x.Competition.sessionNo into y
                             select y;

            var finalAmountEarned = 0.0;
            var totalBonusEarned = 0.0;

            var totalMark = 0.0;
            foreach (var session in groupQuery)
            {
                var row = new string[6];
                var totalSessionMarks = session.Sum(x => x.Competition.q1MaxMarks + x.Competition.q2MaxMarks + x.Competition.q3MaxMarks + x.Competition.q4MaxMarks);
                var totalCompetitorMarks = session.Sum(x => x.q1Marks + x.q2Marks + x.q3Marks + x.q4Marks);
                row[0] = $"Session {session.Key} (Total Marks: {totalCompetitorMarks}/{totalSessionMarks})";
                moneyDGV.Rows.Add(row);

                foreach (var question in session)
                {
                    if (question.q1Marks != 0)
                    {
                        var questionWorth = 100 * ((double)question.Competition.q1MaxMarks / totalSessionMarks);
                        var amtEarned = ((double)question.q1Marks / question.Competition.q1MaxMarks) * questionWorth;
                        row[0] = $"Question 1";
                        row[1] = question.q1Marks.ToString();
                        row[2] = question.Competition.q1MaxMarks.ToString();
                        row[3] = amtEarned.ToString("0.00");
                        row[4] = questionWorth.ToString("0.00");
                        moneyDGV.Rows.Add(row);
                        finalAmountEarned += amtEarned;
                    }

                    if (question.q2Marks != 0)
                    {
                        var questionWorth = 100 * ((double)question.Competition.q2MaxMarks / totalSessionMarks);
                        var amtEarned = ((double)question.q2Marks / question.Competition.q2MaxMarks) * questionWorth;
                        row[0] = $"Question 2";
                        row[1] = question.q2Marks.ToString();
                        row[2] = question.Competition.q2MaxMarks.ToString();
                        row[3] = amtEarned.ToString("0.00");
                        row[4] = questionWorth.ToString("0.00");
                        moneyDGV.Rows.Add(row);
                        finalAmountEarned += amtEarned;
                    }

                    if (question.q3Marks != 0)
                    {
                        var questionWorth = 100 * ((double)question.Competition.q3MaxMarks / totalSessionMarks);
                        var amtEarned = ((double)question.q3Marks / question.Competition.q3MaxMarks) * questionWorth;
                        row[0] = $"Question 3";
                        row[1] = question.q3Marks.ToString();
                        row[2] = question.Competition.q3MaxMarks.ToString();
                        row[3] = amtEarned.ToString("0.00");
                        row[4] = questionWorth.ToString("0.00");
                        moneyDGV.Rows.Add(row);
                        finalAmountEarned += amtEarned;
                    }

                    if (question.q4Marks != 0)
                    {
                        var questionWorth = 100 * ((double)question.Competition.q4MaxMarks / totalSessionMarks);
                        var amtEarned = ((double)question.q4Marks / question.Competition.q4MaxMarks) * questionWorth;
                        row[0] = $"Question 4";
                        row[1] = question.q4Marks.ToString();
                        row[2] = question.Competition.q4MaxMarks.ToString();
                        row[3] = amtEarned.ToString("0.00");
                        row[4] = questionWorth.ToString("0.00");
                        moneyDGV.Rows.Add(row);
                        finalAmountEarned += amtEarned;
                    }
                }

                if (totalCompetitorMarks >= totalSessionMarks * 0.75)
                {
                    totalBonusEarned += 5;
                }

                totalMark += totalCompetitorMarks;
            }

            var skillMedian = context.Skills.Where(x => x.skillName == selectedSkill).First().expectedMedianMark;
            if (totalMark / groupQuery.Count() >= skillMedian)
            {
                totalBonusEarned += 10;
            }

            finalAmountEarned += totalBonusEarned;

            totalBonusLbl.Text = $"Total Bonus: ${totalBonusEarned.ToString("0.00")}";
            totalAmount.Text = $"Total Amount: ${finalAmountEarned.ToString("0.00")}";
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}