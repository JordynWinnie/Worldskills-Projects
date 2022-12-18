using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session5
{
    public partial class EnterMarksForm : Form
    {
        int currentSessionNumber = -1;
        string currentCompetitorName = "";
        int currentSkillNumber = -1;
        double grandTotal = -1;
        public EnterMarksForm()
        {
            InitializeComponent();
        }

        private void EnterMarksForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session5Entities())
            {
                //Populate skill combobox:
                skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());

                //Populate Column Combobox:
                List<string> columns = new List<string>
                {
                    "Question","Grade", "Marks", "MaxMarksCol"
                };

                foreach (var column in columns)
                {
                    marksDGV.Columns.Add(column, column);
                }
                marksDGV.Columns[3].Visible = false;

                marksDGV.Columns[0].ReadOnly = true;
                marksDGV.Columns[2].ReadOnly = true;

            }
        }

        private void sessionCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Updates the GlobalVariable for sessionNumber to be the same as the sessionComboBox
            currentSessionNumber = Convert.ToInt32(sessionCb.SelectedItem.ToString());
            RefreshGrid();
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Populates Session numbers and competitor names:
            using (var context = new Session5Entities())
            {
                sessionCb.Items.Clear();
                var skillNameFromCb = skillCb.SelectedItem.ToString();
                var skillID = context.Skills.Where(x => x.skillName.Equals(skillNameFromCb)).Select(x => x.skillId).First();

                currentSkillNumber = skillID;

                var sessionNumbers = context.Competitions.Where(x => x.skillIdFK == skillID).Select(x => x.sessionNo);

                foreach (var item in sessionNumbers)
                {
                    sessionCb.Items.Add(item);
                }

                competitorCb.Items.Clear();
                competitorCb.Items.AddRange(context.Competitors.Where(x => x.skillIdFK == skillID).Select(x => x.competitorName).ToArray());

            }

            RefreshGrid();
        }

        private void competitorCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Updates the GlobalVariable for competitor name to be the same as the sessionComboBox
            currentCompetitorName = competitorCb.SelectedItem.ToString();
            RefreshGrid();
        }

        /// <summary>
        /// This method attempts to refresh the DGV based on the conditions set by
        /// the global variables.
        /// It is called everytime any combobox is changed
        /// It adapts based on available information, meaning it will not execute
        /// anything is CurrentSession number and Competitor name is not filled in.
        /// 
        /// Since both variables are initialised at the top, this serves as a check
        /// to ensure the user enters both values before the grid refreshes
        /// </summary>
        void RefreshGrid()
        {
            if (currentSessionNumber != -1 && !currentCompetitorName.Equals(string.Empty))
            {
                using (var context = new Session5Entities())
                {
                    marksDGV.Rows.Clear();
                    var competitionInfoQuery = from x in context.Competitions
                                               where x.skillIdFK == currentSkillNumber && x.sessionNo == currentSessionNumber
                                               select new
                                               {
                                                   x.q1MaxMarks,
                                                   x.q2MaxMarks,
                                                   x.q3MaxMarks,
                                                   x.q4MaxMarks
                                               };
                    #region Row Population:
                    foreach (var item in competitionInfoQuery)
                    {
                        //Only adds rows if the max marks for the question is not zero:
                        List<string> row = new List<string>();

                        if (!(item.q1MaxMarks == 0))
                        {
                            row.Add("Question 1");
                            row.Add("");
                            row.Add("");
                            row.Add(item.q1MaxMarks.ToString());
                            marksDGV.Rows.Add(row.ToArray());
                        }

                        row.Clear();
                        if (!(item.q2MaxMarks == 0))
                        {
                            row.Add("Question 2");
                            row.Add("");
                            row.Add("");
                            row.Add(item.q2MaxMarks.ToString());
                            marksDGV.Rows.Add(row.ToArray());
                        }


                        row.Clear();
                        if (!(item.q3MaxMarks == 0))
                        {
                            row.Add("Question 3");
                            row.Add("");
                            row.Add("");
                            row.Add(item.q3MaxMarks.ToString());
                            marksDGV.Rows.Add(row.ToArray());
                        }

                        row.Clear();
                        if (!(item.q4MaxMarks == 0))
                        {
                            row.Add("Question 4");
                            row.Add("");
                            row.Add("");
                            row.Add(item.q4MaxMarks.ToString());
                            marksDGV.Rows.Add(row.ToArray());
                        }

                    }
                    #endregion
                }

            }
        }

        private void marksDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        { 
            MarkGrid();
        }

        /// <summary>
        /// This method attempts to look through all the cells in the grade column,
        /// checks if the value entered is gd, good, av, average, pr, poor
        /// Calculates the marks and populates the marks cell.
        /// It takes the maximum marks from a hidden maximum marks column
        /// </summary>
        void MarkGrid()
        {
            var total = 0.0;
            foreach (DataGridViewRow row in marksDGV.Rows)
            {
                var maxMarkOfRow = Convert.ToDouble(row.Cells[3].Value);
                if (row.Cells[1].Value.ToString().ToLower().Equals("good") || row.Cells[1].Value.ToString().ToLower().Equals("gd"))
                {
                    row.Cells[2].Value = maxMarkOfRow;
                }
                else if (row.Cells[1].Value.ToString().ToLower().Equals("average") || row.Cells[1].Value.ToString().ToLower().Equals("av"))
                {
                    row.Cells[2].Value = maxMarkOfRow * 0.65;
                }
                else if (row.Cells[1].Value.ToString().ToLower().Equals("poor") || row.Cells[1].Value.ToString().ToLower().Equals("pr"))
                {
                    row.Cells[2].Value = maxMarkOfRow * 0.20;
                }
                else
                {
                    //Returns the mark as blank if it doesnt understand user input
                    row.Cells[2].Value = "";
                }

                //if marks cell isnt empty, it adds it to the total
                if (!row.Cells[2].Value.Equals(string.Empty))
                {
                    total += Convert.ToDouble(row.Cells[2].Value);
                }

            }

            totalLbl.Text = total.ToString();
            grandTotal = total;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            //Changes all grade cells to blanks 
            //Changes all mark cells to 0.0
            foreach (DataGridViewRow row in marksDGV.Rows)
            {
                row.Cells[1].Value = "";
                row.Cells[2].Value = 0.0;
            }

            MarkGrid();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            
            var tempBool = true;
            while (tempBool)
            {
                #region Check all fields have been marked:
                foreach (DataGridViewRow row in marksDGV.Rows)
                {
                    if (row.Cells[2].Value.Equals(string.Empty))
                    {
                        MessageBox.Show("One or more fields have not been marked!");
                        tempBool = false;
                        break;
                    }
                }

                if (!tempBool)
                {
                    break;
                }
                #endregion

                using (var context = new Session5Entities())
                {
                    var competitionID = (from x in context.Competitions
                                         where x.skillIdFK == currentSkillNumber && x.sessionNo == currentSessionNumber
                                         select x.competitionId).First();

                    var currentRecordsID = context.Competitors.Where(x => x.competitorName.Equals(currentCompetitorName)).Select(x => x.recordsId).FirstOrDefault();

                    var marksList = new List<double>();
                    //For every mark in marks row, converts the mark to a double then adds it to a temporary list
                    foreach (DataGridViewRow row in marksDGV.Rows)
                    {
                        var currentMark = Convert.ToDouble(row.Cells[2].Value);

                        marksList.Add(currentMark);
                    }

                    //Inserts a result with the current Competition and Record ID
                    Result insertResult = new Result
                    {
                        competitionIdFK = competitionID,
                        recordsIdFK = currentRecordsID,
                    };

                    //Checks the number of entires in the temporary marks list:
                    //The number of entries corresponds to the number of questions:
                    switch (marksList.Count())
                    {
                        case 1:
                            insertResult.q1Marks = marksList[0];
                            break;
                        case 2:
                            insertResult.q1Marks = marksList[0];
                            insertResult.q2Marks = marksList[1];
                            
                            break;
                        case 3:
                            insertResult.q1Marks = marksList[0];
                            insertResult.q2Marks = marksList[1];
                            insertResult.q3Marks = marksList[2];

                            break;
                        case 4:
                            insertResult.q1Marks = marksList[0];
                            insertResult.q2Marks = marksList[1];
                            insertResult.q3Marks = marksList[2];
                            insertResult.q4Marks = marksList[3];
                            break;
                    }

                    insertResult.totalMarks = grandTotal;

                    #region Save to Database:
                    try
                    {
                        context.Results.Add(insertResult);
                        context.SaveChanges();

                        MessageBox.Show("Results added!");
                        //this.Close();
                        break;
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving. Details: \n"+ ex.Message);

                        throw;
                    }

                    #endregion
                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
