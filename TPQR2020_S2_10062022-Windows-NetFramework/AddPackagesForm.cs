using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR2020_S2_10062022_Windows_NetFramework
{
    public partial class AddPackagesForm : Form
    {
        public AddPackagesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddPackagesForm_Load(object sender, EventArgs e)
        {
            var tiers = new List<string>
            {
                "Bronze", "Silver", "Gold"
            };

            tierCb.Items.AddRange(tiers.ToArray());
            tierCb.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            packageNameTb.Text = string.Empty;
            valueNUD.Value = 0;
            qtyNUD.Value = 0;

            foreach (int selection in benefitsCheckList.CheckedIndices)
            {                
                benefitsCheckList.SetItemCheckState(selection, CheckState.Unchecked);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var benefits = new List<string>();
            foreach (string item in benefitsCheckList.CheckedItems)
            {
                benefits.Add(item);
            }

            if (packageNameTb.TextLength == 0 )
            {
                MessageBox.Show("Please enter a package name");
                return;
            }

            if (qtyNUD.Value == 0)
            {
                MessageBox.Show("Quantity should be more than zero");
                return;
            }
            var errorMessage = "";

            var added = AddPackage(packageNameTb.Text, tierCb.SelectedItem.ToString(), (long)valueNUD.Value, (int)qtyNUD.Value, benefits, out errorMessage);

            if (!added)
            {
                MessageBox.Show(errorMessage);
            }
        }

        bool AddPackage(string packageName, string packageTier,long packagePrice, int quantity, IEnumerable<string> benefits, out string errorMessage) 
        { 
            errorMessage = string.Empty;

            using (var context = new Session2Entities())
            {
                if (context.Packages.Any(x=>x.packageName == packageName))
                {
                    errorMessage = "Package name cannot be repeated";
                    return false;
                }

                if (packageTier == "Gold" )
                {
                    if (packagePrice < 50_000)
                    {
                        errorMessage = "Gold Package cannot be lower than $50,000 in value";
                        return false;
                    }

                    if (benefits.Count() != 3)
                    {
                        errorMessage = "Gold Package should have 3 benefits";
                        return false;
                    }
                }

                if (packageTier == "Silver")
                {
                    if (packagePrice > 50_000 || packagePrice < 10_000)
                    {
                        errorMessage = "Silver Package should be between $10,000 and $50,000 in value";
                        return false;
                    }

                    if (benefits.Count() != 2)
                    {
                        errorMessage = "Silver Package should only have 2 benefits";
                        return false;
                    }
                }

                if (packageTier == "Bronze")
                {
                    if (packagePrice > 10_000)
                    {
                        errorMessage = "Bronze should be lower than $10,000 in value";
                        return false;
                    }

                    if (benefits.Count() != 1)
                    {
                        errorMessage = "Bronze Package should only have 1 benefit";
                        return false;
                    }
                }
            
                var package = new Package
                {
                    packageName = packageName,
                    packageTier = packageTier,
                    packageValue = packagePrice,
                    packageQuantity = quantity
                };

                context.Packages.Add(package);
                context.SaveChanges();

                foreach (var benefit in benefits)
                {
                    var newbenefit = new Benefit
                    {
                        benefitName = benefit,
                        packageIdFK = package.packageId
                    };

                    context.Benefits.Add(newbenefit);
                }

                context.SaveChanges();
            }
            
            
            return true;
        }
            
        private void textBox1_Click(object sender, EventArgs e)
        {
            filePathTb.Text = string.Empty;
            var fileDialog = new OpenFileDialog
            {
                Filter = "Comma Seperated Values | *.csv"
            };

            var fileDig = fileDialog.ShowDialog();
            if (fileDig == DialogResult.OK)
            {
                filePathTb.Text = fileDialog.FileName;
            }

        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            if (filePathTb.Text == string.Empty)
            {
                MessageBox.Show("Please select a file");
                return;
            }

            var excelFile = File.ReadLines(filePathTb.Text);
            excelFile = excelFile.Skip(1);
            var errors = new StringBuilder();
            var lineNumber = 1;
            foreach (var line in excelFile)
            {
                
                try
                {
                    var row = line.Split(',');
                    var packageTier = row[0];
                    var packageName = row[1];
                    var packageValue = long.Parse(row[2]);
                    var packageQty = int.Parse(row[3]);

                    var benefits = new List<string>();

                    if (packageTier == "Gold") benefits.AddRange(new string[] { "Online", "Flyer", "Banner" });

                    if (packageTier == "Silver") benefits.AddRange(new string[] { "Online", "Flyer" });

                    if (packageTier == "Bronze") benefits.AddRange(new string[] { "Online" });

                    var added = AddPackage(packageName, packageTier, packageValue, packageQty, benefits, out var errorMessage);

                    if (!added)
                    {
                        errors.AppendLine($"Row {lineNumber}: {errorMessage}");
                    }

                    
                }
                catch (Exception)
                {
                    errors.AppendLine($"Row {lineNumber}: Error reading information, please check that the numbers are formatted correctly");
                    
                }
                lineNumber += 1;
            }

            if (errors.Length != 0)
            {
                MessageBox.Show($"Added with errors: \n{errors.ToString()}");
            }
            else
            {
                MessageBox.Show("Successfully added all data");
            }
        }
    }
}
