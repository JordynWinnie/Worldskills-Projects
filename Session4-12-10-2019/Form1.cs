using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session4_12_10_2019
{
    public partial class Form1 : Form
    {
        public string _transacType;
        public int _tempOrderId;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        void UpdateGrid()
        {
            using (var context = new Session4Entities())
            {
                var destinationWarehouse = (from x in context.OrderItems
                                            join y in context.Orders on x.OrderID equals y.ID
                                            join z in context.Parts on x.PartID equals z.ID
                                            join a in context.TransactionTypes on y.TransactionTypeID equals a.ID
                                            join c in context.Warehouses on y.DestinationWarehouseID equals c.ID
                                            select new
                                            {
                                                x,
                                                y,
                                                z,
                                                a,
                                                PartName = z.Name,
                                                TrasType = a.Name,
                                                DateOfTrans = y.Date,
                                                Amount = x.Amount,

                                                Destination = c.Name

                                            }).OrderByDescending(x => x.y.Date).ThenBy(x => x.a.Name);

                inventoryDGV.ColumnCount = 7;
                inventoryDGV.Columns[0].Name = "Part Name";
                inventoryDGV.Columns[1].Name = "Trasaction Type";
                inventoryDGV.Columns[2].Name = "Date";
                inventoryDGV.Columns[3].Name = "Amount";
                inventoryDGV.Columns[4].Name = "Source";
                inventoryDGV.Columns[5].Name = "Destination";


                object[] rows = new object[7];


                foreach (var item in destinationWarehouse)
                {
                    rows[0] = item.PartName;
                    rows[1] = item.TrasType;
                    rows[2] = item.DateOfTrans;
                    rows[3] = item.Amount;
                    if (item.y.SourceWarehouseID != null)
                    {
                        rows[4] = context.Warehouses.Where(x => x.ID == item.y.SourceWarehouseID).Select(x => x.Name).First();
                    }

                    rows[5] = item.Destination;
                    rows[6] = item.x.ID;
                    inventoryDGV.Rows.Add(rows.ToArray());

                }


                //MessageBox.Show(( destinationWarehouse.Count()).ToString());

            }
        }

        private void inventoryDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;

            if (rowIndex >= 0)
            {
                _transacType = inventoryDGV.Rows[rowIndex].Cells[1].Value.ToString();
                _tempOrderId = Int32.Parse(inventoryDGV.Rows[rowIndex].Cells[6].Value.ToString());
            }


        }

        private void btnPurOrdMag_Click(object sender, EventArgs e)
        {
            EditPurchaseOrders epo = new EditPurchaseOrders(-1);
            epo.ShowDialog();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_transacType == null || _tempOrderId == null)
            {
                MessageBox.Show("Please select a row");
            }
            else
            {
                if (_transacType.Contains("Purchase"))
                {
                    MessageBox.Show("Purcase Order");

                    EditPurchaseOrders epo = new EditPurchaseOrders(_tempOrderId);
                    epo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tras Order");

                }
            }
            
        }
    }
}
