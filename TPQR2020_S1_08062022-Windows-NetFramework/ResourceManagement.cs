using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TPQR2020_S1_08062022_Windows_NetFramework
{
    public partial class ResourceManagement : Form
    {
        private string selectedResource = string.Empty;
        private Dictionary<string, Resource_Type> resourceType;
        private Dictionary<string, Skill> skillsList;

        public ResourceManagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResourceManagement_Load(object sender, EventArgs e)
        {
            var columns = new List<string>()
            {
                "Name", "Type", "No Of Skills", "Allocated Skill(s)", "Available Quantity"
            };

            columns.ForEach (x=> resourceDGV.Columns.Add(x,x));

            using (var context = new Session1Entities())
            {
                resourceType = context.Resource_Type.ToDictionary(x=>x.resTypeName);
                skillsList = context.Skills.ToDictionary(x=>x.skillName);

                resourceTypeCb.Items.Add("No Filter");
                skillCb.Items.Add("No Filter");

                resourceTypeCb.Items.AddRange(resourceType.Keys.ToArray());
                skillCb.Items.AddRange(skillsList.Keys.ToArray());

                resourceTypeCb.SelectedIndex = 0;
                skillCb.SelectedIndex = 0;

                RefreshList();
            }
        }

        void RefreshList()
        {
            if (resourceTypeCb.SelectedIndex == -1 || skillCb.SelectedIndex == -1)
            {
                return;
            }
            resourceDGV.Rows.Clear();

            using (var context = new Session1Entities())
            {
                var resources = context.Resources.ToList();

                if (resourceTypeCb.SelectedItem.ToString() != "No Filter")
                {
                    var selectedResourceType = resourceType[resourceTypeCb.SelectedItem.ToString()].resTypeId;
                    resources = resources.Where(x=>x.resTypeIdFK == selectedResourceType).ToList();
                }

                if (skillCb.SelectedItem.ToString() != "No Filter")
                {
                    var selectedSkill = skillsList[skillCb.SelectedItem.ToString()].skillId;
                    resources = resources.Where(x=>x.Resource_Allocation.Select(y=>y.skillIdFK).Contains(selectedSkill)).ToList();
                }

                foreach (var resource in resources)
                {
                    var availabilityString = "Not Available";

                    if (resource.remainingQuantity > 5)
                    {
                        availabilityString = "Sufficient";
                    }

                    if (resource.remainingQuantity <= 5 && resource.remainingQuantity >= 1)
                    {
                        availabilityString = "Low Stock";
                    }
                    var row = new List<string>
                    {
                        resource.resName, 
                        resource.Resource_Type.resTypeName,
                        resource.Resource_Allocation.Count().ToString(),
                        string.Join(", ", resource.Resource_Allocation.Select(x=>x.Skill.skillName)),
                        availabilityString
                    };

                    resourceDGV.Rows.Add(row.ToArray());
                }

                foreach (DataGridViewRow row in resourceDGV.Rows)
                {
                    var cells = row.Cells;
                    if (cells[4].Value.ToString() == "Not Available")
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void resourceTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Hide();
            var form = new AddResource();
            form.ShowDialog();
            Show();
        }

        private void resourceDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedResource = resourceDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            Console.WriteLine(selectedResource);
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (selectedResource == string.Empty)
            {
                MessageBox.Show("Please select a resource");
                return;
            }

            using (var context = new Session1Entities())
            {
                var resource = context.Resources.Where(x=>x.resName == selectedResource).First();

                var form = new UpdateResource(resource);
                Hide();
                form.ShowDialog();
                RefreshList();
                Show();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedResource == string.Empty)
            {
                MessageBox.Show("Please select a resource");
                return;
            }

            if (MessageBox.Show($"Confirm deletion of the resource {selectedResource}?", "Delete?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var context = new Session1Entities())
                {
                    var resource = context.Resources.Where(x => x.resName == selectedResource).First();

                    context.Resource_Allocation.RemoveRange(resource.Resource_Allocation);
                    context.Resources.Remove(resource);

                    context.SaveChanges();

                    RefreshList();
                }
            }
        }
    }
}
