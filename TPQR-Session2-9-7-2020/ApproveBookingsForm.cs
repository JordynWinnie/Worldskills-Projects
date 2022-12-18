using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session2_9_7_2020
{
    public partial class ApproveBookingsForm : Form
    {
        public ApproveBookingsForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApproveBookingsForm_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Company Name", "Package Name", "Status", "BookingId", "PackageId"
            };

            foreach (var column in columns)
            {
                bookingsDGV.Columns.Add(column, column);
            }
            bookingsDGV.Columns[3].Visible = false;
            bookingsDGV.Columns[4].Visible = false;

            UpdateTable();
        }

        private void UpdateTable()
        {
            bookingsDGV.Rows.Clear();

            using (var context = new Session2Entities())
            {
                var packageQuery = from x in context.Bookings
                                   orderby x.status == "Rejected", x.status == "Approved", x.status == "Pending",
                                   x.User.name
                                   select x;

                foreach (var package in packageQuery)
                {
                    var row = new List<string>
                    {
                        package.User.name,
                        package.Package.packageName,
                        package.status,
                        package.bookingId.ToString(),
                        package.packageIdFK.ToString()
                    };

                    bookingsDGV.Rows.Add(row.ToArray());
                }
            }
        }

        private void approveBtn_Click(object sender, EventArgs e)
        {
            if (bookingsDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row");
                return;
            }

            foreach (DataGridViewRow row in bookingsDGV.SelectedRows)
            {
                if (!row.Cells[2].Value.ToString().Equals("Pending"))
                {
                    MessageBox.Show("Only pending packages can be approved");
                    return;
                }
            }

            foreach (DataGridViewRow row in bookingsDGV.SelectedRows)
            {
                var packageId = int.Parse(row.Cells[4].Value.ToString());
                var bookingId = int.Parse(row.Cells[3].Value.ToString());

                using (var context = new Session2Entities())
                {
                    var currentQty = context.Packages.Where(x => x.packageId == packageId).First().packageQuantity;
                    var bookingQty = context.Bookings.Where(x => x.bookingId == bookingId).First();
                    if (currentQty - bookingQty.quantityBooked < 0)
                    {
                        MessageBox.Show($"Insufficient Quantity to fufil order {bookingQty.Package.packageName} for {bookingQty.User.name}");
                        UpdateTable();
                        return;
                    }

                    currentQty -= bookingQty.quantityBooked;
                    bookingQty.status = "Approved";

                    context.SaveChanges();
                    UpdateTable();
                }
            }
        }

        private void rejectBtn_Click(object sender, EventArgs e)
        {
            if (bookingsDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row");
                return;
            }

            foreach (DataGridViewRow row in bookingsDGV.SelectedRows)
            {
                if (!row.Cells[2].Value.ToString().Equals("Pending"))
                {
                    MessageBox.Show("Only pending packages can be rejected");
                    return;
                }
            }

            foreach (DataGridViewRow row in bookingsDGV.SelectedRows)
            {
                var packageId = int.Parse(row.Cells[4].Value.ToString());
                var bookingId = int.Parse(row.Cells[3].Value.ToString());

                using (var context = new Session2Entities())
                {
                    var currentQty = context.Packages.Where(x => x.packageId == packageId).First().packageQuantity;
                    var bookingQty = context.Bookings.Where(x => x.bookingId == bookingId).First();

                    bookingQty.status = "Rejected";

                    context.SaveChanges();
                    UpdateTable();
                }
            }
        }
    }
}