using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR2020_S1_08062022_Windows_NetFramework
{
    public partial class AddResource : Form
    {
        private Dictionary<string, Skill> allocatedSkillsList;
        private Dictionary<string, Resource_Type> resourceTypeList;

        public AddResource()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addResourceBtn_Click(object sender, EventArgs e)
        {
            if (resourceNameTb.Text == string.Empty)
            {
                MessageBox.Show("Resource name should be entered");
                return;
            }

            if (availableQtyNUD.Value == 0 && allocatedSkillsCLB.CheckedItems.Count > 0)
            {
                MessageBox.Show("Quantity should be more than zero if you would like to allocate this resource.");
                return;
            }
            
            using (var context = new Session1Entities())
            {
                if (context.Resources.Any(x=>x.resName == resourceNameTb.Text))
                {
                    MessageBox.Show("Resource names cannot be repeated.");
                    return;
                }
                var resourceTypeId = resourceTypeList[resourceTypeCb.SelectedItem.ToString()].resTypeId;
                var newResource = new Resource
                {
                    remainingQuantity =  (int)availableQtyNUD.Value,
                    resName = resourceNameTb.Text,
                    resTypeIdFK = resourceTypeId
                };

                context.Resources.Add(newResource);
                context.SaveChanges();

                foreach (string allocation in allocatedSkillsCLB.CheckedItems)
                {
                    var skillId = allocatedSkillsList[allocation].skillId;

                    var newAllocation = new Resource_Allocation
                    {
                        resIdFK = newResource.resId,
                        skillIdFK = skillId
                    };

                    context.Resource_Allocation.Add(newAllocation);
                }

                context.SaveChanges();
                MessageBox.Show("Resource Added!");
            }

        }

        private void AddResource_Load(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                allocatedSkillsList = context.Skills.ToDictionary(x => x.skillName);
                allocatedSkillsCLB.Items.AddRange(allocatedSkillsList.Keys.ToArray());

                resourceTypeList = context.Resource_Type.ToDictionary(x => x.resTypeName);
                resourceTypeCb.Items.AddRange(resourceTypeList.Keys.ToArray());

                resourceTypeCb.SelectedIndex = 0;
            }
        }
    }
}
