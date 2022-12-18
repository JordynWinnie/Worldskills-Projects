using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session2_JordanKhong.Forms
{
    public partial class ApproveBookingsForm : Form
    {
        public ApproveBookingsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApproveBookingsForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                //Add Columns:
                var columns = new List<string>
                {
                    "Company Name",
                    "Package Name",
                    "Status",
                    "BookingID"
                };


                //Population Columns in DGV:
                foreach (var column in columns)
                {
                    sponsorshipDGV.Columns.Add(column, column);
                }

                sponsorshipDGV.Columns[3].Visible = false;
            }

            RefreshList();
        }

        void RefreshList()
        {
            sponsorshipDGV.Rows.Clear();
            using (var context = new Session2Entities())
            {
                var rowInformation = (from x in context.Bookings
                                      select new
                                      {
                                          x.bookingId,
                                          x.Package.packageName,
                                          x.User.name,
                                          x.status,
                                      }).ToList();

                //use a dictionary to make a custom sort order:
                var customSortMapping = new Dictionary<string, int>
                {
                    { "Pending", 1},
                    { "Approved", 2},
                    { "Rejected", 3}
                };

                var sortedInformation = rowInformation.OrderBy(x => customSortMapping[x.status]);
                foreach (var item in sortedInformation)
                {
                    var row = new List<string>{
                        item.name,
                        item.packageName,
                        item.status,
                        item.bookingId.ToString()
                    };

                    sponsorshipDGV.Rows.Add(row.ToArray());
                }


            }
        }

        private void approveBtn_Click(object sender, EventArgs e)
        {
            bool checkIfApproved = true;

            //Check if more than 0 rows are selected
            if (sponsorshipDGV.SelectedRows.Count != 0)
            {
                //Check if anything selected already has an approval/rejection
                foreach (DataGridViewRow row in sponsorshipDGV.SelectedRows)
                {
                    if (row.Cells[2].Value.Equals("Approved") || row.Cells[2].Value.Equals("Rejected"))
                    {
                        checkIfApproved = false;
                    }
                }

                if (checkIfApproved)
                {
                    var result = MessageBox.Show("Confirm approval?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        using (var context = new Session2Entities())
                        {
                            foreach (DataGridViewRow row in sponsorshipDGV.SelectedRows)
                            {

                                var rowBookingID = Convert.ToInt32(row.Cells[3].Value);
                                var currentBooking = context.Bookings.Where(x => x.bookingId == rowBookingID).FirstOrDefault();

                                //If approve, only change the Status to approved

                                currentBooking.status = "Approved";
                            }

                            try
                            {
                                context.SaveChanges();
                                RefreshList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error saving data. Details:\n" + ex.Message);
                            }
                        }
                    }
                }
                else MessageBox.Show("You can only approve pending requests");
                
                
            }
            else MessageBox.Show("Please select an item");

        }

        

        private void rejectBtn_Click(object sender, EventArgs e)
        {
            bool checkIfApproved = true;

            //Check if more than 0 rows are selected
            if (sponsorshipDGV.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow row in sponsorshipDGV.SelectedRows)
                {
                    if (row.Cells[2].Value.Equals("Approved") || row.Cells[2].Value.Equals("Rejected"))
                    {
                        checkIfApproved = false;
                    }
                }

                //Check if anything selected already has an approval/rejection
                if (checkIfApproved)
                {
                    var result = MessageBox.Show("Confirm rejection?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        using (var context = new Session2Entities())
                        {
                            foreach (DataGridViewRow row in sponsorshipDGV.SelectedRows)
                            {

                                var rowBookingID = Convert.ToInt32(row.Cells[3].Value);
                                var currentBooking = context.Bookings.Where(x => x.bookingId == rowBookingID).FirstOrDefault();

                                //If reject, change the Status to rejected, and also add back to currentbooking

                                currentBooking.status = "Rejected";
                                currentBooking.Package.packageQuantity += currentBooking.quantityBooked;
                            }

                            try
                            {
                                context.SaveChanges();
                                RefreshList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error saving data. Details:\n" + ex.Message);
                            }
                        }
                    }
                }
                else MessageBox.Show("You can only reject pending requests");
            }
            else MessageBox.Show("Please select an item");

        }

        private void sponsorshipDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
