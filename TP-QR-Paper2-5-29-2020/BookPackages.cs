using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TP_QR_Paper2_5_29_2020
{
    public partial class BookPackages : Form
    {
        private int selectedPackageId = -1;
        private string _currentUserID;

        public BookPackages(string userIDFK)
        {
            _currentUserID = userIDFK;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BookPackages_Load(object sender, EventArgs e)
        {
            var columns = new List<string>()
            {
                "Tier", "Name", "Value", "Available Qty", "Online", "Flyer", "Banner", "PackageID"
            };

            foreach (var column in columns)
            {
                packageDGV.Columns.Add(column, column);
            }

            var tierList = new List<string>()
            {
                "None",
                "Bronze",
                "Silver",
                "Gold"
            };

            tierComboBox.Items.AddRange(tierList.ToArray());
            tierComboBox.SelectedIndex = 0;

            UpdateDGV();
        }

        private void UpdateDGV()
        {
            packageDGV.Rows.Clear();
            using (var context = new Session2Entities())
            {
                var baseQuery = (from x in context.Packages
                                 orderby x.packageName
                                 where x.packageQuantity > 0
                                 select x).ToList();

                var tierSelected = tierComboBox.SelectedItem.ToString();

                if (!tierSelected.Equals("None"))
                {
                    baseQuery = (from x in baseQuery
                                 where x.packageTier.Equals(tierSelected)
                                 select x).ToList();
                }

                if (textBox1.Text.Length != 0)
                {
                    int finalNumber = 0;
                    if (int.TryParse(textBox1.Text, out finalNumber))
                    {
                        baseQuery = (from x in baseQuery
                                     where x.packageValue <= finalNumber
                                     select x).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number");
                    }
                }

                if (onlineCheckBox.Checked)
                {
                    var currList = new List<Package>();
                    foreach (var package in baseQuery)
                    {
                        if (package.Benefits.Where(x => x.benefitName.Equals("Online")).Any())
                        {
                            currList.Add(package);
                        }
                    }

                    baseQuery = currList;
                }

                if (flyerCheckBox.Checked)
                {
                    var currList = new List<Package>();
                    foreach (var package in baseQuery)
                    {
                        if (package.Benefits.Where(x => x.benefitName.Equals("Flyer")).Any())
                        {
                            currList.Add(package);
                        }
                    }

                    baseQuery = currList;
                }

                if (bannerCheckBox.Checked)
                {
                    var currList = new List<Package>();
                    foreach (var package in baseQuery)
                    {
                        if (package.Benefits.Where(x => x.benefitName.Equals("Banner")).Any())
                        {
                            currList.Add(package);
                        }
                    }

                    baseQuery = currList;
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

        private void tierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void onlineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void flyerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void bannerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void packageDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedPackageId = int.Parse(packageDGV.Rows[e.RowIndex].Cells[7].Value.ToString());
            Console.WriteLine("PackageID: " + selectedPackageId);
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                int finalNumber = 0;

                if (int.TryParse(quantityTb.Text, out finalNumber))
                {
                    if (finalNumber <= 0)
                    {
                        MessageBox.Show("Please enter a quantity that's more than zero");
                    }
                    else
                    {
                        if (selectedPackageId != -1)
                        {
                            var packageAmount = context.Packages.Where(x => x.packageId == selectedPackageId).
                            Select(x => x.packageQuantity).FirstOrDefault();

                            if (finalNumber <= packageAmount)
                            {
                                //Proceed with trasaction
                                AttemptBooking();
                            }
                            else
                            {
                                MessageBox.Show("There are insufficient packages available");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a package");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid quantity");
                }
            }
        }

        private void AttemptBooking()
        {
            var insertBooking = new Booking
            {
                userIdFK = _currentUserID.ToString(),
                packageIdFK = selectedPackageId,
                quantityBooked = int.Parse(quantityTb.Text),
                status = "Pending"
            };

            using (var context = new Session2Entities())
            {
                var packageToChange = context.Packages.Where(x => x.packageId == selectedPackageId).First();
                packageToChange.packageQuantity -= int.Parse(quantityTb.Text);

                context.Bookings.Add(insertBooking);
                context.SaveChanges();
            }

            MessageBox.Show("Booking Successful");
            UpdateDGV();
        }
    }
}