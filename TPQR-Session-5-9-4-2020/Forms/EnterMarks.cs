using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TPQR_Session5_9_4_2020
{
    public partial class EnterMarks : Form
    {
        private Session5Entities context = new Session5Entities();

        private double totalMarks = 0;

        public EnterMarks()

        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EnterMarks_Load(object sender, EventArgs e)
        {
            string[] columns = { "Question", "Grade", "Marks", "Max Marks" };
            foreach (var column in columns)
            {
                marksDGV.Columns.Add(column, column);
            }

            foreach (DataGridViewColumn col in marksDGV.Columns)
            {
                col.ReadOnly = true;
            }

            marksDGV.Columns[1].ReadOnly = false;
            skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
            skillCb.SelectedIndex = 0;
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            sessionCb.Items.Clear();
            var selectedSkill = skillCb.SelectedItem.ToString();
            sessionCb.Items.AddRange(context.Competitions.Where(x => x.Skill.skillName == selectedSkill).Select(x => x.sessionNo.ToString()).ToArray());
            sessionCb.SelectedIndex = 0;
            UpdateCompetitorCb();
        }

        private void competitorNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void sessionCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCompetitorCb();
        }

        private void UpdateCompetitorCb()
        {
            competitorNameCb.Items.Clear();
            var selectedSkill = skillCb.SelectedItem.ToString();
            competitorNameCb.Items.AddRange(context.Competitors.Where(x => x.Skill.skillName == selectedSkill).Select(x => x.competitorName).ToArray());
            competitorNameCb.SelectedIndex = 0;
        }

        private void UpdateTable()
        {
            marksDGV.Rows.Clear();
            var selectedSkill = skillCb.SelectedItem.ToString();
            var selectedSession = int.Parse(sessionCb.SelectedItem.ToString());
            var selectedCompetitor = competitorNameCb.SelectedItem.ToString();

            var competition = (from x in context.Competitions
                               where x.Skill.skillName == selectedSkill && x.sessionNo == selectedSession
                               select x).First();
            string[] row = new string[5];

            if (competition.q1MaxMarks != 0)
            {
                row[0] = "Question 1";
                row[3] = competition.q1MaxMarks.ToString();
                marksDGV.Rows.Add(row);
            }
            if (competition.q2MaxMarks != 0)
            {
                row[0] = "Question 2";
                row[3] = competition.q2MaxMarks.ToString();
                marksDGV.Rows.Add(row);
            }
            if (competition.q3MaxMarks != 0)
            {
                row[0] = "Question 3";
                row[3] = competition.q3MaxMarks.ToString();
                marksDGV.Rows.Add(row);
            }
            if (competition.q4MaxMarks != 0)
            {
                row[0] = "Question 4";
                row[3] = competition.q4MaxMarks.ToString();
                marksDGV.Rows.Add(row);
            }

            CalculateMarks();
        }

        private void CalculateMarks()
        {
            totalMarks = 0;
            foreach (DataGridViewRow row in marksDGV.Rows)
            {
                double temp = 0;
                if (row.Cells[2].Value != null)
                {
                    if (double.TryParse(row.Cells[2].Value.ToString(), out temp))
                    {
                        totalMarks += temp;
                    }
                }
            }
            totalMarksLbl.Text = $"Total Marks: {totalMarks}";
        }

        private void marksDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cellVal = marksDGV[e.ColumnIndex, e.RowIndex];
            var cellToChange = marksDGV[2, e.RowIndex];
            var maxMarks = int.Parse(marksDGV[3, e.RowIndex].Value.ToString());
            if (cellVal.Value != null)
            {
                switch (cellVal.Value.ToString().ToLower())
                {
                    case "good":
                        cellVal.Value = "Good";
                        cellToChange.Value = maxMarks * 1;
                        break;

                    case "gd":
                        cellVal.Value = "Good";
                        cellToChange.Value = maxMarks * 1;
                        break;

                    case "average":
                        cellVal.Value = "Average";
                        cellToChange.Value = maxMarks * 0.65;
                        break;

                    case "av":
                        cellVal.Value = "Average";
                        cellToChange.Value = maxMarks * 0.65;
                        break;

                    case "poor":
                        cellVal.Value = "Poor";
                        cellToChange.Value = maxMarks * 0.2;
                        break;

                    case "pr":
                        cellVal.Value = "Poor";
                        cellToChange.Value = maxMarks * 0.2;
                        break;

                    default:
                        MessageBox.Show("Invalid input detected");
                        cellToChange.Value = string.Empty;
                        cellVal.Value = string.Empty;
                        break;
                }
            }
            CalculateMarks();
        }

        private void clearForm_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            var selectedSkill = skillCb.SelectedItem.ToString();
            var selectedSession = int.Parse(sessionCb.SelectedItem.ToString());
            var selectedCompetitor = competitorNameCb.SelectedItem.ToString();

            var competition = (from x in context.Competitions
                               where x.Skill.skillName == selectedSkill && x.sessionNo == selectedSession
                               select x).First();
            var competitor = context.Competitors.Where(x => x.competitorName == selectedCompetitor && x.Skill.skillName == selectedSkill).First();
            var currentUser = (from x in context.Results
                               where x.competitionIdFK == competition.competitionId && x.Competitor.competitorId == competitor.competitorId
                               select x);
            double q1Mark = 0;
            double q2Mark = 0;
            double q3Mark = 0;
            double q4Mark = 0;

            var idx = 0;
            foreach (DataGridViewRow row in marksDGV.Rows)
            {
                if (row.Cells[2].Value == null)
                {
                    MessageBox.Show("Please mark all the questions");
                    return;
                }
                switch (idx)
                {
                    case 0:
                        q1Mark = double.Parse(row.Cells[2].Value.ToString());
                        break;

                    case 1:
                        q2Mark = double.Parse(row.Cells[2].Value.ToString());
                        break;

                    case 2:
                        q3Mark = double.Parse(row.Cells[2].Value.ToString());
                        break;

                    case 3:
                        q4Mark = double.Parse(row.Cells[2].Value.ToString());
                        break;

                    default:
                        break;
                }
                idx++;
            }

            if (currentUser.Any())
            {
                currentUser.First().q1Marks = q1Mark;
                currentUser.First().q2Marks = q2Mark;
                currentUser.First().q3Marks = q3Mark;
                currentUser.First().q4Marks = q4Mark;
                currentUser.First().totalMarks = totalMarks;
            }
            else
            {
                var insertResult = new Result
                {
                    q1Marks = q1Mark,
                    q2Marks = q2Mark,
                    q3Marks = q3Mark,
                    q4Marks = q4Mark,
                    competitionIdFK = competition.competitionId,
                    recordsIdFK = competitor.recordsId,
                    totalMarks = totalMarks
                };
                context.Results.Add(insertResult);
            }

            context.SaveChanges();
            MessageBox.Show("Changes Saved");
        }
    }
}