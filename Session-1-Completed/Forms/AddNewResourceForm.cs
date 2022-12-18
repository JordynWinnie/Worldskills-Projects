using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session1_JordanKhong.Forms
{
    public partial class AddNewResourceForm : Form
    {
        long currentResourceID = -1;
        public AddNewResourceForm(long _resourceID)
        {
            currentResourceID = _resourceID;
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewResourceForm_Load(object sender, EventArgs e)
        {
            //Interface shares Add/Update UI

            using (var context = new Session1Entities())
            {
                //Update Combobox with resourceTypes
                resourceTypeCb.Items.AddRange(context.Resource_Type.Select(x => x.resTypeName).ToArray());
                resourceTypeCb.SelectedIndex = 0;

                //Update CheckList with all skill names
                skillNameCheckList.Items.AddRange(context.Skills.OrderBy(x => x.skillId).Select(x => x.skillName).ToArray());

                if (currentResourceID == -1)
                {
                    //This means that you're currently adding a resource. The form should be empty
                }
                else
                {
                    //Checks the database for current source information and changes all fields to have the current information:
                    menuLbl.Text = "Update Resource:";
                    addResourceBtn.Text = "Update Resource";

                    var getCurrentSkillsUsingResource = from x in context.Resources
                                                        where x.resId == currentResourceID
                                                        select x;

                    //Checks the boxes of all the skills in the CheckBoxList based on skill id - 1:
                    foreach (var skill in context.Resource_Allocation.Where(x => x.resIdFK == currentResourceID).Select(x => x.skillIdFK))
                    {
                        skillNameCheckList.SetItemChecked(skill - 1, true);
                    }

                    //Disallows you to change Resource Type Combobox and Resource name textbox:
                    resourceNametb.Enabled = false;
                    resourceNametb.Text = getCurrentSkillsUsingResource.Select(x => x.resName).FirstOrDefault();

                    resourceTypeCb.Enabled = false;
                    resourceTypeCb.SelectedItem = getCurrentSkillsUsingResource.Select(x => x.Resource_Type).FirstOrDefault();
                    quantityTb.Text = getCurrentSkillsUsingResource.Select(x => x.remainingQuantity).FirstOrDefault().ToString();

                }


            }

        }

        private void addResourceBtn_Click(object sender, EventArgs e)
        {
            //Checks if an ADD or UPDATE operation is being done:
            if (currentResourceID == -1)
            {
                #region Add Resource Logic:
                while (true)
                {
                    using (var context = new Session1Entities())
                    {
                        #region Validation Checks
                        var checkForSameResourceName = context.Resources.Where(x => x.resName.Equals(resourceNametb.Text)).FirstOrDefault();

                        //Checks for same resource name in db:
                        if (checkForSameResourceName != null)
                        {
                            MessageBox.Show("Two resources cannot have the same name!");
                            break;
                        }

                        //Checks for if resource name field is empty:
                        if (resourceNametb.Text.Equals(string.Empty))
                        {
                            MessageBox.Show("Resource name cannot be empty");
                            break;
                        }

                        try
                        {
                            //Checks if:
                            var quantity = Convert.ToInt32(quantityTb.Text);

                            //1. Quantity is less than 0
                            if (quantity < 0)
                            {
                                MessageBox.Show("Quantity cannot be less than 0");
                            }

                            //2. If Quantity is 0, no skill should be selected:
                            if (quantity == 0 && skillNameCheckList.CheckedItems.Count != 0)
                            {
                                MessageBox.Show("If the quantity is zero, you cannot assign this resource to any skill");
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            //3. If Convert.ToInt32 fails, that means an invalid field has been filled in.
                            MessageBox.Show("Please enter a valid WHOLE number");
                            break;
                        }

                        #endregion

                        #region Adding of Resource
                        //Add new ResourceName:

                        //1. get the ResourceTypeID from the combobox:
                        var resourceNameFromCb = resourceTypeCb.SelectedItem.ToString();
                        var resourceIdType = context.Resource_Type.Where(x => x.resTypeName == resourceNameFromCb).Select(x => x.resTypeId).First();

                        //2. Get the quantity from the textbox:
                        var quantityFromTb = Convert.ToInt32(quantityTb.Text);

                        //3. Insert a new resource into the table and save changes:
                        Resource insertResource = new Resource
                        {
                            resName = resourceNametb.Text,
                            resTypeIdFK = resourceIdType,
                            remainingQuantity = quantityFromTb,
                        };
                        context.Resources.Add(insertResource);
                        context.SaveChanges();

                        //If a skill is checked, a resource allocation has to be made as well:

                        if (!(skillNameCheckList.CheckedItems.Count == 0))
                        {
                            //Gets the latest resource ID that was JUST added by the above code:
                            var insertedResourceId = context.Resources.OrderByDescending(x => x.resId).Select(x => x.resId).First();

                            //Add all checked items into database
                            foreach (var item in skillNameCheckList.CheckedItems)
                            {
                                Console.WriteLine(item.ToString());

                                var skillId = context.Skills.Where(x => x.skillName.Equals(item.ToString())).Select(x => x.skillId).First();

                                Resource_Allocation insertRA = new Resource_Allocation
                                {
                                    resIdFK = insertedResourceId,
                                    skillIdFK = skillId
                                };

                                context.Resource_Allocation.Add(insertRA);
                            }
                        }
                        //Do a final save change to save all changes:
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Changes saved c:");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error adding changes. Details: \n" + ex.Message);
                            throw;
                        }
                    }

                    break;
                    #endregion
                }
                #endregion
            }
            else
            {
                #region Update Resource Logic:
                while (true)
                {
                    #region Validation Checks:
                    //Update Resource:
                    using (var context = new Session1Entities())
                    {
                        var updateResourceQuantity = (from x in context.Resources
                                                      where x.resId == currentResourceID
                                                      select x).FirstOrDefault();

                        updateResourceQuantity.remainingQuantity = Convert.ToInt32(quantityTb.Text);

                        try
                        {
                            var quantity = Convert.ToInt32(quantityTb.Text);

                            if (quantity < 0)
                            {
                                MessageBox.Show("Quantity cannot be 0");
                                break;
                            }

                            if (quantity == 0 && skillNameCheckList.CheckedItems.Count != 0)
                            {
                                MessageBox.Show("If the quantity is zero, you cannot assign this resource to any skill");
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Please enter a valid WHOLE number");
                            break;
                        }

                        #endregion

                        //Deletes all the resources with the same ID as selected:
                        var resourcesToDelete = from x in context.Resource_Allocation
                                                where x.resIdFK == currentResourceID
                                                select x;

                        foreach (var resource in resourcesToDelete)
                        {
                            context.Resource_Allocation.Remove(resource);
                        }

                        //Re-adds allocation based on new checked Items:
                        foreach (var allocation in skillNameCheckList.CheckedItems)
                        {
                            var skillId = context.Skills.Where(x => x.skillName.Equals(allocation.ToString())).Select(x => x.skillId).First();

                            Resource_Allocation insertRA = new Resource_Allocation
                            {
                                resIdFK = (int)currentResourceID,
                                skillIdFK = skillId
                            };

                            context.Resource_Allocation.Add(insertRA);
                        }


                        //Saves changes to database:
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Changes Updated");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error saving. Details: \n" + ex.Message);
                        }

                        break;

                    }
                }



            }
            #endregion

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
