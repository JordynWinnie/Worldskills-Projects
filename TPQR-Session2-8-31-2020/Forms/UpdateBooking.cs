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
    public partial class UpdateBooking : Form
    {
        private Session2Entities context = new Session2Entities();
        private string _userId = string.Empty;
        private int _bookingId = -1;

        public UpdateBooking(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void UpdateBooking_Load(object sender, EventArgs e)
        {
            string[] columns = { "Tier", "Name", "Individual Value ($)", "Quantity Booked", "Sub-Total", "bookingId" };
            foreach (var column in columns)
            {
                sponsorshipDGV.Columns.Add(column, column);
            }

            sponsorshipDGV.Columns[5].Visible = false;

            RefreshTable();
        }

        private void RefreshTable()
        {
            sponsorshipDGV.Rows.Clear();
            var bookingQuery = from x in context.Bookings
                               orderby x.Package.packageTier == "Bronze",
                               x.Package.packageTier == "Silver", x.Package.packageTier == "Gold", x.Package.packageValue
                               where x.userIdFK == _userId
                               select x;
            long total = 0;
            foreach (var booking in bookingQuery)
            {
                var row = new List<string>
                {
                    booking.Package.packageTier,
                    booking.Package.packageName,
                    booking.Package.packageValue.ToString(),
                    booking.quantityBooked.ToString(),
                    (booking.quantityBooked * booking.Package.packageValue).ToString(),
                    booking.bookingId.ToString()
                };

                total += booking.quantityBooked * booking.Package.packageValue;
                sponsorshipDGV.Rows.Add(row.ToArray());
            }
            totalValue.Text = total.ToString();
        }

        private void sponsorshipDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _bookingId = int.Parse(sponsorshipDGV[5, e.RowIndex].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                var booking = context.Bookings.Where(x => x.bookingId == _bookingId).First();

                var package = context.Packages.Where(x => x.packageId == booking.packageIdFK).First();

                //Console.WriteLine(package.packageQuantity + booking.quantityBooked - (int)quantityNUD.Value);
                package.packageQuantity = package.packageQuantity + booking.quantityBooked - (int)quantityNUD.Value;
                booking.quantityBooked = (int)quantityNUD.Value;
                context.SaveChanges();
                MessageBox.Show("Updated");
                RefreshTable();
            }
        }

        private bool Validation()
        {
            if (quantityNUD.Value == 0)
            {
                MessageBox.Show("Quantity should not be zero");
                return false;
            }

            if (_bookingId == -1)
            {
                MessageBox.Show("Select a row");
                return false;
            }

            var booking = context.Bookings.Where(x => x.bookingId == _bookingId).First();

            var qty = context.Packages.Where(x => x.packageId == booking.packageIdFK).First().packageQuantity;
            Console.WriteLine(qty + booking.quantityBooked - quantityNUD.Value);
            if ((qty + booking.quantityBooked - quantityNUD.Value) < 0)
            {
                MessageBox.Show("Not enough packages to allocate");
                return false;
            }

            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_bookingId == -1)
            {
                MessageBox.Show("Select a row");
                return;
            }

            var booking = context.Bookings.Where(x => x.bookingId == _bookingId).First();

            var companyConflict = (from x in context.Bookings
                                   where x.packageIdFK == booking.packageIdFK && x.userIdFK != _userId
                                   select x).Any();

            if (companyConflict)
            {
                MessageBox.Show("Another Company has booked this package, not allowed to delete");
                return;
            }

            var package = context.Packages.Where(x => x.packageId == booking.packageIdFK).First();

            package.packageQuantity += booking.quantityBooked;
            context.Bookings.Remove(booking);
            context.SaveChanges();
            MessageBox.Show("Deleted.");
            RefreshTable();
        }
    }
}