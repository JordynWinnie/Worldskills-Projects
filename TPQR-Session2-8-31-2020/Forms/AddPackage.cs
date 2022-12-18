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

namespace TPQR_Session2_8_31_2020
{
    public partial class AddPackage : Form
    {
        private Session2Entities context = new Session2Entities();
        private int numberChecked = 0;

        public AddPackage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddPackage_Load(object sender, EventArgs e)
        {
            var tierList = new List<string> { "Gold", "Silver", "Bronze" };
            tierCb.Items.AddRange(tierList.ToArray());
            tierCb.SelectedIndex = 0;
        }

        private void addPackageBtn_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                var insertPackage = new Package
                {
                    packageName = packageNametb.Text,
                    packageQuantity = (int)quantityNUD.Value,
                    packageTier = tierCb.SelectedItem.ToString(),
                    packageValue = (long)valueNUD.Value
                };

                context.Packages.Add(insertPackage);
                context.SaveChanges();

                MessageBox.Show("Package added");
            }
        }

        private bool Validation()
        {
            switch (tierCb.SelectedItem.ToString())
            {
                case "Gold":
                    if (valueNUD.Value < 50_000)
                    {
                        MessageBox.Show("Gold packages must be $50,000 or above in value");
                        return false;
                    }
                    if (numberChecked != 3)
                    {
                        MessageBox.Show("Gold packages must have 3 benefits");
                        return false;
                    }
                    break;

                case "Silver":
                    if (valueNUD.Value < 10_000 || valueNUD.Value > 50_000)
                    {
                        MessageBox.Show("Silver packages must be between $10,000 - $50,000 in value");
                        return false;
                    }

                    if (numberChecked != 2)
                    {
                        MessageBox.Show("Silver packages must have only 2 benefits");
                        return false;
                    }
                    break;

                case "Bronze":
                    if (valueNUD.Value > 10_000)
                    {
                        MessageBox.Show("Bronze packages must be $10,000 or below in value");
                        return false;
                    }

                    if (numberChecked != 1)
                    {
                        MessageBox.Show("Bronze packages must have only 1 benefit");
                        return false;
                    }
                    break;

                default:
                    break;
            }

            if (quantityNUD.Value == 0)
            {
                MessageBox.Show("Quantity cannot be 0");
                return false;
            }

            if (packageNametb.Text.Equals(string.Empty))
            {
                MessageBox.Show("Package Name cannot be empty");
                return false;
            }

            return true;
        }

        private void onlineCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
                numberChecked++;
            else
                numberChecked--;

            Console.WriteLine(numberChecked);
        }

        private void flyerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
                numberChecked++;
            else
                numberChecked--;
            Console.WriteLine(numberChecked);
        }

        private void bannerCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
                numberChecked++;
            else
                numberChecked--;
            Console.WriteLine(numberChecked);
        }

        private void clearFormBtn_Click(object sender, EventArgs e)
        {
            packageNametb.Text = string.Empty;
            valueNUD.Value = 0;
            quantityNUD.Value = 0;
            onlineCheckbox.Checked = false;
            flyerCheckBox.Checked = false;
            bannerCheckbox.Checked = false;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { RestoreDirectory = true, DefaultExt = "*csv" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(string.Empty))
            {
                MessageBox.Show("File path is empty");
                return;
            }

            var fileText = File.ReadAllLines(textBox1.Text);
            var filesAppended = 0;
            try
            {
                for (int i = 0; i < fileText.Length; i++)
                {
                    if (i == 0) continue;
                    var row = fileText[i].Split(',');

                    var packageTier = row[0];
                    var packageName = row[1];
                    var packageValue = row[2];
                    var packageQuantity = row[3];

                    if (!context.Packages.Where(x => x.packageName == packageName).Any())
                    {
                        var insertPackage = new Package
                        {
                            packageName = packageName,
                            packageTier = packageTier,
                            packageQuantity = int.Parse(packageQuantity),
                            packageValue = long.Parse(packageValue)
                        };
                        filesAppended++;
                        context.Packages.Add(insertPackage);
                        context.SaveChanges();
                    }
                }

                MessageBox.Show($"{filesAppended} packages uploaded. ({fileText.Length - 1 - filesAppended} Duplicates found)");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}