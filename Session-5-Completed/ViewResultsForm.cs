using Session5.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Session5
{
    public partial class ViewResultsForm : Form
    {
        List<CustomResultClass> goldList = new List<CustomResultClass>();
        List<CustomResultClass> silverList = new List<CustomResultClass>();
        List<CustomResultClass> bronzeList = new List<CustomResultClass>();

        public ViewResultsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewResultsForm_Load(object sender, EventArgs e)
        {

            using (var context = new Session5Entities())
            {
                //Populating Columns:
                var columns = new List<string>
                {
                    "Competitor", "Country", "Total Marks", "SessionFullMarks"
                };

                foreach (var column in columns)
                {
                    marksDGV.Columns.Add(column, column);
                };

                marksDGV.ReadOnly = true;
                marksDGV.Columns[3].Visible = false;

                //Populate skill combobox:
                skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
            }
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            marksDGV.Rows.Clear();
            using (var context = new Session5Entities())
            {
                //Hides all the reward-based UI elements:
                goldFinalistsButton.Visible = false;
                silverFinalistsBtn.Visible = false;
                bronzeFinalistsButton.Visible = false;

                goldFlag1.Image = null;
                goldFlag2.Image = null;
                silverFlag1.Image = null;
                silverFlag2.Image = null;
                bronzeFlag1.Image = null;
                bronzeFlag2.Image = null;

                //Clears the global list
                goldList.Clear();
                silverList.Clear();
                bronzeList.Clear();

                //All relavent queries to get skill info, number of competitors and sessions:
                int completedSessions = 0;
                var skillNameFromCb = skillCb.SelectedItem.ToString();
                var getSkillId = context.Skills.Where(x => x.skillName.Equals(skillNameFromCb)).Select(x => x.skillId).FirstOrDefault();

                var numberOfCompetitors = context.Competitors.Where(x => x.skillIdFK == getSkillId).Count();

                var numberOfSessions = context.Competitions.Where(x => x.skillIdFK == getSkillId).Select(x => x.sessionNo).Count();

                totalNoOfSessionsLbl.Text = $"Total No. Of Sessions: {numberOfSessions}";

                //temporary list made of the CustomResultClass (custom made class)
                var resultList = new List<CustomResultClass>();

                //Loops through all the session numbers:
                foreach (var sessionNo in context.Competitions.Where(x => x.skillIdFK == getSkillId).Select(x => x.sessionNo))
                {
                    //Checks competition id of current session:
                    var compeitionid = context.Competitions.Where(x => x.skillIdFK == getSkillId && x.sessionNo == sessionNo).Select(x => x.competitionId).First();

                    //Checks result list for the count of marked results for current Session. 
                    //If it matches number of competitors, it means the session has been completed:
                    if (context.Results.Where(x => x.competitionIdFK == compeitionid).Count() == numberOfCompetitors)
                    {
                        //Add 1 to completed session count
                        completedSessions++;
                        //Get all the result information:
                        var resultsTable = (from x in context.Results
                                            where x.competitionIdFK == compeitionid && x.Competition.skillIdFK == getSkillId
                                            select new
                                            {
                                                x.totalMarks,
                                                CompetitorName = x.Competitor.competitorName,
                                                CompetitorCountry = x.Competitor.competitorCountry,
                                                TotalMaxMarkForSession = (x.Competition.q1MaxMarks + x.Competition.q2MaxMarks
                                                + x.Competition.q3MaxMarks + x.Competition.q4MaxMarks)
                                            }).ToList();

                        //Loop through all the related compeition id(s):
                        foreach (var item in resultsTable)
                        {
                            //Add the custom class based off results into the resultList
                            CustomResultClass c = new CustomResultClass
                            {
                                Country = item.CompetitorCountry,
                                CompetitorName = item.CompetitorName,
                                TotalMarks = item.totalMarks,
                                TotalSessionMarks = item.TotalMaxMarkForSession
                            };

                            resultList.Add(c);
                        }

                    }

                }
                numberOfCompletedSessions.Text = $"No of Completed Sessions: {completedSessions}";
               
                //A custom class was made to allow Result List to be interacted with by LinQ:
                var groupedListOfMarks = from x in resultList
                                         group x by x.CompetitorName into y
                                         select new
                                         {
                                             TotalMarks = y.Sum(x => x.TotalMarks),
                                             Country = y.Select(x => x.Country),
                                             Name = y.Key,
                                             TotalSessionMark = y.Sum(x => x.TotalSessionMarks)
                                         };

                //Loops through the groupedList by total marks:
                foreach (var item in groupedListOfMarks.OrderByDescending(x => x.TotalMarks))
                {
                    //Add from grouped list
                    var row = new List<string>
                    {
                        item.Name,
                        item.Country.First(),
                        item.TotalMarks.ToString(),
                        item.TotalSessionMark.ToString()
                    };

                    marksDGV.Rows.Add(row.ToArray());
                }

                
                var generalQualifierQuery = (from x in resultList
                                             group x by x.CompetitorName into y
                                             select new
                                             {
                                                 TotalMarks = y.Sum(x => x.TotalMarks),
                                                 Country = y.Select(x => x.Country),
                                                 Name = y.Key,
                                                 TotalSessionMark = y.Sum(x => x.TotalSessionMarks)
                                             });



                //List of people who qualify for Gold:
                #region Determine Gold Finalists
                foreach (var item in generalQualifierQuery.Where(x => x.TotalMarks >= (x.TotalSessionMark * 0.8)).OrderByDescending(x => x.TotalMarks))
                {
                    
                    CustomResultClass customResult = new CustomResultClass
                    {
                        Country = item.Country.First(),
                        TotalMarks = item.TotalMarks,
                        CompetitorName = item.Name
                    };

                    //First competitor ALWAYS gets in.
                    if (goldList.Count == 0)
                    {
                        goldList.Add(customResult);
                    }
                    else
                    {
                        //Check next competitor for Same score, or less than or equal to 2 marks below highest score.
                        if (item.TotalMarks == goldList[0].TotalMarks || (goldList[0].TotalMarks - item.TotalMarks) <= 2)
                        {
                            goldList.Add(customResult);
                        }
                    }
                }

                if (goldList.Count > 2)
                {
                    //If there are more than 2 gold finalists, show a button to show a list of gold medalists
                    goldFinalistsButton.Visible = true;
                }
                else if (goldList.Count == 2)
                {
                    //Sets the 2 flags to two of the gold finalists:
                    goldFlag1.Image = ReturnFlag(goldList[0].Country);
                    goldFlag2.Image = ReturnFlag(goldList[1].Country);
                }
                else if (goldList.Count == 1)
                {
                    //Sets the 1 flags to the only gold finalist:
                    goldFlag1.Image = ReturnFlag(goldList[0].Country);
                }

                #endregion

                #region Determine Gold Finalists
                //List of People who qualify for silver
                foreach (var item in generalQualifierQuery.Where(x => x.TotalMarks >= (x.TotalSessionMark * 0.75)).OrderByDescending(x => x.TotalMarks))
                {
                    //First competitor ALWAYS gets in.
                    CustomResultClass customResult = new CustomResultClass
                    {
                        Country = item.Country.First(),
                        TotalMarks = item.TotalMarks,
                        CompetitorName = item.Name
                    };

                    //Check if the current Finalist is already in the goldFinalists:

                    if (!goldList.Where(x=>x.CompetitorName.Equals(item.Name) && x.TotalMarks == item.TotalMarks).Any())
                    {
                        if (silverList.Count == 0)
                        {
                            silverList.Add(customResult);
                        }
                        else
                        {
                            //Check next competitor for Same score, or less than or equal to 2 marks below highest score.
                            if (item.TotalMarks == silverList[0].TotalMarks || (silverList[0].TotalMarks - item.TotalMarks) <= 2)
                            {
                                silverList.Add(customResult);
                            }
                        }
                    }
                    
                   
                }
                //Same logic as gold:
                if (silverList.Count > 2)
                {
                    silverFinalistsBtn.Visible = true;
                }
                else if (silverList.Count == 2)
                {
                    silverFlag1.Image = ReturnFlag(silverList[0].Country);
                    silverFlag2.Image = ReturnFlag(silverList[1].Country);
                }
                else if (silverList.Count == 1)
                {
                    silverFlag1.Image = ReturnFlag(silverList[0].Country);
                }
                #endregion

                #region Determine Bronze Finalists
                foreach (var item in generalQualifierQuery.Where(x => x.TotalMarks >= (x.TotalSessionMark * 0.71)).OrderByDescending(x => x.TotalMarks))
                {
                    //First competitor ALWAYS gets in.
                    CustomResultClass customResult = new CustomResultClass
                    {
                        Country = item.Country.First(),
                        TotalMarks = item.TotalMarks,
                        CompetitorName = item.Name
                    };

                    //Check if the current Finalist is already in the goldFinalists && silverFinalists

                    if (!goldList.Where(x => x.CompetitorName.Equals(item.Name) && x.TotalMarks == item.TotalMarks).Any() 
                        && !silverList.Where(x => x.CompetitorName.Equals(item.Name) && x.TotalMarks == item.TotalMarks).Any())
                    {
                        if (bronzeList.Count == 0)
                        {
                            bronzeList.Add(customResult);
                        }
                        else
                        {
                            //Check next competitor for Same score, or less than or equal to 2 marks below highest score.
                            if (item.TotalMarks == bronzeList[0].TotalMarks || (bronzeList[0].TotalMarks - item.TotalMarks) <= 2)
                            {
                                bronzeList.Add(customResult);
                            }
                        }
                    }
                }
                //Same logic as silver
                if (bronzeList.Count > 2)
                {
                    bronzeFinalistsButton.Visible = true;
                }
                else if (bronzeList.Count == 2)
                {
                    bronzeFlag1.Image = ReturnFlag(bronzeList[0].Country);
                    bronzeFlag2.Image = ReturnFlag(bronzeList[1].Country);
                }
                else if (bronzeList.Count == 1)
                {
                    bronzeFlag1.Image = ReturnFlag(bronzeList[0].Country);
                }
                #endregion
            }
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

        private void goldFinalistsButton_Click(object sender, EventArgs e)
        {
            //Lists the gold finalists in a messagebox:
            StringBuilder sb = new StringBuilder();

            sb.Append("Gold Finalists List:\n");

            foreach (var item in goldList)
            {
                sb.Append($"\n{item.CompetitorName} from {item.Country}");
            }

            MessageBox.Show(sb.ToString());
        }

        private void silverFinalistsBtn_Click(object sender, EventArgs e)
        {
            //Lists the silver finalists in a messagebox:
            StringBuilder sb = new StringBuilder();

            sb.Append("Silver Finalists List:\n");

            foreach (var item in silverList)
            {
                sb.Append($"\n{item.CompetitorName} from {item.Country}");
            }

            MessageBox.Show(sb.ToString());
        }

        private void bronzeFinalistsButton_Click(object sender, EventArgs e)
        {
            //Lists the bronze finalists in a messagebox:
            StringBuilder sb = new StringBuilder();

            sb.Append("Bronze Finalists List:\n");

            foreach (var item in bronzeList)
            {
                sb.Append($"\n{item.CompetitorName} from {item.Country}");
            }

            MessageBox.Show(sb.ToString());
        }
    }
}


