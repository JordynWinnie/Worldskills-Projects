using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Paper1_5_15_2020
{
    public partial class ResourceManagementForm : Form
    {
        private long selectedResourceId = -1;

        public ResourceManagementForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResourceManagementForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                skillComboBox.Items.Add("None");
                typeComboBox.Items.Add("None");
                skillComboBox.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
                typeComboBox.Items.AddRange(context.Resource_Type.Select(x => x.resTypeName).ToArray());

                //Set up DGV
                var columns = new List<string>
                {
                    "Name", "Type", "No. Of Skills", "Allocated Skill(s)", "Available Quantity", "ResID"
                };

                foreach (var column in columns)
                {
                    resourceDGV.Columns.Add(column, column);
                }
                resourceDGV.Columns[5].Visible = false;
                skillComboBox.SelectedIndex = 0;
            }
        }

        private void SetUpDGV()
        {
            resourceDGV.Rows.Clear();
            using (var context = new Session1Entities())
            {
                var typeComboBoxText = typeComboBox.SelectedItem.ToString();
                var basicQuery = (from x in context.Resources
                                  select new
                                  {
                                      x.resName,
                                      x.Resource_Type.resTypeName,
                                      SkillListCount = x.Resource_Allocation.Select(y => y.Skill.skillName).ToList().Count,
                                      SkillList = x.Resource_Allocation.Select(y => y.Skill.skillName),
                                      Quantity = x.remainingQuantity,
                                      x.resId
                                  }).ToList();
                var basicQuery1 = from x in basicQuery
                                  select new
                                  {
                                      x.resName,
                                      x.resTypeName,
                                      x.SkillListCount,
                                      SkillList = string.Join(", ", x.SkillList),
                                      x.Quantity,
                                      x.resId
                                  };

                if (!skillComboBox.SelectedItem.ToString().Equals("None"))
                {
                    basicQuery1 = basicQuery1.Where(x => x.SkillList.Contains(skillComboBox.SelectedItem.ToString()));
                }

                if (!typeComboBoxText.Equals("None"))
                {
                    basicQuery1 = basicQuery1.Where(x => x.resTypeName.Contains(typeComboBox.SelectedItem.ToString()));
                }

                foreach (var item in basicQuery1)
                {
                    var newRow = new List<string>{
                        item.resName,
                        item.resTypeName,
                        item.SkillListCount.ToString(),
                        item.SkillList
                    };

                    if (item.Quantity > 5)
                    {
                        newRow.Add("Sufficient");
                    }
                    else if (item.Quantity >= 1 && item.Quantity <= 5)
                    {
                        newRow.Add("Low Stock");
                    }
                    else
                    {
                        newRow.Add("No stock");
                    }
                    newRow.Add(item.resId.ToString());
                    resourceDGV.Rows.Add(newRow.ToArray());
                }

                foreach (DataGridViewRow row in resourceDGV.Rows)
                {
                    if (row.Cells[4].Value.ToString().Equals("No stock"))
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void skillComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeComboBox.SelectedIndex == -1)
            {
                typeComboBox.SelectedIndex = 0;
            }

            resourceDGV.Rows.Clear();
            SetUpDGV();
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resourceDGV.Rows.Clear();
            SetUpDGV();
        }

        private void resourceDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(resourceDGV.Rows[e.RowIndex].Cells[5].Value);
            selectedResourceId = long.Parse(resourceDGV.Rows[e.RowIndex].Cells[5].Value.ToString());
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Hide();
            (new AddResourceForm()).ShowDialog();
            Show();
            SetUpDGV();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (selectedResourceId == -1)
            {
                MessageBox.Show("Select a resource");
            }
            else
            {
                Hide();
                (new UpdateResourceForm(selectedResourceId)).ShowDialog();
                Show();
                SetUpDGV();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                var resourceToDelete = context.Resources.Where(x => x.resId == selectedResourceId).First();

                context.Resources.Remove(resourceToDelete);

                var allocationsToDelete = context.Resource_Allocation.Where(x => x.resIdFK == selectedResourceId);

                foreach (var item in allocationsToDelete)
                {
                    context.Resource_Allocation.Remove(item);
                }

                context.SaveChanges();
                MessageBox.Show("Item Deleted");

                SetUpDGV();
            }
        }
    }
}