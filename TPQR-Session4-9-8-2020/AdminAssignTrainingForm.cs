using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session4_9_8_2020
{
    public partial class AdminAssignTrainingForm : Form
    {
        private Session4Entities context = new Session4Entities();

        public AdminAssignTrainingForm()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AdminAssignTrainingForm_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Skill", "Trainee Category", "Training Module", "ModuleId"
            };

            foreach (var column in columns)
            {
                trainingDGV.Columns.Add(column, column);
            }

            trainingDGV.Columns[3].Visible = false;
            skillCb.Items.AddRange(context.Skills.Where(x => x.skillName != "Admin").Select(x => x.skillName).ToArray());
            traineeCategoryCb.Items.AddRange(context.User_Type.Where(x => x.userTypeName != "Admin").Select(x => x.userTypeName).ToArray());
            skillCb.SelectedIndex = 0;
            traineeCategoryCb.SelectedIndex = 0;

            UpdateModules();
        }

        private void UpdateModules()
        {
            trainingModuleCb.Items.Clear();
            if (skillCb.SelectedIndex == -1 || traineeCategoryCb.SelectedIndex == -1)
            {
                return;
            }
            var selectedSkill = skillCb.SelectedItem.ToString();
            var selectedCategory = traineeCategoryCb.SelectedItem.ToString();
            var trainingModules = from x in context.Training_Module
                                  where x.Skill.skillName == selectedSkill && x.User_Type.userTypeName == selectedCategory
                                  && x.Assign_Training.Count == 0
                                  select x;

            foreach (var module in trainingModules)
            {
                trainingModuleCb.Items.Add($"{module.moduleName} ({module.durationDays} days)");
            }

            if (trainingModuleCb.Items.Count != 0)
            {
                trainingModuleCb.SelectedIndex = 0;
            }
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateModules();
        }

        private void traineeCategoryCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateModules();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (trainingModuleCb.SelectedIndex == -1)
            {
                MessageBox.Show("Select a module");
                return;
            }
            var columns = new List<string>
            {
                "Skill", "Trainee Category", "Training Module", "ModuleId"
            };
            var startDateOfCompetition = DateTime.Parse("1 October 2020");

            var selectedSkill = skillCb.SelectedItem.ToString();
            var selectedCategory = traineeCategoryCb.SelectedItem.ToString();
            var selectedModule = trainingModuleCb.SelectedItem.ToString();

            var moduleToAdd = (from x in context.Training_Module
                               where selectedModule.Contains(x.moduleName) && x.User_Type.userTypeName == selectedCategory
                               && x.Skill.skillName == selectedSkill
                               select x).First();

            if (startDateDtp.Value.AddDays(moduleToAdd.durationDays) > startDateOfCompetition)
            {
                MessageBox.Show("The competition will start before this course finishes");
                return;
            }

            foreach (DataGridViewRow dataRow in trainingDGV.Rows)
            {
                if (dataRow.Cells[3].Value.ToString().Equals(moduleToAdd.moduleId.ToString()))
                {
                    MessageBox.Show("Cannot add duplicate courses");
                    return;
                }
            }

            var row = new List<string>
            {
                moduleToAdd.Skill.skillName,
                moduleToAdd.User_Type.userTypeName,
                moduleToAdd.moduleName,
                moduleToAdd.moduleId.ToString()
            };

            trainingDGV.Rows.Add(row.ToArray());
        }

        private void removeRecBtn_Click(object sender, EventArgs e)
        {
            if (trainingDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row");
                return;
            }

            foreach (DataGridViewRow row in trainingDGV.SelectedRows)
            {
                trainingDGV.Rows.RemoveAt(row.Index);
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            if (trainingDGV.Rows.Count == 0)
            {
                MessageBox.Show("Assign at least one training");
                return;
            }
            foreach (DataGridViewRow row in trainingDGV.Rows)
            {
                var moduleId = int.Parse(row.Cells[3].Value.ToString());

                var module = context.Training_Module.Where(x => x.moduleId == moduleId).First();

                var users = context.Users.Where(x => x.skillIdFK == module.skillIdFK && x.User_Type.userTypeId == module.userTypeIdFK);

                foreach (var user in users)
                {
                    var insertTraining = new Assign_Training
                    {
                        moduleIdFK = moduleId,
                        progress = 0,
                        startDate = startDateDtp.Value,
                        userIdFK = user.userId,
                    };

                    context.Assign_Training.Add(insertTraining);
                }
            }
            context.SaveChanges();
            MessageBox.Show("Modules Assigned");
            Close();
        }
    }
}