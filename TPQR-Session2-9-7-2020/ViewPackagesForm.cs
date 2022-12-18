using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session2_9_7_2020
{
    public partial class ViewPackagesForm : Form
    {
        private Session2Entities context = new Session2Entities();

        public ViewPackagesForm()
        {
            InitializeComponent();
        }

        private void ViewPackagesForm_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {"Tier", "Name", "Value ($)", "Available Qty",
                "Online", "Flyer", "Banner"
            };

            foreach (var column in columns)
            {
                packagesDGV.Columns.Add(column, column);
            }
            UpdateTable();
        }

        private void UpdateTable()
        {
            packagesDGV.Rows.Clear();
            var packageQuery = from x in context.Packages
                               orderby x.packageTier == "Bronze", x.packageTier == "Silver", x.packageTier == "Gold",
                               x.packageName
                               select x;

            if (tierRadio.Checked)
            {
                packageQuery = from x in packageQuery
                               orderby x.packageTier == "Bronze", x.packageTier == "Silver", x.packageTier == "Gold"
                               select x;
            }

            if (nameRadio.Checked)
            {
                packageQuery = packageQuery.OrderBy(x => x.packageName);
            }

            if (valueRadio.Checked)
            {
                packageQuery = packageQuery.OrderBy(x => x.packageValue);
            }

            if (qtyRadio.Checked)
            {
                packageQuery = packageQuery.OrderByDescending(x => x.packageQuantity);
            }

            foreach (var package in packageQuery)
            {
                var row = new List<string>
                {
                    package.packageTier,
                    package.packageName,
                    package.packageValue.ToString(),
                    package.packageQuantity.ToString(),
                };

                foreach (var benefit in package.Benefits)
                {
                    if (benefit.benefitName.Equals("Online"))
                    {
                        row.Add("Yes");
                        continue;
                    }
                    if (benefit.benefitName.Equals("Flyer"))
                    {
                        row.Add("Yes");
                        continue;
                    }
                    if (benefit.benefitName.Equals("Banner"))
                    {
                        row.Add("Yes");
                        continue;
                    }

                    row.Add("-");
                }

                packagesDGV.Rows.Add(row.ToArray());
            }
        }

        private void noneRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void tierRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void nameRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void valueRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void qtyRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}