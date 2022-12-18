using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_QR_Paper2_5_29_2020
{
    public partial class ApproveSponsorshipBooking : Form
    {
        private int selectedBookingID;

        public ApproveSponsorshipBooking()
        {
            InitializeComponent();
        }

        private void ApproveSponsorshipBooking_Load(object sender, EventArgs e)
        {
            var columns = new List<string>()
            {
                "Company Name", "Package Name", "Status", "BookingID"
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
                var bookings = from x in context.Bookings
                               orderby x.status
                               select x;

                foreach (var booking in bookings)
                {
                    var row = new List<string>()
                    {
                        booking.User.name,
                        booking.Package.packageName,
                        booking.status,
                        booking.bookingId.ToString()
                    };

                    packageDGV.Rows.Add(row.ToArray());
                }
            }
        }

        private void packageDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedBookingID = int.Parse(packageDGV.Rows[e.RowIndex].Cells[3].Value.ToString());
            Console.WriteLine(selectedBookingID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                var currentBooking = context.Bookings.Where(x => x.bookingId == selectedBookingID).FirstOrDefault();

                currentBooking.status = "Approved";
                context.SaveChanges();
                UpdateDGV();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                var currentBooking = context.Bookings.Where(x => x.bookingId == selectedBookingID).FirstOrDefault();

                currentBooking.status = "Reject";
                context.SaveChanges();
                UpdateDGV();
            }
        }
    }
}