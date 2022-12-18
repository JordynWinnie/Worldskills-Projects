using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TPQR_Session5_9_9_2020.Properties;

namespace TPQR_Session5_9_9_2020
{
    public partial class AnalyseResultsForm : Form
    {
        private Session5Entities context = new Session5Entities();

        public AnalyseResultsForm()
        {
            InitializeComponent();
        }

        private void AnalyseResultsForm_Load(object sender, EventArgs e)
        {
            skilCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
            skilCb.SelectedIndex = 0;

            UpdateForm();
        }

        private void UpdateForm()
        {
            var selectedSkill = skilCb.SelectedItem.ToString();

            var totalSession = from x in context.Competitions
                               where x.Skill.skillName == selectedSkill
                               select x;
            var numberOfCompetitors = (from x in context.Competitors
                                       where x.Skill.skillName == selectedSkill
                                       select x);

            var completedSessions = from x in context.Results
                                    where x.Competitor.Skill.skillName == selectedSkill
                                    group x by x.Competition.sessionNo into y
                                    where y.Select(x => x.Competitor).Count() == numberOfCompetitors.Count()
                                    orderby y.Sum(x => x.totalMarks) descending
                                    select y.Key;

            var resultQuery = from x in context.Results
                              where x.Competitor.Skill.skillName == selectedSkill && completedSessions.Contains(x.Competition.sessionNo)
                              group x by x.Competitor.competitorCountry into y
                              orderby y.Average(x => x.totalMarks) descending
                              select y;
            if (resultQuery.Any())
            {
                bestPerformingLbl.Text = $"Best Performing Country: {resultQuery.First().Key}";
                flag.Image = ReturnFlag(resultQuery.First().Key);
            }
            else
            {
                bestPerformingLbl.Text = $"Best Performing Country: ";
                flag.Image = ReturnFlag("");
            }

            var completedSessions1 = (from x in context.Results
                                      where x.Competitor.Skill.skillName == selectedSkill
                                      group x by x.Competition.sessionNo into y
                                      where y.Select(x => x.Competitor).Count() == numberOfCompetitors.Count()
                                      orderby y.Sum(x => x.totalMarks) descending
                                      select y).ToList();
            if (completedSessions1.Any())
            {
                var easiestSes = completedSessions1.First();
                var hardestSes = completedSessions1.Last();
                easiestSesLbl.Text =
                    $"Easiest Session: {easiestSes.Key} " +
                    $"({easiestSes.Last().totalMarks} - {easiestSes.First().totalMarks})";

                toughSesLbl.Text =
                   $"Hardest Session: {hardestSes.Key} " +
                   $"({hardestSes.Last().totalMarks} - {hardestSes.First().totalMarks})";
            }
            else
            {
                easiestSesLbl.Text = "Easiest Session:";
                toughSesLbl.Text = "Hardest Session:";
            }

            var medianQuery = (from x in context.Results
                               where x.Competition.Skill.skillName == selectedSkill
                               select x.totalMarks).ToList();

            var medianMark = 0.0;

            if (medianQuery.Count % 2 == 0)
            {
                medianMark = (medianQuery[medianQuery.Count / 2] + medianQuery[medianQuery.Count / 2 + 1]) / 2;
            }
            else
            {
                medianMark = medianQuery[medianQuery.Count / 2];
            }

            var expectedMedian = context.Skills.Where(x => x.skillName == selectedSkill).Select(x => x.expectedMedianMark).First();
            if (medianMark >= expectedMedian)
            {
                medianMarkLbl.Text = $"Median Mark: {medianMark} (more than median)";
            }
            else
            {
                medianMarkLbl.Text = $"Median Mark: {medianMark} (less than median)";
            }

            var resultQuery1 = from x in context.Results
                               where x.Competitor.Skill.skillName == selectedSkill
                               group x by x.Competitor.competitorName into y
                               orderby y.Average(x => x.totalMarks) descending
                               select y;
            chart1.Series.Clear();

            foreach (var item in resultQuery1)
            {
                chart1.Series.Add(item.Key);
                foreach (var ses in totalSession)
                {
                    if (item.Where(x => x.Competition.sessionNo == ses.sessionNo).Any())
                    {
                        chart1.Series[item.Key].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        chart1.Series[item.Key].Points.AddXY(ses.sessionNo, item.Where(x => x.Competition.sessionNo == ses.sessionNo).Sum(x => x.totalMarks));
                    }
                    else
                    {
                        chart1.Series[item.Key].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        chart1.Series[item.Key].Points.AddXY(ses.sessionNo, 0);
                    }
                }
            }
        }

        private Bitmap ReturnFlag(string countryName)
        {
            switch (countryName.ToLower())
            {
                case "singapore":
                    return Resources.singapore_flag1;

                case "brunei":
                    return Resources.brunei_flag;

                case "laos":
                    return Resources.laos_newflg;

                case "myanmar":
                    return Resources.myanmar3;

                case "indonesia":
                    return Resources.indonesia2;

                case "thailand":
                    return Resources.flg_thailand;

                case "philippines":
                    return Resources.flg_philippine1;

                case "malaysia":
                    return Resources.flagmalaysia;

                case "vietnam":
                    return Resources.flg_vietnam_new;

                case "cambodia":
                    return Resources.flag_cambodia;

                default:
                    return null;
            }
        }

        private void skilCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}