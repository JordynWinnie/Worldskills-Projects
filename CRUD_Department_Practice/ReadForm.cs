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
    public partial class ReadForm : Form
    {
        public ReadForm()
        {
            InitializeComponent();
        }

        private void ReadForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
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

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
