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
    public partial class UpdateResourceForm : Form
    {
        private long _resId = -1;

        public UpdateResourceForm(long resId)
        {
            _resId = resId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateResourceForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                var resourceQuery = context.Resources.Where(x => x.resId == _resId).FirstOrDefault();

                resourceNameLbl.Text = resourceQuery.resName;
                resourceTypeLbl.Text = resourceQuery.Resource_Type.resTypeName;
                quantityTb.Text = resourceQuery.remainingQuantity.ToString();

                foreach (var item in resourceQuery.Resource_Allocation)
                {
                    if (item.Skill.skillName.Equals("Cyber Security"))
                    {
                        cyberSecCheckBox.Checked = true;
                    }
                    if (item.Skill.skillName.Equals("Software Solutions"))
                    {
                        itssbCheckBox.Checked = true;
                    }
                    if (item.Skill.skillName.Equals("Web Tech"))
                    {
                        webTechCheckBox.Checked = true;
                    }
                    if (item.Skill.skillName.Equals("Networking"))
                    {
                        networkingCheckBox.Checked = true;
                    }
                }
            }
        }

        private void addResourceBtn_Click(object sender, EventArgs e)
        {
            if (AllValid())
            {
                MessageBox.Show("Resource Updated");
                Close();
            }
        }

        private bool AllValid()
        {
            using (var context = new Session1Entities())
            {
                int tempNumber = 0;

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

                if (tempNumber == 0)
                {
                    if (cyberSecCheckBox.Checked || itssbCheckBox.Checked || networkingCheckBox.Checked
                        || webTechCheckBox.Checked)
                    {
                        MessageBox.Show("Cannot allocate skills to resource with no quantity");
                        return false;
                    }
                }

                if (quantityTb.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Fill up all fields");
                    return false;
                }

                try
                {
                    var resourceToUpdate = context.Resources.Where(x => x.resId == _resId).FirstOrDefault();
                    resourceToUpdate.remainingQuantity = tempNumber;

                    context.SaveChanges();

                    var allocationToDelete = context.Resource_Allocation.Where(x => x.resIdFK == _resId);

                    foreach (var item in allocationToDelete)
                    {
                        context.Resource_Allocation.Remove(item);
                    }

                    if (cyberSecCheckBox.Checked)
                    {
                        var newAllocation = new Resource_Allocation
                        {
                            resIdFK = (int)_resId,
                            skillIdFK = 1
                        };

                        context.Resource_Allocation.Add(newAllocation);
                    }

                    if (itssbCheckBox.Checked)
                    {
                        var newAllocation = new Resource_Allocation
                        {
                            resIdFK = (int)_resId,
                            skillIdFK = 2
                        };

                        context.Resource_Allocation.Add(newAllocation);
                    }

                    if (networkingCheckBox.Checked)
                    {
                        var newAllocation = new Resource_Allocation
                        {
                            resIdFK = (int)_resId,
                            skillIdFK = 4
                        };

                        context.Resource_Allocation.Add(newAllocation);
                    }

                    if (webTechCheckBox.Checked)
                    {
                        var newAllocation = new Resource_Allocation
                        {
                            resIdFK = (int)_resId,
                            skillIdFK = 3
                        };

                        context.Resource_Allocation.Add(newAllocation);
                    }

                    context.SaveChanges();
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