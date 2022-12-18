using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session2_JordanKhong.Forms
{
    public partial class ViewPackagesForm : Form
    {
        public ViewPackagesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This method clears the DGV and repopulates it based on the filter selected.
        /// </summary>
        /// <param name="sortOrder"> 
        /// Custom written sort order
        /// 0 = default sort
        /// 1 = Tier Sort
        /// 2 = Value Sort
        /// 3 = Quantity Sort
        /// 4 = Name Sort
        /// </param>
        void RefreshGrid(int sortOrder = 0)
        {
            packagesDGV.Rows.Clear();
            using (var context = new Session2Entities())
            {
                var tableinfo = (from x in context.Packages
                                 select new
                                 {
                                     Tier = x.packageTier,
                                     Name = x.packageName,
                                     Value = x.packageValue,
                                     AvailQnty = x.packageQuantity,
                                     Benefit = x.Benefits
                                 });

                //Copies over a shawdow of "tableInfo" and modifies the query from there:

                var copy = tableinfo;

                switch (sortOrder)
                {
                    case 0:
                        var sortedQuery = (from x in tableinfo
                                           orderby x.Tier, x.Name
                                           select x);

                        copy = sortedQuery;
                        break;

                    case 1:
                        var sortbyTier = (from x in tableinfo
                                          select x).ToList();

                        var mapping = new Dictionary<string, int>
                        {
                            {"Gold",1 },
                            {"Silver",2 },
                            {"Bronze",3 },
                        };

                        var results = sortbyTier.OrderBy(x => mapping[x.Tier]).AsQueryable();

                        copy = results;
                        break;

                    case 2:
                        var sortByValue = from x in tableinfo
                                          orderby x.Value
                                          select x;

                        copy = sortByValue;
                        break;
                    case 3:
                        var sortByQuantity = from x in tableinfo
                                             orderby x.AvailQnty descending
                                             select x;

                        copy = sortByQuantity;
                        break;
                    case 4:
                        var sortByName = from x in tableinfo
                                         orderby x.Name
                                         select x;

                        copy = sortByName;
                        break;
                }

                //Uses the same logic to populate everything accross all 5 cases:
                foreach (var item in copy)
                {
                    List<string> row = new List<string>
                    {
                        item.Tier,
                        item.Name,
                        item.Value.ToString(),
                        item.AvailQnty.ToString(),
                    };

                    List<string> benefits = new List<string>();
                    foreach (var benefit in item.Benefit)
                    {
                        Console.WriteLine(benefit.benefitName);
                        benefits.Add(benefit.benefitName);
                    }

                    if (benefits.Contains("Online"))
                    {
                        row.Add("Yes");
                    }
                    else
                    {
                        row.Add("");
                    }


                    if (benefits.Contains("Flyer"))
                    {
                        row.Add("Yes");
                    }
                    else
                    {
                        row.Add("");
                    }

                    if (benefits.Contains("Banner"))
                    {
                        row.Add("Yes");
                    }
                    else
                    {
                        row.Add("");
                    }


                    packagesDGV.Rows.Add(row.ToArray());
                }
            }
        }

        private void ViewPackagesForm_Load(object sender, EventArgs e)
        {
            List<string> columns = new List<string>
                {
                    "Tier",
                    "Name",
                    "Value",
                    "Available Qty",
                    "Online",
                    "Flyer",
                    "Banner"
                };

            foreach (var column in columns)
            {
                packagesDGV.Columns.Add(column, column);
            }

            RefreshGrid();
        }

        private void defaultRadio_CheckedChanged(object sender, EventArgs e)
        {
            //0 = Default Sorting
            if (defaultRadio.Checked)
            {
                RefreshGrid(0);
            }
        }

        private void tierRadio_CheckedChanged(object sender, EventArgs e)
        {
            //1 = Tier Sorting
            if (tierRadio.Checked)
            {
                RefreshGrid(1);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //4 = Name Sorting
            if (nameRadio.Checked)
            {
                RefreshGrid(4);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //2 = Value Sorting
            if (valueRadio.Checked)
            {
                RefreshGrid(2);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //3 = Quantity Sorting
            if (qtyRadio.Checked)
            {
                RefreshGrid(3);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
