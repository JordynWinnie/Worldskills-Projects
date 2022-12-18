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
    public partial class CreateForm : Form
    {
        public int _departmentID;
        public CreateForm()
        {
            InitializeComponent();
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            using (var context = new AdventureWorks2017Entities())
            {
                _departmentID = context.Departments.OrderByDescending(x => x.DepartmentID).Select(x => x.DepartmentID).First() + 1;
                lblDepartmentID.Text = $"Department ID: {_departmentID}";
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            using (var context = new AdventureWorks2017Entities())
            {
                if (tbDepartmentName.Text == string.Empty || tbGroupName.Text == string.Empty)
                {
                    MessageBox.Show("Please fill up all the boxes");
                }
                else
                {
                    Department newDep = new Department
                    {
                        DepartmentID = (short)_departmentID,
                        Name = tbDepartmentName.Text,
                        GroupName = tbGroupName.Text,
                        ModifiedDate = DateTime.Now
                    };

                    context.Departments.Add(newDep);
                    context.SaveChanges();
                    this.Close();
                }
            }
        }
    }
}
