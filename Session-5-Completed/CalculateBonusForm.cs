using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session5
{
    public partial class CalculateBonusForm : Form
    {
        public CalculateBonusForm()
        {
            InitializeComponent();
        }

        private void CalculateBonusForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session5Entities())
            {
                //populate skill combobox:
                skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());

                //Populate columns
                var columns = new List<string>
                {
                    "Question", "Marks Received", "Max Possible Marks", "Amount Recieved"
                };
                
                foreach (var column in columns)
                {
                    bonusDGV.Columns.Add(column, column);
                }

                bonusDGV.ReadOnly = true;
            }
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session5Entities())
            {
                //Populate Competitor ComboBox
                var skillNameFromCb = skillCb.SelectedItem.ToString();
                var skillID = context.Skills.Where(x => x.skillName.Equals(skillNameFromCb)).Select(x => x.skillId).First();
                competitorCb.Items.Clear();

                competitorCb.Items.AddRange(context.Competitors.Where(x => x.skillIdFK == skillID).Select(x => x.competitorName).ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void competitorCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session5Entities())
            {
                int totalBonus = 0;
                double totalReceived = 0;

                #region All Queries for necessary information
                var skillNameFromCb = skillCb.SelectedItem.ToString();
                var skillID = context.Skills.Where(x => x.skillName.Equals(skillNameFromCb)).Select(x => x.skillId).First();

                var competitorNameFromCb = competitorCb.SelectedItem.ToString();
                var recordsID = context.Competitors.Where(x => x.competitorName.Equals(competitorNameFromCb)).Select(x => x.recordsId).First();

                var questionSetNumber = from x in context.Competitions
                                      where x.skillIdFK == skillID
                                      group x by x.sessionNo into y
                                      select y;
                #endregion

                bonusDGV.Rows.Clear();
                foreach (var questionSet in questionSetNumber)
                {
                    //Demarks all sessions with their respective full marks:
                    var sessionMarksRow = questionSet.Key;
                    var totalMarksForSession = questionSet.Sum(x => x.q1MaxMarks + x.q2MaxMarks + x.q3MaxMarks + x.q4MaxMarks);
                    bonusDGV.Rows.Add($"Session {questionSet.Key} (Total marks: {totalMarksForSession})");

                    foreach (var session in questionSet)
                    {
                        List<string> row = new List<string>();

                        var getCompetitorPerformance = context.Results.Where(x => x.competitionIdFK == session.competitionId && x.recordsIdFK == recordsID);
                        
                        //Check if they score > 75% of total.
                        var getCompetitorSessionTotalMark = context.Results.Where(x => x.competitionIdFK == session.competitionId && x.recordsIdFK == recordsID).Select(x=>x.totalMarks);

                        if (getCompetitorSessionTotalMark.Any())
                        {
                            if (getCompetitorSessionTotalMark.First() >= (Convert.ToDouble(totalMarksForSession) * 0.75))
                            {
                                totalBonus += 5;
                            }
                            
                        }

                        //Checks for a question 1, and calculates worth. Repeats for all questions:
                        //Marks question as not marked yet if nothing is returned from the database:

                        if (!(session.q1MaxMarks == 0))
                        {
                            #region Question 1
                            var questionWorth = (Convert.ToDouble(session.q1MaxMarks) / Convert.ToDouble(totalMarksForSession)) * 100;

                            row.Add($"Question 1 (Worth ${questionWorth})");
                            if (getCompetitorPerformance.Any())
                            {
                                row.Add(getCompetitorPerformance.First().q1Marks.ToString());
                            }
                            else
                            {
                                row.Add("(Not Marked Yet)");
                            }

                            row.Add(session.q1MaxMarks.ToString());

                            if (getCompetitorPerformance.Any())
                            {
                                row.Add(((getCompetitorPerformance.First().q1Marks / session.q1MaxMarks) * questionWorth).ToString("0.00"));
                                totalReceived += (getCompetitorPerformance.First().q1Marks / session.q1MaxMarks) * questionWorth;
                            }
                            else
                            {
                                row.Add("(Not Marked Yet)");
                            }
                            bonusDGV.Rows.Add(row.ToArray());
                            #endregion
                        }

                        row.Clear();

                        if (!(session.q2MaxMarks == 0))
                        {
                            #region Question 2
                            var questionWorth = (Convert.ToDouble(session.q2MaxMarks) / Convert.ToDouble(totalMarksForSession)) * 100;

                            row.Add($"Question 2 (Worth ${questionWorth})");
                            if (getCompetitorPerformance.Any())
                            {
                                

                                row.Add(getCompetitorPerformance.First().q2Marks.ToString());
                            }
                            else
                            {
                                row.Add("(Not Marked Yet)");
                            }
                            row.Add(session.q2MaxMarks.ToString());

                            if (getCompetitorPerformance.Any())
                            {
                                row.Add(((getCompetitorPerformance.First().q2Marks / session.q2MaxMarks) * questionWorth).ToString("0.00"));
                                totalReceived += (getCompetitorPerformance.First().q2Marks / session.q2MaxMarks) * questionWorth;
                            }
                            else
                            {
                                row.Add("(Not Marked Yet)");
                            }

                            bonusDGV.Rows.Add(row.ToArray());
                            #endregion
                        }
                        row.Clear();

                        if (!(session.q3MaxMarks == 0))
                        {
                            #region Question 3
                            var questionWorth = (Convert.ToDouble(session.q3MaxMarks) / Convert.ToDouble(totalMarksForSession)) * 100;

                            row.Add($"Question 3 (Worth ${questionWorth})");
                            if (getCompetitorPerformance.Any())
                            {
                                row.Add(getCompetitorPerformance.First().q3Marks.ToString());
                                

                            }
                            else
                            {
                                row.Add("(Not Marked Yet)");
                            }
                            row.Add(session.q3MaxMarks.ToString());

                            if (getCompetitorPerformance.Any())
                            {
                                row.Add(((getCompetitorPerformance.First().q3Marks / session.q3MaxMarks) * questionWorth).ToString("0.00"));
                                totalReceived += (getCompetitorPerformance.First().q3Marks / session.q3MaxMarks) * questionWorth;
                            }
                            else
                            {
                                row.Add("(Not Marked Yet)");
                            }
                            bonusDGV.Rows.Add(row.ToArray());
                            #endregion
                        }

                        row.Clear();

                        if (!(session.q4MaxMarks == 0))
                        {
                            #region Question 4
                            var questionWorth = (Convert.ToDouble(session.q4MaxMarks) / Convert.ToDouble(totalMarksForSession)) * 100;

                            row.Add($"Question 4 (Worth ${questionWorth})");
                            if (getCompetitorPerformance.Any())
                            {
                                row.Add(getCompetitorPerformance.First().q4Marks.ToString());
                            }
                            else
                            {
                                row.Add("(Not Marked Yet)");
                            }
                            row.Add(session.q4MaxMarks.ToString());

                            if (getCompetitorPerformance.Any())
                            {
                                row.Add(((getCompetitorPerformance.First().q4Marks / session.q4MaxMarks) * questionWorth).ToString("0.00"));
                                totalReceived += (getCompetitorPerformance.First().q4Marks / session.q4MaxMarks) * questionWorth;
                            }
                            else
                            {
                                row.Add("(Not Marked Yet)");
                            }
                            bonusDGV.Rows.Add(row.ToArray());
                            #endregion
                        }
                    }
                }

                //Gets current median, the gets the average score of the competitor:
                var currentMedianForSkill = context.Skills.Where(x => x.skillId == skillID).Select(x => x.expectedMedianMark).FirstOrDefault();
                var competitorAverageScore = context.Results.Where(x => x.recordsIdFK == recordsID).Average(x => x.totalMarks);

                //If he scores above median, gets an extra:
                if (competitorAverageScore >= currentMedianForSkill)
                {
                    totalBonus += 10;
                }

                BonusLbl.Text = $"Bonus: ${totalBonus}";
                totalToReceiveLbl.Text = $"Total Amount Received: ${totalReceived + totalBonus}";

            }
        }
    }
}
