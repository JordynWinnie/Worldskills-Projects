using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TPQR2020_S1_08062022_Windows_NetFramework
{
    public partial class UpdateResource : Form
    {
        private Resource currentResource;
        private Dictionary<string, Skill> allocatedSkillsList;

        public UpdateResource(Resource resource)
        {
            this.currentResource = resource;
            InitializeComponent();
        }

        private void UpdateResource_Load(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                allocatedSkillsList = context.Skills.ToDictionary(x => x.skillName);
                allocatedSkillsCLB.Items.AddRange(allocatedSkillsList.Keys.ToArray());

                resourceNameLbl.Text = currentResource.resName;
                resourceTypeLbl.Text = currentResource.Resource_Type.resTypeName;
                availableQtyNUD.Value = currentResource.remainingQuantity;

                foreach (var allocation in currentResource.Resource_Allocation)
                {
                    var idx = allocatedSkillsCLB.Items.IndexOf(allocation.Skill.skillName);
                    allocatedSkillsCLB.SetItemChecked(idx, true);
                }
            }
        }

        private void addResourceBtn_Click(object sender, EventArgs e)
        {
            if (availableQtyNUD.Value == 0 && allocatedSkillsCLB.CheckedItems.Count > 0)
            {
                MessageBox.Show("Quantity should be more than zero if you would like to allocate this resource.");
                return;
            }

            using (var context = new Session1Entities())
            {
                var changeResource = context.Resources.Where(x=>x.resId == currentResource.resId).First();

                changeResource.remainingQuantity = (int)availableQtyNUD.Value;

                context.SaveChanges();

                var old_allocations = context.Resource_Allocation.Where(x=>x.resIdFK == currentResource.resId);

                context.Resource_Allocation.RemoveRange(old_allocations);

                foreach (string allocation in allocatedSkillsCLB.CheckedItems)
                {
                    var skillId = allocatedSkillsList[allocation].skillId;

                    var newAllocation = new Resource_Allocation
                    {
                        resIdFK = currentResource.resId,
                        skillIdFK = skillId
                    };

                    context.Resource_Allocation.Add(newAllocation);
                }

                context.SaveChanges();
                MessageBox.Show("Resource Updated");
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
