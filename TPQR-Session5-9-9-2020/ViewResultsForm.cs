using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TPQR_Session5_9_9_2020.Properties;

namespace TPQR_Session5_9_9_2020
{
    public partial class ViewResultsForm : Form
    {
        private Session5Entities context = new Session5Entities();
        private List<string> goldCompetitors;
        private List<string> silverCompetitors;
        private List<string> bronzedCompetitors;

        public ViewResultsForm()
        {
            InitializeComponent();
        }

        private void ViewResultsForm_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Competitor", "Country", "Total Marks", "TotalSessionMarks"
            };
            foreach (var column in columns)
            {
                marksDGV.Columns.Add(column, column);
            }
            skilCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
            skilCb.SelectedIndex = 0;

            UpdateTable();
        }

        private void UpdateTable()
        {
            marksDGV.Rows.Clear();
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
                                    select y.Key;

            totalSessionsLabel.Text = $"Total Sessions: {totalSession.Count()}";
            noOfCompletedSessionsLbl.Text = $"No Of Completed Sessions: {completedSessions.Count()}";

            var resultQuery = from x in context.Results
                              where x.Competitor.Skill.skillName == selectedSkill && completedSessions.Contains(x.Competition.sessionNo)
                              group x by x.Competitor.competitorName into y
                              orderby y.Sum(x => x.totalMarks) descending
                              select y;

            foreach (var result in resultQuery)
            {
                var row = new List<string>
                {
                    result.Key,
                    result.Select(x=>x.Competitor.competitorCountry).First(),
                    result.Sum(x=>x.totalMarks).ToString(),
                    result.Sum(x=>x.Competition.q1MaxMarks + x.Competition.q2MaxMarks + x.Competition.q3MaxMarks + x.Competition.q4MaxMarks).ToString()
                };

                marksDGV.Rows.Add(row.ToArray());
            }

            var goldQuery = (from x in resultQuery
                             where x.Sum(y => y.totalMarks)
                             >= x.Sum(y => y.Competition.q1MaxMarks + y.Competition.q2MaxMarks + y.Competition.q3MaxMarks + y.Competition.q4MaxMarks) * .80
                             select x).ToList();

            var silverQuery = (from x in resultQuery
                               where x.Sum(y => y.totalMarks)
                               >= x.Sum(y => y.Competition.q1MaxMarks + y.Competition.q2MaxMarks + y.Competition.q3MaxMarks + y.Competition.q4MaxMarks) * .75
                               select x).ToList();

            var bronzeQuery = (from x in resultQuery
                               where x.Sum(y => y.totalMarks)
                               >= x.Sum(y => y.Competition.q1MaxMarks + y.Competition.q2MaxMarks + y.Competition.q3MaxMarks + y.Competition.q4MaxMarks) * .71
                               select x).ToList();

            goldCompetitors = new List<string>();
            silverCompetitors = new List<string>();
            bronzedCompetitors = new List<string>();
            foreach (DataGridViewRow row1 in marksDGV.Rows)
            {
                var maxMarks = double.Parse(row1.Cells[3].Value.ToString());
                var currentMark = double.Parse(row1.Cells[2].Value.ToString());
                var competitorName = row1.Cells[0].Value.ToString();
                //Categorise into Gold:
                if (currentMark >= maxMarks * .85)
                {
                    if (goldCompetitors.Count == 0)
                    {
                        goldCompetitors.Add(competitorName);
                    }
                    else
                    {
                        var firstPlace = goldCompetitors[0];
                        var placeHolder = goldQuery.Where(x => x.Key == firstPlace).First();

                        if (placeHolder.Sum(x => x.totalMarks) - currentMark <= 2)
                        {
                            goldCompetitors.Add(competitorName);
                        }
                        else
                        {
                            silverCompetitors.Add(competitorName);
                        }
                    }
                    continue;
                }
                //Categories into Silver
                if (currentMark >= maxMarks * .75)
                {
                    if (silverCompetitors.Count == 0)
                    {
                        silverCompetitors.Add(competitorName);
                    }
                    else
                    {
                        var firstPlace = silverCompetitors[0];
                        var placeHolder = silverQuery.Where(x => x.Key == firstPlace).First();

                        if (placeHolder.Sum(x => x.totalMarks) - currentMark <= 2)
                        {
                            silverCompetitors.Add(competitorName);
                        }
                        else
                        {
                            bronzedCompetitors.Add(competitorName);
                        }
                    }
                    continue;
                }

                if (currentMark >= maxMarks * .71)
                {
                    if (bronzedCompetitors.Count == 0)
                    {
                        bronzedCompetitors.Add(competitorName);
                    }
                    else
                    {
                        var firstPlace = bronzedCompetitors[0];
                        var placeHolder = bronzeQuery.Where(x => x.Key == firstPlace).First();

                        if (placeHolder.Sum(x => x.totalMarks) - currentMark <= 2)
                        {
                            bronzedCompetitors.Add(competitorName);
                        }
                    }
                    continue;
                }
            }

            Console.WriteLine("Gold Competitors: " + string.Join(", ", goldCompetitors));
            Console.WriteLine("Silver Competitors: " + string.Join(", ", silverCompetitors));
            Console.WriteLine("Bronze Competitors: " + string.Join(", ", bronzedCompetitors));

            for (int i = 0; i < goldCompetitors.Count; i++)
            {
                var competitor = goldCompetitors[i];
                var country = context.Competitors.Where(x => x.competitorName == competitor).First().competitorCountry;
                if (i == 0)
                {
                    goldFlg1.Image = ReturnFlag(country);
                }
                if (i == 1)
                {
                    goldFlg2.Image = ReturnFlag(country);
                }
            }

            for (int i = 0; i < silverCompetitors.Count; i++)
            {
                var competitor = silverCompetitors[i];
                var country = context.Competitors.Where(x => x.competitorName == competitor).First().competitorCountry;
                if (i == 0)
                {
                    silverFlg1.Image = ReturnFlag(country);
                }
                if (i == 1)
                {
                    silverFlg2.Image = ReturnFlag(country);
                }
            }

            for (int i = 0; i < bronzedCompetitors.Count; i++)
            {
                var competitor = bronzedCompetitors[i];
                var country = context.Competitors.Where(x => x.competitorName == competitor).First().competitorCountry;
                if (i == 0)
                {
                    bronzeFlg1.Image = ReturnFlag(country);
                }
                if (i == 1)
                {
                    bronzeFlg2.Image = ReturnFlag(country);
                }
            }

            if (goldCompetitors.Count < 2)
            {
                moreGoldBtn.Enabled = false;
            }
            else
            {
                moreGoldBtn.Enabled = true;
            }

            if (silverCompetitors.Count < 2)
            {
                moreSilverBtn.Enabled = false;
            }
            else
            {
                moreSilverBtn.Enabled = true;
            }

            if (bronzedCompetitors.Count < 2)
            {
                moreBronzeBtn.Enabled = false;
            }
            else
            {
                moreBronzeBtn.Enabled = true;
            }
        }

        private void skilCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
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

        private void moreSilverBtn_Click(object sender, EventArgs e)
        {
            var silverCountries = new List<string>();

            foreach (var item in silverCompetitors)
            {
                var country = context.Competitors.Where(x => x.competitorName == item).First().competitorCountry;
                silverCountries.Add(country);
            }

            MessageBox.Show($"Countries: {string.Join(",", silverCountries)}");
        }

        private void moreGoldBtn_Click(object sender, EventArgs e)
        {
            var goldCountries = new List<string>();

            foreach (var item in goldCompetitors)
            {
                var country = context.Competitors.Where(x => x.competitorName == item).First().competitorCountry;
                goldCountries.Add(country);
            }

            MessageBox.Show($"Countries: {string.Join(",", goldCountries)}");
        }

        private void moreBronzeBtn_Click(object sender, EventArgs e)
        {
            var bronzeCountries = new List<string>();

            foreach (var item in bronzedCompetitors)
            {
                var country = context.Competitors.Where(x => x.competitorName == item).First().competitorCountry;
                bronzeCountries.Add(country);
            }

            MessageBox.Show($"Countries: {string.Join(",", bronzeCountries)}");
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}