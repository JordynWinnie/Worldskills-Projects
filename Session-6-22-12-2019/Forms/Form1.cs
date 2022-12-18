using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Session_6_22_12_2019
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new Session6Entities())
            {
                #region EM spending by Department 
                var departmentSpendingTemp = (from x in context.Orders
                                              where x.EmergencyMaintenance.EMStartDate != null && x.EmergencyMaintenance.EMEndDate != null
                                              select new
                                              {
                                                  Department = x.EmergencyMaintenance.Asset.DepartmentLocation.Department.Name,
                                                  Date = x.Date,
                                                  Spending = x.OrderItems.Sum(y => y.Amount * y.UnitPrice)
                                              }).ToList();

                var departmentSpending = (from p in departmentSpendingTemp
                                          select new
                                          {
                                              p.Department,
                                              p.Spending,
                                              Date = p.Date.ToString("yyyy-MM")
                                          }).ToList();


                var dateColumns = (from p in departmentSpending
                                   orderby p.Date descending
                                   select p.Date).Distinct();

                if (dateColumns.Count() > 10)
                {
                    dateColumns = dateColumns.Take(10);
                }

                var departmentsInList = (from p in departmentSpending
                                         orderby p.Department
                                         select p.Department).Distinct();


                //Add all the columns required:
                emSpendingDGV.Columns.Clear();

                emSpendingDGV.Columns.Add("DepartmentName", "Department \\ Month");


                foreach (var date in dateColumns)
                {
                    emSpendingDGV.Columns.Add(date, date);
                }

                foreach (var department in departmentsInList)
                {
                    List<string> row = new List<string>();

                    row.Add(department);

                    foreach (var monthlySpending in dateColumns)
                    {

                        var spending = (from p in departmentSpending
                                        where p.Department == department && p.Date == monthlySpending
                                        select p.Spending).Sum().Value.ToString("0");

                        row.Add(spending);
                    }

                    emSpendingDGV.Rows.Add(row.ToArray());
                }

                //TODO: high light parts

                HighLightTable();

                #endregion
                //OLD CODE:
                #region Old code attempt
                /*var EMSpending = from x in context.EmergencyMaintenances
                                 where x.EMEndDate != null
                                 group x by new { Test = x.EMEndDate.Value.Year.ToString() + "-" + x.EMEndDate.Value.Month.ToString() } into y
                                 orderby y.Key.Test descending
                                 select y;

                var departmentBasedSpending = from x in context.OrderItems
                                              where x.Order.EmergencyMaintenance.EMEndDate != null
                                              group x by new { Test = x.Order.EmergencyMaintenance.EMEndDate.Value.Month + "-" + x.Order.EmergencyMaintenance.EMEndDate.Value.Year } into y
                                              select y;
*/
                /*List<string> columns = new List<string>
                {
                    "Department / Month"
                };

                foreach (var item in columns)
                {
                    emSpendingDGV.Columns.Add(item, item);
                }

                foreach (var item in departmentBasedSpending)
                {
                    emSpendingDGV.Columns.Add(item.Key.ToString(), item.Key.ToString());

                    foreach (var cost in item)
                    {
                        cost.Amount.ToString();
                    };
                }*/
                #endregion

                #region Most Used Parts
                //most used parts:
                var mostUsedPartsTemp = (from x in context.OrderItems
                                         where x.Order.EmergencyMaintenance.EMStartDate != null && x.Order.EmergencyMaintenance.EMEndDate != null
                                         select new
                                         {
                                             Date = x.Order.Date,
                                             Amt = x.Amount,
                                             TotalCost = x.UnitPrice * x.Amount,
                                             PartName = x.Part.Name
                                         }).ToList();

                var mostUsedParts = (from x in mostUsedPartsTemp
                                     select new
                                     {
                                         x.PartName,
                                         Date = x.Date.ToString("yyyy-MM"),
                                         x.Amt,
                                         x.TotalCost
                                     }).ToList();

                mostusedPartsDGV.Columns.Clear();

                //Populate the columns:

                mostusedPartsDGV.Columns.Add("AssetName", "Asset Name \\ Month");


                foreach (var date in dateColumns)
                {
                    mostusedPartsDGV.Columns.Add(date, date);
                }


                //Ask about this?

                var MostUsedParts_HighestCost = from x in mostUsedParts
                                                group x by new { x.Date, x.PartName } into y
                                                select new
                                                {
                                                    y.Key.PartName,
                                                    y.Key.Date,
                                                    TotalCost = y.Sum(p => p.TotalCost)
                                                };
                List<string> partNameMostCostRow = new List<string>();
                partNameMostCostRow.Add("Highest Cost");
                foreach (var date in dateColumns)
                {

                    var maxCost = (from p in MostUsedParts_HighestCost
                                   where p.Date == date
                                   orderby p.TotalCost descending
                                   select p.TotalCost).FirstOrDefault();

                    var partnameMostCost = String.Join(",", (from p in MostUsedParts_HighestCost
                                                             where p.Date == date && p.TotalCost == maxCost
                                                             orderby p.PartName descending
                                                             select p.PartName));

                    partNameMostCostRow.Add(partnameMostCost);


                }
                mostusedPartsDGV.Rows.Add(partNameMostCostRow.ToArray());

                var mostUsedParts_totalQuantity = from x in mostUsedParts
                                                  group x by new { x.Date, x.PartName } into y
                                                  select new
                                                  {
                                                      y.Key.Date,
                                                      y.Key.PartName,
                                                      TotalParts = y.Sum(z => z.Amt)
                                                  };

                List<string> maxQuantityRow = new List<string>();
                maxQuantityRow.Add("Most Number");
                foreach (var date in dateColumns)
                {
                    var maxQuantity = (from x in mostUsedParts_totalQuantity
                                       where x.Date == date
                                       orderby x.TotalParts descending
                                       select x.TotalParts).FirstOrDefault();

                    var maxQuantityPart = String.Join(",", (from x in mostUsedParts_totalQuantity
                                                            where x.Date == date && x.TotalParts == maxQuantity
                                                            orderby x.PartName descending
                                                            select x.PartName));
                    maxQuantityRow.Add(maxQuantityPart);

                }

                mostusedPartsDGV.Rows.Add(maxQuantityRow.ToArray());
                #endregion

                #region Costly Assets:
                var costlyAssets = (from x in context.OrderItems
                                    where x.Order.EmergencyMaintenance.EMStartDate != null && x.Order.EmergencyMaintenance.EMEndDate != null
                                    select new
                                    {
                                        Date = x.Order.Date,
                                        DepartmentName = x.Order.EmergencyMaintenance.Asset.DepartmentLocation.Department.Name,
                                        TotalCost = x.Amount * x.UnitPrice,
                                        PartName = x.Part.Name
                                    }).ToList();

                var costlyAssetQuery = (from x in costlyAssets
                                        select new
                                        {
                                            Date = x.Date.ToString("yyyy-MM"),
                                            x.DepartmentName,
                                            x.PartName,
                                            x.TotalCost
                                        });
                costlyAssetsDGV.Columns.Add("Costly Assets", "Asset Name \\ Month");
                foreach (var date in dateColumns)
                {
                    costlyAssetsDGV.Columns.Add(date, date);
                }

                //Adding the costly assets:

                var groupbyAssetName = from x in costlyAssetQuery
                                       group x by new { x.Date, x.DepartmentName, x.PartName } into y
                                       select new
                                       {
                                           y.Key.Date,
                                           y.Key.DepartmentName,
                                           y.Key.PartName,
                                           TotalCost = y.Sum(z => z.TotalCost)
                                       };
                List<string> costlyAssetPartNameRow = new List<string>();
                List<string> costlyAssetDepartmentRow = new List<string>();
                costlyAssetPartNameRow.Add("Asset");
                costlyAssetDepartmentRow.Add("Department");
                foreach (var date in dateColumns)
                {
                    var mostCostlyAssets = (from x in groupbyAssetName
                                            where x.Date == date
                                            orderby x.TotalCost descending
                                            select x.TotalCost).FirstOrDefault();

                    var assetNameCostly = String.Join(",", (from x in groupbyAssetName
                                                            where x.Date == date && x.TotalCost == mostCostlyAssets
                                                            select x.PartName));

                    var departmentUsed = String.Join(",", (from x in groupbyAssetName
                                                           where x.Date == date && x.TotalCost == mostCostlyAssets
                                                           select x.DepartmentName));

                    costlyAssetPartNameRow.Add(assetNameCostly);
                    costlyAssetDepartmentRow.Add(departmentUsed);
                }

                costlyAssetsDGV.Rows.Add(costlyAssetPartNameRow.ToArray());
                costlyAssetsDGV.Rows.Add(costlyAssetDepartmentRow.ToArray());

                #endregion

                #region Department Spending Ratio
                var departmentSpendingRatioChart = from x in departmentSpending
                                                   group x by x.Department into y
                                                   select new
                                                   {
                                                       y.Key,
                                                       TotalSpent = y.Sum(z => z.Spending)
                                                   };

                foreach (var item in departmentSpendingRatioChart)
                {
                    var index = spendingRatioChart.Series[0].Points.AddY(item.TotalSpent);
                    spendingRatioChart.Series[0].Points[index].Label = item.Key;
                }

                #endregion

                #region Monthly Department Spending
                //OLD CODE:
                var monthlyDeptSpendingTemp = (from x in context.OrderItems
                                               where x.Order.EmergencyMaintenance.EMStartDate != null && x.Order.EmergencyMaintenance.EMEndDate != null
                                               select new
                                               {
                                                   Spending = x.Amount * x.UnitPrice,
                                                   DeptName = x.Order.EmergencyMaintenance.Asset.DepartmentLocation.Department.Name,
                                                   Date = x.Order.Date
                                               }).ToList();

                var monthlyDeptSpending = (from x in monthlyDeptSpendingTemp
                                           select new
                                           {
                                               x.Spending,
                                               x.DeptName,
                                               Date = x.Date.ToString("yyyy-MM")
                                           }).ToList();

                var columnChartInfo = (from x in monthlyDeptSpending
                                       group x by new { x.Date, x.DeptName } into y
                                       select new
                                       {
                                           y.Key.DeptName,
                                           y.Key.Date,
                                           TotalSpent = y.Sum(z => z.Spending)
                                       }).ToList();

                monthlyDepartmentSpendingChart.Series.Clear();
                monthlyDepartmentSpendingChart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;

                foreach (var item in monthlyDeptSpending.Select(x => x.DeptName).Distinct())
                {
                    Console.WriteLine(item);
                    monthlyDepartmentSpendingChart.Series.Add(item.Trim());
                }

                foreach (var date in dateColumns)
                {
                    //Console.WriteLine(date);
                    foreach (var department in monthlyDeptSpending.Select(x => x.DeptName).Distinct())
                    {
                        var seriesInformation = (from x in columnChartInfo
                                                 orderby x.Date
                                                 where x.Date == date && x.DeptName == department
                                                 select x).FirstOrDefault();
                        
                        if (seriesInformation == null)
                        {
                            Console.WriteLine(date);
                            monthlyDepartmentSpendingChart.Series[department].Points.AddXY(date, 0);
                            
                        }
                        else
                        {
                            Console.WriteLine(date);
                            monthlyDepartmentSpendingChart.Series[department].Points.AddXY(date, seriesInformation.TotalSpent);
                        }
                        
                    }
                    
                    
                    
                    
                }


                /*var DS_MonthlyDepartmentSpendingRatio = (from p in departmentSpendingTemp
                                                         group p by new { p.Date, p.Department } into q
                                                         orderby q.Key.Date, q.Key.Department
                                                         select new
                                                         {
                                                             q.Key.Department,
                                                             q.Key.Date,
                                                             Total = q.Sum(p => p.Spending)
                                                         });

                monthlyDepartmentSpendingChart.Series.Clear();
                foreach (var DeptName in DS_MonthlyDepartmentSpendingRatio.Select(p => p.Department).Distinct())
                {
                    //Add each deptname as a series
                    monthlyDepartmentSpendingChart.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series(DeptName) { });
                }

                var curDate = DateTime.MaxValue;
                var DateIdx = 0;
                foreach (var r in DS_MonthlyDepartmentSpendingRatio)
                {
                    if (curDate != r.Date)
                    {
                        curDate = r.Date;
                        DateIdx++;
                    }
                    var idx = monthlyDepartmentSpendingChart.Series[r.Department].Points.AddXY(DateIdx, r.Total);
                    monthlyDepartmentSpendingChart.Series[r.Department].Points[idx].AxisLabel = r.Date.ToString("yyyy-MM");
                    monthlyDepartmentSpendingChart.Series[r.Department].Points[idx].Label = r.Total.Value.ToString("#,##0");
                }*/
                #endregion
            }
        }

        private void HighLightTable()
        {
            //Get count of the number of rows
            /*#region Jeffery's Code:
            for (var i = 1; i < emSpendingDGV.Columns.Count; i++)
            {
                decimal Lo = int.MaxValue;
                int LowRow = -1;
                decimal Hi = int.MinValue;
                int HiRow = -1;

                //Get the hi/lo per column
                for (var j = 0; j < emSpendingDGV.Rows.Count; j++)
                {
                    var Value = Convert.ToDecimal(emSpendingDGV.Rows[j].Cells[i].Value);

                    if (Value > 0)
                    {
                        if (Value < Lo)
                        {
                            Lo = Value;
                            LowRow = j;
                        }

                        if (Value > Hi)
                        {
                            Hi = Value;
                            HiRow = j;
                        }
                    }
                }

                //Now set the color
                if (LowRow == -1 && HiRow == -1)
                {
                    //Do nothing
                }
                else if (LowRow == HiRow)
                {
                    emSpendingDGV.Rows[HiRow].Cells[i].Style.ForeColor = Color.Red;
                    emSpendingDGV.Rows[LowRow].Cells[i].Style.ForeColor = Color.Red;
                }
                else
                {
                    if (HiRow > -1) emSpendingDGV.Rows[HiRow].Cells[i].Style.ForeColor = Color.Red;
                    if (LowRow > -1) emSpendingDGV.Rows[LowRow].Cells[i].Style.ForeColor = Color.Green;
                }
            }
            #endregion */

            #region Old Code Attempt:

            /* //Jordan's Code:
             for (int i = 1; i < emSpendingDGV.Columns.Count; i++)
             {
                 List<decimal> hiList = new List<decimal>();
                 List<decimal> loList = new List<decimal>();
                 List<decimal> originalList = new List<decimal>();
                 for (int j = 0; j < emSpendingDGV.Rows.Count; j++)
                 {
                     var valueToCompare = Convert.ToDecimal(emSpendingDGV[i, j].Value.ToString());

                     originalList.Add(valueToCompare);
                     if (valueToCompare > 0)
                     {
                         hiList.Add(valueToCompare);
                         loList.Add(valueToCompare);
                     }
                     else
                     {
                         hiList.Add(int.MinValue);
                         loList.Add(int.MaxValue);
                     }

                     Console.WriteLine(valueToCompare.ToString());
                 }

                 var minIdx = loList.IndexOf(loList.Min());
                 var maxIdx = hiList.IndexOf(hiList.Max());

                 if (!(originalList[minIdx] == 0 && originalList[maxIdx] == 0))
                 {
                     emSpendingDGV.Rows[minIdx].Cells[i].Style.ForeColor = Color.Green;
                     emSpendingDGV.Rows[maxIdx].Cells[i].Style.ForeColor = Color.Red;
                 }
             }*/
            #endregion

            #region Dylan's Code:
            for (int i = 1; i < emSpendingDGV.Columns.Count; i++)
            {
                List<decimal> values = new List<decimal>();

                for (int j = 0; j < emSpendingDGV.Rows.Count; j++)
                {
                    var valueToCompare = Convert.ToDecimal(emSpendingDGV[i, j].Value.ToString());

                    values.Add(valueToCompare);
                }
                var get0 = (from x in values
                            select x).Except(new List<decimal>() { 0 }).ToList();

                if (get0.Count > 0)
                {
                    var minValue = get0.Min();
                    var maxValue = get0.Max();
                    var minIdx = values.IndexOf(minValue);
                    var maxIdx = values.IndexOf(maxValue);

                    if (!(values[minIdx] == 0 && values[maxIdx] == 0))
                    {
                        emSpendingDGV.Rows[minIdx].Cells[i].Style.ForeColor = Color.Green;
                        emSpendingDGV.Rows[maxIdx].Cells[i].Style.ForeColor = Color.Red;
                    }
                }
            }
            #endregion
        }
    }
}
