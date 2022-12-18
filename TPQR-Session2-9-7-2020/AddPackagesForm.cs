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

namespace TPQR_Session2_9_7_2020
{
    public partial class AddPackagesForm : Form
    {
        private int numberOfChecked = 0;
        private Session2Entities context = new Session2Entities();

        public AddPackagesForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void desiredQtyNUD_ValueChanged(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void AddPackagesForm_Load(object sender, EventArgs e)
        {
            tierCb.Items.AddRange(context.Packages.Select(x => x.packageTier).Distinct().ToArray());
            tierCb.SelectedIndex = 0;
        }

        private void addPackage_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                var newPackage = new Package
                {
                    packageName = packageNameTb.Text,
                    packageQuantity = (int)qtyNUD.Value,
                    packageTier = tierCb.SelectedItem.ToString(),
                    packageValue = (int)valueNUD.Value
                };

                context.Packages.Add(newPackage);

                if (onlineCheck.Checked)
                {
                    var benefit = new Benefit
                    {
                        benefitName = "Online",
                        packageIdFK = newPackage.packageId
                    };
                    context.Benefits.Add(benefit);
                }
                if (bannerCheck.Checked)
                {
                    var benefit = new Benefit
                    {
                        benefitName = "Banner",
                        packageIdFK = newPackage.packageId
                    };
                    context.Benefits.Add(benefit);
                }

                if (flyerCheck.Checked)
                {
                    var benefit = new Benefit
                    {
                        benefitName = "Flyer",
                        packageIdFK = newPackage.packageId
                    };
                    context.Benefits.Add(benefit);
                }

                context.SaveChanges();
                MessageBox.Show("Package Added");
            }
        }

        private bool Validation()
        {
            Console.WriteLine(numberOfChecked);
            var selectedTier = tierCb.SelectedItem.ToString();

            if (qtyNUD.Value == 0)
            {
                MessageBox.Show("Quantity must more than zero");
                return false;
            }

            if (context.Packages.Where(x => x.packageName == packageNameTb.Text).Any())
            {
                MessageBox.Show("Package name cannot be repeated");
                return false;
            }
            switch (selectedTier)
            {
                case "Bronze":
                    if (valueNUD.Value > 10_000)
                    {
                        MessageBox.Show("Bronze packages must be less than $10,000 in value");
                        return false;
                    }

                    if (numberOfChecked != 1)
                    {
                        MessageBox.Show("Bronze can only have one benefit");
                        return false;
                    }
                    break;

                case "Silver":
                    if (valueNUD.Value < 10_000 || valueNUD.Value > 50_000)
                    {
                        MessageBox.Show("Silver packages must be between $10,000 - $50,000 in value");
                        return false;
                    }

                    if (numberOfChecked != 2)
                    {
                        MessageBox.Show("Silver can only have two benefits");
                        return false;
                    }
                    break;

                case "Gold":
                    if (valueNUD.Value < 50_000)
                    {
                        MessageBox.Show("Gold packages must be more than $50,000 in value");
                        return false;
                    }

                    if (numberOfChecked != 3)
                    {
                        MessageBox.Show("Gold needs three benefits");
                        return false;
                    }
                    break;

                default:
                    break;
            }

            if (packageNameTb.TextLength == 0)
            {
                MessageBox.Show("Name cannot be blank");
                return false;
            }

            return true;
        }

        private void bannerCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                numberOfChecked++;
            }
            else
            {
                numberOfChecked--;
            }
        }

        private void flyerCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                numberOfChecked++;
            }
            else
            {
                numberOfChecked--;
            }
        }

        private void onlineCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                numberOfChecked++;
            }
            else
            {
                numberOfChecked--;
            }
        }

        private void clearForm_Click(object sender, EventArgs e)
        {
            tierCb.SelectedIndex = 0;
            onlineCheck.Checked = false;
            bannerCheck.Checked = false;
            flyerCheck.Checked = false;
            packageNameTb.Text = string.Empty;
            qtyNUD.Value = 0;
            valueNUD.Value = 0;
        }

        private void filePathTb_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                DefaultExt = "*csv",
                RestoreDirectory = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePathTb.Text = ofd.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePathTb.Text))
            {
                MessageBox.Show("Select a file");
                return;
            }

            if (!filePathTb.Text.Contains(".csv"))
            {
                MessageBox.Show("File not supported. Please only choose .csv files");
                return;
            }

            var file = File.ReadAllLines(filePathTb.Text).Skip(1);

            foreach (var line in file)
            {
                var row = line.Split(',');

                var tier = row[0];
                var name = row[1];
                var value = int.Parse(row[2]);
                var qty = int.Parse(row[3]);

                if (!context.Packages.Where(x => x.packageName == name).Any())
                {
                    var insertPackage = new Package
                    {
                        packageTier = tier,
                        packageName = name,
                        packageValue = value,
                        packageQuantity = qty
                    };

                    context.Packages.Add(insertPackage);
                }
            }

            context.SaveChanges();
            MessageBox.Show("Changes appended");
        }
    }
}