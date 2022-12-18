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
    public partial class BookPackagesSponsorForm : Form
    {
        private int _packageId = -1;
        private Session2Entities context = new Session2Entities();
        private string _userId = string.Empty;

        public BookPackagesSponsorForm(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void BookPackagesSponsorForm_Load(object sender, EventArgs e)
        {
            var columns = new List<string> { "packageId", "Tier", "Name", "Value ($)", "Available Qty",
                "Online", "Flyer", "Banner" };

            foreach (var column in columns)
            {
                packagesDGV.Columns.Add(column, column);
            }

            tierCb.Items.Add("All");
            tierCb.Items.AddRange(context.Packages.Select(x => x.packageTier).Distinct().ToArray());
            tierCb.SelectedIndex = 0;

            UpdateTable();
        }

        private void UpdateTable()
        {
            packagesDGV.Rows.Clear();

            var packageQuery = from x in context.Packages
                               where x.packageQuantity != 0
                               select x;

            if (!tierCb.SelectedItem.ToString().Equals("All"))
            {
                var selectedTier = tierCb.SelectedItem.ToString();
                packageQuery = packageQuery.Where(x => x.packageTier == selectedTier);
            }

            if (budgetNUD.Value != 0)
            {
                packageQuery = packageQuery.Where(x => x.packageValue <= budgetNUD.Value);
            }

            foreach (var item in packageQuery)
            {
                var inCat = false;
                var row = new List<string>
                {
                    item.packageId.ToString(),
                    item.packageTier,
                    item.packageName,
                    item.packageValue.ToString(),
                    item.packageQuantity.ToString(),
                };

                foreach (var benefit in item.Benefits)
                {
                    if (benefit.benefitName.Equals("Online"))
                    {
                        if (onlineCheck.Checked)
                        {
                            inCat = true;
                        }
                        row.Add("Yes");
                        continue;
                    }
                    if (benefit.benefitName.Equals("Flyer"))
                    {
                        if (flyerCheck.Checked)
                        {
                            inCat = true;
                        }
                        row.Add("Yes");
                        continue;
                    }
                    if (benefit.benefitName.Equals("Banner"))
                    {
                        if (bannerCheck.Checked)
                        {
                            inCat = true;
                        }
                        row.Add("Yes");
                        continue;
                    }

                    row.Add("-");
                }

                if (inCat || (!onlineCheck.Checked && !bannerCheck.Checked && !flyerCheck.Checked))
                {
                    packagesDGV.Rows.Add(row.ToArray());
                }
            }
        }

        private void tierCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void budgetNUD_ValueChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void flyerCheck_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void bannerCheck_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void onlineCheck_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                if (_packageId == -1)
                {
                    MessageBox.Show("Please select a package");
                    return;
                }
                var packageToBook = context.Packages.Where(x => x.packageId == _packageId).First();

                if (packageToBook.packageQuantity < desiredQtyNUD.Value)
                {
                    MessageBox.Show("Insufficient Packages");
                    return;
                }

                var insertBooking = new Booking
                {
                    packageIdFK = packageToBook.packageId,
                    userIdFK = _userId,
                    quantityBooked = (int)desiredQtyNUD.Value,
                    status = "Pending",
                };

                context.Bookings.Add(insertBooking);
                context.SaveChanges();

                MessageBox.Show("Booking Made");
                Close();
            }
        }

        private void packagesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _packageId = int.Parse(packagesDGV[0, e.RowIndex].Value.ToString());
            Console.WriteLine(_packageId);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}