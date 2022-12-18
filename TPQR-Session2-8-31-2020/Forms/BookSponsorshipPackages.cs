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
    public partial class BookSponsorshipPackages : Form
    {
        private Session2Entities context = new Session2Entities();
        private int _packageId = -1;
        private string _userId = string.Empty;

        public BookSponsorshipPackages(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void BookSponsorshipPackages_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
               "Id","Tier", "Name", "Value", "Available Qty", "Online", "Flyer", "Banner"
            };

            foreach (var column in columns)
            {
                packageDGV.Columns.Add(column, column);
            }

            packageDGV.Columns[0].Visible = false;
            budgetNUD.Maximum = int.MaxValue;
            var tierList = new List<string> { "None", "Gold", "Silver", "Bronze" };
            comboBox1.Items.AddRange(tierList.ToArray());

            comboBox1.SelectedIndex = 0;

            RefreshTable();
        }

        private void RefreshTable()
        {
            packageDGV.Rows.Clear();
            var packageQuery = (from x in context.Packages
                                where x.packageQuantity != 0
                                orderby x.packageName
                                select x).ToList();

            if (budgetNUD.Value != 0)
            {
                packageQuery = packageQuery.Where(x => x.packageValue <= budgetNUD.Value).ToList();
            }

            if (comboBox1.SelectedIndex != 0)
            {
                packageQuery = packageQuery.Where(x => x.packageTier.Equals(comboBox1.SelectedItem.ToString())).ToList();
            }
            foreach (var package in packageQuery)
            {
                var row = new List<string>
                {
                    package.packageId.ToString(),package.packageTier, package.packageName,
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

                var benefitFilter = true;
                if (onlineCheckBox.Checked)
                {
                    if (!package.Benefits.Where(x => x.benefitName == "Online").Any())
                    {
                        benefitFilter = false;
                    }
                }

                if (flyersCheckBox.Checked)
                {
                    if (!package.Benefits.Where(x => x.benefitName == "Flyer").Any())
                    {
                        benefitFilter = false;
                    }
                }
                if (bannerCheckbox.Checked)
                {
                    if (!package.Benefits.Where(x => x.benefitName == "Banner").Any())
                    {
                        benefitFilter = false;
                    }
                }

                if (benefitFilter)
                {
                    packageDGV.Rows.Add(row.ToArray());
                }
            }
        }

        private void budgetNUD_ValueChanged(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void onlineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void flyersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void bannerCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void packageDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _packageId = int.Parse(packageDGV[0, e.RowIndex].Value.ToString());
            Console.WriteLine(_packageId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                var booking = new Booking
                {
                    userIdFK = _userId,
                    packageIdFK = _packageId,
                    quantityBooked = (int)desiredQty.Value,
                    status = "Pending"
                };

                context.Bookings.Add(booking);
                context.SaveChanges();
                MessageBox.Show("Booking Set");
                RefreshTable();
            }
        }

        private bool Validation()
        {
            if (desiredQty.Value == 0)
            {
                MessageBox.Show("Desired Quantity cannot be 0");
                return false;
            }

            if (_packageId == -1)
            {
                MessageBox.Show("Please select a package");
                return false;
            }

            var package = context.Packages.Where(x => x.packageId == _packageId).First();

            if (package.packageQuantity < desiredQty.Value)
            {
                MessageBox.Show("Not enough packages to book");
                return false;
            }

            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}