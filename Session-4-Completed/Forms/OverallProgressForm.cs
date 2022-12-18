using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session_4_JordanKhong.Forms
{
    public partial class OverallProgressForm : Form
    {
        public OverallProgressForm()
        {
            InitializeComponent();
        }

        private void OverallProgressForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                //Populate skill combobox:
                skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).Take(4).ToArray());
            }
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                //Clear all the DGVS:
                trainingModuleAssignmentDateDGV.Rows.Clear();
                trainingModuleAssignmentDateDGV.Columns.Clear();

                competitorTrainingDGV.Rows.Clear();
                competitorTrainingDGV.Columns.Clear();

                expertTrainingDGV.Rows.Clear();
                expertTrainingDGV.Columns.Clear();

                
                #region Get all relavent query information:
                var skillNameFromCb = skillCb.SelectedItem.ToString();

                var skillID = context.Skills.Where(x => x.skillName.Equals(skillNameFromCb)).Select(x => x.skillId).First();

                var moduleAssignDateQuery1 = (from x in context.Assign_Training
                                              where x.User.skillIdFK == skillID
                                              select x).ToList();

                var moduleAssignDateQuery = from x in moduleAssignDateQuery1
                                            orderby x.startDate
                                            group x by x.startDate.ToString("MMMM yyyy") into y
                                            select new
                                            {
                                                y.Key,
                                                CompetitorTrainings = y.Where(x => x.User.userTypeIdFK == 3).Count(),
                                                ExpertTraining = y.Where(x => x.User.userTypeIdFK == 2).Count()
                                            };

                var allStartDatesInAssignedTraining = from x in moduleAssignDateQuery1
                                                      select new
                                                      {
                                                          FormattedDate = x.startDate.ToString("MMMM yyyy")
                                                      };

                #endregion

                #region Start Building the table for Overall Number of Modules:
                var columns = new List<string>();
                var row = new List<string>();
                //Start building the row:
                //If no trainings found, inform user.
                if (moduleAssignDateQuery.Any())
                {
                    //Add columns based on number of "groups" of dates 
                    columns.Add("Trainee Category");
                    foreach (var item in allStartDatesInAssignedTraining.Distinct())
                    {
                        columns.Add($"No of training modules that start in {item.FormattedDate}");
                    }

                    foreach (var item in columns)
                    {
                        trainingModuleAssignmentDateDGV.Columns.Add(item, item);
                    }


                    #region Add rows for competitor:
                    row.Add("Competitor");
                    //For each "group" of dates, see if there are any competitor trainings:
                    foreach (var item in allStartDatesInAssignedTraining.Distinct())
                    {
                        foreach (var moduleAssigned in moduleAssignDateQuery.Where(x => x.Key.Equals(item.FormattedDate)))
                        {
                            if (moduleAssigned != null)
                            {
                                row.Add(moduleAssigned.CompetitorTrainings.ToString());
                            }
                            else
                            {
                                row.Add("0");
                            }
                        }
                    }
                    trainingModuleAssignmentDateDGV.Rows.Add(row.ToArray());
                    row.Clear();
                    #endregion

                    #region Add rows for expert
                    row.Add("Expert");
                    //For each "group" of dates, see if there are any expert trainings:
                    foreach (var item in allStartDatesInAssignedTraining.Distinct())
                    {
                        foreach (var moduleAssigned in moduleAssignDateQuery.Where(x => x.Key.Equals(item.FormattedDate)))
                        {
                            if (moduleAssigned != null)
                            {
                                row.Add(moduleAssigned.ExpertTraining.ToString());
                            }
                            else
                            {
                                row.Add("0");
                            }
                        }
                    }

                    trainingModuleAssignmentDateDGV.Rows.Add(row.ToArray());
                    row.Clear();
                    #endregion
                }
                else
                {
                    //Add a column that tells the user no assignments have been found:
                    trainingModuleAssignmentDateDGV.Columns.Add("No training assignments have been found for the current selected skill :c"
                        , "No training assignments have been found for the current selected skill :c");
                }

                columns.Clear();
                row.Clear();

                #endregion

                #region Start Building the table for Progress made from Experts:

                #region Relavant Queries required for building the ExpertTable:
                var trainingProgressTableExperts = from x in moduleAssignDateQuery1
                                                   where x.User.userTypeIdFK == 2
                                                   group x by x.Training_Module.moduleName into y
                                                   select new
                                                   {
                                                       y.Key,
                                                       CompletedCount = y.Where(x => x.progress == 100).Count(),
                                                       InProgressCount = y.Where(x => x.progress >= 1 && x.progress <= 99).Count(),
                                                       NotStartedCount = y.Where(x => x.progress <= 0).Count()
                                                   };

                var allModuleNamesExperts = (from x in trainingProgressTableExperts
                                             select x.Key).Distinct();

                #endregion

                //Check if there are any trainings for experts, if not, inform user:
                if (trainingProgressTableExperts.Any())
                {
                    #region Populating the columms:
                    columns.Add("Status (Experts)");

                    foreach (var item in allModuleNamesExperts.Distinct())
                    {
                        columns.Add(item);
                    }

                    foreach (var item in columns)
                    {
                        expertTrainingDGV.Columns.Add(item, item);
                    }
                    #endregion

                    #region Building the "Completed" Row
                    row.Add("Completed");

                    foreach (var item in allModuleNamesExperts.Distinct())
                    {
                        foreach (var training in trainingProgressTableExperts.Where(x => x.Key.Equals(item)))
                        {
                            if (training != null)
                            {
                                row.Add(training.CompletedCount.ToString());
                            }
                            else
                            {
                                row.Add("0");
                            }

                        }
                    }
                    expertTrainingDGV.Rows.Add(row.ToArray());

                    row.Clear();
                    #endregion

                    #region Building the "In Progress" Row
                    row.Add("In Progress");

                    foreach (var item in allModuleNamesExperts.Distinct())
                    {
                        foreach (var training in trainingProgressTableExperts.Where(x => x.Key.Equals(item)))
                        {
                            if (training != null)
                            {
                                row.Add(training.InProgressCount.ToString());
                            }
                            else
                            {
                                row.Add("0");
                            }

                        }
                    }
                    expertTrainingDGV.Rows.Add(row.ToArray());
                    row.Clear();
                    #endregion

                    #region Building the "Not Started" Row
                    row.Add("Not Started");

                    foreach (var item in allModuleNamesExperts.Distinct())
                    {
                        foreach (var training in trainingProgressTableExperts.Where(x => x.Key.Equals(item)))
                        {
                            if (training != null)
                            {
                                row.Add(training.NotStartedCount.ToString());
                            }
                            else
                            {
                                row.Add("0");
                            }

                        }
                    }
                    expertTrainingDGV.Rows.Add(row.ToArray());
                    row.Clear();
                    #endregion
                }
                else
                {
                    //Adds a column that mentions that there are no training for experts:
                    expertTrainingDGV.Columns.Add("-"
                        , "No training assignments for experts have been found for the current selected skill");
                }

                columns.Clear();
                row.Clear();

                #endregion

                #region Start Building the table and Chart for the Progress made from Competitors:
                #region Relavant Queries required for building the CompetitorTable:
                var trainingProgressTableCompetitors = from x in moduleAssignDateQuery1
                                                       where x.User.userTypeIdFK == 3
                                                       group x by x.Training_Module.moduleName into y
                                                       select new
                                                       {
                                                           y.Key,
                                                           CompletedCount = y.Where(x => x.progress == 100).Count(),
                                                           InProgressCount = y.Where(x => x.progress >= 1 && x.progress <= 99).Count(),
                                                           NotStartedCount = y.Where(x => x.progress <= 0).Count()
                                                       };

                var allModuleNamesCompetitors = (from x in trainingProgressTableCompetitors
                                                 select x.Key).Distinct();
                #endregion


                if (trainingProgressTableCompetitors.Any())
                {
                    //Clear all series, and add pre-defined Series:
                    overallProgressChart.Series.Clear();
                    overallProgressChart.Series.Add("Completed");
                    overallProgressChart.Series.Add("In Progress");
                    overallProgressChart.Series.Add("Not Started");

                    #region Populating the columns
                    columns.Add("Status (Competitors)");

                    foreach (var item in allModuleNamesCompetitors.Distinct())
                    {
                        columns.Add(item);
                        
                    }

                    foreach (var item in columns)
                    {
                        competitorTrainingDGV.Columns.Add(item, item);
                    }
                    #endregion

                    #region Populating the "Completed" row, along with filling info for chart
                    row.Add("Completed");

                    foreach (var item in allModuleNamesCompetitors.Distinct())
                    {
                        foreach (var training in trainingProgressTableCompetitors.Where(x => x.Key.Equals(item)))
                        {
                            if (training != null)
                            {
                                row.Add(training.CompletedCount.ToString());
                                overallProgressChart.Series["Completed"].Points.AddXY(item, training.CompletedCount);
                            }
                            else
                            {
                                row.Add("0");
                            }

                        }
                    }
                    competitorTrainingDGV.Rows.Add(row.ToArray());

                    row.Clear();
                    #endregion

                    #region Populating the "InProgress" row, along with filling info for chart
                    row.Add("In Progress");

                    foreach (var item in allModuleNamesCompetitors.Distinct())
                    {
                        foreach (var training in trainingProgressTableCompetitors.Where(x => x.Key.Equals(item)))
                        {
                            if (training != null)
                            {
                                row.Add(training.InProgressCount.ToString());
                                overallProgressChart.Series["In Progress"].Points.AddXY(item, training.InProgressCount);
                            }
                            else
                            {
                                row.Add("0");
                            }

                        }
                    }
                    competitorTrainingDGV.Rows.Add(row.ToArray());
                    row.Clear();
                    #endregion

                    #region Populating the "Not Started" row, along with filling info for chart
                    row.Add("Not Started");

                    foreach (var item in allModuleNamesCompetitors.Distinct())
                    {
                        foreach (var training in trainingProgressTableCompetitors.Where(x => x.Key.Equals(item)))
                        {
                            if (training != null)
                            {
                                row.Add(training.NotStartedCount.ToString());
                                overallProgressChart.Series["Not Started"].Points.AddXY(item, training.NotStartedCount);
                            }
                            else
                            {
                                row.Add("0");
                            }

                        }
                    }
                    competitorTrainingDGV.Rows.Add(row.ToArray());
                    row.Clear();
                    #endregion
                }
                else
                {
                    //Adds a column that mentions that there are not training for Competitors:
                    competitorTrainingDGV.Columns.Add("-"
                        , "No training assignments for competitors have been found for the current selected skill");
                }

                columns.Clear();
                row.Clear();

                #endregion
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
