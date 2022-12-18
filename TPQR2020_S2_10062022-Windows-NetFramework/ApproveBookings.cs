using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TPQR2020_S2_10062022_Windows_NetFramework
{

    public partial class ApproveBookings : Form
    {
       
        public ApproveBookings()
        {
            InitializeComponent();
        }

        private void ApproveBookings_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
                {
                    "PackageId", "Company Name", "Package Name", "Status"
                };

            columns.ForEach(x => packageDGV.Columns.Add(x, x));

            packageDGV.Columns[0].Visible = false;
            RefreshList();

        }

        void RefreshList()
        {
            packageDGV.Rows.Clear();
            using (var context = new Session2Entities())
            {
                var bookings = context.Bookings
                    .OrderBy(x=> x.status == "Rejected")
                    .OrderBy(x=> x.status == "Approved")
                    .OrderBy(x=> x.status == "Pending");


                foreach (var booking in bookings)
                {
                    var row = new List<string>
                    {
                        booking.bookingId.ToString(),
                        booking.User.name,
                        booking.Package.packageName,
                        booking.status
                    };

                    packageDGV.Rows.Add(row.ToArray());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void packageDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void approveBtn_Click(object sender, EventArgs e)
        {
            using (var context = new  Session2Entities())
            {
                if (packageDGV.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow item in packageDGV.SelectedRows)
                    {
                        var cells = item.Cells;
                        var bookingId = int.Parse(cells[0].Value.ToString());
                        var status = cells[3].Value.ToString();

                        if (status == "Pending")
                        {
                            var booking = context.Bookings.Where(x=>x.bookingId == bookingId).First();
                            booking.status = "Approved";
                        }

                        context.SaveChanges();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a package to approve");
                }
            }

            RefreshList();
            
        }

        private void rejectBtn_Click(object sender, EventArgs e)
        {

            using (var context = new Session2Entities())
            {
                if (packageDGV.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow item in packageDGV.SelectedRows)
                    {
                        var cells = item.Cells;
                        var bookingId = int.Parse(cells[0].Value.ToString());
                        var status = cells[3].Value.ToString();

                        if (status == "Pending")
                        {
                            var booking = context.Bookings.Where(x => x.bookingId == bookingId).First();
                            booking.status = "Rejected";

                            booking.Package.packageQuantity += booking.quantityBooked;
                        }

                        context.SaveChanges();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a package to reject");
                }

                RefreshList();
            }
        }
    }
}
