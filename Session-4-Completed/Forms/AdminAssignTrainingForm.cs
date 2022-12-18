using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session_4_JordanKhong
{

    public partial class AdminAssignTrainingForm : Form
    {
        int skillID = -1;
        int userTypeId = -1;
        int tempRowIdx = -1;
        List<string> moduleList = new List<string>();

        public AdminAssignTrainingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminAssignTrainingForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                //Populate SkillCombo box:
                skillCombo.Items.AddRange(context.Skills.Where(x => x.skillId <= 4)
                    .OrderBy(x => x.skillName).Select(x => x.skillName).ToArray());

            }
            
            //Add Columns and populate DGV:
            var columns = new List<string>
            {
                "Skill","Trainee Category","Training Module"
            };

            foreach (var column in columns)
            {
                skillDGV.Columns.Add(column, column);
            }
        }

        private void skillCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Populate Trainee Type Combobox after skill combobox is selected:
            using (var context = new Session4Entities())
            {
                traineeCategoryCombo.Items.Clear();
                traineeCategoryCombo.Items.AddRange(context.User_Type.Where(x => x.userTypeId >= 2)
                    .OrderBy(x => x.userTypeName).Select(x => x.userTypeName).ToArray());

                var skillNameFromCb = skillCombo.SelectedItem.ToString();

                skillID = context.Skills.Where(x => x.skillName.Equals(skillNameFromCb)).Select(x => x.skillId).First();

            }
            RefreshModuleBox(skillID, userTypeId);
        }

        private void moduleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void traineeCategoryCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change userTypeId globalVariable when traineeCateGoryComboBox is changed:
            var traineeCategoryFromCb = traineeCategoryCombo.SelectedItem.ToString();

            using (var context = new Session4Entities())
            {
                userTypeId = context.User_Type.Where(x => x.userTypeName.Equals(traineeCategoryFromCb)).Select(x => x.userTypeId).First();
            }

            RefreshModuleBox(skillID, userTypeId);
        }

        private void RefreshModuleBox(int skillID = -1, int traineeCategoryID = -1)
        {
            //Only populate ModuleCombobox if a skill and category is chooses:
            if (skillID != -1 && traineeCategoryID != 1)
            {
                using (var context = new Session4Entities())
                {
                    //gets list of modules based on traineeType and skill 
                    var moduleListQuery = context.Training_Module.Where(x => x.userTypeIdFK == traineeCategoryID && x.skillIdFK == skillID).OrderBy(x => x.moduleName);


                    moduleComboBox.Items.Clear();
                    moduleList.Clear();
                    foreach (var module in moduleListQuery)
                    {
                        Console.WriteLine(module.moduleName);
                        var checkForCurrentAssignment = (from x in context.Assign_Training
                                                         where x.moduleIdFK == module.moduleId
                                                         select x).Any();
                        if (!checkForCurrentAssignment)
                        {
                            moduleComboBox.Items.Add($"{module.moduleName} ({module.durationDays} days)");
                            moduleList.Add(module.moduleName);
                        }

                    }
                }

            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            //Add to DGV for skill training:
            using (var context = new Session4Entities())
            {
                var tempBool = true;
                while (tempBool)
                {
                    try
                    {
                        #region Validation:
                        var selectedModuleFromList = moduleList[moduleComboBox.SelectedIndex];

                        Console.WriteLine(selectedModuleFromList);
                        var selectedModule = context.Training_Module.Where(x => x.userTypeIdFK == userTypeId && x.skillIdFK == skillID && x.moduleName == selectedModuleFromList).OrderBy(x => x.moduleName).FirstOrDefault();

                        if (selectedModule != null)
                        {
                            if (!(startDateDtp.Value.AddDays(selectedModule.durationDays) < DateTime.Parse("26 July 2020")))
                            {
                                MessageBox.Show("This module can't be completed before the start of the competion");
                                tempBool = false;
                                break;
                            }


                            foreach (DataGridViewRow checkRow in skillDGV.Rows)
                            {
                                if (checkRow.Cells[2].Value.Equals(selectedModuleFromList))
                                {
                                    MessageBox.Show("Cannot add duplicate module with Skill");
                                    tempBool = false;
                                    break;
                                }
                            }

                            if (!tempBool)
                            {
                                break;
                            }
                            #endregion

                            //Make new row using a list and add it to DGV:
                            List<string> row = new List<string>
            {
                skillCombo.SelectedItem.ToString(),
                traineeCategoryCombo.SelectedItem.ToString(),
                selectedModuleFromList,
                startDateDtp.Value.ToString()
            };

                            skillDGV.Rows.Add(row.ToArray());
                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }


                    break;
                }




            }

        }

        private void skillDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tempRowIdx = e.RowIndex;
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (tempRowIdx >= 0)
            {
                skillDGV.Rows.RemoveAt(tempRowIdx);
            }

        }

        /// <summary>
        /// Once the user is satisfied with all the assignments, the user can
        // click on the Assign button to update the database.NOTE: When a training module is
        //assigned to a type of trainee for a particular skill area, it means that it is assigned to all
        //the people who are of that type in that skill(e.g.If I assign module AA to Web Tech
        //competitors, and there are four competitors in the Web Tech skill area, then module AA
        //will be assigned to all four of them). By default, when a module is first assigned to a
        //trainee, their progress for that module is set to 0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void assignBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                #region Assign Training to all Trainees

                var traineeCategoryFromCb = traineeCategoryCombo.SelectedItem.ToString();

                userTypeId = context.User_Type.Where(x => x.userTypeName.Equals(traineeCategoryFromCb)).Select(x => x.userTypeId).First();

                var skillNameFromCb = skillCombo.SelectedItem.ToString();

                skillID = context.Skills.Where(x => x.skillName.Equals(skillNameFromCb)).Select(x => x.skillId).First();

                foreach (DataGridViewRow row in skillDGV.Rows)
                {
                    //Training Module ID:
                    var moduleNameFromCell = row.Cells[2].Value.ToString();
                    var moduleID = context.Training_Module.Where(x => x.moduleName.Equals(moduleNameFromCell) && x.skillIdFK == skillID
                    && x.userTypeIdFK == userTypeId).Select(x => x.moduleId).First();

                    //Assign to every member selected  
                    foreach (var member in context.Users.Where(x => x.skillIdFK == skillID && x.userTypeIdFK == userTypeId))
                    {
                        Assign_Training insertAssignTraining = new Assign_Training
                        {
                            moduleIdFK = moduleID,
                            userIdFK = member.userId,
                            startDate = startDateDtp.Value,
                            progress = 0
                        };

                        context.Assign_Training.Add(insertAssignTraining);
                    }


                }
                #endregion

                #region Save to db:
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Changes applied. c:");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred. Details:\n" + ex.Message);
                    throw;
                }
                #endregion
            }
        }
    }
}
