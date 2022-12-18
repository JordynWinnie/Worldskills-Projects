using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Department_Practice
{
    public partial class UpdateForm : Form
    {
        public int _departmentID;
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DepartmentData.SelectedRows == null || _departmentID == 0)
            {
                MessageBox.Show("Please Select a record");
            }
            else
            {
                UpdateDataForm udf = new UpdateDataForm(_departmentID);
                udf.ShowDialog();
            }
        }
        void UpdateGrid()
        {
            using (var context = new AdventureWorks2017Entities())
            {
                var readQuery = (from x in context.Departments
                                 orderby x.DepartmentID
                                 select new
                                 {
                                     DepartmentID = x.DepartmentID,
                                     DepartmentName = x.Name,
                                     DepartmentGroupName = x.GroupName,
                                     ModifiedDate = x.ModifiedDate
                                 }).ToList();

                DepartmentData.DataSource = readQuery;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void DepartmentData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //MessageBox.Show(DepartmentData.Rows[e.RowIndex].Cells[0].Value.ToString());
                _departmentID = Int32.Parse(DepartmentData.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }
    }
}
