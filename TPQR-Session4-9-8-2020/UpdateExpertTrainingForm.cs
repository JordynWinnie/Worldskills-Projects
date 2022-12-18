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
    public partial class UpdateExpertTrainingForm : Form
    {
        private Session4Entities context = new Session4Entities();
        private object _oldValue;

        public UpdateExpertTrainingForm()
        {
            InitializeComponent();
        }

        private void UpdateExpertTrainingForm_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Training Module", "Durations (days)", "Start Date", "Estimated End Date", "Progress", "trainingId"
            };

            foreach (var column in columns)
            {
                trainingDGV.Columns.Add(column, column);
            }

            trainingDGV.Columns[5].Visible = false;

            foreach (DataGridViewColumn col in trainingDGV.Columns)
            {
                col.ReadOnly = true;
            }

            trainingDGV.Columns[4].ReadOnly = false;
            skillCb.Items.AddRange(context.Skills.Where(x => x.skillName != "Admin").Select(x => x.skillName).ToArray());
            skillCb.SelectedIndex = 0;

            UpdateNames();
        }

        private void UpdateNames()
        {
            competitorNameCb.Items.Clear();
            if (skillCb.SelectedIndex == -1)
            {
                return;
            }
            var selectedSkill = skillCb.SelectedItem.ToString();

            competitorNameCb.Items.AddRange(context.Users.Where(x => x.Skill.skillName == selectedSkill && x.userTypeIdFK == 2)
                .Select(x => x.name).ToArray());
            if (competitorNameCb.Items.Count != 0)
            {
                competitorNameCb.SelectedIndex = 0;
            }

            UpdateTable();
        }

        private void UpdateTable()
        {
            trainingDGV.Rows.Clear();
            if (skillCb.SelectedIndex == -1 || competitorNameCb.SelectedIndex == -1)
            {
                return;
            }

            var selectedName = competitorNameCb.SelectedItem.ToString();
            var selectedSkill = skillCb.SelectedItem.ToString();
            var trainingQuery = (from x in context.Assign_Training
                                 where x.User.name == selectedName && x.Training_Module.Skill.skillName == selectedSkill
                                 select x).ToList();

            if (nameRadio.Checked)
            {
                trainingQuery = trainingQuery.OrderBy(x => x.Training_Module.moduleName).ToList();
            }
            else
            {
                trainingQuery = trainingQuery.OrderByDescending(x => x.progress).ToList();
            }

            for (int i = 0; i < trainingQuery.Count; i++)
            {
                var row = new List<string> {
                    trainingQuery[i].Training_Module.moduleName,
                    trainingQuery[i].Training_Module.durationDays.ToString(),
                    trainingQuery[i].startDate.ToShortDateString(),
                    (trainingQuery[i].startDate.AddDays(trainingQuery[i].Training_Module.durationDays)).ToShortDateString(),
                    trainingQuery[i].progress.ToString(),
                    trainingQuery[i].trainingId.ToString()
                };

                trainingDGV.Rows.Add(row.ToArray());
                var endDate = trainingQuery[i].startDate.AddDays(trainingQuery[i].Training_Module.durationDays);

                if ((endDate - DateTime.Now).Days <= 5)
                {
                    trainingDGV.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else if ((endDate - DateTime.Now).Days <= 14)
                {
                    trainingDGV.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    trainingDGV.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNames();
        }

        private void competitorNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void progress_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void nameRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void trainingDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _oldValue = trainingDGV[e.ColumnIndex, e.RowIndex].Value;
        }

        private void trainingDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int newProgressValue = 0;

            if (int.TryParse(trainingDGV[4, e.RowIndex].Value.ToString(), out newProgressValue))
            {
                var trainingId = int.Parse(trainingDGV[5, e.RowIndex].Value.ToString());
                var trainingProgress = context.Assign_Training.Where(x => x.trainingId == trainingId).First().progress;
                if (newProgressValue < trainingProgress)
                {
                    MessageBox.Show("Value cannot be lower than previous value");
                    trainingDGV[4, e.RowIndex].Value = _oldValue;
                }
            }
            else
            {
                trainingDGV[4, e.RowIndex].Value = _oldValue;
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in trainingDGV.Rows)
            {
                var trainingId = int.Parse(row.Cells[5].Value.ToString());
                var progress = int.Parse(row.Cells[4].Value.ToString());

                var trainingToModify = context.Assign_Training.Where(x => x.trainingId == trainingId).First();

                trainingToModify.progress = progress;
            }
            context.SaveChanges();
            MessageBox.Show("Changes saved");
            Close();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}