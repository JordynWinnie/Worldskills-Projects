using System;
using System.Linq;
using System.Windows.Forms;

namespace TPQR_Paper1_5_15_2020
{
    public partial class AddResourceForm : Form
    {
        public AddResourceForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddResourceForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                resourceTypeCombobox.Items.AddRange(context.Resource_Type.Select(x => x.resTypeName).ToArray());
                resourceTypeCombobox.SelectedIndex = 0;

                allocatedSkills.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
            }
        }

        private void addResourceBtn_Click(object sender, EventArgs e)
        {
            if (AllValid())
            {
                MessageBox.Show("Resource Added!");
            }
        }

        private bool AllValid()
        {
            using (var context = new Session1Entities())
            {
                int tempNumber = 0;
                if (context.Resources.Where(x => x.resName.Equals(resourceNameTb.Text)).Any())
                {
                    MessageBox.Show("Resources cannot share the same name");
                    return false;
                }

                if (!int.TryParse(quantityTb.Text, out tempNumber))
                {
                    MessageBox.Show("Quantity should be a valid number");
                    return false;
                }

                if (tempNumber < 0)
                {
                    MessageBox.Show("Quantity should be zero or above");
                    return false;
                }

                if (tempNumber == 0 && allocatedSkills.CheckedItems.Count != 0)
                {
                    MessageBox.Show("Cannot allocate skills to resource with no quantity");
                    return false;
                }

                if (resourceNameTb.Text.Equals(string.Empty) || quantityTb.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Fill up all fields");
                    return false;
                }
                var selectedResourceType = resourceTypeCombobox.SelectedItem.ToString();
                var resourceTypeFK = context.Resource_Type.Where(x => x.resTypeName.Equals(selectedResourceType)).
                    Select(x => x.resTypeId).First();

                try
                {
                    var newResource = new Resource
                    {
                        remainingQuantity = tempNumber,
                        resName = resourceNameTb.Text,
                        resTypeIdFK = resourceTypeFK
                    };

                    context.Resources.Add(newResource);
                    context.SaveChanges();
                    var resId = context.Resources.OrderByDescending(x => x.resId).Select(x => x.resId).First();

                    if (allocatedSkills.CheckedItems.Count != 0)
                    {
                        foreach (var item in allocatedSkills.CheckedItems)
                        {
                            var skillid = context.Skills.Where(x => x.skillName.Equals(item.ToString())).Select(x => x.skillId).FirstOrDefault();
                            var newAllocation = new Resource_Allocation
                            {
                                resIdFK = resId,
                                skillIdFK = skillid,
                            };

                            context.Resource_Allocation.Add(newAllocation);
                            context.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving");
                    return false;
                    throw ex;
                }
            }
            return true;
        }
    }
}