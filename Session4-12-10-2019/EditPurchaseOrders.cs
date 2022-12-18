using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Session4_12_10_2019
{
    public partial class EditPurchaseOrders : Form
    {
        public Dictionary<long?, string> supplierList = new Dictionary<long?, string>();
        public Dictionary<long?, string> warehouseList = new Dictionary<long?, string>();
        public Dictionary<long?, string> partList = new Dictionary<long?, string>();
        public int _currentOrderID;
        public List<PartBatchAmount> partBatchList = new List<PartBatchAmount>();

        public class PartBatchAmount
        {
            public string PartName { get; set; }
            public string batchNumber { get; set; }
            public decimal amount { get; set; }
        }

        public EditPurchaseOrders(int state)
        {
            _currentOrderID = state;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void EditPurchaseOrders_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            using (var context = new Session4Entities())
            {
                //Population Comboboxes:

                foreach (var item in context.Suppliers)
                {
                    supplierList.Add(item.ID, item.Name);
                    supplierCb.Items.Add(item.Name);
                }
                foreach (var item in context.Warehouses)
                {
                    warehouseList.Add(item.ID, item.Name);
                    warehouseCb.Items.Add(item.Name);
                }


                foreach (var item in context.Parts)
                {
                    partList.Add(item.ID, item.Name);
                    partsNameCb.Items.Add(item.Name);
                }
                supplierCb.SelectedIndex = 0;
                warehouseCb.SelectedIndex = 0;
                partsNameCb.SelectedIndex = 0;

                if (_currentOrderID == -1)
                {
                    this.Text = "NEW PURCHASE";
                }
                else
                {
                    this.Text = "EDITING PURCHASE";

                    var partQuery = from x in context.OrderItems
                                    where x.ID == _currentOrderID
                                    join y in context.Parts on x.PartID equals y.ID
                                    select new
                                    {
                                        x,
                                        y

                                    };

                    foreach (var item in partQuery)
                    {
                        object[] rows = new object[3];

                        rows[0] = item.y.Name;
                        rows[1] = item.x.BatchNumber;
                        rows[2] = item.x.Amount;
                        PartBatchAmount p = new PartBatchAmount
                        {
                            PartName = item.y.Name,
                            amount = item.x.Amount,
                            batchNumber =
                            item.x.BatchNumber
                        };

                        partBatchList.Add(p);
                        partsListDGV.Rows.Add(rows.ToArray());
                    }
                }
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {

            using (var context = new Session4Entities())
            {

                if (context.Parts.Where(x => x.ID == (partsNameCb.SelectedIndex + 1)).Select(x => x.BatchNumberHasRequired).First() == true
                    && tbBatchNo.Text == string.Empty)
                {
                    MessageBox.Show("Please enter batch number");
                }
                else if (tbAmount.Text == string.Empty)
                {
                    MessageBox.Show("Please enter amount");
                }
                else
                {
                    object[] rows = new object[3];

                    rows[0] = partsNameCb.SelectedItem.ToString();
                    rows[1] = tbBatchNo.Text;
                    rows[2] = tbAmount.Text;

                    PartBatchAmount p = new PartBatchAmount
                    {
                        PartName = partsNameCb.SelectedItem.ToString(),
                        amount = Decimal.Parse(tbAmount.Text),
                        batchNumber = tbBatchNo.Text
                    };

                partBatchList.Add(p);
                partsListDGV.Rows.Add(rows.ToArray());
            }
        }
    }

    void UpdateGrid()
    {
        partsListDGV.ColumnCount = 4;
        partsListDGV.Columns[0].Name = "Part Name";
        partsListDGV.Columns[1].Name = "Batch Number";
        partsListDGV.Columns[2].Name = "Amount";

        partsListDGV.Rows.Clear();

    }

        private void button1_Click(object sender, EventArgs e)
        {
            //This section is for the DEBUG Button, where all the items in the current DatagridView can be
            //printed out
            label7.Text = "";
            StringBuilder sb = new StringBuilder();
            foreach (var item in partBatchList)
            {
                sb.Append($"NAME: { item.PartName} BN: {item.batchNumber} AMT: {item.amount} \n");
            }

            label7.Text = sb.ToString();
        }
    }
}

