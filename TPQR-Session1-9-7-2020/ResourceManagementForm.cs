using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session1_9_7_2020
{
    public partial class ResourceManagementForm : Form
    {
        private Session1Entities context = new Session1Entities();
        private int _resId = -1;

        public ResourceManagementForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResourceManagementForm_Load(object sender, EventArgs e)
        {
            string[] columns = { "Name", "Type", "No. of Skills", "Allocated Skills", "Quantity", "ID" };

            foreach (var column in columns)
            {
                resourceDGV.Columns.Add(column, column);
            }

            resourceDGV.Columns[5].Visible = false;
            typeFilterCb.Items.Add("All");
            typeFilterCb.Items.AddRange(context.Resource_Type.Select(x => x.resTypeName).ToArray());

            skillFilterCb.Items.Add("All");
            skillFilterCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());

            typeFilterCb.SelectedIndex = 0;
            skillFilterCb.SelectedIndex = 0;

            UpdateTable();
        }

        private void UpdateTable()
        {
            if (typeFilterCb.SelectedIndex == -1 || skillFilterCb.SelectedIndex == -1)
            {
                return;
            }

            resourceDGV.Rows.Clear();

            var unchangedAllocation = from x in context.Resource_Allocation
                                      select x;
            var allocationQuery = from x in context.Resource_Allocation
                                  select x;

            var nonAllocatedResources = from x in context.Resources
                                        where x.remainingQuantity == 0 || x.Resource_Allocation.Count == 0
                                        select x;

            var selectedType = typeFilterCb.SelectedItem.ToString();
            var selectedSkill = skillFilterCb.SelectedItem.ToString();
            if (!selectedType.Equals("All"))
            {
                allocationQuery = allocationQuery.Where(x => x.Resource.Resource_Type.resTypeName == selectedType);
                nonAllocatedResources = nonAllocatedResources.Where(x => x.Resource_Type.resTypeName == selectedType);
            }
            if (!selectedSkill.Equals("All"))
            {
                allocationQuery = allocationQuery.Where(x => x.Skill.skillName == selectedSkill);
            }

            var finalQuery = from x in allocationQuery
                             group x by x.Resource.resName into y
                             select y;

            foreach (var item in finalQuery)
            {
                var row = new List<string>
                {
                    item.Key,
                    item.Select(x=>x.Resource.Resource_Type.resTypeName).First(),
                    item.Count().ToString(),
                    string.Join(", ", unchangedAllocation.Where(x=>x.Resource.resName == item.Key).Select(x=>x.Skill.skillName)),
                };

                var qty = item.Select(x => x.Resource.remainingQuantity).First();
                if (qty <= 0)
                {
                    row.Add("Not Available");
                }
                else if (qty > 0 && qty <= 5)
                {
                    row.Add("Low Stock");
                }
                else
                {
                    row.Add("Available");
                }
                row.Add(item.Select(x => x.resIdFK).First().ToString());

                resourceDGV.Rows.Add(row.ToArray());
            }

            if (selectedSkill.Equals("All"))
            {
                foreach (var item in nonAllocatedResources)
                {
                    var row = new List<string>
                {
                    item.resName,
                    item.Resource_Type.resTypeName,
                    item.remainingQuantity.ToString(),
                    "Nil"
                };
                    var qty = item.remainingQuantity;
                    if (qty <= 0)
                    {
                        row.Add("Not Available");
                    }
                    else if (qty > 0 && qty <= 5)
                    {
                        row.Add("Low Stock");
                    }
                    else
                    {
                        row.Add("Available");
                    }
                    row.Add(item.resId.ToString());
                    resourceDGV.Rows.Add(row.ToArray());
                }
            }

            foreach (DataGridViewRow row in resourceDGV.Rows)
            {
                if (row.Cells[4].Value.Equals("Not Available"))
                {
                    row.DefaultCellStyle.BackColor = Color.OrangeRed;
                }
            }
        }

        private void typeFilterCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void skillFilterCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void resourceDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _resId = int.Parse(resourceDGV[5, e.RowIndex].Value.ToString());
            Console.WriteLine(_resId);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (_resId == -1)
            {
                MessageBox.Show("Please select an item");
                return;
            }

            Hide();
            new AddResourceForm(_resId).ShowDialog();
            Show();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new AddResourceForm(-1).ShowDialog();
            Show();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (_resId == -1)
            {
                MessageBox.Show("Please select an item");
                return;
            }

            var resourceToDelete = context.Resources.Where(x => x.resId == _resId).First();

            if (MessageBox.Show($"Confirm Deletion of item: {resourceToDelete.resName}?", "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            var allocations = resourceToDelete.Resource_Allocation.ToList();

            foreach (var allocation in allocations)
            {
                context.Resource_Allocation.Remove(allocation);
            }

            context.Resources.Remove(resourceToDelete);
            context.SaveChanges();
            MessageBox.Show("Item Deleted");
            UpdateTable();
        }
    }
}