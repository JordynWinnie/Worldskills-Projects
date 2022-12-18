using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session2_JordanKhong.Forms
{
    public partial class BookPackageForm : Form
    {
        //Global Variables to store PackageID and CurrentUser
        int currentPackageID = -1;
        string currentUserID = "";
        public BookPackageForm(string _userID)
        {
            currentUserID = _userID;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BookPackageForm_Load(object sender, EventArgs e)
        {
            //Makes DGV readonly as they should not be able to change anything:
            packagesDGV.ReadOnly = true;
            using (var context = new Session2Entities())
            {

                //Populate Combobox:
                tierCb.Items.Add("No Filter");
                tierCb.Items.AddRange(context.Packages.Select(x => x.packageTier).Distinct().ToArray());

                //Populate Columns
                List<string> columns = new List<string>
                {
                    "Tier",
                    "Name",
                    "Value",
                    "Available Qty",
                    "Online",
                    "Flyer",
                    "Banner",
                    "PackageID"
                };

                foreach (var column in columns)
                {
                    packagesDGV.Columns.Add(column, column);
                }

                packagesDGV.Columns[7].Visible = false;
                RefreshList();
                tierCb.SelectedIndex = 0;
            }
        }

        void RefreshList()
        {

            #region Populates Rows with respective packages:
            packagesDGV.Rows.Clear();
            using (var context = new Session2Entities())
            {
                var tableinfo = from x in context.Packages
                                select new
                                {
                                    Tier = x.packageTier,
                                    Name = x.packageName,
                                    Value = x.packageValue,
                                    AvailQnty = x.packageQuantity,
                                    Benefit = x.Benefits,
                                    PackageID = x.packageId
                                };

                foreach (var item in tableinfo)
                {
                    //Population of the rows:

                    //1. Checks if item has quantity more than 0
                    if (item.AvailQnty > 0)
                    {
                        Console.WriteLine(item.Name);
                        List<string> row = new List<string>
                    {
                        item.Tier,
                        item.Name,
                        item.Value.ToString(),
                        item.AvailQnty.ToString(),
                    };

                        //2. Adds the list of benefits into a string list called benefits
                        var benefits = new List<string>();


                        foreach (var benefit in item.Benefit)
                        {
                            benefits.Add(benefit.benefitName);
                        }

                        //3. Checks if the various benefits are in the benefits list, if it is, add a "Yes", if not, leave it blank.
                        #region Population Benefits:
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
                        #endregion

                        
                        row.Add(item.PackageID.ToString());

                        //adds row to DGV
                        packagesDGV.Rows.Add(row.ToArray());
                    }

                }
            }
            #endregion

        }

        private void tierCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                
                RefreshList();


                //Hides any row that doesn't have the same tier name as the one selected by the combobox:
                if (!tierCb.SelectedItem.Equals("No Filter"))
                {
                    foreach (DataGridViewRow row in packagesDGV.Rows)
                    {
                        if (!row.Cells[0].Value.Equals(tierCb.SelectedItem))
                        {
                            row.Visible = false;
                        }
                    }
                }

            }
        }

        private void budgetTb_TextChanged(object sender, EventArgs e)
        {
            RefreshList();

            //Hides any row that doesn't have the same tier name as the one selected by the combobox:
            if (!budgetTb.Text.Equals(string.Empty))
            {
                try
                {
                    
                    var currentNumber = Convert.ToInt32(budgetTb.Text);

                    foreach (DataGridViewRow row in packagesDGV.Rows)
                    {
                        if (!(Convert.ToInt32(row.Cells[2].Value) <= currentNumber))
                        {
                            row.Visible = false;
                        }
                    }
                }
                catch (Exception)
                {
                    //Tells user to enter valid number if ConvertToInt32 Fails:
                    MessageBox.Show("Number entered is not a valid number");
                    budgetTb.Text = "0";
                }
                
                
            }

        }

        private void onlineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
            //Hides any row that doesn't have the "yes" at the online column
            
            if (onlineCheckBox.Checked)
            {
                foreach (DataGridViewRow row in packagesDGV.Rows)
                {
                    if (!row.Cells[4].Value.Equals("Yes"))
                    {
                        row.Visible = false;
                    }
                }
            }


        }

        private void flyersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
            //Hides any row that doesn't have the "yes" at the flyers column
            if (flyersCheckBox.Checked)
            {
                foreach (DataGridViewRow row in packagesDGV.Rows)
                {
                    if (!row.Cells[5].Value.Equals("Yes"))
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void bannerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
            //Hides any row that doesn't have the "yes" at the banner column
            if (bannerCheckBox.Checked)
            {
                foreach (DataGridViewRow row in packagesDGV.Rows)
                {
                    if (!row.Cells[6].Value.Equals("Yes"))
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void BookBtn_Click(object sender, EventArgs e)
        {
            //If you click book without selecting a cell item, the global variable is initialised as -1
            //this is used as a check to make the user click on a cell item to book
            if (currentPackageID == -1)
            {
                MessageBox.Show("Please select an item");
            }
            else
            {
                //Check Quantity from db:
                //While loop keeps running till either database save, or an error occurs:
                while (true)
                {
                    using (var context = new Session2Entities())
                    {
                        #region Validation Check
                        var currentQuantity = context.Packages.Where(x => x.packageId == currentPackageID).Select(x => x.packageQuantity).First();

                        try
                        {
                            var requestedQuantity = Convert.ToInt32(quantityTb.Text);

                            if (requestedQuantity > currentQuantity)
                            {
                                MessageBox.Show("There isn't enough of the current package to book this order");
                                break;
                            }
                            if (requestedQuantity <= 0)
                            {
                                MessageBox.Show("Quantity should be more than zero");
                                break;
                            }

                            #endregion

                            //Updates package quantity:
                            var getPackage = context.Packages.Where(x => x.packageId == currentPackageID).First();

                            getPackage.packageQuantity = currentQuantity - requestedQuantity;

                            //Makes a new booking:
                            Booking insertBooking = new Booking
                            {
                                userIdFK = currentUserID,
                                packageIdFK = currentPackageID,
                                quantityBooked = requestedQuantity,
                                status = "Pending"
                            };

                            context.Bookings.Add(insertBooking);

                        }
                        catch (Exception)
                        {
                            //If ConvertInt32 fails, ask user to enter valid number
                            MessageBox.Show("Please enter a valid number");
                            break;
                        }

                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Booking requested c:");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while saving. Details: \n" + ex.Message);
                            break;
                        }

                        break;
                    }
                }

            }
        }

        private void packagesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Sets global variable currentPackageID to hidden column with package ID
            if (e.RowIndex >= 0)
            {
                currentPackageID = Convert.ToInt32(packagesDGV.Rows[e.RowIndex].Cells[7].Value);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
