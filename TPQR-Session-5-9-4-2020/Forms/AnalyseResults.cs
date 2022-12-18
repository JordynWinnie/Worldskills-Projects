using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPQR_Session5_9_4_2020.Properties;

namespace TPQR_Session5_9_4_2020
{
    public partial class AnalyseResults : Form
    {
        private Session5Entities context = new Session5Entities();

        public AnalyseResults()
        {
            InitializeComponent();
        }

        private void AnalyseResults_Load(object sender, EventArgs e)
        {
            skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
            skillCb.SelectedIndex = 0;

            UpdateForm();
        }

        private void UpdateForm()
        {
            var selectedSkill = skillCb.SelectedItem.ToString();
            var numberOfParticipants = context.Competitors.Where(x => x.Skill.skillName == selectedSkill).Count();
            var sessionQuery = (from x in context.Competitions
                                where x.Skill.skillName == selectedSkill && x.Results.Count == numberOfParticipants
                                select x);
            var countryQuery = from x in context.Results
                               where sessionQuery.Contains(x.Competition)
                               group x by x.Competitor.competitorCountry into y
                               orderby y.Average(x => x.totalMarks) descending
                               select y;

            if (countryQuery.Any())
            {
                bestPerformingCountryLbl.Text = $"Best Performing Country: {countryQuery.First().Key}";
                PutFlagInPictureBox(new List<string> { countryQuery.First().Key }, new List<PictureBox> { countryFlag });
            }
            else
            {
                bestPerformingCountryLbl.Text = $"Best Performing Country: (Not enough data)";
                countryFlag.Image = null;
            }

            var countryQuery1 = (from x in context.Results
                                 where sessionQuery.Contains(x.Competition)
                                 group x by x.Competition.sessionNo into y
                                 orderby y.Sum(x => x.totalMarks) descending
                                 select y).ToList();

            if (countryQuery1.Any())
            {
                var easiestSession = countryQuery1.First().OrderByDescending(x => x.totalMarks);
                var hardestSession = countryQuery1.Last().OrderByDescending(x => x.totalMarks);
                easiestSesLbl.Text = $"Easiest Session: {easiestSession.First().Competition.sessionNo} ({easiestSession.Last().totalMarks} - {easiestSession.First().totalMarks})";
                hardestSessionLbl.Text = $"Hardest Session: {hardestSession.First().Competition.sessionNo} ({hardestSession.Last().totalMarks} - {hardestSession.First().totalMarks})";
            }
            else
            {
                easiestSesLbl.Text = $"Easiest Session: (Not enough data)";
                hardestSessionLbl.Text = $"Hardest Session: (Not enough data)";
            }

            var medianCalculation = (from x in context.Results
                                     where sessionQuery.Contains(x.Competition)
                                     select x.totalMarks).ToList();
            medianCalculation.Sort();

            var graphQuery = from x in context.Results
                             where x.Competition.Skill.skillName == selectedSkill
                             group x by new { x.Competitor.competitorName, x.Competition.sessionNo } into y
                             select y;

            var allAvailableSessions = from x in context.Competitions
                                       where x.Skill.skillName == selectedSkill
                                       select x;

            markChart.Series.Clear();

            foreach (var name in graphQuery.Select(x => x.Key.competitorName).Distinct())
            {
                var idx = markChart.Series.Add(name);
                idx.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                idx.BorderWidth = 3;
            }
            foreach (var session in graphQuery)
            {
                markChart.Series[session.Key.competitorName].Points.AddXY(session.Key.sessionNo, session.Sum(x => x.totalMarks));
            }

            if (medianCalculation.Count < 2)
            {
                medianMarkLbl.Text = $"Median Mark: (Not enough data)";
                return;
            }

            decimal median = 0;
            if (medianCalculation.Count % 2 == 0)
            {
                //Even elements

                var firstNo = medianCalculation[medianCalculation.Count / 2];
                var secondNo = medianCalculation[medianCalculation.Count / 2 - 1];
                median = (decimal)(firstNo + secondNo) / 2;

                medianMarkLbl.Text = $"Median Mark: {median}";
            }
            else
            {
                //Odd elements

                median = (decimal)medianCalculation[medianCalculation.Count / 2];
                medianMarkLbl.Text = $"Median Mark: {median}";
            }

            var skillMedian = context.Skills.Where(x => x.skillName == selectedSkill).First().expectedMedianMark;

            if (median >= skillMedian)
            {
                medianMarkLbl.Text += " (more than expected median)";
            }
            else
            {
                medianMarkLbl.Text += " (less than expected median)";
            }
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void PutFlagInPictureBox(List<string> listOfCountries, List<PictureBox> pictureBoxes)
        {
            foreach (var pictureBox in pictureBoxes)
            {
                pictureBox.Image = null;
            }
            if (listOfCountries.Count == 0)
            {
                return;
            }

            for (int i = 0; i < listOfCountries.Count; i++)
            {
                switch (listOfCountries[i].ToLower())
                {
                    case "singapore":
                        pictureBoxes[i].Image = Resources.singapore_flag1;
                        break;

                    case "indonesia":
                        pictureBoxes[i].Image = Resources.indonesia2;
                        break;

                    case "thailand":
                        pictureBoxes[i].Image = Resources.flg_thailand;
                        break;

                    case "malaysia":
                        pictureBoxes[i].Image = Resources.flagmalaysia;
                        break;

                    case "philippines":
                        pictureBoxes[i].Image = Resources.flg_philippine1;
                        break;

                    case "vietnam":
                        pictureBoxes[i].Image = Resources.flg_vietnam_new;
                        break;

                    case "brunei":
                        pictureBoxes[i].Image = Resources.brunei_flag;
                        break;

                    case "myanmar":
                        pictureBoxes[i].Image = Resources.myanmar3;
                        break;

                    case "cambodia":
                        pictureBoxes[i].Image = Resources.flag_cambodia;
                        break;

                    case "laos":
                        pictureBoxes[i].Image = Resources.laos_newflg;
                        break;

                    default:
                        break;
                }
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}