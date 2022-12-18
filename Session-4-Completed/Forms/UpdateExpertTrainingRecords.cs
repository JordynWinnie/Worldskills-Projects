using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Session_4_JordanKhong
{
    public partial class UpdateExpertTrainingRecords : Form
    {
        List<TrainingRecordsTemplate> trainingRecords = new List<TrainingRecordsTemplate>();
        int currentSelectedValue = 0;
        public UpdateExpertTrainingRecords()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateExpertTrainingRecords_Load(object sender, EventArgs e)
        {
            //Populate SkillCb:
            using (var context = new Session4Entities())
            {
                skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).Take(4).ToArray());

                //Populate Columns:
                var columns = new List<string>
                {
                    "Training Module", "Duration (Days)", "Start Date", "Latest End Date", "Progress (%)"
                };


                foreach (var column in columns)
                {
                    competitorDGV.Columns.Add(column, column);
                }
                //Ensure only relavent rows are editable:
                competitorDGV.Columns[0].ReadOnly = true;
                competitorDGV.Columns[1].ReadOnly = true;
                competitorDGV.Columns[2].ReadOnly = true;
                competitorDGV.Columns[3].ReadOnly = true;
            }

        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Populate Competitor names:
            competitiorCb.Items.Clear();
            using (var context = new Session4Entities())
            {
                competitiorCb.Items.Clear();

                var skillNameFromCb = skillCb.SelectedItem.ToString();

                var skillID = context.Skills.Where(x => x.skillName.Equals(skillNameFromCb)).Select(x => x.skillId).First();

                competitiorCb.Items.AddRange(context.Users.Where(x => x.skillIdFK == skillID && x.userTypeIdFK == 2).Select(x => x.name).ToArray());
            }
        }

        private void competitiorCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                var competitorNameFromCb = competitiorCb.SelectedItem.ToString();
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
                competitorDGV.Rows.Clear();
                trainingRecords.Clear();

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

                nameRadio.Checked = true;
                UpdateGridStatus();
            }
        }

        void UpdateGridStatus()
        {
            //Logic Similar to the one found in the UpdateCompetitorTraining Form
            #region Filtering Information
            competitorDGV.Rows.Clear();

            var filteredInfoModuleName = from x in trainingRecords
                                         orderby x.ModuleName
                                         select x;

            //Check Radio Button Filter
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
            else if (ProgressRadio.Checked)
            {

                var filteredInfoProgress = from x in trainingRecords
                                           orderby x.Progress descending
                                           select x;

                foreach (var item in filteredInfoProgress)
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

            #region Highlighting Information
            //Start Highlighting
            //Checks all rows for the date, then compares with system time:
            foreach (DataGridViewRow row in competitorDGV.Rows)
            {
                if (DateTime.Parse(row.Cells[3].Value.ToString()) <= DateTime.Now.AddDays(5))
                {
                    //highlight red
                    row.DefaultCellStyle.BackColor = Color.Red;
                    
                }
                else if (DateTime.Parse(row.Cells[3].Value.ToString()) <= DateTime.Now.AddDays(14))
                {
                    //highlight yellow
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                
            }
            #endregion
        }

        private void nameRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGridStatus();

        }

        private void ProgressRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGridStatus();
        }

        private void competitorDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentSelectedValue = Convert.ToInt32(competitorDGV.Rows[e.RowIndex].Cells[4].Value);
            }
        }

        private void competitorDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Logic similar to the one found in UpdateCompetitorTraining Form
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

        private void updateBtn_Click(object sender, EventArgs e)
        {
            //Logic Similar to the one found in the UpdateCompetitorTraining Form
            using (var context = new Session4Entities())
            {
                var competitorNameFromCb = competitiorCb.SelectedItem.ToString();

                foreach (DataGridViewRow row in competitorDGV.Rows)
                {
                    var moduleNameFromRow = row.Cells[0].Value.ToString();
                    var competitorTrainingInfo = from x in context.Assign_Training
                                                 where x.User.name.Equals(competitorNameFromCb)
                                                 && x.Training_Module.moduleName.Equals(moduleNameFromRow)
                                                 select x;

                    competitorTrainingInfo.First().progress = Convert.ToInt32(row.Cells[4].Value);
                }

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
            }
        }
    }
}
