using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_QR_Paper2_5_29_2020
{
    public partial class ViewPackages : Form
    {
        public ViewPackages()
        {
            InitializeComponent();
        }

        private void ViewPackages_Load(object sender, EventArgs e)
        {
            var columns = new List<string>()
            {
                "Tier", "Name", "Value", "Available Qty", "Online", "Flyer", "Banner", "PackageID"
            };

            foreach (var column in columns)
            {
                packageDGV.Columns.Add(column, column);
            }

            UpdateDGV();
        }

        private void UpdateDGV()
        {
            packageDGV.Rows.Clear();
            using (var context = new Session2Entities())
            {
                var baseQuery = (from x in context.Packages
                                 select x).ToList();

                if (tierRadio.Checked)
                {
                    baseQuery = baseQuery.OrderBy(x => x.packageTier).ToList();
                }

                if (nameRadio.Checked)
                {
                    baseQuery = baseQuery.OrderBy(x => x.packageName).ToList();
                }

                if (valueRadio.Checked)
                {
                    baseQuery = baseQuery.OrderBy(x => x.packageValue).ToList();
                }

                if (quantityRadio.Checked)
                {
                    baseQuery = baseQuery.OrderByDescending(x => x.packageQuantity).ToList();
                }

                foreach (var package in baseQuery)
                {
                    var row = new List<string>();

                    row.Add(package.packageTier);
                    row.Add(package.packageName);
                    row.Add(package.packageValue.ToString());
                    row.Add(package.packageQuantity.ToString());

                    if (package.Benefits.Where(x => x.benefitName.Equals("Online")).Any())
                    {
                        row.Add("Yes");
                    }
                    else
                    {
                        row.Add("No");
                    }

                    if (package.Benefits.Where(x => x.benefitName.Equals("Flyer")).Any())
                    {
                        row.Add("Yes");
                    }
                    else
                    {
                        row.Add("No");
                    }

                    if (package.Benefits.Where(x => x.benefitName.Equals("Banner")).Any())
                    {
                        row.Add("Yes");
                    }
                    else
                    {
                        row.Add("No");
                    }

                    row.Add(package.packageId.ToString());
                    packageDGV.Rows.Add(row.ToArray());
                }
            }
        }

        private void tierRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void nameRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void valueRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void quantityRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}