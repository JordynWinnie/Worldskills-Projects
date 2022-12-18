using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPQR_Session5_9_4_2020.Properties;

namespace TPQR_Session5_9_4_2020
{
    public partial class ViewResults : Form
    {
        private Session5Entities context = new Session5Entities();
        private List<string> finalGoldCountries = new List<string>();
        private List<string> finalSilverCountries = new List<string>();
        private List<string> finalBronzeCountries = new List<string>();

        public ViewResults()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ViewResults_Load(object sender, EventArgs e)
        {
            string[] columns = { "Competitor", "Country", "Total Marks" };

            foreach (var column in columns)
            {
                marksDGV.Columns.Add(column, column);
            }
            skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
            skillCb.SelectedIndex = 0;
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            marksDGV.Rows.Clear();
            var selectedSkill = skillCb.SelectedItem.ToString();
            var numberOfParticipants = context.Competitors.Where(x => x.Skill.skillName == selectedSkill).Count();
            var sessionQuery = (from x in context.Competitions
                                where x.Skill.skillName == selectedSkill
                                select x);

            totalSessionNoLvl.Text = $"Total Number of Sessions: {sessionQuery.Count()}";
            sessionQuery = sessionQuery.Where(x => x.Results.Count == numberOfParticipants);

            var groupQuery = from x in context.Results
                             where sessionQuery.Contains(x.Competition)
                             group x by x.Competitor.competitorName into y
                             orderby y.Sum(x => x.totalMarks) descending
                             select y;

            finalGoldCountries.Clear();
            finalSilverCountries.Clear();
            finalBronzeCountries.Clear();

            var goldList = new List<double>();
            var silverList = new List<double>();
            var bronzeList = new List<double>();
            foreach (var group in groupQuery)
            {
                var totalMark = group.Sum(x => x.Competition.q1MaxMarks + x.Competition.q2MaxMarks + x.Competition.q3MaxMarks + x.Competition.q4MaxMarks);
                var competitorTotalMark = group.Sum(x => x.totalMarks);
                var row = new List<string>
                {
                    group.Key,
                    group.Select(x=>x.Competitor.competitorCountry).First(),
                    competitorTotalMark.ToString(),
                    totalMark.ToString()
                };
                marksDGV.Rows.Add(row.ToArray());

                if (competitorTotalMark > totalMark * 0.8)
                {
                    goldList.Add(competitorTotalMark);

                    if (goldList.Count > 0)
                    {
                        if (goldList[0] - competitorTotalMark <= 2)
                        {
                            finalGoldCountries.Add(group.First().Competitor.competitorCountry);
                        }
                    }
                    else
                    {
                        finalGoldCountries.Add(group.First().Competitor.competitorCountry);
                    }
                    continue;
                }

                if (competitorTotalMark > totalMark * 0.75)
                {
                    silverList.Add(competitorTotalMark);

                    if (silverList.Count > 0)
                    {
                        if (silverList[0] - competitorTotalMark <= 2)
                        {
                            finalSilverCountries.Add(group.First().Competitor.competitorCountry);
                        }
                    }
                    else
                    {
                        finalSilverCountries.Add(group.First().Competitor.competitorCountry);
                    }
                    continue;
                }

                if (competitorTotalMark > totalMark * 0.71)
                {
                    bronzeList.Add(competitorTotalMark);

                    if (bronzeList.Count > 0)
                    {
                        if (bronzeList[0] - competitorTotalMark <= 2)
                        {
                            finalBronzeCountries.Add(group.First().Competitor.competitorCountry);
                        }
                    }
                    else
                    {
                        finalBronzeCountries.Add(group.First().Competitor.competitorCountry);
                    }
                    continue;
                }
            }

            numberOfCompletedSesLbl.Text = $"Number of completed Sessions: {sessionQuery.Count()}";

            DisplayFlags();
        }

        private void DisplayFlags()
        {
            if (finalGoldCountries.Count > 2)
            {
                goldMedalistBtn.Enabled = true;
            }
            else
            {
                goldMedalistBtn.Enabled = false;
            }

            if (finalSilverCountries.Count > 2)
            {
                silverMedalistBtn.Enabled = true;
            }
            else
            {
                silverMedalistBtn.Enabled = false;
            }

            if (finalBronzeCountries.Count > 2)
            {
                bronzeMedalistBtn.Enabled = true;
            }
            else
            {
                bronzeMedalistBtn.Enabled = false;
            }

            var tempGold = finalGoldCountries.Take(2).ToList();
            var tempSilver = finalSilverCountries.Take(2).ToList();
            var tempBronze = finalBronzeCountries.Take(2).ToList();

            PutFlagInPictureBox(tempGold, new List<PictureBox> { goldFlag1, goldFlag2 });
            PutFlagInPictureBox(tempSilver, new List<PictureBox> { silverFlag1, silverFlag2 });
            PutFlagInPictureBox(tempBronze, new List<PictureBox> { bronzeFlag1, bronzeFlag2 });
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

        private void silverMedalistBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"All Medalists: {string.Join(", ", finalSilverCountries)}");
        }

        private void goldMedalistBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"All Medalists: {string.Join(", ", finalGoldCountries)}");
        }

        private void bronzeMedalistBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"All Medalists: {string.Join(", ", finalBronzeCountries)}");
        }
    }
}