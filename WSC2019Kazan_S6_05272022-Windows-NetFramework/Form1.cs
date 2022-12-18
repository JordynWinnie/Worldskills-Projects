using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using WSC2019Kazan_S6_05272022_Windows_NetFramework.Properties;

namespace WSC2019Kazan_S6_05272022_Windows_NetFramework
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> defaultDictionary = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            var langPath = Path.GetFullPath("./languages");

            foreach (var item in Directory.GetFiles(langPath))
            {
                try
                {
                    XDocument tryLoad = XDocument.Load(item); 
                    languageCB.Items.Add(Path.GetFileNameWithoutExtension(item));
                }
                catch (Exception)
                {
                }
                
            }
            
            // Set Default Lang: 
            var defaultLangPath = Path.GetFullPath($"./languages/default.xml");
            XDocument doc = XDocument.Load(defaultLangPath);

            foreach (var item in doc.Descendants("InventoryDashboard"))
            {
                var dashboardBaseName = item.Name;
                foreach (var formTitle in item.Elements("FormTitle"))
                {
                    defaultDictionary[$"{dashboardBaseName}/{formTitle.Name}"] = formTitle.Attribute("name").Value;
                }

                foreach (var panelTitle in item.Elements("PanelTitle"))
                {
                    var panelTitleName = panelTitle.Name;
                    var panelElementName = panelTitle.Attribute("name").Value;
                    var translation = panelTitle.Attribute("value").Value;
                    defaultDictionary[$"{dashboardBaseName}/{panelTitleName}/{panelElementName}"] = translation;
                    //panelTitle.Attribute("value").Value);
                }

                foreach (var button in item.Elements("Button"))
                {
                    var buttonTitle = button.Name;
                    var buttonElementName = button.Attribute("name").Value;
                    var translation = button.Attribute("value").Value;
                    defaultDictionary[$"{dashboardBaseName}/{buttonTitle}/{buttonElementName}"] = translation;
                }


                foreach (var label in item.Elements("Label"))
                {
                    var buttonTitle = label.Name;
                    var buttonElementName = label.Attribute("name").Value;
                    var translation = label.Attribute("value").Value;
                    defaultDictionary[$"{dashboardBaseName}/{buttonTitle}/{buttonElementName}"] = translation;
                }
            
            }
            var saved_Lang = Settings.Default.savedLanguage;
            languageCB.SelectedItem = saved_Lang;

            LoadEMSpendingByDepartment();
            LoadMonthlyReportForMostUsedParts();
            LoadMonthlyCostlyAssets();
            LoadDepartmentPieChart();
            LoadDepartmentSpendingChart();
        }
        


         void LoadDepartmentSpendingChart()
        {
            using (var context = new Session6Entities())
            {
                var orders = context.Orders
                   .Where(x => x.TransactionTypeID == 3)
                   .Where(x => x.EmergencyMaintenance.EMStartDate != null)
                   .OrderByDescending(x => x.Date)
                   .AsEnumerable()
                   .GroupBy(x => new {
                       date = $"{x.Date.Year}-{x.Date.Month.ToString().PadLeft(2, '0')}",
                       x.EmergencyMaintenance.Asset.DepartmentLocation.Department.Name
                   });

                
                var departments = orders.Select(x=>x.Key.Name).Distinct();
                var dates = orders.Select(x=>x.Key.date).Distinct();
                monthlyDepartmentSpendingChart.Series.Clear();
                foreach (var dep in departments)
                {
                    monthlyDepartmentSpendingChart.Series.Add(dep);
                }

                foreach (var date in dates)
                {
                    var spending = orders.Where(x=>x.Key.date == date).ToList();
                    foreach (var item in spending)
                    {
                        
                        var sum = item.Sum(x=>x.OrderItems.Sum(y=>y.Amount * y.UnitPrice));

                        monthlyDepartmentSpendingChart.Series[item.Key.Name].Points.AddXY(date, sum);
                    }
                }
                }
               
            }
        

        private void LoadDepartmentPieChart()
        {
            using (var context = new Session6Entities())
            {
                var orders = context.Orders
                   .Where(x => x.TransactionTypeID == 3)
                   .Where(x => x.EmergencyMaintenance.EMStartDate != null)
                   .OrderByDescending(x => x.Date)
                   .AsEnumerable()
                   .GroupBy(x => x.EmergencyMaintenance.Asset.DepartmentLocation.Department.Name);

                foreach (var item in orders)
                {
                    var fullSum = item.Sum(x=>x.OrderItems.Sum(y=>y.Amount * y.UnitPrice));
                    departmentSpendingRatioChart.Series[0].Points.AddXY(
                        item.Select(x=>x.EmergencyMaintenance.Asset.DepartmentLocation.Department.Name).First(), 
                        fullSum);
                    
                }

                departmentSpendingRatioChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                
            }
        }

        private void LoadMonthlyCostlyAssets()
        {
            using (var context = new Session6Entities())
            {
                var orders = context.Orders
                    .Where(x => x.TransactionTypeID == 3)
                    .Where(x => x.EmergencyMaintenance.EMStartDate != null)
                    .OrderByDescending(x => x.Date)
                    .AsEnumerable()
                    .GroupBy(x => new {
                        date = $"{x.Date.Year}-{x.Date.Month.ToString().PadLeft(2, '0')}",
                        x.EmergencyMaintenance.Asset,
                    });

                var columns = new List<string>
                {
                    "Asset Name / Month"
                };
                var dates = orders.Select(x => x.Key.date).Distinct();
                columns.AddRange(dates.ToArray());
                columns.ForEach(x => monthyReportCostlyAssetsDGV.Columns.Add(x, x));

                var assetRow = new List<string> { "Asset" };
                var departmentRow = new List<string> { "Department" };

                foreach (var date in dates)
                {
                    var assets = orders.Where(x => x.Key.date == date).ToList();

                    var assetNameString = new List<string>();
                    var departmentNameString = new List<string>();

                    var assetCosts = new List<decimal>();
                    foreach (var item in assets)
                    {
                        var sum = item.Sum(x => x.OrderItems.Sum(y => y.UnitPrice * y.Amount)).Value;
                        assetCosts.Add(sum);
                    }

                    var maxCost = assetCosts.Max();


                    for (int i = 0; i < assetCosts.Count; i++)
                    {
                        if (assetCosts[i] == maxCost)
                        {
                            assetNameString.Add(assets[i].Key.Asset.AssetName);
                            departmentNameString.Add(assets[i].Key.Asset.DepartmentLocation.Department.Name);
                        }
                    }

                    assetRow.Add(string.Join(", ", assetNameString));
                    departmentRow.Add(string.Join(", ", departmentNameString));
                }

                monthyReportCostlyAssetsDGV.Rows.Add(assetRow.ToArray());
                monthyReportCostlyAssetsDGV.Rows.Add(departmentRow.ToArray());
            }
        }

        private void LoadMonthlyReportForMostUsedParts()
        {
            using (var context = new Session6Entities())
            {
                var orders = context.OrderItems
                        .Where(x => x.Order.TransactionTypeID == 3)
                        .AsEnumerable()
                        .OrderByDescending(x => x.Order.Date)
                        .GroupBy(x => new {
                            date = $"{x.Order.Date.Year}-{x.Order.Date.Month.ToString().PadLeft(2, '0')}",
                            x.Part.Name
                        })
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

                    var maxValueStringList = new List<string>();
                    var maxUseStringList = new List<string>();

                    var monthOrder = orders.Where(x => x.Key.date == date).ToList();

                    var maxValueList = new List<decimal>();
                    var maxUseList = new List<decimal>();

                    foreach (var item in monthOrder)
                    {
                        maxValueList.Add(item.Sum(x => x.UnitPrice * x.Amount).Value);
                        maxUseList.Add(item.Sum(x => x.Amount));
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

                    highestCostRow.Add(string.Join(", ", maxValueStringList));
                    mostNumber.Add(string.Join(", ", maxUseStringList));
                }

                monthlyReportMostUsedDGV.Rows.Add(highestCostRow.ToArray());
                monthlyReportMostUsedDGV.Rows.Add(mostNumber.ToArray());
            }
        }

        private void LoadEMSpendingByDepartment()
        {
            using (var context = new Session6Entities())
            {
                var orders = context.Orders
                    .Where(x => x.TransactionTypeID == 3)
                    .Where(x => x.EmergencyMaintenance.EMEndDate != null)
                    .AsEnumerable()
                    .OrderByDescending(x => x.Date)
                    .GroupBy(x => new { date = $"{x.Date.Year}-{x.Date.Month.ToString().PadLeft(2, '0')}", x.EmergencyMaintenance.Asset.DepartmentLocation.Department.Name })
                    .ToList();

                var columns = new List<string>
                {
                    "Department / Month"
                };

                var departments = orders.Select(x => x.Key.Name).Distinct();
                var dates = orders.Select(x => x.Key.date).Distinct();

                columns.AddRange(dates.ToArray());

                columns.ForEach(x => emSpendingDepartmentDGV.Columns.Add(x, x));

                foreach (var dep in departments)
                {
                    var row = new List<string>();
                    row.Add(dep);

                    foreach (var date in dates)
                    {
                        var currentSpending = orders.Where(x => x.Key.date == date && x.Key.Name == dep).FirstOrDefault();

                        if (currentSpending != null)
                        {
                            var spending = 0M;
                            foreach (var item in currentSpending)
                            {
                                spending += item.OrderItems.Sum(x => x.UnitPrice * x.Amount).Value;
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
                        rowValues.Add(decimal.Parse(emSpendingDepartmentDGV[i, j].Value.ToString()));
                    }
                    var largestValue = rowValues.Where(x => x > 0).Max();
                    var smallestValue = rowValues.Where(x => x > 0).Min();

                    var largestIdx = rowValues.FindIndex(x => x != 0 && x == largestValue);
                    var smallestIdx = rowValues.FindIndex(x => x != 0 && x == smallestValue);

                    emSpendingDepartmentDGV[i, smallestIdx].Style.ForeColor = Color.Green;
                    emSpendingDepartmentDGV[i, largestIdx].Style.ForeColor = Color.Red;
                }

            }
        }

        private void languageCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (defaultDictionary.Count == 0) return;
            Settings.Default["savedLanguage"] = languageCB.SelectedItem;
            Settings.Default.Save();
            var langPath = Path.GetFullPath($"./languages/{languageCB.SelectedItem}.xml");
            XDocument doc = XDocument.Load(langPath);

            var languageDict = new Dictionary<string, string>();
            foreach (var item in doc.Descendants("InventoryDashboard"))
            {
                var dashboardBaseName = item.Name;
                foreach (var formTitle in item.Elements("FormTitle"))
                {
                    languageDict[$"{dashboardBaseName}/{formTitle.Name}"] = formTitle.Attribute("name").Value;
                }

                foreach (var panelTitle in item.Elements("PanelTitle"))
                {
                    var panelTitleName = panelTitle.Name;
                    var panelElementName = panelTitle.Attribute("name").Value;
                    var translation = panelTitle.Attribute("value").Value;
                    languageDict[$"{dashboardBaseName}/{panelTitleName}/{panelElementName}"] = translation;
                    //panelTitle.Attribute("value").Value);
                }

                foreach (var button in item.Elements("Button"))
                {
                    var buttonTitle = button.Name;
                    var buttonElementName = button.Attribute("name").Value;
                    var translation = button.Attribute("value").Value;
                    languageDict[$"{dashboardBaseName}/{buttonTitle}/{buttonElementName}"] = translation;
                }


                foreach (var label in item.Elements("Label"))
                {
                    var buttonTitle = label.Name;
                    var buttonElementName = label.Attribute("name").Value;
                    var translation = label.Attribute("value").Value;
                    languageDict[$"{dashboardBaseName}/{buttonTitle}/{buttonElementName}"] = translation;
                }

                
            }


   
            this.Text = GetLangText("InventoryDashboard/FormTitle", languageDict);
            emSpendingByDepGB.Text = GetLangText("InventoryDashboard/PanelTitle/EMSpendingByDepartment", languageDict);
            monthlyReportMostUsedDGV.Text = GetLangText("InventoryDashboard/PanelTitle/MonthlyReportMostUsedParts", languageDict);

            monthyReportCostlyAssetsDGV.Text = GetLangText("InventoryDashboard/PanelTitle/MonthlyReportCostlyAssets", languageDict);
            depSpendingRatioGB.Text = GetLangText("InventoryDashboard/PanelTitle/DepartmentSpendingRatio", languageDict);
            departmentSpendingRatioChart.Text = GetLangText("InventoryDashboard/PanelTitle/MonthlyDepartmentSpending", languageDict);

            inventoryControlBtn.Text = GetLangText("InventoryDashboard/Button/InventoryControl", languageDict);
            closeBtn.Text = GetLangText("InventoryDashboard/Button/Close", languageDict);

            languageLbl.Text = GetLangText("InventoryDashboard/Label/lang", languageDict);
        }

        private string GetLangText(string key, Dictionary<string, string> currentLangDict)
        {
            if (currentLangDict.ContainsKey(key)) return currentLangDict[key];
            else return defaultDictionary[key];
        }
    }
}
