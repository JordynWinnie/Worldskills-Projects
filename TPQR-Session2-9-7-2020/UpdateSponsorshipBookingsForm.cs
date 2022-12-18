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
    public partial class UpdateSponsorshipBookingsForm : Form
    {
        private string _userId = string.Empty;
        private int _bookingId = -1;
        private Session2Entities context = new Session2Entities();

        public UpdateSponsorshipBookingsForm(string userid)
        {
            _userId = userid;
            InitializeComponent();
        }

        private void UpdateSponsorshipBookingsForm_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Tier", "Name", "Individual Value", "Quantity Booked", "Sub-Total Value", "bookingId"
            };

            foreach (var column in columns)
            {
                packagesDGV.Columns.Add(column, column);
            }

            packagesDGV.Columns[5].Visible = false;
            UpdateTable();
        }

        private void UpdateTable()
        {
            var packageQuery = from x in context.Bookings
                               where x.status == "Approved" && x.userIdFK == _userId
                               select x;
            long totalVal = 0;
            foreach (var item in packageQuery)
            {
                var row = new List<string>
                {
                    item.Package.packageTier,
                    item.Package.packageName,
                    item.Package.packageValue.ToString(),
                    item.quantityBooked.ToString(),
                    (item.Package.packageValue * item.quantityBooked).ToString(),
                    item.bookingId.ToString()
                };
                totalVal += (item.Package.packageValue * item.quantityBooked);
                packagesDGV.Rows.Add(row.ToArray());
            }

            totalValLbl.Text = $"Total Value: ${totalVal}";
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void packagesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void packagesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _bookingId = int.Parse(packagesDGV[5, e.RowIndex].Value.ToString());
            Console.WriteLine(_bookingId);
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (_bookingId == -1)
            {
                MessageBox.Show("Please choose a cell");
                return;
            }

            if (qtyNUD.Value == 0)
            {
                MessageBox.Show("Quantity cannot be zero");
                return;
            }

            var bookingToModify = context.Bookings.Where(x => x.bookingId == _bookingId).First();
            var package = context.Packages.Where(x => x.packageId == bookingToModify.packageIdFK).First();

            var newQuantityToOrder = (int)qtyNUD.Value - bookingToModify.quantityBooked;

            if (newQuantityToOrder > package.packageQuantity)
            {
                MessageBox.Show("Not enough packages to cater to update");
                return;
            }

            bookingToModify.quantityBooked += newQuantityToOrder;
            package.packageQuantity -= newQuantityToOrder;

            _bookingId = -1;

            context.SaveChanges();
            UpdateTable();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (_bookingId == -1)
            {
                MessageBox.Show("Please choose a cell");
                return;
            }

            var bookingToModify = context.Bookings.Where(x => x.bookingId == _bookingId).First();
            var package = context.Packages.Where(x => x.packageId == bookingToModify.packageIdFK).First();

            var otherCompanyCheck = context.Bookings.Where(x => x.packageIdFK == bookingToModify.packageIdFK && x.userIdFK != _userId).Any();

            if (otherCompanyCheck)
            {
                MessageBox.Show("One or more companies already booked this, you may not delete this");
                return;
            }
            if (MessageBox.Show("Delete this entry?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                package.packageQuantity += bookingToModify.quantityBooked;
                context.Bookings.Remove(bookingToModify);
                context.SaveChanges();
                MessageBox.Show("Deleted");
                _bookingId = -1;
                UpdateTable();
            }
        }
    }
}