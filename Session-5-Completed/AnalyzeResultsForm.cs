using Session5.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Session5
{
    public partial class AnalyzeResultsForm : Form
    {
        public AnalyzeResultsForm()
        {
            InitializeComponent();
        }

        private void AnalyzeResultsForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session5Entities())
            {
                //Populate skill combobox:
                skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
                skillCb.SelectedIndex = 0;

            }
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session5Entities())
            {
                #region Queries to get all relavent information
                var skillNameFromCb = skillCb.SelectedItem.ToString();
                var getSkillId = context.Skills.Where(x => x.skillName.Equals(skillNameFromCb)).Select(x => x.skillId).FirstOrDefault();

                var bestPerformingCountry = from x in context.Results
                                            where x.Competitor.skillIdFK == getSkillId
                                            group x by x.Competitor.competitorCountry into y
                                            select new
                                            {
                                                Country = y.Key,
                                                CountryAvg = y.Average(x => x.totalMarks),
                                                CountryTotal = y.Sum(x => x.totalMarks)
                                            };

                var bestCountry = bestPerformingCountry.Max(x => x.CountryAvg);

                var bestCountryScore = bestPerformingCountry.Where(x => x.CountryAvg == bestCountry).Select(x => x.CountryTotal).First();
                #endregion

                totalMarksLbl.Text = bestCountryScore.ToString();

                //Sets best performing country flag:
                currentFlag.Image = ReturnFlag(bestPerformingCountry
                    .Where(x => x.CountryAvg == bestCountry).Select(x => x.Country).First());


                var sessionInfo = (from x in context.Results
                                   where x.Competition.skillIdFK == getSkillId
                                   group x by x.Competition.competitionId into y
                                   select new
                                   {
                                       y,
                                       LowestScore = y.Min(x => x.totalMarks),
                                       HighestScore = y.Max(x => x.totalMarks),
                                   });

                //Get the session with highest high score and lowest high score:
                var easiestSession = sessionInfo.Max(x => x.HighestScore);
                var hardestSession = sessionInfo.Min(x => x.HighestScore);


                #region Get the respective sessionIDs:
                var easiestCompetitionID = sessionInfo.Where(x => x.HighestScore.Equals(easiestSession)).Select(x => x.y.Key).FirstOrDefault();
                var easiestSessionName = context.Competitions.Where(x => x.competitionId == easiestCompetitionID).Select(x => x.sessionNo).FirstOrDefault();



                easiestSessionLbl.Text = $"{easiestSessionName} ({sessionInfo.Where(x => x.HighestScore.Equals(easiestSession)).Select(x => x.LowestScore).First()} - {sessionInfo.Where(x => x.HighestScore.Equals(easiestSession)).Select(x => x.HighestScore).First()}) marks";

                var toughestSessionCompID = sessionInfo.Where(x => x.HighestScore.Equals(hardestSession)).Select(x => x.y.Key).FirstOrDefault();
                var toughestSessionName = context.Competitions.Where(x => x.competitionId == toughestSessionCompID).Select(x => x.sessionNo).FirstOrDefault();

                toughestSessionLbl.Text = $"{toughestSessionName} ({sessionInfo.Where(x => x.HighestScore.Equals(hardestSession)).Select(x => x.LowestScore).First()} - {sessionInfo.Where(x => x.HighestScore.Equals(hardestSession)).Select(x => x.HighestScore).First()}) marks";

                #endregion

                #region Chart population:
                var graphSessionInfo = (from x in context.Results
                                        where x.Competition.skillIdFK == getSkillId
                                        group x by new { x.Competition.sessionNo, x.Competitor.competitorName } into y
                                        select new
                                        {
                                            CompetitorName = y.Key.competitorName,
                                            SessionName = y.Key.sessionNo,
                                            TotalMark = y.Sum(x => x.totalMarks)

                                        }).ToList();

                trendCompetitor.Series.Clear();

                //Set axis labels:
                trendCompetitor.ChartAreas["ChartArea1"].AxisX.Title = "Session Number";
                trendCompetitor.ChartAreas["ChartArea1"].AxisY.Title = "Total Marks";

                //Loop through all competitor names, add them as a series
                foreach (var item in graphSessionInfo.Select(x => x.CompetitorName).Distinct())
                {
                    trendCompetitor.Series.Add(item);
                    trendCompetitor.Series[item].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }

                //Loop through the whole query, add info based on the series:
                foreach (var item in graphSessionInfo)
                {
                    var idx = trendCompetitor.Series[item.CompetitorName].Points.AddXY($"Session {item.SessionName}", item.TotalMark);
                    trendCompetitor.Series[item.CompetitorName].Points[idx].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                }

                #endregion

                #region Median Calculation
                var calcuationOfMedian = from x in context.Results
                                         where x.Competitor.skillIdFK == getSkillId
                                         select x;

                var totalList = new List<double>();
                totalList.Clear();
                //Add all total marks to a list:
                foreach (var total in calcuationOfMedian)
                {
                    totalList.Add(total.totalMarks);
                }

                //Sort the table:
                totalList.Sort();


                double median = 0.0;
                //Check if list has odd number elements or even number elements:
                if (totalList.Count % 2 == 0)
                {
                    //Even number elements
                    median = (totalList[totalList.Count / 2] + totalList[(totalList.Count / 2) - 1]) / 2;
                }
                else
                {
                    median = totalList[totalList.Count / 2];
                    //Odd number elements
                }

                medianMarkLbl.Text = median.ToString();

                medianDownArrow.Visible = false;
                medianUpArrow.Visible = false;

                var expectedSkillMedian = context.Skills.Where(x => x.skillId == getSkillId).Select(x => x.expectedMedianMark).First();

                if (median >= expectedSkillMedian )
                {
                    medianUpArrow.Visible = true;
                }
                else
                {
                    medianDownArrow.Visible = true;
                }
                #endregion
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// This method takes in the country name, which can be spelled case insensitive
        /// and returns the country flag as a bitmap
        /// If it cannot find the country name, it returns a broken flag to indicate there is a missing file
        /// </summary>
        Bitmap ReturnFlag(string countryName)
        {
            switch (countryName.Trim().ToLower())
            {
                case "brunei":
                    return Resources.brunei_flag;
                case "australia":
                    return Resources.australia_flg;
                case "china":
                    return Resources.chinaflag;
                case "cambodia":
                    return Resources.flag_cambodia;
                case "russia":
                    return Resources.flag_russia;
                case "malaysia":
                    return Resources.flagmalaysia;
                case "india":
                    return Resources.flg_india;
                case "philippine":
                    return Resources.flg_philippine1;
                case "qatar":
                    return Resources.flg_qatar;
                case "thailand":
                    return Resources.flg_thailand;
                case "vietnam":
                    return Resources.flg_vietnam_new;
                case "indonesia":
                    return Resources.indonesia2;
                case "laos":
                    return Resources.laos_newflg;
                case "maldives":
                    return Resources.maldivesfg;
                case "myanmar":
                    return Resources.myanmar3;
                case "newzealand":
                    return Resources.newzealand_flg5;
                case "greece":
                    return Resources.old_greece;
                case "singapore":
                    return Resources.singapore_flag1;
                case "southkorea":
                    return Resources.southkorea_flag_new;
                case "switzerland":
                    return Resources.switzerland_old;
                default:
                    return Resources.brokenFlag;
            }
        }
    }
}
