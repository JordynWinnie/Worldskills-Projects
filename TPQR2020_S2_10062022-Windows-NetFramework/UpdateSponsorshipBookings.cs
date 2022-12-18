using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR2020_S2_10062022_Windows_NetFramework
{
    public partial class UpdateSponsorshipBookings : Form
    {
        private User currentUser;
        private int selectedBookingID = -1;

        public UpdateSponsorshipBookings(User user)
        {
            this.currentUser = user;
            InitializeComponent();
        }

        private void UpdateSponsorshipBookings_Load(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                var bookings = context.Bookings.Where(x => x.status != "Pending" && x.userIdFK == currentUser.userId);

                if (bookings.Count() == 0)
                {
                    MessageBox.Show("You do not have any approved bookings");
                    Close();
                    return;
                }
            }

            var columns = new List<string>
            {
                "PackageID", "Tier", "Name", "Individual Value ($)", "Quantity Booked", "Sub-Total Value ($)"
            };
            
            columns.ForEach(x => packageDGV.Columns.Add(x,x));
            packageDGV.Columns[0].Visible = false;

            RefreshList();
        }

        void RefreshList()
        {
            var fullTotal = 0L;

            using (var context = new Session2Entities())
            {
                packageDGV.Rows.Clear();
                var bookings = context.Bookings.Where(x=>x.userIdFK == currentUser.userId);
                foreach (var booking in bookings)
                {
                    var subTotal = booking.quantityBooked * booking.Package.packageValue;
                    var row = new List<string>
                {
                    booking.bookingId.ToString(),
                    booking.Package.packageTier,
                    booking.Package.packageName,
                    booking.Package.packageValue.ToString(),
                    booking.quantityBooked.ToString(),
                    subTotal.ToString()
                };
                    packageDGV.Rows.Add(row.ToArray());
                    fullTotal += subTotal;
                }

                totalValueLbl.Text = fullTotal.ToString();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void packageDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedBookingID = int.Parse(packageDGV[0, e.RowIndex].Value.ToString());
        }

        private void packageDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void updateQty_Click(object sender, EventArgs e)
        {
            if (newQty.Value == 0)
            {
                MessageBox.Show("New Quantity should be more than 0");
                return;
            }

            if (selectedBookingID == -1)
            {
                MessageBox.Show("Please select a booking");
                return;
            }

            using (var context = new Session2Entities())
            {
                var booking = context.Bookings.Where(x=>x.bookingId == selectedBookingID).First();
                var package = booking.Package;

                var newAmountOfPackage = package.packageQuantity - (newQty.Value - booking.quantityBooked);

                if (newAmountOfPackage < 0)
                {
                    MessageBox.Show("There isn't enough of the package for you to book.");
                    return;
                }

                package.packageQuantity = (int)newAmountOfPackage;

                booking.quantityBooked = (int)newQty.Value;

                context.SaveChanges();

                MessageBox.Show("Updated Records");

                RefreshList();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedBookingID == -1)
            {
                MessageBox.Show("Please select a booking");
                return;
            }

            using (var context = new Session2Entities())
            {
                var booking = context.Bookings.Where(x => x.bookingId == selectedBookingID).First();
                var package = booking.Package;


                var otherSponsors = context.Bookings.Where(x=>x.packageIdFK == package.packageId && x.userIdFK != currentUser.userId).Count();

                if (otherSponsors > 0)
                {
                    MessageBox.Show("There are other sponsors booking this package, you may not delete this booking");
                    return;
                }

                package.packageQuantity += booking.quantityBooked;
                context.Bookings.Remove(booking);

                context.SaveChanges();
                MessageBox.Show("Deleted Record");

                RefreshList();


                var bookings = context.Bookings.Where(x => x.status != "Pending" && x.userIdFK == currentUser.userId);

                if (bookings.Count() == 0)
                {
                    MessageBox.Show("You do not have any approved bookings");
                    Close();
                    return;
                }
            }
        }
    }
}
