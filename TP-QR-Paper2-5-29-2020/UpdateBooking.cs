using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_QR_Paper2_5_29_2020
{
    public partial class UpdateBooking : Form
    {
        private string _currentUserID;
        private int selectedPackageID;
        private int selectedBookingID;

        public UpdateBooking(string userIDFK)
        {
            _currentUserID = userIDFK;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateBooking_Load(object sender, EventArgs e)
        {
            var columns = new List<string>()
            {
                "Tier","Name","Individual Value ($)", "Quantity Boooked", "Subtotal", "BookingID", "PackageID"
            };

            foreach (var column in columns)
            {
                packageDGV.Columns.Add(column, column);
            }

            UpdateDGV();
        }

        private void UpdateDGV()
        {
            packageDGV.Rows.Clear();
            using (var context = new Session2Entities())
            {
                long totalValue = 0;
                var bookings = context.Bookings.OrderBy(x => x.Package.packageTier).ThenBy(x => x.Package.packageValue)
                    .Where(x => x.userIdFK == _currentUserID && x.status.Equals("Approved"));

                foreach (var booking in bookings)
                {
                    var row = new List<string>()
                    {
                        booking.Package.packageTier,
                        booking.Package.packageName,
                        booking.Package.packageValue.ToString(),
                        booking.quantityBooked.ToString(),
                        (booking.quantityBooked * booking.Package.packageValue).ToString(),
                        booking.bookingId.ToString(),
                        booking.Package.packageId.ToString()
                    };
                    totalValue += booking.quantityBooked * booking.Package.packageValue;
                    packageDGV.Rows.Add(row.ToArray());
                }
                totalLbl.Text = totalValue.ToString();
            }
        }

        private void updateQtyBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                int finalNumber = 0;

                if (int.TryParse(quantityTb.Text, out finalNumber))
                {
                    if (finalNumber <= 0)
                    {
                        MessageBox.Show("Please enter a quantity that's more than zero");
                        if (finalNumber == 0)
                        {
                            MessageBox.Show("Please use the delete function instead to reduce quantity to 0");
                        }
                    }
                    else
                    {
                        if (selectedPackageID != -1)
                        {
                            var packageAmount = context.Packages.Where(x => x.packageId == selectedPackageID).
                            Select(x => x.packageQuantity).FirstOrDefault();

                            var bookingAmount = context.Bookings.Where(x => x.bookingId == selectedBookingID).
                                Select(x => x.quantityBooked).FirstOrDefault();

                            var amountToExtraBook = finalNumber - bookingAmount;

                            if (amountToExtraBook <= packageAmount)
                            {
                                AttemptChangeBooking();
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

        private void AttemptChangeBooking()
        {
            using (var context = new Session2Entities())
            {
                var package = context.Packages.Where(x => x.packageId == selectedPackageID).First();

                var booking = context.Bookings.Where(x => x.bookingId == selectedBookingID).First();

                var amountToExtraBook = int.Parse(quantityTb.Text) - booking.quantityBooked;

                package.packageQuantity -= amountToExtraBook;
                booking.quantityBooked += amountToExtraBook;

                context.SaveChanges();
                MessageBox.Show("Booking updated");
                UpdateDGV();
            }
        }

        private void packageDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedBookingID = int.Parse(packageDGV.Rows[e.RowIndex].Cells[5].Value.ToString());
            selectedPackageID = int.Parse(packageDGV.Rows[e.RowIndex].Cells[6].Value.ToString());

            Console.WriteLine("PackageID: " + selectedPackageID + " BookingID: " + selectedBookingID);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                if (context.Bookings.Where(x => x.packageIdFK == selectedPackageID && x.userIdFK != _currentUserID).Any())
                {
                    MessageBox.Show("Unable to delete, package currently booked by other sponsors also");
                }
                else
                {
                    var package = context.Packages.Where(x => x.packageId == selectedPackageID).First();

                    var booking = context.Bookings.Where(x => x.bookingId == selectedBookingID).First();

                    context.Bookings.Remove(booking);
                    package.packageQuantity += booking.quantityBooked;
                    context.SaveChanges();
                    MessageBox.Show("Deleted.");
                    UpdateDGV();
                }
            }
        }
    }
}