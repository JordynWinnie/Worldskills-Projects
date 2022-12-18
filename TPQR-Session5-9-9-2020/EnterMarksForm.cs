using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TPQR_Session5_9_9_2020
{
    public partial class EnterMarksForm : Form
    {
        private Session5Entities context = new Session5Entities();
        private object _oldValue;

        public EnterMarksForm()
        {
            InitializeComponent();
        }

        private void EnterMarksForm_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Question", "Grade", "Marks", "Total Marks"
            };

            foreach (var column in columns)
            {
                marksDGV.Columns.Add(column, column);
            }

            foreach (DataGridViewColumn item in marksDGV.Columns)
            {
                item.ReadOnly = true;
            }

            marksDGV.Columns[1].ReadOnly = false;
            skilCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
            skilCb.SelectedIndex = 0;

            UpdateSessionCb();
        }

        private void UpdateSessionCb()
        {
            if (skilCb.SelectedIndex == -1)
            {
                return;
            }
            sessionCb.Items.Clear();
            var selectedSkill = skilCb.SelectedItem.ToString();
            sessionCb.Items.AddRange(context.Competitions.Where(x => x.Skill.skillName == selectedSkill).Select(x => x.sessionNo.ToString()).ToArray());
            sessionCb.SelectedIndex = 0;

            UpdateNamesCb();
        }

        private void UpdateNamesCb()
        {
            if (skilCb.SelectedIndex == -1 || sessionCb.SelectedIndex == -1)
            {
                return;
            }

            competitorNameCb.Items.Clear();
            var selectedSkill = skilCb.SelectedItem.ToString();

            competitorNameCb.Items.AddRange(context.Competitors.Where(x => x.Skill.skillName == selectedSkill).Select(x => x.competitorName).ToArray());
            competitorNameCb.SelectedIndex = 0;

            UpdateTable();
        }

        private void skilCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSessionCb();
        }

        private void UpdateTable()
        {
            marksDGV.Rows.Clear();

            var selectedSkill = skilCb.SelectedItem.ToString();
            var sessionNo = int.Parse(sessionCb.SelectedItem.ToString());

            var questionsQuery = (from x in context.Competitions
                                  where x.sessionNo == sessionNo && x.Skill.skillName == selectedSkill
                                  select x).First();

            string[] row = new string[4];

            if (questionsQuery.q1MaxMarks != 0)
            {
                row[0] = "Question 1";
                row[1] = "";
                row[2] = "";
                row[3] = questionsQuery.q1MaxMarks.ToString();
                marksDGV.Rows.Add(row);
            };

            if (questionsQuery.q2MaxMarks != 0)
            {
                row[0] = "Question 2";
                row[1] = "";
                row[2] = "";
                row[3] = questionsQuery.q2MaxMarks.ToString();
                marksDGV.Rows.Add(row);
            };

            if (questionsQuery.q3MaxMarks != 0)
            {
                row[0] = "Question 3";
                row[1] = "";
                row[2] = "";
                row[3] = questionsQuery.q3MaxMarks.ToString();
                marksDGV.Rows.Add(row);
            };

            if (questionsQuery.q4MaxMarks != 0)
            {
                row[0] = "Question 4";
                row[1] = "";
                row[2] = "";
                row[3] = questionsQuery.q4MaxMarks.ToString();
                marksDGV.Rows.Add(row);
            };

            totalMarksLbl.Text = $"Total Marks: 0";
        }

        private void competitorNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void sessionCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void marksDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _oldValue = marksDGV[e.ColumnIndex, e.RowIndex].Value;
        }

        private void marksDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var totalMarkValue = double.Parse(marksDGV[3, e.RowIndex].Value.ToString());
            switch (marksDGV[1, e.RowIndex].Value.ToString().ToLower())
            {
                case "gd":
                    marksDGV[2, e.RowIndex].Value = totalMarkValue * 1;
                    break;

                case "good":
                    marksDGV[2, e.RowIndex].Value = totalMarkValue * 1;
                    break;

                case "av":
                    marksDGV[2, e.RowIndex].Value = totalMarkValue * 0.65;
                    break;

                case "average":
                    marksDGV[2, e.RowIndex].Value = totalMarkValue * 0.65;
                    break;

                case "bd":
                    marksDGV[2, e.RowIndex].Value = totalMarkValue * 0.2;
                    break;

                case "bad":
                    marksDGV[2, e.RowIndex].Value = totalMarkValue * 0.2;
                    break;

                default:
                    marksDGV[1, e.RowIndex].Value = _oldValue;
                    break;
            }

            var totalMarks = 0.0;
            foreach (DataGridViewRow row in marksDGV.Rows)
            {
                var mark = 0.0;
                if (double.TryParse(row.Cells[2].Value.ToString(), out mark))
                {
                    totalMarks += mark;
                }
            }

            totalMarksLbl.Text = $"Total Marks: {totalMarks}";
        }

        private void clearFormBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in marksDGV.Rows)
            {
                row.Cells[1].Value = "";
                row.Cells[2].Value = "";
            }

            totalMarksLbl.Text = $"Total Marks: 0";
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            var selectedSkill = skilCb.SelectedItem.ToString();
            var sessionNo = int.Parse(sessionCb.SelectedItem.ToString());
            var competitorName = competitorNameCb.SelectedItem.ToString();

            var questionsQuery = (from x in context.Competitions
                                  where x.sessionNo == sessionNo && x.Skill.skillName == selectedSkill
                                  select x).First();
            var questionId = questionsQuery.competitionId;

            var competitor = (from x in context.Competitors
                              where x.Skill.skillName == selectedSkill && x.competitorName == competitorName
                              select x).First();

            var result = from x in context.Results
                         where x.competitionIdFK == questionsQuery.competitionId && x.recordsIdFK == competitor.recordsId
                         select x;
            if (result.Any())
            {
                context.Results.Remove(result.First());
            }
            var totalMarks = 0.0;
            foreach (DataGridViewRow row in marksDGV.Rows)
            {
                var mark = 0.0;
                if (double.TryParse(row.Cells[2].Value.ToString(), out mark))
                {
                    totalMarks += mark;
                }
                else
                {
                    MessageBox.Show("Please fill up all the marks");
                    return;
                }
            }

            var insertResult = new Result
            {
                competitionIdFK = questionsQuery.competitionId,
                recordsIdFK = competitor.recordsId,
                totalMarks = totalMarks
            };
            for (int i = 0; i < marksDGV.Rows.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        insertResult.q1Marks = double.Parse(marksDGV[2, i].Value.ToString());
                        break;

                    case 1:
                        insertResult.q2Marks = double.Parse(marksDGV[2, i].Value.ToString());
                        break;

                    case 2:
                        insertResult.q3Marks = double.Parse(marksDGV[2, i].Value.ToString());
                        break;

                    case 3:
                        insertResult.q4Marks = double.Parse(marksDGV[2, i].Value.ToString());
                        break;

                    default:
                        break;
                }
            }

            context.Results.Add(insertResult);
            context.SaveChanges();
            MessageBox.Show("Marks saved");
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}