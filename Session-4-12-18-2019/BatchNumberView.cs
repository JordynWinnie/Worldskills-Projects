using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session_4_12_18_2019
{
    public partial class BatchNumberView : Form
    {
        string _partName = "";
        string _warehouseName = "";
        int _state = -1;
        public BatchNumberView(string partName,string warehouseName, int state)
        {
            _partName = partName;
            _state = state;
            _warehouseName = warehouseName;
            InitializeComponent();
        }

        private void BatchNumberView_Load(object sender, EventArgs e)
        {
            List<string> columnName = new List<string>
            {
                "Batch Number",
                "Stock"
            };
            foreach (var item in columnName)
            {
                dataGridView1.Columns.Add(item, item);
            }
            
            using (var context = new Session4Entities())
            {

                var currentWarehouseId = context.Warehouses.Where(x => x.Name.Equals(_warehouseName)).Select(x => x.ID).First();

                var currentPart = context.Parts.Where(x => x.Name == _partName).Select(x => x.ID).First();

               

                if (_state == 1)
                {
                    var partList = context.OrderItems.Where(x => x.PartID == currentPart && x.Order.SourceWarehouseID == currentWarehouseId);

                    foreach (var part in partList)
                    {
                        List<string> newRow = new List<string>
                        {
                            part.BatchNumber,
                            part.Amount.ToString(),
                        };

                        dataGridView1.Rows.Add(newRow.ToArray());
                    }
                }
                else if (_state == 2)
                {
                    var partList = context.OrderItems.Where(x => x.PartID == currentPart && x.Order.DestinationWarehouseID == currentWarehouseId);
                    foreach (var part in partList)
                    {
                        List<string> newRow = new List<string>
                        {
                            part.BatchNumber,
                            part.Amount.ToString(),
                        };

                        dataGridView1.Rows.Add(newRow.ToArray());
                    }
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
