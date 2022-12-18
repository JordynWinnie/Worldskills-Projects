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
    public partial class UpdateDataForm : Form
    {
        public int _departmentID;
        public UpdateDataForm(int departmentID)
        {
            _departmentID = departmentID;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            using (var context = new AdventureWorks2017Entities())
            {
                

                var updateQ = from x in context.Departments
                              where x.DepartmentID == _departmentID
                              select x;

                foreach (var item in updateQ)
                {
                    item.DepartmentID = (short) _departmentID;
                    item.Name = tbDepartmentName.Text;
                    item.GroupName = tbGroupName.Text;
                    item.ModifiedDate = DateTime.Now;
                }

                context.SaveChanges();
            }
        }

        private void UpdateDataForm_Load(object sender, EventArgs e)
        {
            UpdateData();
        }
        void UpdateData()
        {
            lblDepartmentID.Text = $"Department ID: {_departmentID}";
            using (var context = new AdventureWorks2017Entities())
            {
                tbDepartmentName.Text = context.Departments.Where(x => x.DepartmentID == _departmentID)
                                    .Select(x => x.Name).FirstOrDefault();

                tbGroupName.Text = context.Departments.Where(x => x.DepartmentID == _departmentID)
                                    .Select(x => x.GroupName).FirstOrDefault();
            }
        }
    }
}
