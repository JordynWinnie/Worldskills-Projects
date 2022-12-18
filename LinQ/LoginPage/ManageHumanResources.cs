using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace LoginPage
{
    public partial class ManageHumanResources : Form
    {
        private Session s = new Session();

        public short profileID;
        public int businessID;


        public ManageHumanResources(Session session)
        {

            InitializeComponent();

            s = session;
            if (session.isManager && session.isHR)
            {
                Text = "Human Resource (Manager & HR)";
                label1.Text = $"Employee List for {session.currentUser.Person.FirstName} (Manager & HR)";
                addNewStaffBtn.Visible = true;
                viewExitedStaffBtn.Visible = true;
                profileID = 0;
            }
            else if (session.isHR)
            {
                Text = "Human Resource (HR ONLY)";
                label1.Text = $"Employee List for {session.currentUser.Person.FirstName} (HR Only)";
                profileID = 1;
            }
            else if (session.isManager)
            {
                Text = "Human Resource (MANAGER ONLY)";
                label1.Text = $"Employee List for {session.currentUser.Person.FirstName} (HR Only)";
                profileID = 2;
            }
            else
            {
                Text = "Human Resource (Non-Manager)";
                profileID = 3;
            }


            //Optimisation of DataGridView:

            //1: Double Buffer Enabled
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                employeeList,
                new object[] { true });

            //2: RowHeaderFixedWidthSize
            //employeeList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;

            //3: AutoSize
            //employeeList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

        }

        private void ManageHumanResources_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'adventureWorks2017DataSet.vEmployee' table. You can move, or remove it, as needed.
            vEmployeeTableAdapter.Fill(adventureWorks2017DataSet.vEmployee);

            using (AdventureWorks2017Entities context = new AdventureWorks2017Entities())
            {
                //Defining Column Names:
                employeeList.ColumnCount = 7;
                employeeList.Columns[0].Name = "Title";
                employeeList.Columns[1].Name = "Name";
                employeeList.Columns[2].Name = "Job Title";
                employeeList.Columns[3].Name = "Email Address";
                employeeList.Columns[4].Name = "City";
                employeeList.Columns[5].Name = "State";
                employeeList.Columns[6].Name = "BusinessEntityID";

                employeeList.Columns[6].Visible = false;

                List<DataGridViewRow> rows = new List<DataGridViewRow>();

                //General Query, to be compounded with other queries
                var tableJoin = from y in context.Employees
                                join x in context.vEmployees on y.BusinessEntityID equals x.BusinessEntityID
                                orderby x.BusinessEntityID
                                select new
                                {
                                    x.BusinessEntityID,
                                    Title = y.Person.Title,
                                    Name = y.Person.FirstName + " " + y.Person.MiddleName + " " + y.Person.LastName,
                                    JobTitle = y.JobTitle,
                                    Email = x.EmailAddress,
                                    City = x.City,
                                    State = x.StateProvinceName,
                                    OrgLevel = y.OrganizationLevel
                                    
                                };

                //Query ONLY for people under Manager:
                var underManager = from x in context.uspGetManagerEmployees(s.currentUser.BusinessEntityID)
                                   join y in context.vEmployees on x.BusinessEntityID equals y.BusinessEntityID
                                   select new
                                   {
                                       x.BusinessEntityID,
                                       Title = y.Title,
                                       Name = y.FirstName + " " + y.MiddleName + " " + y.LastName,
                                       JobTitle = y.JobTitle,
                                       Email = y.EmailAddress,
                                       City = y.City,
                                       State = y.StateProvinceName
                                   };

                switch (profileID)
                {
                    //MGR+HR = 0, HRONLY = 1, MGRONLY = 2, NONMGR = 3
                    case 0:

                        foreach (var item in tableJoin)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(employeeList);
                            row.Cells[0].Value = item.Title;
                            row.Cells[1].Value = item.Name;
                            row.Cells[2].Value = item.JobTitle;
                            row.Cells[3].Value = item.Email;
                            row.Cells[4].Value = item.City;
                            row.Cells[5].Value = item.State;
                            row.Cells[6].Value = item.BusinessEntityID;
                            rows.Add(row);
                        }

                        employeeList.Rows.AddRange(rows.ToArray());

                        break;

                    case 1:

                        var HRONLY = from y in tableJoin
                                     where y.OrgLevel >= 3
                                     select y;

                        foreach (var item in HRONLY)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(employeeList);
                            row.Cells[0].Value = item.Title;
                            row.Cells[1].Value = item.Name;
                            row.Cells[2].Value = item.JobTitle;
                            row.Cells[3].Value = item.Email;
                            row.Cells[4].Value = item.City;
                            row.Cells[5].Value = item.State;
                            row.Cells[6].Value = item.BusinessEntityID;
                            rows.Add(row);
                        }

                        employeeList.Rows.AddRange(rows.ToArray());

                        break;

                    case 2:
                        foreach (var item in underManager)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(employeeList);
                            row.Cells[0].Value = item.Title;
                            row.Cells[1].Value = item.Name;
                            row.Cells[2].Value = item.JobTitle;
                            row.Cells[3].Value = item.Email;
                            row.Cells[4].Value = item.City;
                            row.Cells[5].Value = item.State;
                            row.Cells[6].Value = item.BusinessEntityID;
                            rows.Add(row);
                        }

                        employeeList.Rows.AddRange(rows.ToArray());

                        break;
                    case 3:
                        break;

                    default:
                        MessageBox.Show("Invalid ProfileID detected, please relog.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }

        }

        private void manageStaffBtn_Click(object sender, EventArgs e)
        {
            ManageStaff manageStaffForm = new ManageStaff(s);

            Hide();
            manageStaffForm.ShowDialog();

            Close();
        }

        private void addNewStaffBtn_Click(object sender, EventArgs e)
        {

        }

        private void viewExitedStaffBtn_Click(object sender, EventArgs e)
        {
            using (AdventureWorks2017Entities context = new AdventureWorks2017Entities())
            {
                List<DataGridViewRow> rows = new List<DataGridViewRow>();

                var tableJoin = from y in context.Employees
                                join x in context.vEmployees on y.BusinessEntityID equals x.BusinessEntityID
                                orderby x.BusinessEntityID
                                select new
                                {
                                    x.BusinessEntityID,
                                    Title = y.Person.Title,
                                    Name = y.Person.FirstName + " " + y.Person.MiddleName + " " + y.Person.LastName,
                                    JobTitle = y.JobTitle,
                                    Email = x.EmailAddress,
                                    City = x.City,
                                    State = x.StateProvinceName,
                                    OrgLevel = y.OrganizationLevel
                                };

                if (viewExitedStaffBtn.Text.Contains("View Exited Staff"))
                {
                    viewExitedStaffBtn.Text = "View Current Staff";
                    addNewStaffBtn.Visible = false;
                    IQueryable<int> employeesQuit = from x in context.EmployeeDepartmentHistories
                                                    where x.EndDate != null
                                                    select x.BusinessEntityID;


                    foreach (var item in tableJoin)
                    {
                        foreach (int employee in employeesQuit)
                        {
                            if (item.BusinessEntityID == employee)
                            {
                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(employeeList);
                                row.Cells[0].Value = item.Title;
                                row.Cells[1].Value = item.Name;
                                row.Cells[2].Value = item.JobTitle;
                                row.Cells[3].Value = item.Email;
                                row.Cells[4].Value = item.City;
                                row.Cells[5].Value = item.State;
                                row.Cells[6].Value = item.BusinessEntityID;
                                rows.Add(row);
                            }
                        }
                    }
                    employeeList.Rows.Clear();
                    employeeList.Rows.AddRange(rows.ToArray());
                }
                else
                {
                    viewExitedStaffBtn.Text = "View Exited Staff";
                    addNewStaffBtn.Visible = true;
                    foreach (var item in tableJoin)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(employeeList);
                        row.Cells[0].Value = item.Title;
                        row.Cells[1].Value = item.Name;
                        row.Cells[2].Value = item.JobTitle;
                        row.Cells[3].Value = item.Email;
                        row.Cells[4].Value = item.City;
                        row.Cells[5].Value = item.State;
                        row.Cells[6].Value = item.BusinessEntityID;
                        rows.Add(row);
                    }

                    employeeList.Rows.Clear();
                    employeeList.Rows.AddRange(rows.ToArray());
                }
            }
        }

        private void employeeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = e.RowIndex;

            if (index >= 0)
            {
                DataGridViewRow selectedRow = employeeList.Rows[index];

                s.modifiedCurrentUserID = Int32.Parse(selectedRow.Cells[6].Value.ToString());
            }
            
        }
    }
}
