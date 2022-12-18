using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Paper5_9_23_2020
{
    public partial class EnterMarksForm : Form
    {
        private Session5Entities context = new Session5Entities();
        private string selectedSkill;
        private object _currentCellValue;
        private double totalMarks;

        public EnterMarksForm()
        {
            InitializeComponent();
        }

        private void EnterMarksForm_Load(object sender, EventArgs e)
        {
            skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());

            var columns = new List<string> { "Question", "Grade", "Marks", "MaxMarks" };
            foreach (var column in columns)
            {
                marksDGV.Columns.Add(column, column);
            }
            foreach (DataGridViewColumn column1 in marksDGV.Columns)
            {
                column1.ReadOnly = true;
            }
            marksDGV.Columns[1].ReadOnly = false;
            skillCb.SelectedIndex = 0;
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSkill = skillCb.SelectedItem.ToString();
            RefreshSessionsAndName();
        }

        private void RefreshSessionsAndName()
        {
            sessionNoCb.Items.Clear();
            competitorNameCb.Items.Clear();
            sessionNoCb.Items.AddRange(context.Competitions.Where(x => x.Skill.skillName == selectedSkill).Select(x => x.sessionNo.ToString()).ToArray());
            competitorNameCb.Items.AddRange(context.Competitors.Where(x => x.Skill.skillName == selectedSkill).Select(x => x.competitorName).ToArray());

            sessionNoCb.SelectedIndex = 0;
            competitorNameCb.SelectedIndex = 0;

            RefreshDGV();
        }

        private void RefreshDGV()
        {
            marksDGV.Rows.Clear();
            string[] row = new string[4];
            if (competitorNameCb.SelectedIndex == -1 || sessionNoCb.SelectedIndex == -1)
            {
                return;
            }
            var sessionNo = int.Parse(sessionNoCb.SelectedItem.ToString());
            var competition = context.Competitions.Where(x => x.Skill.skillName == selectedSkill && x.sessionNo == sessionNo).First();

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
        }

        private void sessionNoCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        private void marksDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var maxMarks = double.Parse(marksDGV[3, e.RowIndex].Value.ToString());
            switch (marksDGV[1, e.RowIndex].Value.ToString().ToLower())
            {
                case "gd":
                    marksDGV[2, e.RowIndex].Value = maxMarks * 1.0;
                    break;

                case "good":
                    marksDGV[2, e.RowIndex].Value = maxMarks * 1.0;
                    break;

                case "av":
                    marksDGV[2, e.RowIndex].Value = maxMarks * 0.65;
                    break;

                case "average":
                    marksDGV[2, e.RowIndex].Value = maxMarks * 0.65;
                    break;

                case "pr":
                    marksDGV[2, e.RowIndex].Value = maxMarks * 0.2;
                    break;

                case "poor":
                    marksDGV[2, e.RowIndex].Value = maxMarks * 0.2;
                    break;

                default:
                    marksDGV[1, e.RowIndex].Value = _currentCellValue;
                    break;
            }
            totalMarks = 0.0;
            foreach (DataGridViewRow row in marksDGV.Rows)
            {
                double tempOut = 0.0;
                if (row.Cells[2].Value != null)
                {
                    if (double.TryParse(row.Cells[2].Value.ToString(), out tempOut))
                    {
                        totalMarks += tempOut;
                    }
                }
            }

            totalMarksLbl.Text = $"Total Marks: {totalMarks}";
        }

        private void marksDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void marksDGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _currentCellValue = marksDGV[e.ColumnIndex, e.RowIndex].Value;
        }

        private void clearForm_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in marksDGV.Rows)
            {
                row.Cells[1].Value = string.Empty;
                row.Cells[2].Value = string.Empty;
            }

            totalMarksLbl.Text = $"Total Marks: 0";
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            var competitorName = competitorNameCb.SelectedItem.ToString();
            var recordsID = context.Competitors.Where(x => x.competitorName == competitorName && x.Skill.skillName == selectedSkill).First().recordsId;
            var sessionNo = int.Parse(sessionNoCb.SelectedItem.ToString());
            var competition = context.Competitions.Where(x => x.Skill.skillName == selectedSkill && x.sessionNo == sessionNo).First().competitionId;

            var result = context.Results.Where(x => x.competitionIdFK == competition && x.recordsIdFK == recordsID);

            if (result.Any())
            {
                context.Results.Remove(result.First());
            }

            foreach (DataGridViewRow row in marksDGV.Rows)
            {
                if (row.Cells[2].Value == null)
                {
                    MessageBox.Show("All marks should be entered");
                    return;
                }
            }

            var insertResult = new Result
            {
                competitionIdFK = competition,
                recordsIdFK = recordsID,
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
            MessageBox.Show("Marks Entered");
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}