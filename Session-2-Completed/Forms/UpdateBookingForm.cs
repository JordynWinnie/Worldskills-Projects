using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session2_JordanKhong.Forms
{
    public partial class UpdateBookingForm : Form
    {
        string _userId = "";
        long _selectedBookingId = -1;
        public UpdateBookingForm(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateBookingForm_Load(object sender, EventArgs e)
        {
            //new list with all column names:
            var columns = new List<string>
                {
                    "Tier", "Name", "Individual Value","Quantity Booked", "Subtotal Value","BookingID(DEBUG)"
                };

            //populate DGV with all columns:
            foreach (var column in columns)
            {
                packagesDGV.Columns.Add(column, column);
            }

            packagesDGV.Columns[5].Visible = false;
            RefreshList();
        }

        void RefreshList()
        {

            using (var context = new Session2Entities())
            {
                #region Table Population:
                packagesDGV.Rows.Clear();

                var tableInfo = from x in context.Bookings
                                where x.userIdFK.Equals(_userId) && x.status.Equals("Approved")
                                select new
                                {
                                    Tier = x.Package.packageTier,
                                    Name = x.Package.packageName,
                                    IndivValue = x.Package.packageValue,
                                    Quantity = x.quantityBooked,
                                    SubtotalValue = x.quantityBooked * x.Package.packageValue,
                                    BookingId = x.bookingId
                                };

                //Adds all the data into the table:
                foreach (var item in tableInfo)
                {
                    List<string> row = new List<string>
                    {
                        item.Tier,
                        item.Name,
                        item.IndivValue.ToString(),
                        item.Quantity.ToString(),
                        item.SubtotalValue.ToString(),
                        item.BookingId.ToString(),
                    };

                    packagesDGV.Rows.Add(row.ToArray());
                }

                //Checks if TableInfo returns any values, if they don't, the subtotal should be 0.
                if (tableInfo.Any())
                {
                    lblTotal.Text = tableInfo.Sum(x => x.SubtotalValue).ToString();
                }
                else
                {
                    lblTotal.Text = "0";
                }

                #endregion

            }
        }

        private void packagesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void updateQntyBtn_Click(object sender, EventArgs e)
        {

            while (true)
            {
                using (var context = new Session2Entities())
                {
                    #region Validation Checks
                    _selectedBookingId = Convert.ToInt64(packagesDGV.SelectedRows[0].Cells[5].Value);
                    var bookingToUpdate = context.Bookings.Where(x => x.bookingId == _selectedBookingId).First();

                    if (quantityTb.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Quantity cannot be empty");
                        break;
                    }

                    try
                    {
                        var quantityToUpdate = Convert.ToInt32(quantityTb.Text);

                        if (quantityToUpdate <= 0)
                        {
                            MessageBox.Show("Quantity cannot be less than zero");
                            break;
                        }

                        //Adds current quantity booked back to amount in db to see if new request can be satified:
                        var checkForSufficientQuantity = bookingToUpdate.Package.packageQuantity + bookingToUpdate.quantityBooked;

                        if ((checkForSufficientQuantity - quantityToUpdate) < 0)
                        {
                            MessageBox.Show("There aren't enough packages to satisfy this request");
                            break;
                        }

                        bookingToUpdate.quantityBooked = quantityToUpdate;
                        bookingToUpdate.Package.packageQuantity = checkForSufficientQuantity - quantityToUpdate;
                        context.SaveChanges();
                        RefreshList();
                        break;

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Please enter a valid quantity");
                        break;
                    }

                    #endregion
                }
            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                //Opens dialog box to ask if they want to delete the item:
                _selectedBookingId = Convert.ToInt64(packagesDGV.SelectedRows[0].Cells[5].Value);
                var result = MessageBox.Show("Do you want to delete this item?", "Confirm?", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    //deletes the relavent bookings:
                    var bookingToDelete = context.Bookings.Where(x => x.bookingId == _selectedBookingId).First();
                    
                    //update the package quantity in the database, add back whatever quantity was booked.
                    bookingToDelete.Package.packageQuantity += bookingToDelete.quantityBooked;
                    context.Bookings.Remove(bookingToDelete);

                    context.SaveChanges();
                    RefreshList();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

