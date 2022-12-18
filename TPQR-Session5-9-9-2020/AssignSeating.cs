using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TPQR_Session5_9_9_2020
{
    public partial class AssignSeating : Form
    {
        private Session5Entities context = new Session5Entities();

        public AssignSeating()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AssignSeating_Load(object sender, EventArgs e)
        {
            var columns = new List<string> { "1", "2" };
            foreach (var column in columns)
            {
                assignedDGV.Columns.Add(column, column);
                shadowTable.Columns.Add(column, column);
            }
            skilCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
            skilCb.SelectedIndex = 0;

            UpdateTable();
        }

        private void UpdateTable()
        {
            unassignedListBox.Items.Clear();
            assignedDGV.Rows.Clear();
            shadowTable.Rows.Clear();
            var selectedSkill = skilCb.SelectedItem.ToString();

            var competitors = from x in context.Competitors
                              where x.Skill.skillName == selectedSkill
                              select x;
            assignedCompLbl.Text = $"Assigned Competitors: {competitors.Where(x => x.assignedSeat != 0).Count()}";
            unassignedLbl.Text = $"Unassigned Comptitors: {competitors.Where(x => x.assignedSeat == 0).Count()}";

            foreach (var unassigned in competitors.Where(x => x.assignedSeat == 0))
            {
                unassignedListBox.Items.Add($"{unassigned.competitorName}, {unassigned.competitorCountry}");
            }

            var row = new string[2];
            for (int i = 1; i < competitors.Count() + 1; i++)
            {
                if (i % 2 != 0)
                {
                    row[0] = i.ToString();
                    row[1] = (i + 1).ToString();

                    shadowTable.Rows.Add(row);
                    if (competitors.Where(x => x.assignedSeat == i).Any())
                    {
                        var comp = competitors.Where(x => x.assignedSeat == i).First();
                        row[0] = $"{i} {comp.competitorId}";
                    }
                    else
                    {
                        row[0] = i.ToString();
                    }

                    if (i + 1 > competitors.Count())
                    {
                        row[1] = "";
                    }
                    else
                    {
                        if (competitors.Where(x => x.assignedSeat == i + 1).Any())
                        {
                            var comp = competitors.Where(x => x.assignedSeat == i + 1).First();
                            row[1] = $"{i + 1} {comp.competitorId}";
                        }
                        else
                        {
                            row[1] = (i + 1).ToString();
                        }
                    }

                    assignedDGV.Rows.Add(row);
                }
            }

            ColourTable();
        }

        private void ColourTable()
        {
            foreach (DataGridViewRow row1 in assignedDGV.Rows)
            {
                foreach (DataGridViewColumn column in assignedDGV.Columns)
                {
                    if (assignedDGV[column.Index, row1.Index].Value.ToString().Equals(string.Empty))
                    {
                        continue;
                    }
                    if (!int.TryParse(assignedDGV[column.Index, row1.Index].Value.ToString(), out _))
                    {
                        assignedDGV[column.Index, row1.Index].Style.BackColor = Color.AliceBlue;
                    }
                }
            }
        }

        private void skilCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void manualAssignmentBtn_Click(object sender, EventArgs e)
        {
            if (unassignedListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select an unassigned person");
                return;
            }

            if (assignedDGV.SelectedCells.Count != 1)
            {
                MessageBox.Show("Select only one seat");
                return;
            }

            var selectedUnassigned = unassignedListBox.SelectedItem.ToString();
            var selectedSeat = assignedDGV.SelectedCells[0];
            if (selectedSeat.Value.ToString().Equals(string.Empty))
            {
                MessageBox.Show("Invalid Seat Selected");
                return;
            }
            var unassignedPersonCountry = (from x in context.Competitors
                                           where selectedUnassigned.Contains(x.competitorCountry) && selectedUnassigned.Contains(x.competitorName)
                                           select x).First();
            if (!CheckConst(selectedSeat, unassignedPersonCountry.competitorCountry, true))
            {
                return;
            }

            if (int.TryParse(selectedSeat.Value.ToString(), out _))
            {
                assignedDGV[selectedSeat.ColumnIndex, selectedSeat.RowIndex].Value = $"{shadowTable[selectedSeat.ColumnIndex, selectedSeat.RowIndex].Value} " +
                $"{unassignedPersonCountry.competitorId}";
            }
            else
            {
                var selectedSeatInfo = selectedSeat.Value.ToString();
                var competitor = (from x in context.Competitors
                                  where selectedSeatInfo.Contains(x.competitorId)
                                  select x).First();

                assignedDGV[selectedSeat.ColumnIndex, selectedSeat.RowIndex].Value = $"{shadowTable[selectedSeat.ColumnIndex, selectedSeat.RowIndex].Value} " +
                $"{unassignedPersonCountry.competitorId}";

                unassignedListBox.Items.Add($"{competitor.competitorName}, {competitor.competitorCountry}");
            }

            unassignedListBox.Items.RemoveAt(unassignedListBox.SelectedIndex);
            ColourTable();
        }

        private bool CheckConst(DataGridViewCell cell, string currentCountry, bool messageShow)
        {
            if (cell.RowIndex - 1 >= 0)
            {
                Console.WriteLine("Above Exists");
                var cellOfPersonAbove = assignedDGV[cell.ColumnIndex, cell.RowIndex - 1].Value.ToString();

                var personAboveCountry = (from x in context.Competitors
                                          where cellOfPersonAbove.Contains(x.competitorId)
                                          select x.competitorCountry).FirstOrDefault();

                if (personAboveCountry == currentCountry)
                {
                    if (messageShow)
                    {
                        MessageBox.Show("Cannot assign, does not meet constraints");
                    }

                    return false;
                }
            }

            if (cell.RowIndex + 1 < assignedDGV.Rows.Count)
            {
                Console.WriteLine("Below Exists");
                var cellOfPersonBelow = assignedDGV[cell.ColumnIndex, cell.RowIndex + 1].Value.ToString();

                var personBelowCountry = (from x in context.Competitors
                                          where cellOfPersonBelow.Contains(x.competitorId)
                                          select x.competitorCountry).FirstOrDefault();

                if (personBelowCountry == currentCountry)
                {
                    if (messageShow)
                    {
                        MessageBox.Show("Cannot assign, does not meet constraints");
                    }
                    return false;
                }
            }

            return true;
        }

        private void swapSeatsBtn_Click(object sender, EventArgs e)
        {
            if (assignedDGV.SelectedCells.Count != 2)
            {
                MessageBox.Show("Select 2 seats");
                return;
            }
            var firstCell = assignedDGV.SelectedCells[0];
            var secondCell = assignedDGV.SelectedCells[1];
            if (int.TryParse(firstCell.Value.ToString(), out _) || int.TryParse(secondCell.Value.ToString(), out _))
            {
                MessageBox.Show("Only select occupied seats");
                return;
            }
            if (firstCell.Value.ToString().Equals(string.Empty) || secondCell.Value.ToString().Equals(string.Empty))
            {
                MessageBox.Show("Invalid Seat Selected");
                return;
            }

            var firstCellCountry = (from x in context.Competitors
                                    where firstCell.Value.ToString().Contains(x.competitorId)
                                    select x).First();

            var secondCellCountry = (from x in context.Competitors
                                     where secondCell.Value.ToString().Contains(x.competitorId)
                                     select x).First();
            Console.WriteLine(firstCellCountry);
            Console.WriteLine(secondCellCountry);
            if (CheckConst(firstCell, secondCellCountry.competitorCountry, true) && CheckConst(secondCell, firstCellCountry.competitorCountry, true))
            {
                assignedDGV[firstCell.ColumnIndex, firstCell.RowIndex].Value =
                    $"{shadowTable[firstCell.ColumnIndex, firstCell.RowIndex].Value} {secondCellCountry.competitorId}";

                assignedDGV[secondCell.ColumnIndex, secondCell.RowIndex].Value =
                   $"{shadowTable[secondCell.ColumnIndex, secondCell.RowIndex].Value} {firstCellCountry.competitorId}";
            }

            ColourTable();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            var selectedSkill = skilCb.SelectedItem.ToString();
            foreach (DataGridViewColumn column in assignedDGV.Columns)
            {
                foreach (DataGridViewRow row in assignedDGV.Rows)
                {
                    var cell = assignedDGV[column.Index, row.Index].Value.ToString();
                    var competitor = (from x in context.Competitors
                                      where cell.Contains(x.competitorId) && x.Skill.skillName == selectedSkill
                                      select x).FirstOrDefault();
                    if (competitor != null)
                    {
                        competitor.assignedSeat = int.Parse(shadowTable[column.Index, row.Index].Value.ToString());
                    }
                }
            }
            context.SaveChanges();
            MessageBox.Show("Changes Saved");
            ColourTable();
        }

        private void randomAssignBtn_Click(object sender, EventArgs e)
        {
            ShuffleSeats();
        }

        private void ShuffleSeats()
        {
            assignedDGV.Rows.Clear();
            var selectedSkill = skilCb.SelectedItem.ToString();
            var competitors = from x in context.Competitors
                              where x.Skill.skillName == selectedSkill
                              select x;
            var row = new string[2];
            for (int i = 1; i < competitors.Count() + 1; i++)
            {
                if (i % 2 != 0)
                {
                    row[0] = i.ToString();
                    if (i + 1 > competitors.Count())
                    {
                        row[1] = "";
                    }
                    else
                    {
                        row[1] = (i + 1).ToString();
                    }

                    assignedDGV.Rows.Add(row);
                }
            }

            var checkForImpossibleArrangement = (from x in context.Competitors
                                                 where x.Skill.skillName == selectedSkill
                                                 group x by x.competitorCountry into y
                                                 orderby y.Count() descending
                                                 select y);

            var listOfUnassigned = competitors.ToList();
            if (checkForImpossibleArrangement.First().Count() > assignedDGV.Rows.Count)
            {
                MessageBox.Show("Impossible to randomly assign");
                return;
            }

            var shuffled = listOfUnassigned.OrderBy(x => Guid.NewGuid()).ToList();

            foreach (DataGridViewRow row1 in assignedDGV.Rows)
            {
                foreach (DataGridViewColumn column in assignedDGV.Columns)
                {
                    if (shuffled.Count() == 0)
                    {
                        return;
                    }
                    var cell = assignedDGV[column.Index, row1.Index];

                    if (!CheckConst(cell, shuffled[0].competitorCountry, false))
                    {
                        ShuffleSeats();
                        return;
                    }
                    assignedDGV[column.Index, row1.Index].Value = $"{shadowTable[cell.ColumnIndex, cell.RowIndex].Value} {shuffled[0].competitorId}";
                    shuffled.RemoveAt(0);
                }
            }

            ColourTable();
        }
    }
}