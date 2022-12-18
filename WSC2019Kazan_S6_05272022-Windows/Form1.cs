using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace WSC2019Kazan_S6_05272022_Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadEMSpendingByDepartment();
            LoadMonthlyReportForMostUsedParts();
        }

        private void LoadMonthlyReportForMostUsedParts()
        {
            using (var context = new Session6Context())
            {
                var orders = context.OrderItems
                        .Include(x=>x.Order)
                        .Include(x=>x.Part)
                        .Where(x=>x.Order.TransactionTypeId == 3)
                        .AsEnumerable()
                        .OrderByDescending(x=>x.Order.Date)
                        .GroupBy(x=> new { date = $"{x.Order.Date.Year}-{x.Order.Date.Month.ToString().PadLeft(2, '0')}", 
                            x.Part.Name})
                        .ToList();

                var columns = new List<string>
                {
                    "Notes / Month"
                };

                var dates = orders.Select(x => x.Key.date).Distinct();

                columns.AddRange(dates.ToArray());
                columns.ForEach(x => monthlyReportMostUsedDGV.Columns.Add(x, x));
                
                var highestCostRow = new List<string> { "Highest Cost" };
                var mostNumber = new List<string> { "Most Number" };

                foreach (var date in dates)
                {
                    Debug.WriteLine(date);
                    var maxValueStringList = new List<string>();
                    var maxUseStringList = new List<string>();

                    var monthOrder = orders.Where(x=>x.Key.date == date).ToList();

                    var maxValueList = new List<decimal>();
                    var maxUseList = new List<decimal>();

                    foreach (var item in monthOrder)
                    {
                        maxValueList.Add(item.Sum(x=>x.UnitPrice * x.Amount)!.Value);
                        maxUseList.Add(item.Sum(x=>x.Amount));
                    }
                    
                    var maxValue = maxValueList.Max();
                    var maxUse = maxUseList.Max();

                    for (int i = 0; i < maxUseList.Count; i++)
                    {
                        if (maxValue == maxValueList[i])
                        {
                            maxValueStringList.Add(monthOrder[i].Key.Name);
                        }

                        if (maxUse == maxUseList[i])
                        {
                            maxUseStringList.Add(monthOrder[i].Key.Name);
                        }
                    }

                    highestCostRow.Add(string.Join(", " , maxValueStringList));
                    mostNumber.Add(string.Join(", ", maxUseStringList));
                }

                monthlyReportMostUsedDGV.Rows.Add(highestCostRow.ToArray());
                monthlyReportMostUsedDGV.Rows.Add(mostNumber.ToArray());
            }
        }

        private void LoadEMSpendingByDepartment()
        {
            using (var context = new Session6Context())
            {
                var orders = context.Orders
                    .Where(x=>x.TransactionTypeId == 3)
                    .Include(x=>x.EmergencyMaintenances!.Asset.DepartmentLocation.Department)
                    .Include(x=>x.OrderItems)
                    .Where(x=>x.EmergencyMaintenances!.EmendDate != null)
                    .AsEnumerable()
                    .OrderByDescending(x=>x.Date)
                    .GroupBy(x=> new { date = $"{x.Date.Year}-{x.Date.Month.ToString().PadLeft(2, '0')}", x.EmergencyMaintenances!.Asset.DepartmentLocation.Department.Name })
                    .ToList();

                var columns = new List<string>
                {
                    "Department / Month"
                };

                var departments = orders.Select(x=>x.Key.Name).Distinct();
                var dates = orders.Select(x => x.Key.date).Distinct();

                columns.AddRange(dates.ToArray());

                columns.ForEach(x => emSpendingDepartmentDGV.Columns.Add(x, x));

                foreach (var dep in departments)
                {
                    var row = new List<string>();
                    row.Add(dep);
                    Debug.WriteLine(dep);
                    foreach (var date in dates)
                    {
                        var currentSpending = orders.Where(x=>x.Key.date == date && x.Key.Name == dep).FirstOrDefault();
                        
                        if (currentSpending != null)
                        {
                            var spending = 0M;
                            foreach (var item in currentSpending)
                            {
                                spending += item.OrderItems.Sum(x=>x.UnitPrice * x.Amount)!.Value;
                            }
                            row.Add(spending.ToString("0.0"));
                        }
                        else
                        {
                            row.Add("0");
                        }
                        
                    }
                    emSpendingDepartmentDGV.Rows.Add(row.ToArray());
                }


                // Highlighting

                for (int i = 1; i < emSpendingDepartmentDGV.ColumnCount; i++)
                {
                    var rowValues = new List<decimal>();
                    for (int j = 0; j < emSpendingDepartmentDGV.RowCount; j++)
                    {
                        rowValues.Add(decimal.Parse(emSpendingDepartmentDGV[i, j].Value.ToString()!));
                    }
                    var largestValue = rowValues.Where(x=>x > 0).Max();
                    var smallestValue = rowValues.Where(x=>x > 0).Min();

                    var largestIdx = rowValues.FindIndex(x=>x != 0 && x == largestValue);
                    var smallestIdx = rowValues.FindIndex(x=>x != 0 && x == smallestValue);

                    emSpendingDepartmentDGV[i, smallestIdx].Style.ForeColor = Color.Green;
                    emSpendingDepartmentDGV[i, largestIdx].Style.ForeColor = Color.Red;
                }
                
            }  
        }
    }
}