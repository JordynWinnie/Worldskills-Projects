using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session_4_JordanKhong
{
    public partial class CompetitorMenu : Form
    {
        List<TrainingRecordsTemplate> trainingRecords = new List<TrainingRecordsTemplate>();
        int currentSelectedValue = 0;
        public CompetitorMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void CompetitorMenu_Load(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                //Populate Skill combobox:
                skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).Take(4).ToArray());

                //Populate Columns:
                var columns = new List<string>
                {
                    "Training Module", "Duration (Days)", "Start Date", "Estimated End Date", "Progress (%)"
                };


                foreach (var column in columns)
                {
                    competitorDGV.Columns.Add(column, column);
                }

                //Ensure only relavent columns are editable:
                competitorDGV.Columns[0].ReadOnly = true;
                competitorDGV.Columns[1].ReadOnly = true;
                competitorDGV.Columns[2].ReadOnly = true;
                competitorDGV.Columns[3].ReadOnly = true;

                //Pre-define a few progress types in progress combobox:
                progressCb.Items.Add("Completed");
                progressCb.Items.Add("In Progress");
                progressCb.Items.Add("Not Started");
            }
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                //Update CompetitorNamesCombobox after skill has been selected:
                competitorNameCb.Items.Clear();

                var skillNameFromCb = skillCb.SelectedItem.ToString();

                var skillID = context.Skills.Where(x => x.skillName.Equals(skillNameFromCb)).Select(x => x.skillId).First();

                competitorNameCb.Items.AddRange(context.Users.Where(x => x.skillIdFK == skillID && x.userTypeIdFK == 3).Select(x => x.name).ToArray());


            }
        }

        private void competitorNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                #region Queries to fill up competitor training information:
                var competitorNameFromCb = competitorNameCb.SelectedItem.ToString();
                var competitorTrainingInfo = from x in context.Assign_Training
                                             where x.User.name.Equals(competitorNameFromCb)
                                             group x by x.Training_Module.moduleName into y
                                             select new
                                             {
                                                 ModuleName = y.Key,
                                                 Duration = y.Select(x => x.Training_Module.durationDays),
                                                 StartDate = y.Select(x => x.startDate),
                                                 Progress = y.Select(x => x.progress)
                                             };
                #endregion

                competitorDGV.Rows.Clear();
                trainingRecords.Clear();

                #region Populating a Template Class for CompetitorTraining:
                foreach (var training in competitorTrainingInfo)
                {
                    var trainingRecord = new TrainingRecordsTemplate
                    {
                        ModuleName = training.ModuleName,
                        DurationInDays = training.Duration.First(),
                        StartTime = training.StartDate.First(),
                        EstimatedEndTime = training.StartDate.First().AddDays(training.Duration.First()),
                        Progress = training.Progress.First()
                    };

                    trainingRecords.Add(trainingRecord);
                }
                #endregion
                nameRadio.Checked = true;
                UpdateGridStatus();
            }
        }


        private void nameRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGridStatus();
        }

        private void EndDateRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGridStatus();
        }

        private void competitorDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void trainingModuleNameTb_TextChanged(object sender, EventArgs e)
        {
            UpdateGridStatus();
        }

        private void progressCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGridStatus();

        }

        void UpdateGridStatus()
        {
            competitorDGV.Rows.Clear();
            #region Filters information:

            //Gets the information from the TemplateList, which is a global variable:
            var filteredInfoModuleName = from x in trainingRecords
                               orderby x.ModuleName
                               select x;
            #region Filter By name:
            if (nameRadio.Checked)
            {
                foreach (var item in filteredInfoModuleName)
                {
                    var row = new List<string>
                {
                    item.ModuleName,
                    item.DurationInDays.ToString(),
                    item.StartTime.ToString("dd/MM/yyyy"),
                    item.EstimatedEndTime.ToString("dd/MM/yyyy"),
                    item.Progress.ToString()
                };

                    competitorDGV.Rows.Add(row.ToArray());
                }
            }
            #endregion

            #region Filter by Estimated End Time
            else
            {
                var filteredInfoDate = from x in trainingRecords
                                       orderby x.EstimatedEndTime descending
                                       select x;

                foreach (var item in filteredInfoDate)
                {
                    var row = new List<string>
                {
                    item.ModuleName,
                    item.DurationInDays.ToString(),
                    item.StartTime.ToString("dd/MM/yyyy"),
                    item.EstimatedEndTime.ToString("dd/MM/yyyy"),
                    item.Progress.ToString()
                };

                    competitorDGV.Rows.Add(row.ToArray());
                }

            }
            #endregion

            #region Filters by TextBox Text:
            //Checks Textbox:
            foreach (DataGridViewRow row in competitorDGV.Rows)
            {
                if (!trainingModuleNameTb.Text.Equals(string.Empty))
                {
                    if (!row.Cells[0].Value.ToString().ToLower().Contains(trainingModuleNameTb.Text.ToLower()))
                    {
                        row.Visible = false;
                    }
                }
                else
                {
                    row.Visible = true;
                }

            }
            #endregion

            #region Filters by progress combobox:
            //Checks Progress ComboBox, ensures something is selected.
            //Filters based on progress value, hiding all the rows not within the condition:
            if (progressCb.SelectedIndex != -1)
            {
                if (progressCb.SelectedItem.ToString().Equals("Completed"))
                {
                    foreach (DataGridViewRow row in competitorDGV.Rows)
                    {
                        if (!(Convert.ToInt32(row.Cells[4].Value) == 100))
                        {
                            row.Visible = false;
                        }
                    }
                }
                else if (progressCb.SelectedItem.ToString().Equals("In Progress"))
                {
                    foreach (DataGridViewRow row in competitorDGV.Rows)
                    {
                        if (!(Convert.ToInt32(row.Cells[4].Value) <= 99 && Convert.ToInt32(row.Cells[4].Value) >= 1))
                        {
                            row.Visible = false;
                        }
                    }
                }
                else if (progressCb.SelectedItem.ToString().Equals("Not Started"))
                {
                    foreach (DataGridViewRow row in competitorDGV.Rows)
                    {
                        if (!(Convert.ToInt32(row.Cells[4].Value) == 0))
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
            #endregion
            #endregion
        }

        private void competitorDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Validates the cell, ensures that it is an int, it is between 0 and 100, and the progress
            //value is not lower than in database:
            if (e.ColumnIndex == 4)
            {
               
                if (competitorDGV.IsCurrentCellDirty)
                {
                    //Check for int, and progress between 0 and 100
                    if (!int.TryParse(e.FormattedValue.ToString(), out _))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Please enter a progress value in whole numbers");
                    }
                    else if (Convert.ToInt32(e.FormattedValue) < 0 || Convert.ToInt32(e.FormattedValue) > 100)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Please enter a progress value between 0 and 100");
                    }
                    else if (currentSelectedValue > Convert.ToInt32(e.FormattedValue))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Progress value should not be lower than previous entered value.");
                    }


                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                //Goes through all the rows and updates all relavent records:
                #region Update Logic:
                var competitorNameFromCb = competitorNameCb.SelectedItem.ToString();
                
                foreach (DataGridViewRow row in competitorDGV.Rows)
                {
                    var moduleNameFromRow = row.Cells[0].Value.ToString();
                    var competitorTrainingInfo = from x in context.Assign_Training
                                                 where x.User.name.Equals(competitorNameFromCb) 
                                                 && x.Training_Module.moduleName.Equals(moduleNameFromRow)
                                                 select x;

                    competitorTrainingInfo.First().progress = Convert.ToInt32(row.Cells[4].Value);


                }

                #endregion

                #region Saving to Db:
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Changes updated c:");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving changes. Details:\n" + ex.Message);
                    throw;
                }
                #endregion
            }

        }

        private void competitorDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentSelectedValue = Convert.ToInt32(competitorDGV.Rows[e.RowIndex].Cells[4].Value);
            }
        }
    }

    
}
