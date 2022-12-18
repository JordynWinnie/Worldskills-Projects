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
    public partial class ApproveBookings : Form
    {
        private Session2Entities context = new Session2Entities();

        public ApproveBookings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApproveBookings_Load(object sender, EventArgs e)
        {
            string[] columns = { "Company Name", "Package Name", "Status", "id", "packageID" };
            foreach (var column in columns)
            {
                sponsorshipDGV.Columns.Add(column, column);
            }

            sponsorshipDGV.Columns[3].Visible = false;
            sponsorshipDGV.Columns[4].Visible = false;

            RefreshTable();
        }

        private void RefreshTable()
        {
            sponsorshipDGV.Rows.Clear();
            var bookingsQuery = (from x in context.Bookings
                                 orderby x.status == "Rejected",
                                 x.status == "Approved", x.status == "Pending", x.User.name
                                 select x);

            foreach (var booking in bookingsQuery)
            {
                var row = new List<string>
                {
                    booking.User.name,
                    booking.Package.packageName,
                    booking.status,
                    booking.bookingId.ToString(),
                    booking.packageIdFK.ToString()
                };

                sponsorshipDGV.Rows.Add(row.ToArray());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sponsorshipDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row");
                return;
            }

            var bookingsInPackageID = new Dictionary<int, int>();
            foreach (DataGridViewRow row in sponsorshipDGV.SelectedRows)
            {
                if (!row.Cells[2].Value.ToString().Equals("Pending"))
                {
                    MessageBox.Show("Only pending orders can be approved/rejected");
                    return;
                }
                var packageId = int.Parse(row.Cells[4].Value.ToString());
                var bookingId = int.Parse(row.Cells[3].Value.ToString());

                var bookingQty = context.Bookings.Where(x => x.bookingId == bookingId).Select(x => x.quantityBooked).First();

                if (bookingsInPackageID.ContainsKey(packageId))
                {
                    bookingsInPackageID[packageId] += bookingQty;
                }
                else
                {
                    bookingsInPackageID.Add(packageId, bookingQty);
                }
            }

            foreach (var package in bookingsInPackageID)
            {
                var packageQty = context.Packages.Where(x => x.packageId == package.Key).First();
                if (packageQty.packageQuantity < package.Value)
                {
                    MessageBox.Show($"Unable to fufil all orders, {packageQty.packageName} has insufficient quantity for current selection");
                    return;
                }
            }

            if (MessageBox.Show($"Approve all {sponsorshipDGV.SelectedRows.Count} bookings?", "Approval", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in sponsorshipDGV.SelectedRows)
                {
                    var packageId = int.Parse(row.Cells[4].Value.ToString());
                    var bookingId = int.Parse(row.Cells[3].Value.ToString());

                    var booking = context.Bookings.Where(x => x.bookingId == bookingId).First();
                    var package = context.Packages.Where(x => x.packageId == packageId).First();

                    booking.status = "Approved";
                    package.packageQuantity -= booking.quantityBooked;
                }
                context.SaveChanges();
                MessageBox.Show("Changes Saved");
                RefreshTable();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sponsorshipDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row");
                return;
            }

            foreach (DataGridViewRow row in sponsorshipDGV.SelectedRows)
            {
                if (!row.Cells[2].Value.ToString().Equals("Pending"))
                {
                    MessageBox.Show("Only pending orders can be approved/rejected");
                    return;
                }
            }

            if (MessageBox.Show($"Reject all {sponsorshipDGV.SelectedRows.Count} bookings?", "Approval", MessageBoxButtons.YesNo)
               == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in sponsorshipDGV.SelectedRows)
                {
                    var packageId = int.Parse(row.Cells[4].Value.ToString());
                    var bookingId = int.Parse(row.Cells[3].Value.ToString());

                    var booking = context.Bookings.Where(x => x.bookingId == bookingId).First();
                    var package = context.Packages.Where(x => x.packageId == packageId).First();

                    booking.status = "Rejected";
                }
                context.SaveChanges();
                MessageBox.Show("Changes Saved");
                RefreshTable();
            }
        }
    }
}