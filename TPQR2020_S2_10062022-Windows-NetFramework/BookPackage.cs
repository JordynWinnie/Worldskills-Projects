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
    public partial class BookPackage : Form
    {
        private List<IGrouping<string, Package>> tierList;
        private List<IGrouping<string, Benefit>> benefitsList;
        private int selectedPackageID = -1;
        private User currentUser;

        public BookPackage(User user = null)
        {
            this.currentUser = user;    
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BookPackage_Load(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                var columns = new List<string>
                {
                    "PackageID", "Tier", "Name", "Value ($)", "Available Qty", "Online", "Flyer", "Banner", 
                };

                columns.ForEach(x => packageDGV.Columns.Add(x, x));
                packageDGV.Columns[0].Visible = false;

                tierList = context.Packages.GroupBy(x=>x.packageTier).ToList();
                tierCb.Items.Add("No Filter");
                tierCb.Items.AddRange(tierList.Select(x=>x.Key).ToArray());

                tierCb.SelectedIndex = 0;

                benefitsList = context.Benefits.GroupBy(x=>x.benefitName).ToList();
                benefitsCheckList.Items.AddRange(benefitsList.Select(x=>x.Key).ToArray());

            }
        }

        private void RefreshList()
        {
            using (var context = new Session2Entities())
            {
                packageDGV.Rows.Clear();
                var packages = context.Benefits.GroupBy(x => x.Package).ToList();

                if (tierCb.SelectedItem.ToString() != "No Filter")
                {
                    packages = packages.Where(x=>x.Key.packageTier == tierCb.SelectedItem.ToString()).ToList();
                }

                if (filterByBudget.Value > 0)
                {
                    packages = packages.Where(x=>x.Key.packageValue <= filterByBudget.Value).ToList();
                }

                if (benefitsCheckList.CheckedItems.Count > 0)
                {
                    foreach (string benefit in benefitsCheckList.CheckedItems)
                    {
                        packages = packages.Where(x=>x.Key.Benefits.Select(y=>y.benefitName).Contains(benefit)).ToList();
                    }
                }
                packages = packages.OrderBy(x => x.Key.packageName).Where(x => x.Key.packageQuantity != 0).ToList();

                foreach (var package in packages)
                {
                    var row = new List<string>();
                    row.Add(package.Key.packageId.ToString());
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

        private void tierCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void filterByBudget_ValueChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void benefitsCheckList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void benefitsCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void benefitsCheckList_Click(object sender, EventArgs e)
        {
            
        }

        private void benefitsCheckList_MouseUp(object sender, MouseEventArgs e)
        {
            RefreshList();
        }

        private void packageDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedPackageID = int.Parse(packageDGV[0, e.RowIndex].Value.ToString());
            Console.WriteLine(selectedPackageID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (desiredQty.Value == 0)
            {
                MessageBox.Show("Please enter a booking quantity of more than 0");
                return;
            }

            if (selectedPackageID == -1)
            {
                MessageBox.Show("Please select a package");
                return;
            }
            using (var context = new Session2Entities())
            {
                var package = context.Packages.Where(x=>x.packageId == selectedPackageID).First();

                if (desiredQty.Value > package.packageQuantity)
                {
                    MessageBox.Show("There isn't enough of this package for your current booking.");
                    return;
                }

                var newBooking = new Booking
                {
                    packageIdFK = package.packageId,
                    quantityBooked = (int)desiredQty.Value,
                    status = "Pending",
                    userIdFK = currentUser.userId
                };

                context.Bookings.Add(newBooking);
                
                package.packageQuantity -= (int)desiredQty.Value;

                context.SaveChanges();

                MessageBox.Show("Booking made");

                Close();
            }
        }

        private void packageDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
