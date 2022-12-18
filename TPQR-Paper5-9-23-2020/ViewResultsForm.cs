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
    public partial class ViewResultsForm : Form
    {
        private Session5Entities context = new Session5Entities();
        private string selectedSkill;

        public ViewResultsForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ViewResultsForm_Load(object sender, EventArgs e)
        {
            var columns = new List<string> { "Competitor", "Country", "Total Marks" };

            foreach (var column in columns)
            {
                competitorDGV.Columns.Add(column, column);
            }

            skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
            skillCb.SelectedIndex = 0;
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            competitorDGV.Rows.Clear();
            selectedSkill = skillCb.SelectedItem.ToString();
            var totalNumberOfSession = context.Competitions.Where(x => x.Skill.skillName == selectedSkill).Count();

            var numberOfCompetitors = context.Competitors.Where(x => x.Skill.skillName == selectedSkill).Count();

            totalNumberOfSessionsLbl.Text = $"Totao number of Sessions: {totalNumberOfSession}";
            var completedSessions = from x in context.Results
                                    where x.Competition.Skill.skillName == selectedSkill
                                    group x by x.Competition.sessionNo into y
                                    where y.Count() == numberOfCompetitors
                                    select y;

            completedSessionsLbl.Text = $"Completed Sessions: {completedSessions.Count()}";

            var results = from x in context.Results
                          where x.Competition.Skill.skillName == selectedSkill
                          group x by x.Competitor.competitorName into y
                          orderby y.Sum(x => x.totalMarks) descending
                          select y;

            var goldQualifier = new List<string>();
            var silverQualifiers = new List<string>();
            var bronzeQualifers = new List<string>();
            foreach (var result in results)
            {
                var row = new List<string>()
                {
                    result.Key,
                    result.First().Competitor.competitorName,
                    result.Sum(x=>x.totalMarks).ToString()
                };
                competitorDGV.Rows.Add(row.ToArray());
                var competitionMaxMark = result.Sum(x => x.Competition.q1MaxMarks + x.Competition.q2MaxMarks + x.Competition.q3MaxMarks
                + x.Competition.q4MaxMarks);
                if (result.Sum(x => x.totalMarks) >= competitionMaxMark * .8)
                {
                    goldQualifier.Add(result.Key);
                    continue;
                }

                if (result.Sum(x => x.totalMarks) >= competitionMaxMark * .75)
                {
                    silverQualifiers.Add(result.Key);
                    continue;
                }

                if (result.Sum(x => x.totalMarks) >= competitionMaxMark * .71)
                {
                    bronzeQualifers.Add(result.Key);
                    continue;
                }
            }

            foreach (var gold in goldQualifier)
            {
                Console.WriteLine(gold);
            }

            foreach (var silver in silverQualifiers)
            {
                Console.WriteLine(silver);
            }

            foreach (var bronze in bronzeQualifers)
            {
                Console.WriteLine(bronze);
            }
        }
    }
}