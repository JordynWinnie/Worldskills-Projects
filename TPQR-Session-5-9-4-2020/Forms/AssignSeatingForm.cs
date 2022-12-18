using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TPQR_Session5_9_4_2020
{
    public partial class AssignSeatingForm : Form
    {
        private int _colIdx = -1;
        private int _rowIdx = -1;
        private Session5Entities context = new Session5Entities();

        public AssignSeatingForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AssignSeatingForm_Load(object sender, EventArgs e)
        {
            skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());
            skillCb.SelectedIndex = 0;
        }

        private void skillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSeatingLayout();
        }

        private void RefreshSeatingLayout()
        {
            unassignedListBox.Items.Clear();
            seatingDGV.Rows.Clear();
            seatingDGV.Columns.Clear();
            var skillSelected = skillCb.SelectedItem.ToString();

            var arrangement = context.Competitors.Where(x => x.Skill.skillName == skillSelected);

            unassignedLbl.Text = $"Unassigned Seats: {arrangement.Where(x => x.assignedSeat == 0).Count()}";
            assignedLbl.Text = $"Assigned Seats: {arrangement.Where(x => x.assignedSeat != 0).Count()}";

            foreach (var user in arrangement.Where(x => x.assignedSeat == 0))
            {
                unassignedListBox.Items.Add($"{user.competitorName}, {user.competitorCountry} -- {user.recordsId}");
            }

            var numberOfSeats = arrangement.Count();

            seatingDGV.Columns.Add("1", "1");
            seatingDGV.Columns.Add("2", "2");

            //Generate Seats
            var currVal = 0;

            for (int i = 0; i < numberOfSeats / 2; i++)
            {
                var firstColSeatNo = currVal + 1;
                var secondColSeatNo = currVal + 2;
                var firstColUser = arrangement.Where(x => x.assignedSeat == firstColSeatNo);
                var secondColUser = arrangement.Where(x => x.assignedSeat == secondColSeatNo);
                string[] row = new string[2];
                if (firstColUser.Any())
                {
                    row[0] = $"{firstColSeatNo}\n{firstColUser.First().competitorId}";
                }
                else
                {
                    row[0] = firstColSeatNo.ToString();
                }

                if (secondColUser.Any())
                {
                    row[1] = $"{secondColSeatNo}\n{secondColUser.First().competitorId}";
                }
                else
                {
                    row[1] = secondColSeatNo.ToString();
                }

                currVal += 2;
                seatingDGV.Rows.Add(row);

                if (i + 1 == numberOfSeats / 2 && numberOfSeats % 2 != 0)
                {
                    var oldColUser = arrangement.Where(x => x.assignedSeat == secondColSeatNo + 1);
                    string[] oddNumberRow = new string[2];
                    if (oldColUser.Any())
                    {
                        oddNumberRow[0] = $"{secondColSeatNo + 1}\n{oldColUser.First().competitorId}";
                    }
                    else
                    {
                        oddNumberRow[0] = (secondColSeatNo + 1).ToString();
                    }
                    seatingDGV.Rows.Add(oddNumberRow);
                }
            }

            UpdateShadowTable();
            ColourTable();
            RefreshToolTips();
        }

        private void UpdateShadowTable()
        {
            shadowTable.Rows.Clear();
            shadowTable.Columns.Clear();
            shadowTable.Columns.Add("1", "1");
            shadowTable.Columns.Add("2", "2");
            var skillSelected = skillCb.SelectedItem.ToString();

            var arrangement = context.Competitors.Where(x => x.Skill.skillName == skillSelected);
            var numberOfSeats = arrangement.Count();
            var currVal = 0;
            for (int i = 0; i < numberOfSeats / 2; i++)
            {
                var firstColSeatNo = currVal + 1;
                var secondColSeatNo = currVal + 2;

                string[] row = new string[2];

                row[0] = firstColSeatNo.ToString();
                row[1] = secondColSeatNo.ToString();

                currVal += 2;
                shadowTable.Rows.Add(row);

                if (i + 1 == numberOfSeats / 2 && numberOfSeats % 2 != 0)
                {
                    string[] oddNumberRow = new string[2];

                    oddNumberRow[0] = (secondColSeatNo + 1).ToString();

                    shadowTable.Rows.Add(oddNumberRow);
                }
            }
        }

        private void ColourTable()
        {
            foreach (DataGridViewColumn column in seatingDGV.Columns)
            {
                foreach (DataGridViewRow row in seatingDGV.Rows)
                {
                    if (seatingDGV[column.Index, row.Index].Value != null)
                    {
                        if (!int.TryParse(seatingDGV[column.Index, row.Index].Value.ToString(), out _))
                        {
                            seatingDGV[column.Index, row.Index].Style.BackColor = Color.BlueViolet;
                        }
                    }
                }
            }
        }

        private void seatingDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _colIdx = e.ColumnIndex;
            _rowIdx = e.RowIndex;
        }

        private void randomAssign_Click(object sender, EventArgs e)
        {
            seatingDGV.Rows.Clear();
            seatingDGV.Columns.Clear();
            seatingDGV.Columns.Add("1", "1");
            seatingDGV.Columns.Add("2", "2");
            unassignedListBox.Items.Clear();
            var skillSelected = skillCb.SelectedItem.ToString();

            var arrangement = context.Competitors.Where(x => x.Skill.skillName == skillSelected);
            unassignedLbl.Text = $"Unassigned Seats: 0";
            assignedLbl.Text = $"Assigned Seats: {arrangement.Count()}";

            var numberOfSeats = arrangement.Count();

            var highestCountryCheck = from x in arrangement
                                      group x by x.competitorCountry into y
                                      orderby y.Count() descending
                                      select y;

            var highestCountry = highestCountryCheck.First().Count();

            if (numberOfSeats + 1 / 2 < highestCountry)
            {
                MessageBox.Show("Unable to assign seats in current constraint");
                return;
            }

            var numberOfRows = numberOfSeats % 2 != 0 ? numberOfSeats / 2 + 1 : numberOfSeats / 2;

            var currVal = 0;

            for (int i = 0; i < numberOfSeats / 2; i++)
            {
                var firstColSeatNo = currVal + 1;
                var secondColSeatNo = currVal + 2;

                string[] row = new string[2];

                row[0] = firstColSeatNo.ToString();
                row[1] = secondColSeatNo.ToString();

                currVal += 2;
                seatingDGV.Rows.Add(row);

                if (i + 1 == numberOfSeats / 2 && numberOfSeats % 2 != 0)
                {
                    string[] oddNumberRow = new string[2];

                    oddNumberRow[0] = (secondColSeatNo + 1).ToString();

                    seatingDGV.Rows.Add(oddNumberRow);
                }
            }
            if (numberOfSeats % 2 == 0)
            {
                //If even number of seats:
                if (numberOfSeats / 2 % 2 == 0)
                {
                    var colIdx = 0;
                    var rowIdx = 0;

                    foreach (var country in highestCountryCheck)
                    {
                        if (rowIdx > numberOfRows)
                        {
                            rowIdx = 0;
                        }
                        foreach (var competitor in country)
                        {
                            seatingDGV[colIdx, rowIdx].Value += "\n" + competitor.competitorId;

                            colIdx = colIdx == 1 ? 0 : 1;

                            if (rowIdx + 1 == numberOfRows)
                            {
                                colIdx = colIdx == 1 ? 0 : 1;
                                rowIdx = 0;
                            }
                            else
                            {
                                rowIdx++;
                            }
                        }
                    }
                }
                else
                {
                    //if number of even rows is odd, assign diagonally, but from 1:

                    var colIdx = 1;
                    var rowIdx = 0;

                    foreach (var country in highestCountryCheck)
                    {
                        if (rowIdx > numberOfRows)
                        {
                            rowIdx = 0;
                        }
                        foreach (var competitor in country)
                        {
                            seatingDGV[colIdx, rowIdx].Value += "\n" + competitor.competitorId;

                            colIdx = colIdx == 1 ? 0 : 1;

                            if (rowIdx + 1 == numberOfRows)
                            {
                                rowIdx = 0;
                            }
                            else
                            {
                                rowIdx++;
                            }
                        }
                    }
                }
            }
            else
            {
                //If odd number of seats, assign with additional condition:
                if (numberOfSeats / 2 % 2 == 0)
                {
                    //if number of even rows is even, assign diagonally, but from 1:

                    var colIdx = 0;
                    var rowIdx = 0;

                    foreach (var country in highestCountryCheck)
                    {
                        if (rowIdx > numberOfRows)
                        {
                            rowIdx = 0;
                        }
                        foreach (var competitor in country)
                        {
                            seatingDGV[colIdx, rowIdx].Value += "\n" + competitor.competitorId;

                            colIdx = colIdx == 1 ? 0 : 1;

                            if (rowIdx + 2 > numberOfRows)
                            {
                                rowIdx = 0;
                            }
                            else
                            {
                                rowIdx++;
                            }
                        }
                    }
                }
                else
                {
                    //if number of even rows is odd, assign diagonally, but from 1:

                    var colIdx = 1;
                    var rowIdx = 0;

                    foreach (var country in highestCountryCheck)
                    {
                        if (rowIdx > numberOfRows)
                        {
                            rowIdx = 0;
                        }
                        foreach (var competitor in country)
                        {
                            seatingDGV[colIdx, rowIdx].Value += "\n" + competitor.competitorId;

                            colIdx = colIdx == 1 ? 0 : 1;

                            if (rowIdx + 2 > numberOfRows)
                            {
                                colIdx = colIdx == 1 ? 0 : 1;
                                rowIdx = 0;
                            }
                            else
                            {
                                rowIdx++;
                            }
                        }
                    }
                }
            }
            RefreshToolTips();
        }

        private void manualAssignBtn_Click(object sender, EventArgs e)
        {
            if (unassignedListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select someone from the unassigned list");
                return;
            }

            if (_colIdx == -1)
            {
                MessageBox.Show("Select someone on the table");
                return;
            }

            //CheckCompetitor:
            var selectedSkill = skillCb.SelectedItem.ToString();
            var selectedCompetitor = unassignedListBox.SelectedItem.ToString();
            var competitor = (from x in context.Competitors
                              where selectedCompetitor.Contains(x.recordsId.ToString()) && selectedCompetitor.Contains(x.competitorName)
                              && selectedCompetitor.Contains(x.competitorCountry)
                              select x).First();

            if (CheckConstraints(_colIdx, _rowIdx, competitor.competitorId))
            {
                if (!int.TryParse(seatingDGV[_colIdx, _rowIdx].Value.ToString(), out _))
                {
                    var currentCellCompetitor = seatingDGV[_colIdx, _rowIdx].Value.ToString();
                    var currentCompetitor = (from x in context.Competitors
                                             where currentCellCompetitor.Contains(x.competitorId) && x.Skill.skillName == selectedSkill
                                             select x).First();
                    seatingDGV[_colIdx, _rowIdx].Style.BackColor = Color.White;
                    unassignedListBox.Items.Add($"{currentCompetitor.competitorName}, {currentCompetitor.competitorCountry} -- {currentCompetitor.recordsId}");
                }
                seatingDGV[_colIdx, _rowIdx].Value = $"{shadowTable[_colIdx, _rowIdx].Value}\n{competitor.competitorId}";
                unassignedListBox.Items.RemoveAt(unassignedListBox.SelectedIndex);
            }

            RefreshToolTips();
        }

        private bool CheckConstraints(int colIdx, int rowIdx, string competitorId)
        {
            RefreshToolTips();
            var currentCompetitor = context.Competitors.Where(x => x.competitorId == competitorId).First();
            if (rowIdx - 1 >= 0)
            {
                //Top person exists:
                var topCompetitorId = seatingDGV[colIdx, rowIdx - 1].Value.ToString().Substring(1).Trim();

                if (topCompetitorId.Length > 1)
                {
                    if (context.Competitors.Where(x => x.competitorId == topCompetitorId).First().competitorCountry == currentCompetitor.competitorCountry)
                    {
                        MessageBox.Show("Unable to perform assignment, constaints not met");
                        return false;
                    }
                }
            }

            if (rowIdx + 1 < seatingDGV.Rows.Count)
            {
                //Bottom person exists:
                var bottomCompetitorId = seatingDGV[colIdx, rowIdx + 1].Value.ToString().Substring(1).Trim();

                if (bottomCompetitorId.Length > 1)
                {
                    if (context.Competitors.Where(x => x.competitorId == bottomCompetitorId).First().competitorCountry == currentCompetitor.competitorCountry)
                    {
                        MessageBox.Show("Unable to perform assignment, constaints not met");
                        return false;
                    }
                }
            }

            return true;
        }

        private void swapSeatBtn_Click(object sender, EventArgs e)
        {
            if (seatingDGV.SelectedCells.Count != 2)
            {
                MessageBox.Show("Please select 2 cells for swapping");
                return;
            }
            var firstSelectedCell = seatingDGV.SelectedCells[0];
            var secondSelectedCell = seatingDGV.SelectedCells[1];

            var selectedSkill = skillCb.SelectedItem.ToString();
            var currentFirstCellCompetitor = firstSelectedCell.Value.ToString();
            var currentSecondCell = secondSelectedCell.Value.ToString();

            var currentFirst = new Competitor();
            var currentSecond = new Competitor();
            if (!int.TryParse(currentFirstCellCompetitor, out _))
            {
                currentFirst = (from x in context.Competitors
                                where currentFirstCellCompetitor.Contains(x.competitorId) && x.Skill.skillName == selectedSkill
                                select x).First();
                if (!CheckConstraints(secondSelectedCell.ColumnIndex, secondSelectedCell.RowIndex, currentFirst.competitorId))
                {
                    return;
                }
            }

            if (!int.TryParse(currentSecondCell, out _))
            {
                currentSecond = (from x in context.Competitors
                                 where currentSecondCell.Contains(x.competitorId) && x.Skill.skillName == selectedSkill
                                 select x).First();
                if (!CheckConstraints(firstSelectedCell.ColumnIndex, firstSelectedCell.RowIndex, currentSecond.competitorId))
                {
                    return;
                }
            }

            seatingDGV.SelectedCells[0].Value = shadowTable[firstSelectedCell.ColumnIndex, firstSelectedCell.RowIndex].Value + "\n" + currentSecond.competitorId;
            seatingDGV.SelectedCells[1].Value = shadowTable[secondSelectedCell.ColumnIndex, secondSelectedCell.RowIndex].Value + "\n" + currentFirst.competitorId;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in seatingDGV.Columns)
            {
                foreach (DataGridViewRow row in seatingDGV.Rows)
                {
                    var selectedSkill = skillCb.SelectedItem.ToString();
                    var selectedCell = seatingDGV[column.Index, row.Index].Value;
                    if (selectedCell != null)
                    {
                        var competitorToModify = (from x in context.Competitors
                                                  where selectedCell.ToString().Contains(x.competitorId) && x.Skill.skillName == selectedSkill
                                                  select x).FirstOrDefault();

                        if (competitorToModify != null)
                        {
                            competitorToModify.assignedSeat = int.Parse(shadowTable[column.Index, row.Index].Value.ToString());
                        }
                    }
                }
            }

            context.SaveChanges();
            MessageBox.Show("Changes saved");
            RefreshSeatingLayout();
            RefreshToolTips();
        }

        private void RefreshToolTips()
        {
            foreach (DataGridViewColumn column in seatingDGV.Columns)
            {
                foreach (DataGridViewRow row in seatingDGV.Rows)
                {
                    var currentCell = seatingDGV[column.Index, row.Index];
                    var selectedSkill = skillCb.SelectedItem.ToString();
                    if (currentCell.Value != null)
                    {
                        if (!int.TryParse(currentCell.Value.ToString(), out _))
                        {
                            var currentUser = (from x in context.Competitors
                                               where currentCell.Value.ToString().Contains(x.competitorId) && x.Skill.skillName == selectedSkill
                                               select x).First();

                            currentCell.ToolTipText = $"{currentUser.competitorName}, {currentUser.competitorCountry}";
                        }
                    }
                }
            }
        }
    }
}