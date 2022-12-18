using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR2020_S2_10062022_Windows_NetFramework
{
    public partial class ViewSponsorshipPackages : Form
    {
        public ViewSponsorshipPackages()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ViewSponsorshipPackages_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Tier", "Name", "Value ($)", "Available Qty", "Online", "Flyer", "Banner",
            };

            columns.ForEach(x => packageDGV.Columns.Add(x, x));

            RefreshList();
        }

        void RefreshList()
        {
            using (var context = new Session2Entities())
            {
                packageDGV.Rows.Clear();
                var packages = context.Benefits.GroupBy(x => x.Package).ToList();

                if (tierChecked.Checked)
                {
                    packages = packages.OrderBy(x => x.Key.packageTier == "Bronze")
                        .ThenBy(x => x.Key.packageTier == "Silver")
                        .ThenBy(x => x.Key.packageTier == "Gold")
                        .ToList();
                }

                if (nameChecked.Checked)
                {
                    packages = packages.OrderBy(x => x.Key.packageName).ToList();
                }

                if (valueChecked.Checked)
                {
                    packages = packages.OrderBy(x => x.Key.packageValue).ToList();
                }

                if (quantityChecked.Checked)
                {
                    packages = packages.OrderByDescending(x => x.Key.packageQuantity).ToList();
                }

                foreach (var package in packages)
                {
                    var row = new List<string>();
                    row.Add(package.Key.packageTier);
                    row.Add(package.Key.packageName);
                    row.Add(package.Key.packageValue.ToString());
                    row.Add(package.Key.packageQuantity.ToString());

                    foreach (var benefit in package)
                    {
                        if (benefit.benefitName == "Online")
                        {
                            row.Add("Yes");
                            continue;
                        }

                        if (benefit.benefitName == "Flyer")
                        {
                            row.Add("Yes");
                            continue;
                        }

                        if (benefit.benefitName == "Banner")
                        {
                            row.Add("Yes");
                            continue;
                        }

                        row.Add("-");
                    }
                    packageDGV.Rows.Add(row.ToArray());
                }
            }
        }

        private void tierChecked_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void valueChecked_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void nameChecked_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void quantityChecked_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }
    }
}
