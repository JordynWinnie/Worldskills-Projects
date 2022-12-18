using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session2_8_31_2020
{
    public partial class ViewPackagesSponManager : Form
    {
        private Session2Entities context = new Session2Entities();
        public ViewPackagesSponManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ViewPackagesSponManager_Load(object sender, EventArgs e)
        {


            var columns = new List<string>
            {
               "Tier", "Name", "Value", "Available Qty", "Online", "Flyer", "Banner"
            };


            foreach (var column in columns)
            {
                packageDGV.Columns.Add(column, column);
            }

            RefreshTable();

        }

        private void RefreshTable()
        {
            packageDGV.Rows.Clear();
            var packages = from x in context.Packages
                           orderby x.packageTier == "Bronze",
                           x.packageTier == "Silver", x.packageTier == "Gold", x.packageName
                           select x;

            if (tierRb.Checked)
            {
                packages = packages.OrderBy(x=>x.packageTier == "Bronze")
                    .ThenBy(x=>x.packageTier == "Silver")
                    .ThenBy(x=>x.packageTier == "Gold");
            }

            if (nameRb.Checked)
            {
                packages = packages.OrderBy(x=>x.packageName);
            }

            if (valueAscRb.Checked)
            {
                packages = packages.OrderBy(x=>x.packageValue);
            }

            if (valueDecRb.Checked)
            {
                packages = packages.OrderByDescending(x=>x.packageQuantity);
            }
            foreach (var package in packages)
            {
               
                var row = new List<string>
                {
                    package.packageTier, package.packageName,
                    package.packageValue.ToString(), package.packageQuantity.ToString()
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
                    row.Add(string.Empty);
                }

                packageDGV.Rows.Add(row.ToArray());
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void noneRb_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void valueDecRb_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void nameRb_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void valueAscRb_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTable();

        }

        private void tierRb_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTable();
        }
    }
}
