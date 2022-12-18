using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KazanSession4_28_02_2020
{
    public partial class ManageCurrentInventory : Form
    {
        public ManageCurrentInventory()
        {
            InitializeComponent();
        }

        private void ManageCurrentInventory_Load(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                var columns = new List<string>
                {
                    "Part Name", "Transaction Type","Date","Amount","Source","Destination","ORDERID","ORDERITEMID"
                };

                foreach (var column in columns)
                {
                    orderDGV.Columns.Add(column, column);
                };

                var editColumnButton = new DataGridViewButtonColumn
                {
                    Text = "Edit",
                    HeaderText = "Edit",
                    UseColumnTextForButtonValue = true,
                    Name = "Edit"
                };

                var removeColumnButton = new DataGridViewButtonColumn
                {
                    Text = "Remove",
                    HeaderText = "Remove",
                    UseColumnTextForButtonValue = true,
                    Name = "Remove"
                };

                orderDGV.Columns.Add(editColumnButton);
                orderDGV.Columns.Add(removeColumnButton);


                RefreshGrid();

            }


        }

        void RefreshGrid()
        {
            orderDGV.Rows.Clear();
            using (var context = new Session4Entities())
            {
                var currentInventory = from x in context.OrderItems
                                       orderby x.Order.Date descending, x.Order.TransactionTypeID
                                       select x;

                foreach (var order in currentInventory)
                {
                    var row = new List<string>
                    {
                        order.Part.Name,
                        order.Order.TransactionType.Name,
                        order.Order.Date.ToString(),
                        order.Amount.ToString(),
                    };

                    //Check if Source warehouse exists, if not, it is a supplier:
                    if (order.Order.SourceWarehouseID != null)
                    {
                        row.Add(context.Warehouses.Where(x => x.ID == order.Order.SourceWarehouseID).Select(x => x.Name).FirstOrDefault());
                    }
                    else
                    {
                        row.Add(context.Suppliers.Where(x => x.ID == order.Order.SupplierID).Select(x => x.Name).FirstOrDefault());
                    }

                    row.Add(context.Warehouses.Where(x => x.ID == order.Order.DestinationWarehouseID).Select(x => x.Name).FirstOrDefault());
                    row.Add(order.Order.ID.ToString());
                    row.Add(order.ID.ToString());
                    orderDGV.Rows.Add(row.ToArray());
                }

                foreach (DataGridViewRow row in orderDGV.Rows)
                {
                    if (row.Cells[1].Value.ToString().Contains("Purchase"))
                    {
                        row.Cells[3].Style.BackColor = Color.LightGreen;
                    }
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new PurchaseOrderForm(-1)).ShowDialog();
            RefreshGrid();
            this.Show();
        }

        private void orderDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (orderDGV.Columns["Edit"].Index == e.ColumnIndex)
            {
                MessageBox.Show("Edit Button Clicked");
                MessageBox.Show(orderDGV.Rows[e.RowIndex].Cells[1].Value.ToString());
                if (orderDGV.Rows[e.RowIndex].Cells[1].Value.ToString().Contains("Purchase"))
                {
                    this.Hide();
                    (new PurchaseOrderForm(Convert.ToInt64(orderDGV.Rows[e.RowIndex].Cells[6].Value.ToString()))).ShowDialog();
                    RefreshGrid();
                    this.Show();
                }
                else
                {
                    this.Hide();
                    (new WarehouseManagementForm(Convert.ToInt64(orderDGV.Rows[e.RowIndex].Cells[6].Value.ToString()))).ShowDialog();
                    RefreshGrid();
                    this.Show();
                }
                
            }
            else if (orderDGV.Columns["Remove"].Index == e.ColumnIndex)
            {
               var result = MessageBox.Show("Are you sure you want to remove?", "Warning", MessageBoxButtons.YesNo);
                
                if (result == DialogResult.Yes)
                {
                    using (var context = new Session4Entities())
                    {
                        var removedItemId = Convert.ToInt64(orderDGV.Rows[e.ColumnIndex].Cells[7].Value.ToString());
                        var removedItem = context.OrderItems.Where(x => x.ID == removedItemId).First();
                        context.OrderItems.Remove(removedItem);

                        context.SaveChanges();
                        MessageBox.Show("Item removed");
                        RefreshGrid();
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new WarehouseManagementForm(-1)).ShowDialog();
            RefreshGrid();
            this.Show();
        }
    }
}
