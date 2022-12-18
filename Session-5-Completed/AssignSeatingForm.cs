using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Session5
{
    public partial class AssignSeatingForm : Form
    {
        string selectedCompetitorFromUListId = "";
        string selectedCompetitorFromSeat = "";


        public AssignSeatingForm()
        {
            InitializeComponent();
        }

        private void AssignSeatingForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session5Entities())
            {
                //Populate Skill Combobox:
                skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());

                //Populate and add Temporary Columns (hidden):
                var columns = new List<string>
                {
                    "s1","s2"
                };

                foreach (var column in columns)
                {
                    allocatedDGV.Columns.Add(column, column);
                }

                //Change Wrapping mode:
                allocatedDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                skillCb.SelectedIndex = 0;

                allocatedDGV.ReadOnly = true;
            }

            UpdateText();
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session5Entities())
            {
                unassignedCompetitorList.Items.Clear();

                var skillNameFromCb = skillCb.SelectedItem.ToString();

                var skillID = context.Skills.Where(x => x.skillName.Equals(skillNameFromCb)).Select(x => x.skillId).FirstOrDefault();


                var competitorAllocation = from x in context.Competitors
                                           where x.skillIdFK == skillID
                                           select x;

                //Dynamically generate DGV with all the rows

                //1. Get number of competitors:

                //2. Find out if odd or even.

                allocatedDGV.Rows.Clear();

                if (competitorAllocation.Count() % 2 == 0)
                {
                    //Even number of competitors:

                    for (int i = 0; i < competitorAllocation.Count(); i++)
                    {
                        if ((i + 1) % 2 == 0)
                        {
                            var row = new List<string>
                            {
                                (i).ToString(),
                                (i+1).ToString()
                            };

                            allocatedDGV.Rows.Add(row.ToArray());
                        }
                    }
                }
                else
                {
                    //Odd number of competitors:
                    for (int i = 0; i < competitorAllocation.Count(); i++)
                    {
                        //generates an extra empty seat
                        if ((i + 1) % 2 == 0)
                        {
                            var row = new List<string>
                            {
                                (i).ToString(),
                                (i+1).ToString()
                            };

                            allocatedDGV.Rows.Add(row.ToArray());
                        }
                        else if (competitorAllocation.Count() - 1 == i)
                        {
                            var row = new List<string>
                            {
                                (i+1).ToString(),
                                ""
                            };

                            allocatedDGV.Rows.Add(row.ToArray());
                        }
                    }
                }

                //Populate competitor list:
                foreach (var competitor in competitorAllocation)
                {
                    if (competitor.assignedSeat == 0)
                    {
                        //If he doesnt have a seat, add him to the unassgined list:
                        unassignedCompetitorList.Items.Add(string.Join(", ", competitor.competitorName, competitor.competitorCountry, competitor.competitorId));
                    }
                    else
                    {
                        //If competitor has a seat prior, assign it to him:
                        #region Already Assigned Seating Population
                        foreach (DataGridViewRow row in allocatedDGV.Rows)
                        {
                            if (row.Cells["s1"].Value.Equals(competitor.assignedSeat.ToString()))
                            {
                                row.Cells["s1"].Value = $"{row.Cells["s1"].Value} \n{competitor.competitorId}";
                                row.Cells["s1"].Style.BackColor = Color.CornflowerBlue;

                            }

                            if (row.Cells["s2"].Value.Equals(competitor.assignedSeat.ToString()))
                            {
                                row.Cells["s2"].Value = $"{row.Cells["s2"].Value} \n{competitor.competitorId}";
                                row.Cells["s2"].Style.BackColor = Color.CornflowerBlue;
                            }

                        }
                        #endregion  
                    }
                }
            }
            UpdateText();
        }

        private void unassignedCompetitorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get and Update the selected Competitor from unassigned List:
            if (unassignedCompetitorList.SelectedIndex != -1)
            {
                selectedCompetitorFromUListId = unassignedCompetitorList.SelectedItem.ToString().Split(',')[2].Trim();
            }
            UpdateText();

        }

        private void allocatedDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void allocatedDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Get and Update the selected Competitor from seat DGV List:
            selectedCompetitorFromSeat = allocatedDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            UpdateText();
        }

        private void manuallyAssignedBtn_Click(object sender, EventArgs e)
        {
            //Manual Assignment, check if either selected seat or unassigned list is not selected:
            if (selectedCompetitorFromSeat.Equals(string.Empty) || selectedCompetitorFromUListId.Equals(string.Empty))
            {
                MessageBox.Show("Please select from unassigned list and seat menu");
            }
            else
            {
                CheckIfAssigned(selectedCompetitorFromUListId, selectedCompetitorFromSeat);
                UpdateText();
            }
        }

        private bool CheckIfAssigned(string unAssigned, string AssignedSeat)
        {
            //Check if it is ONLY a number (meaning seat is not assigned)
            if (int.TryParse(AssignedSeat, out _))
            {
                //Seat is unassigned. ONLY move the person from UList to Grid

                #region Check constraints:
                if (checkConstraint(allocatedDGV.CurrentCell))
                {
                    #region Assign the person to the DGV:
                    var selectedListCountryCode = unassignedCompetitorList.SelectedItem.ToString().Split(',')[2].Trim();
                    allocatedDGV.CurrentCell.Value = $"{allocatedDGV.CurrentCell.Value}\n{selectedListCountryCode}";
                    unassignedCompetitorList.Items.RemoveAt(unassignedCompetitorList.SelectedIndex);
                    unassignedCompetitorList.SelectedIndex = -1;
                    selectedCompetitorFromUListId = "";
                    allocatedDGV.CurrentCell.Style.BackColor = Color.CornflowerBlue;
                    allocatedDGV.CurrentCell.Selected = false;
                    #endregion
                }
                else MessageBox.Show("The same country participants cannot be above, or below current selected participant");
                #endregion
            }
            else
            {
                if (checkConstraint(allocatedDGV.CurrentCell))
                {
                    #region Check the list and DGV to swap:
                    //Checks both list AND Grid Country to swap them
                    var selectedListCountryCode = unassignedCompetitorList.SelectedItem.ToString().Split(',')[2].Trim();
                    var selectedGridCountryCode = allocatedDGV.CurrentCell.Value.ToString().Split('\n')[1].Trim();
                    var selectedGridNumber = allocatedDGV.CurrentCell.Value.ToString().Split('\n')[0].Trim();

                    //Remove value from List, assign value to DGV:
                    allocatedDGV.CurrentCell.Value = $"{selectedGridNumber}\n{selectedListCountryCode}";

                    
                    unassignedCompetitorList.Items.RemoveAt(unassignedCompetitorList.SelectedIndex);

                    //Adds the DGV object back into list, resets all the global variables for another swap:
                    using (var context = new Session5Entities())
                    {
                        var competitor = context.Competitors.Where(x => x.competitorId.Equals(selectedGridCountryCode)).First();
                        var listQuery = string.Join(", ", competitor.competitorName, competitor.competitorCountry, competitor.competitorId);

                        unassignedCompetitorList.Items.Add(listQuery);
                        unassignedCompetitorList.SelectedIndex = -1;
                        selectedCompetitorFromUListId = "";
                        selectedCompetitorFromSeat = "";
                    }

                    allocatedDGV.CurrentCell.Selected = false;
                    #endregion
                }
                else MessageBox.Show("The same country participants cannot be above, or below current selected participant");
            }
            return false;
        }
        /// <summary>
        /// This method checks if the top cell and bottom cell is part of the same country
        /// It takes in a sample cell, which it uses to compare with the cells above and below it
        /// It also takes in a isList boolean, which allows the method to know if the swap is happening
        /// between cells, or from the Unassigned list
        /// </summary>
        /// <param name="sampleCell"></param>
        /// <param name="isList"></param>
        /// <returns></returns>
        bool checkConstraint(DataGridViewCell sampleCell = null, bool isList = true)
        {
            var currentRowIdx = sampleCell.RowIndex;
            var currentColIdx = sampleCell.ColumnIndex;

            if (sampleCell.RowIndex == 0)
            {
                #region If cell is at the very top, only check below:

                if (allocatedDGV.Rows[currentRowIdx + 1].Cells[currentColIdx].Style.BackColor == Color.CornflowerBlue)
                {
                    //Checks if cell below is of the same country
                    try
                    {
                        var bottomCountry = allocatedDGV.Rows[currentRowIdx + 1].Cells[currentColIdx].Value.ToString().Split('\n')[1].Trim().Substring(0, 2);

                        if (isList)
                        {
                            if (bottomCountry.Equals(selectedCompetitorFromUListId.Substring(0, 2)))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            var currentCellCountry = sampleCell.Value.ToString().Split('\n')[1].Trim().Substring(0, 2);

                            if (bottomCountry.Equals(currentCellCountry))
                            {
                                return false;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                #endregion

            }
            else if (sampleCell.RowIndex == (allocatedDGV.Rows.Count - 1))
            {
                #region If the Cell is at the very bottom, check only the top:
                Console.WriteLine("Check above");
                //Only check above

                if (allocatedDGV.Rows[currentRowIdx - 1].Cells[currentColIdx].Style.BackColor == Color.CornflowerBlue)
                {

                    //Checks if cell above is of the same country
                    var aboveCountry = allocatedDGV.Rows[currentRowIdx - 1].Cells[currentColIdx].Value.ToString().Split('\n')[1].Trim().Substring(0, 2);
                    if (isList)
                    {
                        if (aboveCountry.Equals(selectedCompetitorFromUListId.Substring(0, 2)))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        var currentCellCountry = sampleCell.Value.ToString().Split('\n')[1].Trim().Substring(0, 2);

                        if (aboveCountry.Equals(currentCellCountry))
                        {
                            return false;
                        }
                    }
                }
                #endregion
            }
            else
            {
                //check both above and below:
                #region If the cell is anywhere between, check above and below:

                if (allocatedDGV.Rows[currentRowIdx - 1].Cells[currentColIdx].Style.BackColor == Color.CornflowerBlue)
                {
                    var aboveCountry = allocatedDGV.Rows[currentRowIdx - 1].Cells[currentColIdx].Value.ToString().Split('\n')[1].Trim().Substring(0, 2);
                    //Checks if cell above is of the same country
                    if (isList)
                    {

                        if (aboveCountry.Equals(selectedCompetitorFromUListId.Substring(0, 2)))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        var currentCellCountry = sampleCell.Value.ToString().Split('\n')[1].Trim().Substring(0, 2);

                        if (aboveCountry.Equals(currentCellCountry))
                        {
                            return false;
                        }
                    }

                }

                if (allocatedDGV.Rows[currentRowIdx + 1].Cells[currentColIdx].Style.BackColor == Color.CornflowerBlue)
                {
                    //Checks if cell below is of the same country

                    try
                    {
                        var bottomCountry = allocatedDGV.Rows[currentRowIdx + 1].Cells[currentColIdx].Value.ToString().Split('\n')[1].Trim().Substring(0, 2);
                        //Marks whether check is for a ListEntry or a Swap Entry
                        if (isList)
                        {
                            if (bottomCountry.Equals(selectedCompetitorFromUListId.Substring(0, 2)))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            var currentCellCountry = sampleCell.Value.ToString().Split('\n')[1].Trim().Substring(0, 2);

                            if (bottomCountry.Equals(currentCellCountry))
                            {
                                return false;
                            }
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }

                }

                #endregion
            }
            //If all checks pass, return true.
            return true;
        }

        private void swapSeatsBtn_Click(object sender, EventArgs e)
        {
            if (allocatedDGV.SelectedCells.Count == 2)
            {
                var tempBool = true;
                while (tempBool)
                {
                    DataGridViewCell originalCell = null;
                    DataGridViewCell targetCell = null;

                    //Do a swap, if empty, do not swap:
                    foreach (DataGridViewCell cell in allocatedDGV.SelectedCells)
                    {

                        if (cell.Style.BackColor != Color.CornflowerBlue)
                        {
                            MessageBox.Show("Swap cannot happen with an empty seat");
                            tempBool = false;
                            break;

                        }
                        if (cell.Value.Equals(allocatedDGV.CurrentCell.Value))
                        {
                            //One Cell acts as the "original" cell to be compared.
                            targetCell = cell;
                        }
                        else
                        {
                            originalCell = cell;
                        }
                    }

                    if (!tempBool)
                    {
                        break;
                    }

                    Console.WriteLine($"Original CellCords: {originalCell.RowIndex} , {originalCell.ColumnIndex}");
                    Console.WriteLine($"Target CellCords: {targetCell.RowIndex} , {targetCell.ColumnIndex}");
                    //Store the original Values of both selected cells:
                    var originalValue = originalCell.Value;
                    var targetValue = targetCell.Value;

                    var originalNumber = originalCell.Value.ToString().Split('\n')[0];
                    var targetNumber = targetCell.Value.ToString().Split('\n')[0];

                    var originalCountry = originalCell.Value.ToString().Split('\n')[1];
                    var targetCountry = targetCell.Value.ToString().Split('\n')[1];

                    //Perform a swap first without checking:
                    allocatedDGV.Rows[originalCell.RowIndex].Cells[originalCell.ColumnIndex].Value = $"{originalNumber}\n{targetCountry}";
                    allocatedDGV.Rows[targetCell.RowIndex].Cells[targetCell.ColumnIndex].Value = $"{targetNumber}\n{originalCountry}";

                    //Do a check:

                    foreach (DataGridViewCell cell in allocatedDGV.SelectedCells)
                    {
                        
                        if (checkConstraint(cell, false))
                        {
                            tempBool = false;
                        }
                        else
                        {
                            //if either cell returns a false check constraint, revert the values:
                            MessageBox.Show("Conflict found");

                            allocatedDGV.Rows[originalCell.RowIndex].Cells[originalCell.ColumnIndex].Value = originalValue;
                            allocatedDGV.Rows[targetCell.RowIndex].Cells[targetCell.ColumnIndex].Value = targetValue;

                            tempBool = false;
                            break;

                        }

                    }

                    if (!tempBool)
                    {
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Select 2 boxes");
            }

            UpdateText();
        }

        /// <summary>
        /// Randomly assigned is actually not completely random, it is based on an algorithm.
        /// Steps are shown in the comments below:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void randomlyAssignedBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session5Entities())
            {
                var skillNameFromCb = skillCb.SelectedItem.ToString();

                var skillID = context.Skills.Where(x => x.skillName.Equals(skillNameFromCb)).Select(x => x.skillId).FirstOrDefault();


                var sumOfCompetitorsFromCountry = (from x in context.Competitors
                                                   where x.skillIdFK == skillID
                                                   group x by x.competitorCountry into y
                                                   select new
                                                   {
                                                       y.Key,
                                                       SumOfCompetitorsFromCountry = y.Select(x => x.competitorId).Count()
                                                   }).OrderByDescending(x => x.SumOfCompetitorsFromCountry)
                                                  ;

                var competitorAllocation = from x in context.Competitors
                                           where x.skillIdFK == skillID
                                           select x;

                //Check the country with highest occurance > more than number of rows. 
                //Meaning, it will be impossible to auto-assign

                //First Check: Check number of rows:

                var numberOfSeats = allocatedDGV.Rows.Count;

                //2nd Check: highest occurance Country > Rows
                if (sumOfCompetitorsFromCountry.Select(x => x.SumOfCompetitorsFromCountry).First() > numberOfSeats && !(numberOfSeats == 1))
                {
                    MessageBox.Show("Randomly assigning is impossible. Conflicts will definitely happen.");
                }
                else
                {
                    //1st Step: Queue all the allocations:

                    Queue<string> allocationQueue = new Queue<string>();

                    //2nd Step: For every group of competitors from a country, each country has multiple people in it
                    foreach (var item in sumOfCompetitorsFromCountry)
                    {
                        //Take every competitor from skill area
                        var currentAllocation = from x in competitorAllocation
                                                where x.competitorCountry.Equals(item.Key)
                                                select x;

                        //Add those people into the allocation queue:
                        foreach (var allocation in currentAllocation)
                        {
                            allocationQueue.Enqueue(allocation.competitorId);
                        }
                    }
                    var tempCount = allocatedDGV.Rows.Count;
                    //Behavoir should change depending on Odd rows or even

                    if (allocatedDGV.Rows.Count % 2 == 0)
                    {
                        //3.1 Step, when rows are even, keep taking every alternate part of the queue. Since it is sorted
                        //by the most popular country first, the constraint is never hit.
                        allocatedDGV.Rows.Clear();
                        //Even algo:
                        #region Step 3.1
                        for (int i = 0; i < tempCount; i++)
                        {
                            Console.WriteLine("Iteration:" + i);
                            if (i % 2 == 0)
                            {
                                allocatedDGV.Rows.Add(allocationQueue.Take(2).ToArray());
                                allocationQueue.Dequeue();
                                allocationQueue.Dequeue();

                            }
                            else
                            {
                                allocatedDGV.Rows.Add(allocationQueue.Skip(2).Take(2).ToArray());
                            }
                        }
                        #endregion
                    }
                    else if (allocatedDGV.Rows.Count == 1)
                    {
                        //3.2 Step: In the odd edge case that only 2 seats are given, just take whatever is in the queue
                        //since the constraint is never hit
                        allocatedDGV.Rows.Clear();
                        allocatedDGV.Rows.Add(allocationQueue.Take(2).ToArray());
                        allocationQueue.Dequeue();
                        allocationQueue.Dequeue();
                    }
                    else
                    {
                        //Odd Algo:
                        allocatedDGV.Rows.Clear();

                        //3.3 Step, when rows are old, keep taking every alternate part of the queue. Since it is sorted
                        //by the most popular country first, the constraint is never hit.
                        //However, for the last 3 iterations, only take 2 then take 1, so that the rows are balanced.
                        #region Step 3.3:
                        for (int i = 0; i < (tempCount - 1); i++)
                        {
                            if (i % 2 == 0)
                            {
                                allocatedDGV.Rows.Add(allocationQueue.Take(2).ToArray());
                                allocationQueue.Dequeue();
                                allocationQueue.Dequeue();
                            }
                            else
                            {
                                if (allocationQueue.Count <= 3)
                                {
                                    allocatedDGV.Rows.Add(allocationQueue.Skip(1).Take(2).ToArray());
                                    allocatedDGV.Rows.Add(allocationQueue.Take(1).ToArray());
                                }
                                else
                                {
                                    allocatedDGV.Rows.Add(allocationQueue.Skip(2).Take(2).ToArray());
                                }
                            }
                        }
                        #endregion
                    }
                }
            }
            //Step 4: Clear the Unassigned Competitor List:
            unassignedCompetitorList.Items.Clear();
            //Step 5: Re-Assign numbers back to the DGV and colour the cells
            #region Step 5
            int iterationCount = 1;
            foreach (DataGridViewRow row in allocatedDGV.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    try
                    {
                        if (!cell.Value.Equals(string.Empty))
                        {
                            cell.Value = $"{iterationCount}\n{cell.Value}";
                            iterationCount++;
                            cell.Style.BackColor = Color.CornflowerBlue;
                        }
                    }
                    catch (Exception)
                    {


                    }
                }
            }
            #endregion
            UpdateText();
        }

        void UpdateText()
        {
            //Updates the Total number of unassigned and assigned members:
            int total = 0;
            using (var context = new Session5Entities())
            {
                #region Queries to get count of number of competitors
                var skillNameFromCb = skillCb.SelectedItem.ToString();

                var skillID = context.Skills.Where(x => x.skillName.Equals(skillNameFromCb)).Select(x => x.skillId).FirstOrDefault();

                var competitorAllocation = from x in context.Competitors
                                           where x.skillIdFK == skillID
                                           select x;

                total = competitorAllocation.Count();
                #endregion

                #region Counts number of allocated based on if the cell is Blue
                int allocated = 0;
                foreach (DataGridViewRow row in allocatedDGV.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Style.BackColor == Color.CornflowerBlue)
                        {
                            allocated++;
                            var countryIdFromCell = cell.Value.ToString().Split('\n')[1];

                            var toolTipInfo = context.Competitors.Where(x => x.competitorId.Equals(countryIdFromCell)).FirstOrDefault();

                            cell.ToolTipText = $"{toolTipInfo.competitorName}, {toolTipInfo.competitorCountry}";
                        }
                    }
                }
                #endregion
                assignedCompLbl.Text = $"Allocated: {allocated}";
                unassignedCompLbl.Text = $"Unallocated: {total - allocated}";
            }

        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session5Entities())
            {
                #region Goes through all the cells to get info to update
                foreach (DataGridViewRow row in allocatedDGV.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Style.BackColor == Color.CornflowerBlue)
                        {
                            var seatNumber = cell.Value.ToString().Split('\n')[0].Trim();
                            var competitorID = cell.Value.ToString().Split('\n')[1].Trim();


                            var updateCompetitor = context.Competitors.Where(x => x.competitorId.Equals(competitorID)).First();

                            updateCompetitor.assignedSeat = Convert.ToInt32(seatNumber);
                        }
                    }
                }
                #endregion

                #region Save To Database:
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Changes Saved. c:");
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error saving. Details:\n" + ex.Message);
                }
                #endregion
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

