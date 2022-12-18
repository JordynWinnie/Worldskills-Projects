using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TPQR_Session1_9_7_2020
{
    public partial class AddResourceForm : Form
    {
        private Session1Entities context = new Session1Entities();

        private int _resId = -1;

        public AddResourceForm(int resId)
        {
            _resId = resId;
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void typeFilterCb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void AddResourceForm_Load(object sender, EventArgs e)
        {
            resourceTypeCb.Items.AddRange(context.Resource_Type.Select(x => x.resTypeName).ToArray());
            allocatedSkills.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
            resourceTypeCb.SelectedIndex = 0;

            if (_resId != -1)
            {
                //Update Mode
                title.Text = "Update Resource";
                this.Text = "Update Resource";
                addBtn.Text = "Update";

                var resourceInfo = context.Resources.Where(x => x.resId == _resId).First();

                resourceNameTb.Text = resourceInfo.resName;
                resourceTypeCb.SelectedItem = resourceInfo.Resource_Type.resTypeName;
                quantityNUD.Value = resourceInfo.remainingQuantity;

                for (int i = 0; i < allocatedSkills.Items.Count; i++)
                {
                    foreach (var resourceSkill in resourceInfo.Resource_Allocation)
                    {
                        if (allocatedSkills.Items[i].ToString().Equals(resourceSkill.Skill.skillName))
                        {
                            allocatedSkills.SetItemChecked(i, true);
                        }
                    }
                }
            }
            else
            {
                this.Text = "Add Resource";
                addBtn.Text = "Add";
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (resourceNameTb.Text.Length == 0)
            {
                MessageBox.Show("Enter a resource name");
                return;
            }

            if (quantityNUD.Value == 0)
            {
                if (allocatedSkills.CheckedItems.Count != 0)
                {
                    MessageBox.Show("Resource of 0 quantity cannot have skills allocated to it");
                    return;
                }
            }

            if (_resId == -1)
            {
                if (context.Resources.Where(x => x.resName == resourceNameTb.Text).Any())
                {
                    MessageBox.Show("Resource name taken, please choose another");
                    return;
                }
                var selectedType = resourceTypeCb.SelectedItem.ToString();
                var typeId = context.Resource_Type.Where(x => x.resTypeName == selectedType).First();

                var insertResource = new Resource
                {
                    remainingQuantity = (int)quantityNUD.Value,
                    resName = resourceNameTb.Text,
                    resTypeIdFK = typeId.resTypeId,
                };

                context.Resources.Add(insertResource);

                if (allocatedSkills.CheckedItems.Count != 0)
                {
                    foreach (var item in allocatedSkills.CheckedItems)
                    {
                        var skillName = item.ToString();
                        var skill = context.Skills.Where(x => x.skillName == skillName).First();
                        var insertAllocation = new Resource_Allocation
                        {
                            resIdFK = insertResource.resId,
                            skillIdFK = skill.skillId
                        };
                        context.Resource_Allocation.Add(insertAllocation);
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Changes saved");
            }
            else
            {
                var selectedType = resourceTypeCb.SelectedItem.ToString();
                var typeId = context.Resource_Type.Where(x => x.resTypeName == selectedType).First();
                var resourceToModify = context.Resources.Where(x => x.resId == _resId).First();
                if (context.Resources.Where(x => x.resName == resourceNameTb.Text && x.resName != resourceToModify.resName).Any())
                {
                    MessageBox.Show("Resource name taken, please choose another");
                    return;
                }

                var allocations = resourceToModify.Resource_Allocation.ToList();
                foreach (var allocation in allocations)
                {
                    context.Resource_Allocation.Remove(allocation);
                }

                resourceToModify.resName = resourceNameTb.Text;
                resourceToModify.remainingQuantity = (int)quantityNUD.Value;
                resourceToModify.resTypeIdFK = typeId.resTypeId;

                if (allocatedSkills.CheckedItems.Count != 0)
                {
                    foreach (var item in allocatedSkills.CheckedItems)
                    {
                        var skillName = item.ToString();
                        var skill = context.Skills.Where(x => x.skillName == skillName).First();
                        var insertAllocation = new Resource_Allocation
                        {
                            resIdFK = resourceToModify.resId,
                            skillIdFK = skill.skillId
                        };
                        context.Resource_Allocation.Add(insertAllocation);
                    }
                }
                context.SaveChanges();
                MessageBox.Show("Changes saved");
                Close();
            }
        }
    }
}