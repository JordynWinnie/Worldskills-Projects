using System;
using System.Windows.Forms;

namespace AbuDhabu_Session3_6_11_2020
{
    public partial class ConfirmAmountForm : Form
    {
        private decimal _totalCost = -1;

        public ConfirmAmountForm(decimal totalCost)
        {
            _totalCost = totalCost;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ConfirmAmountForm_Load(object sender, EventArgs e)
        {
            totalCostLbl.Text = $"Total Cost: {_totalCost.ToString("0")}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void totalCostLbl_Click(object sender, EventArgs e)
        {
        }
    }
}