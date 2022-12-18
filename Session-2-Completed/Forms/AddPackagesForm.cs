using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Session2_JordanKhong.Forms
{
    public partial class AddPackagesForm : Form
    {
        public AddPackagesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            //Opens the file dialog when you click on the textbox:
            OpenFileDialog op = new OpenFileDialog
            {
                DefaultExt = ".csv"
            };

            var result = op.ShowDialog();

            if (result == DialogResult.OK)
            {
                filePathTb.Text = op.FileName;
            }
        }

        private void clearFormBtn_Click(object sender, EventArgs e)
        {
            //Clears entire form by:
            //1: Clearing the Combobox, repopulating it.
            //2: Making all the Textboxes empty
            //3: Clearing the benefits check list, and repopulating it
            tierCb.Items.Clear();
            using (var context = new Session2Entities())
            {
                tierCb.Items.AddRange(context.Packages.Select(x => x.packageTier).Distinct().ToArray());
                tierCb.SelectedIndex = 0;
                packageNameTb.Text = string.Empty;
                valueTb.Text = string.Empty;
                availQntyTb.Text = string.Empty;
                benefitsCheckList.Items.Clear();
                benefitsCheckList.Items.AddRange(context.Benefits.Select(x => x.benefitName).Distinct().ToArray());

            }


        }

        private void AddPackagesForm_Load(object sender, EventArgs e)
        {
            //Populates benefits checklist and tier combobox
            using (var context = new Session2Entities())
            {
                tierCb.Items.AddRange(context.Packages.Select(x => x.packageTier).Distinct().ToArray());
                tierCb.SelectedIndex = 0;
                benefitsCheckList.Items.Clear();
                benefitsCheckList.Items.AddRange(context.Benefits.Select(x => x.benefitName).Distinct().ToArray());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                while (true)
                {
                    #region Validation Checks:
                    var checkForSameName = context.Packages.Where(x => x.packageName.Equals(packageNameTb.Text)).Any();

                    //Check for duplicate name:
                    if (checkForSameName)
                    {
                        MessageBox.Show("Package can't have the same name as an existing package!");

                        break;
                    }
                    //Check for appropriate Value:

                    try
                    {
                        var currentValue = Convert.ToInt64(valueTb.Text);

                        #region Validation for Bronze Tier:
                        if (tierCb.SelectedItem.Equals("Bronze"))
                        {
                            Console.WriteLine("Bronze Comp");
                            if (currentValue > 10000)
                            {
                                MessageBox.Show("Bronze Tier value cannot be more than $10,000");
                                break;
                            }

                            if (benefitsCheckList.CheckedItems.Count < 1 || benefitsCheckList.CheckedItems.Count >= 2)
                            {
                                MessageBox.Show("Bronze Tier should have one benefit");
                                break;
                            }

                        }
                        #endregion

                        #region Validation for Silver tier:
                        else if (tierCb.SelectedItem.Equals("Silver"))
                        {
                            Console.WriteLine("Silver Comp");

                            if (currentValue < 10000 || currentValue > 50000)
                            {
                                MessageBox.Show("Silver Tier value must be between $10,000 and $50,000");
                                break;
                            }

                            if (benefitsCheckList.CheckedItems.Count < 2 || benefitsCheckList.CheckedItems.Count >= 3)
                            {
                                MessageBox.Show("Silver Tier should have two benefits");
                                break;
                            }
                        }
                        #endregion

                        #region Validation for Gold Tier:
                        else
                        {
                            Console.WriteLine("Gold Comp");

                            if (currentValue < 50000)
                            {
                                MessageBox.Show("Gold Tier value must be above $50,000");
                                break;
                            }

                            if (benefitsCheckList.CheckedItems.Count < 3 || benefitsCheckList.CheckedItems.Count >= 4)
                            {
                                MessageBox.Show("Gold Tier should have three benefits");
                                break;
                            }
                        }
                        #endregion
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Enter a valid value");
                        break;
                    }

                    try
                    {
                        #region Validation for Quantity To Add:
                        var currentQuantity = Convert.ToInt64(availQntyTb.Text);

                        if (currentQuantity <= 0)
                        {
                            MessageBox.Show("Quantity must be greater than zero");
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Enter a valid quantity");
                        break;
                    }
                    #endregion

                    if (packageNameTb.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Package name shouldn't be empty");
                        break;
                    }
                    #endregion

                    #region Inserting into database:
                    var insertPackage = new Package
                    {
                        packageTier = tierCb.SelectedItem.ToString(),
                        packageName = packageNameTb.Text,
                        packageValue = Convert.ToInt64(valueTb.Text),
                        packageQuantity = Convert.ToInt32(availQntyTb.Text)
                    };
                    context.Packages.Add(insertPackage);

                    context.SaveChanges();

                    //Add the relavent selected benefits:
                    var latestPackageID = context.Packages.OrderByDescending(x => x.packageId).Select(x => x.packageId).First();

                    foreach (var benefit in benefitsCheckList.CheckedItems)
                    {
                        var insertBenefit = new Benefit
                        {
                            packageIdFK = latestPackageID,
                            benefitName = benefit.ToString()
                        };
                        context.Benefits.Add(insertBenefit);
                    }

                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Changes saved");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving to database. Details:\n" + ex.Message);
                    }

                    break;
                    #endregion
                }
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                try
                {
                    using (var stream = new StreamReader(filePathTb.Text))
                    {
                        #region File Reading logic:
                        //Skips a line first (column names)
                        stream.ReadLine();
                        while (!stream.EndOfStream)
                        {
                            var rowInfo = stream.ReadLine();
                            var cellInfo = rowInfo.Split(',');

                            //Check if package is currently in DB:
                            var packageName = cellInfo[1];
                            var getPackageDuplicate = context.Packages.Where(x => x.packageName.Equals(packageName)).Any();

                            if (!getPackageDuplicate)
                            {
                                //Inserts based on csv info:
                                var insertPackage = new Package
                                {
                                    packageTier = cellInfo[0].Trim(),
                                    packageName = cellInfo[1].Trim(),
                                    packageValue = Convert.ToInt64(cellInfo[2].Trim()),
                                    packageQuantity = Convert.ToInt32(cellInfo[3].Trim())
                                };

                                context.Packages.Add(insertPackage);
                            }
                        }
                        #endregion

                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Data Successfully appended!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error saving changes. Details:\n" + ex.Message);

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file. Details:\n" + ex.Message);
                }

                

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
