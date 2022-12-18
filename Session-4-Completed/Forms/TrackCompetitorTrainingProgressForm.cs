using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Session_4_JordanKhong
{
    public partial class TrackCompetitorTrainingProgressForm : Form
    {
        string currentUserId = "";
        public TrackCompetitorTrainingProgressForm(string userID)
        {
            currentUserId = userID;
            InitializeComponent();
        }

        private void TrackCompetitorTrainingProgressForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                trainingDGV.ReadOnly = true;

                var currentUserSkillID = context.Users.Where(x => x.userId.Equals(currentUserId)).Select(x => x.skillIdFK).FirstOrDefault();
                skillnameLbl.Text = context.Skills.Where(x => x.skillId == currentUserSkillID).Select(x => x.skillName).FirstOrDefault();

                #region Queries to group Assigned Trainings by Module Name:
                var currentModuleProgress = (from x in context.Assign_Training
                                             where x.Training_Module.skillIdFK == currentUserSkillID
                                             orderby x.Training_Module.moduleName
                                             group x by x.User.name into y
                                             select new
                                             {
                                                 CompetitorName = y.Key,
                                                 ModulesAssigned = y.Select(x => x.Training_Module.moduleName).Distinct(),
                                                 Progress = y.Select(x => x.progress)
                                             });

                var currentAvailableModules = from x in context.Assign_Training
                                              where x.Training_Module.skillIdFK == currentUserSkillID
                                              select x.Training_Module.moduleName;

                #endregion

                #region Populating of rows and columns:
                if (currentModuleProgress.Any())
                {
                    #region Populating Columns:
                    List<string> columns = new List<string>();
                    columns.Add("Name Of Competitor");

                    //Adds all current modules in group:
                    foreach (var item in currentAvailableModules.Distinct())
                    {
                        columns.Add(item);
                    }

                    foreach (var column in columns)
                    {
                        trainingDGV.Columns.Add(column, column);
                    }
                    #endregion

                    #region Populating Rows:
                    //Add all the names, and respective progress for each module in a double foreach loop:
                    foreach (var item in currentModuleProgress)
                    {
                        List<string> row = new List<string>
                    {
                        item.CompetitorName
                    };

                        foreach (var progress in item.Progress)
                        {
                            row.Add(progress.ToString());
                        }

                        trainingDGV.Rows.Add(row.ToArray());
                    }
                    #endregion
                }
                else
                {
                    //If no trainings are found, a column is shown to tell that information:
                    trainingDGV.Columns.Add("-", "There are currently no training records in this skill area");
                }

                #endregion

                #region Highlighting Cells
                foreach (DataGridViewRow row in trainingDGV.Rows)
                {
                    foreach (DataGridViewCell item in row.Cells)
                    {
                        try
                        {
                            if (Convert.ToInt32(item.Value) == 0)
                            {
                                item.Style.BackColor = Color.Red;
                            }
                        }
                        catch (Exception)
                        {

                        }

                    }
                }
                #endregion
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
