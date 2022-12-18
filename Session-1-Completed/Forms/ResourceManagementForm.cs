using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Session1_JordanKhong.Forms
{
    public partial class ResourceManagementForm : Form
    {
        /// <summary>
        /// Global fields keep track of every change that happens accross methods.
        /// </summary>

        int typeFieldId = -1;
        int skillFieldId = -1;
        long selectedResId = -1;
        public ResourceManagementForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResourceManagementForm_Load(object sender, EventArgs e)
        {
            //Load all columns:
            List<string> columns = new List<string>
            {
                "Name",
                "Type",
                "No. Of Skills",
                "Allocated Skills",
                "Available Quantity",
                "ResourceID"
            };

            //Populate Columns in DGV:
            foreach (var column in columns)
            {
                resourceDGV.Columns.Add(column, column);
            }

            resourceDGV.Columns[5].Visible = false;

            //Load all skill types:
            using (var context = new Session1Entities())
            {
                //Add a default type, "No Sorting"
                typeCombo.Items.Add("No sorting");
                skillCombo.Items.Add("No sorting");


                typeCombo.Items.AddRange(context.Resource_Type.Select(x => x.resTypeName).ToArray());
                skillCombo.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());

                typeCombo.SelectedIndex = 0;
                skillCombo.SelectedIndex = 0;
            }

            ReSortTable(typeFieldId, skillFieldId);
        }

        /// <summary>
        /// This method "refreshes" the table based on the latest information and is called everytime the filter type is changed
        /// </summary>
        /// <param name="type"> Accepts a type Id, and defaults to -1 to represent "no sorting" </param>
        /// <param name="skill"> Accepts a skill Id, and defaults to -1 to represent "no sorting"</param>
        void ReSortTable(int type = -1, int skill = -1)
        {
            resourceDGV.Rows.Clear();

            //If either value is not filled in, it defaults to -1, meaning no sorting.

            using (var context = new Session1Entities())
            {

                //Get all resources from resource table, calculate their respective values:
                var defaultResourceQuery = (from x in context.Resources
                                            orderby x.resName
                                            group x by x.resName into y
                                            select new
                                            {
                                                ResourceName = y.Key,
                                                ResourceType = y.Select(x => x.Resource_Type.resTypeName),
                                                ResourceAllocation = y.Select(x => x.Resource_Allocation),
                                                Quantity = y.Sum(x => x.remainingQuantity),
                                                ResourceID = y.Select(x => x.resId)
                                            });


                if (type == -1 && skill == -1)
                {
                    #region Logic for Default, Default Sorting:
                    foreach (var resource in defaultResourceQuery)
                    {
                        //Uses default query to make the rows:
                        #region Population of Columns
                        //1st columns, which is name, type and allocation count can be taken straight from the query:
                        var row = new List<string>
                        {
                            resource.ResourceName,
                            resource.ResourceType.First(),
                            resource.ResourceAllocation.First().Where(x=>x.resIdFK == resource.ResourceID.First()).Select(x=>x.Skill.skillName).Count().ToString(),
                        };
                        #endregion

                        #region Logic for Column "Allocated Skills"
                        //For allocated skills, there can be more than 1 skill, so use a Join to join all the skill names with a comma.
                        var allocatedSkills = String.Join(",", resource.ResourceAllocation.First().Where(x => x.resIdFK == resource.ResourceID.First()).Select(x => x.Skill.skillName));


                        //Sometimes, no skill is assigned to the resource, in that case, add a "NIL"
                        if (allocatedSkills.Equals(""))
                        {
                            row.Add("NIL");
                        }
                        else
                        {
                            row.Add(allocatedSkills);
                        }
                        #endregion

                        #region Login for column "Available Quantity"
                        //Checks resource count and fills up the appropriate value
                        if (resource.Quantity <= 0)
                        {
                            row.Add("Not available");
                        }
                        else if (resource.Quantity >= 1 && resource.Quantity <= 5)
                        {
                            row.Add("Low Stock");
                        }
                        else
                        {
                            row.Add("Sufficient");
                        }
                        #endregion

                        row.Add(resource.ResourceID.First().ToString());
                        resourceDGV.Rows.Add(row.ToArray());
                    }
                    #endregion
                }
                else if (type == -1)
                {
                    #region Logic for Default Type, but selected Skill Sorting:
                    var currentSelectedSkill = skillCombo.SelectedItem.ToString();

                    //The query is still the same query from above:
                    foreach (var resource in defaultResourceQuery)
                    {
                        //However, this does a check first to see if it's of the skill selected based on skill name:
                        if (resource.ResourceAllocation.First().Where(x => x.resIdFK == resource.ResourceID.First()).Select(x => x.Skill.skillName).Contains(currentSelectedSkill))
                        {
                            var row = new List<string>
                        {
                            resource.ResourceName,
                            resource.ResourceType.First(),
                            resource.ResourceAllocation.First().Where(x=>x.resIdFK == resource.ResourceID.First()).Select(x=>x.Skill.skillName).Count().ToString(),
                        };

                            //Rest of the logic is the same as the one above.
                            var allocatedSkills = String.Join(",", resource.ResourceAllocation.First().Where(x => x.resIdFK == resource.ResourceID.First()).Select(x => x.Skill.skillName));


                            if (allocatedSkills.Equals(""))
                            {
                                row.Add("NIL");
                            }
                            else
                            {
                                row.Add(allocatedSkills);
                            }

                            if (resource.Quantity <= 0)
                            {
                                row.Add("Not available");
                            }
                            else if (resource.Quantity >= 1 && resource.Quantity <= 5)
                            {
                                row.Add("Low Stock");
                            }
                            else
                            {
                                row.Add("Sufficient");
                            }


                            row.Add(resource.ResourceID.First().ToString());
                            resourceDGV.Rows.Add(row.ToArray());
                        }

                    }
                    #endregion
                }
                else if (skill == -1)
                {
                    #region Logic for selected type Sorting, but default skill sorting
                    var currentSelectedType = typeCombo.SelectedItem.ToString();
                    
                    //uses the same query as above
                    foreach (var resource in defaultResourceQuery)
                    {
                        //However, this one instead checks the resource type directly:
                        if (resource.ResourceType.First().Equals(currentSelectedType))
                        {
                            var row = new List<string>
                        {
                            resource.ResourceName,
                            resource.ResourceType.First(),
                            resource.ResourceAllocation.First().Where(x=>x.resIdFK == resource.ResourceID.First()).Select(x=>x.Skill.skillName).Count().ToString(),
                        };

                            //Rest of the logic is the same:
                            var allocatedSkills = String.Join(",", resource.ResourceAllocation.First().Where(x => x.resIdFK == resource.ResourceID.First()).Select(x => x.Skill.skillName));

                            if (allocatedSkills.Equals(""))
                            {
                                row.Add("NIL");
                            }
                            else
                            {
                                row.Add(allocatedSkills);
                            }

                            if (resource.Quantity <= 0)
                            {
                                row.Add("Not available");
                            }
                            else if (resource.Quantity >= 1 && resource.Quantity <= 5)
                            {
                                row.Add("Low Stock");
                            }
                            else
                            {
                                row.Add("Sufficient");
                            }


                            row.Add(resource.ResourceID.First().ToString());
                            resourceDGV.Rows.Add(row.ToArray());
                        }

                    }
                    #endregion
                }
                else
                {
                    #region Logic for both type and skill sorting:

                    //Gets the currentType and currentSkill from the comboboxes:
                    var currentSelectedType = typeCombo.SelectedItem.ToString();
                    var currentSelectedSkill = skillCombo.SelectedItem.ToString();

                    //uses the same query:
                    foreach (var resource in defaultResourceQuery)
                    {
                        //Uses a combination of the two above to filter information:
                        if (resource.ResourceType.First().Equals(currentSelectedType) && resource.ResourceAllocation.First().Where(x => x.resIdFK == resource.ResourceID.First()).Select(x => x.Skill.skillName).Contains(currentSelectedSkill))
                        {
                            var row = new List<string>
                        {
                            resource.ResourceName,
                            resource.ResourceType.First(),
                            resource.ResourceAllocation.First().Where(x=>x.resIdFK == resource.ResourceID.First()).Select(x=>x.Skill.skillName).Count().ToString(),
                        };

                            //uses the same logic as above to join and populate the rest of the rows:
                            var allocatedSkills = String.Join(",", resource.ResourceAllocation.First().Where(x => x.resIdFK == resource.ResourceID.First()).Select(x => x.Skill.skillName));

                            if (allocatedSkills.Equals(""))
                            {
                                row.Add("NIL");
                            }
                            else
                            {
                                row.Add(allocatedSkills);
                            }

                            if (resource.Quantity <= 0)
                            {
                                row.Add("Not available");
                            }
                            else if (resource.Quantity >= 1 && resource.Quantity <= 5)
                            {
                                row.Add("Low Stock");
                            }
                            else
                            {
                                row.Add("Sufficient");
                            }


                            row.Add(resource.ResourceID.First().ToString());
                            resourceDGV.Rows.Add(row.ToArray());
                        }


                    }

                    #endregion

                }

                #region Coloring Rows:
                //Checks all rows, and sees if last column, "Available quantity" has a "not available" and colours it red:
                foreach (DataGridViewRow row in resourceDGV.Rows)
                {
                    Console.WriteLine(row.Cells[4].Value.ToString());
                    if (row.Cells[4].Value.ToString().Contains("Not"))
                    {
                        row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                    }

                }
                #endregion
            }

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            //Opens a "Add Resouce form" with the ID -1, letting the next form know it's a Add Resource and Not Update:
            this.Hide();
            (new AddNewResourceForm(-1)).ShowDialog();
            this.Show();
            ReSortTable(typeFieldId, skillFieldId);
        }

        private void TypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Checks if it's "No Sorting" selected (meaning index = 0) and changes the global TypeFieldID
            if (typeCombo.SelectedIndex == 0)
            {
                typeFieldId = -1;
                ReSortTable(typeFieldId, skillFieldId);
            }
            else
            {
                //if not "no sorting" it gets the typeId to change the global variable TypeFieldID:
                using (var context = new Session1Entities())
                {
                    var typeNameFromComboBox = typeCombo.SelectedItem.ToString();
                    var getTypeId = context.Resource_Type.Where(x => x.resTypeName.Equals(typeNameFromComboBox)).Select(x => x.resTypeId).First();

                    typeFieldId = getTypeId;
                    
                    ReSortTable(typeFieldId, skillFieldId);

                }
            }
        }

        private void SkillCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Checks if it's "No Sorting" selected (meaning index = 0) and changes the global skillFieldId
            if (skillCombo.SelectedIndex == 0)
            {
                skillFieldId = -1;
                ReSortTable(typeFieldId, skillFieldId);
            }
            else
            {
                //if not "no sorting" it gets the skillid to change the global variable skillFieldId:
                using (var context = new Session1Entities())
                {
                    var skillNameFromComboBox = skillCombo.SelectedItem.ToString();
                    var getSkillId = context.Skills.Where(x => x.skillName.Equals(skillNameFromComboBox)).Select(x => x.skillId).First();

                    skillFieldId = getSkillId;
                    ReSortTable(typeFieldId, skillFieldId);

                }
            }
        }

        private void ResourceDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //At every cell click, it changes the global variable selectedResId to a hidden column which contains the ResourceId
            if (e.RowIndex >= 0)
            {
                selectedResId = Convert.ToInt64(resourceDGV.Rows[e.RowIndex].Cells[5].Value);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void updateBtn_Click(object sender, EventArgs e)
        {
            //If you click update without selecting a cell item, the global variable is initialised as -1
            //this is used as a check to make the user click on a cell item to update
            if (selectedResId == -1)
            {
                MessageBox.Show("Please select an item to update");

            }
            else
            {

                //Shows the AddNewResource form, and placing in the ResourceId to tell the form that it is
                // an update, not an add:
                this.Hide();
                (new AddNewResourceForm(selectedResId)).ShowDialog();
                this.Show();
                ReSortTable(typeFieldId, skillFieldId);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //If you click delete without selecting a cell item, the global variable is initialised as -1
            //this is used as a check to make the user click on a cell item to delete
            if (selectedResId == -1)
            {
                MessageBox.Show("Please select an item to delete");
            }
            else
            {
                //Gets the current resource from resource table based on ID
                using (var context = new Session1Entities())
                {
                    var getResource = context.Resources.Where(x => x.resId == selectedResId).Select(x => x).FirstOrDefault();

                    #region Deletion Process:
                    //Asks user if you want to delete:
                    var result = MessageBox.Show($"Are you sure you want to delete the resource: '{getResource.resName}'?", "Warning", MessageBoxButtons.YesNo);

                    //if yes,
                    if (result == DialogResult.Yes)
                    {
                        var getResourceAllocations = context.Resource_Allocation.Where(x => x.resIdFK == selectedResId);
                        //Delete all related allocations:
                        foreach (var resource in getResourceAllocations)
                        {
                            context.Resource_Allocation.Remove(resource);
                        }
                        //Delete the selected item.
                        context.Resources.Remove(getResource);
                        
                        //Attempt to save changes, and refresh the table.
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Item deleted.");
                            ReSortTable(typeFieldId, skillFieldId);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting item. Details: \n" + ex.Message);
                        }

                    }
                    #endregion
                }

            }
        }
    }
}
