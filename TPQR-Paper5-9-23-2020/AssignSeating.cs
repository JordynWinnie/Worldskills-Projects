using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Paper5_9_23_2020
{
    public partial class AssignSeating : Form
    {
        private Session5Entities context = new Session5Entities();

        public AssignSeating()
        {
            InitializeComponent();
        }

        private void AssignSeating_Load(object sender, EventArgs e)
        {
            skillCb.Items.AddRange(context.Skills.Select(x => x.skillName).ToArray());

            seatAssignmentDGV.Columns.Add("1", "1");
            seatAssignmentDGV.Columns.Add("2", "2");

            shadowDGV.Columns.Add("1", "1");
            shadowDGV.Columns.Add("2", "2");

            skillCb.SelectedIndexChanged += SkillCb_SelectedIndexChanged;
            skillCb.SelectedIndex = 0;
        }

        private void SkillCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSeating();
        }

        private void RefreshSeating()
        {
            var selectedSkill = skillCb.SelectedItem.ToString();
            using (var context = new Session5Entities())
            {
                seatAssignmentDGV.Rows.Clear();
                unassignedList.Items.Clear();
                shadowDGV.Rows.Clear();
                var competitors = context.Competitors.Where(x => x.Skill.skillName == selectedSkill).ToList();
                var unassignedCompetitors = competitors.Where(x => x.assignedSeat == 0);
                var assignedCompetitors = competitors.Where(x => x.assignedSeat != 0);

                assignedLbl.Text = $"Assigned Competitors: {assignedCompetitors.Count()}";
                unassignedLbl.Text = $"Unassigned Competitors: {unassignedCompetitors.Count()}";

                foreach (var competitor in unassignedCompetitors)
                {
                    unassignedList.Items.Add($"{competitor.competitorName}, {competitor.competitorCountry}");
                }

                if (competitors.Count % 2 == 0)
                {
                    int count = 0;
                    for (int i = 0; i < competitors.Count / 2; i++)
                    {
                        string[] row = { $"{count + 1} ", $"{count + 2} " };
                        shadowDGV.Rows.Add(row);
                        var competitor1 = assignedCompetitors.Where(x => x.competitorId == competitors[count].competitorId);
                        var competitor2 = assignedCompetitors.Where(x => x.competitorId == competitors[count + 1].competitorId);

                        if (competitor1.Any())
                        {
                            row[0] += competitor1.First().competitorId;
                        }

                        if (competitor2.Any())
                        {
                            row[1] += competitor2.First().competitorId;
                        }

                        count += 2;
                        seatAssignmentDGV.Rows.Add(row);
                    }
                }
                else
                {
                    int count = 0;
                    for (int i = 0; i < competitors.Count / 2 + 1; i++)
                    {
                        string[] row = { $"{count + 1} ", $"{count + 2} " };
                        shadowDGV.Rows.Add(row);
                        var competitor1 = assignedCompetitors.Where(x => x.competitorId == competitors[count].competitorId);

                        if (count + 1 != competitors.Count)
                        {
                            var competitor2 = assignedCompetitors.Where(x => x.competitorId == competitors[count + 1].competitorId);
                            if (competitor2.Any())
                            {
                                row[1] += competitor2.First().competitorId;
                            }
                        }
                        else
                        {
                            row[1] = string.Empty;
                        }

                        if (competitor1.Any())
                        {
                            row[0] += competitor1.First().competitorId;
                        }

                        count += 2;
                        seatAssignmentDGV.Rows.Add(row);
                    }
                }

                foreach (DataGridViewColumn column in seatAssignmentDGV.Columns)
                {
                    foreach (DataGridViewRow row in seatAssignmentDGV.Rows)
                    {
                        if (!int.TryParse(seatAssignmentDGV[column.Index, row.Index].Value.ToString(), out _))
                        {
                            seatAssignmentDGV[column.Index, row.Index].Style.BackColor = Color.Blue;
                            seatAssignmentDGV[column.Index, row.Index].Style.ForeColor = Color.White;
                        }
                    }
                }
            }
        }

        private bool CheckCell(DataGridViewCell currentCell, string countryName)
        {
            var topCellExists = currentCell.RowIndex - 1 >= 0;
            var bottomCellExists = currentCell.RowIndex + 1 < seatAssignmentDGV.Rows.Count;

            using (var context = new Session5Entities())
            {
                if (topCellExists)
                {
                    var topCellValue = seatAssignmentDGV[currentCell.ColumnIndex, currentCell.RowIndex - 1].Value.ToString();

                    var topCountry = context.Competitors.Where(x => topCellValue.Contains(x.competitorId));

                    if (topCountry.Any() && topCountry.FirstOrDefault().competitorCountry == countryName)
                    {
                        return false;
                    }
                }

                if (bottomCellExists)
                {
                    var bottomCellValue = seatAssignmentDGV[currentCell.ColumnIndex, currentCell.RowIndex + 1].Value.ToString();
                    var bottomCountry = context.Competitors.Where(x => bottomCellValue.Contains(x.competitorId));

                    if (bottomCountry.Any() && bottomCountry.FirstOrDefault().competitorCountry == countryName)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void manualAssign_Click(object sender, EventArgs e)
        {
            if (seatAssignmentDGV.SelectedCells.Count != 1)
            {
                MessageBox.Show("Please select a cell");
                return;
            }

            if (unassignedList.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a competitor");
                return;
            }

            using (var context = new Session5Entities())
            {
                var selectedCompetitor = unassignedList.SelectedItem.ToString();
                var unassignedCompetitorCountry = context.Competitors.Where(x => selectedCompetitor.Contains(x.competitorName) && selectedCompetitor.Contains(x.competitorCountry));
                var currentCell = seatAssignmentDGV.CurrentCell;
                if (CheckCell(seatAssignmentDGV.CurrentCell, unassignedCompetitorCountry.First().competitorCountry))
                {
                    if (int.TryParse(currentCell.Value.ToString(), out _))
                    {
                        //Empty cell:
                        seatAssignmentDGV.CurrentCell.Value = $"{shadowDGV[currentCell.ColumnIndex, currentCell.RowIndex].Value} {unassignedCompetitorCountry.First().competitorId}";
                        unassignedList.Items.RemoveAt(unassignedList.SelectedIndex);
                    }
                    else
                    {
                        var assignedCountry = context.Competitors.Where(x => currentCell.Value.ToString().Contains(x.competitorId)).First();
                        //Non-Empty Cell:
                        seatAssignmentDGV.CurrentCell.Value = $"{shadowDGV[currentCell.ColumnIndex, currentCell.RowIndex].Value} {unassignedCompetitorCountry.First().competitorId}";
                        unassignedList.Items.Add($"{assignedCountry.competitorName}, {assignedCountry.competitorCountry}");
                        unassignedList.Items.RemoveAt(unassignedList.SelectedIndex);
                    }
                }
                else
                {
                    MessageBox.Show("Does not fufil constaints");
                    return;
                }
            }
        }

        private void swapSeatBtn_Click(object sender, EventArgs e)
        {
            if (seatAssignmentDGV.SelectedCells.Count != 2)
            {
                MessageBox.Show("Please select 2 cells");
                return;
            }

            using (var context = new Session5Entities())
            {
                var firstCell = seatAssignmentDGV.SelectedCells[0];
                var secondCell = seatAssignmentDGV.SelectedCells[1];

                var firstCellCountry = context.Competitors.Where(x => firstCell.Value.ToString().Contains(x.competitorId)).FirstOrDefault();
                var secondCellCountry = context.Competitors.Where(x => secondCell.Value.ToString().Contains(x.competitorId)).FirstOrDefault();

                if (firstCellCountry == null || secondCellCountry == null)
                {
                    MessageBox.Show("Only assigned seats can be swapped");
                    return;
                }

                if (CheckCell(firstCell, secondCellCountry.competitorCountry) && CheckCell(secondCell, firstCellCountry.competitorCountry))
                {
                    firstCell.Value = $"{shadowDGV[firstCell.ColumnIndex, firstCell.RowIndex].Value}{secondCellCountry.competitorId}";
                    secondCell.Value = $"{shadowDGV[secondCell.ColumnIndex, secondCell.RowIndex].Value}{firstCellCountry.competitorId}";
                }
                else
                {
                    MessageBox.Show("Does not fit constaints");
                    return;
                }
            }
        }

        private void RandomAsgn_Click(object sender, EventArgs e)
        {
            RandomiseSeats();
        }

        private void RandomiseSeats()
        {
            unassignedLbl.Text = "Unassigned Competitors: 0";
            using (var context = new Session5Entities())
            {
                seatAssignmentDGV.Rows.Clear();
                unassignedList.Items.Clear();
                shadowDGV.Rows.Clear();
                var selectedSkill = skillCb.SelectedItem.ToString();
                var competitors = context.Competitors.Where(x => x.Skill.skillName == selectedSkill).ToList();
                competitors = competitors.OrderBy(x => Guid.NewGuid()).ToList();
                if (competitors.Count % 2 == 0)
                {
                    int count = 0;
                    for (int i = 0; i < competitors.Count / 2; i++)
                    {
                        string[] row = { $"{count + 1} ", $"{count + 2} " };
                        shadowDGV.Rows.Add(row);
                        var competitor1 = competitors[count];
                        var competitor2 = competitors[count + 1];

                        row[0] += competitor1.competitorId;

                        row[1] += competitor2.competitorId;

                        count += 2;
                        seatAssignmentDGV.Rows.Add(row);
                    }
                }
                else
                {
                    int count = 0;
                    for (int i = 0; i < competitors.Count / 2 + 1; i++)
                    {
                        string[] row = { $"{count + 1} ", $"{count + 2} " };
                        shadowDGV.Rows.Add(row);
                        var competitor1 = competitors[count];

                        if (count + 1 != competitors.Count)
                        {
                            var competitor2 = competitors[count + 1];

                            row[1] += competitor2.competitorId;
                        }
                        else
                        {
                            row[1] = string.Empty;
                        }

                        row[0] += competitor1.competitorId;

                        count += 2;
                        seatAssignmentDGV.Rows.Add(row);
                    }
                }
                foreach (DataGridViewColumn column in seatAssignmentDGV.Columns)
                {
                    foreach (DataGridViewRow row in seatAssignmentDGV.Rows)
                    {
                        var currentCell = seatAssignmentDGV[column.Index, row.Index].Value.ToString();
                        if (!string.IsNullOrEmpty(currentCell))
                        {
                            var currentCountry = context.Competitors.Where(x => currentCell.Contains(x.competitorId)).First().competitorCountry;
                            if (!CheckCell(seatAssignmentDGV[column.Index, row.Index], currentCountry))
                            {
                                RandomiseSeats();
                            }
                        }
                    }
                }
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            var selectedSkill = skillCb.SelectedItem.ToString();
            foreach (DataGridViewColumn column in seatAssignmentDGV.Columns)
            {
                foreach (DataGridViewRow row in seatAssignmentDGV.Rows)
                {
                    var currentCell = seatAssignmentDGV[column.Index, row.Index];

                    var currentCountry = context.Competitors.Where(x => currentCell.Value.ToString().Contains(x.competitorId) && x.Skill.skillName == selectedSkill).FirstOrDefault();

                    if (currentCountry != null)
                    {
                        currentCountry.assignedSeat = int.Parse(shadowDGV[currentCell.ColumnIndex, currentCell.RowIndex].Value.ToString());
                    }
                }
            }

            context.SaveChanges();
            RefreshSeating();
            MessageBox.Show("Changes Saved");
        }
    }
}