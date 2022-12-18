using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NTUPracticeMock2
{
    public partial class ManageHumanResources : Form
    {
        public SessionInformation currentSession;

        public ManageHumanResources(SessionInformation s)
        {
            currentSession = s;
            InitializeComponent();
        }

        private void ManageHumanResources_Load(object sender, EventArgs e)
        {

            using (var context = new AdventureWorks2017Entities())
            {
                employeeGrid.Rows.Clear();

                employeeGrid.ColumnCount = 7;
                employeeGrid.Columns[0].Name = "Title";
                employeeGrid.Columns[1].Name = "Name";
                employeeGrid.Columns[2].Name = "Job Title";
                employeeGrid.Columns[3].Name = "Email";
                employeeGrid.Columns[4].Name = "City";
                employeeGrid.Columns[5].Name = "State";
                employeeGrid.Columns[6].Name = "Business ID (DEBUG)";

                employeeGrid.Columns[6].Visible = false;

                var mainQuery = from x in context.vEmployees
                                join y in context.EmailAddresses on x.BusinessEntityID equals y.BusinessEntityID
                                select new
                                {
                                    x.Title,
                                    Name = x.FirstName + " " + x.MiddleName + " " + x.LastName,
                                    x.JobTitle,
                                    y.EmailAddress1,
                                    x.City,
                                    x.StateProvinceName,
                                    x.BusinessEntityID
                                };

                var HROnly = from x in context.Employees
                             where x.OrganizationLevel >= 3
                             join y in context.EmailAddresses on x.BusinessEntityID equals y.BusinessEntityID
                             join z in context.vEmployees on x.BusinessEntityID equals z.BusinessEntityID
                             select new
                             {
                                 z.Title,
                                 Name = z.FirstName + " " + z.MiddleName + " " + z.LastName,
                                 x.JobTitle,
                                 y.EmailAddress1,
                                 z.City,
                                 z.StateProvinceName,
                                 x.BusinessEntityID
                             };

                var managerEmployee = from x in context.uspGetManagerEmployees(currentSession.currentUser.BusinessEntityID)
                                      select x.BusinessEntityID;

                if (currentSession.isHR && currentSession.isManager)
                {
                    ViewExitedStaffBtn.Visible = true;
                    AddNewStaffBtn.Visible = true;

                    foreach (var item in mainQuery)
                    {
                        object[] vs = new object[7];
                        vs[0] = item.Title;
                        vs[1] = item.Name;
                        vs[2] = item.JobTitle;
                        vs[3] = item.EmailAddress1;
                        vs[4] = item.City;
                        vs[5] = item.StateProvinceName;
                        vs[6] = item.BusinessEntityID;

                        employeeGrid.Rows.Add(vs.ToArray());
                    }
                }
                else if (currentSession.isHR)
                {
                    foreach (var item in HROnly)
                    {
                        object[] vs = new object[7];
                        vs[0] = item.Title;
                        vs[1] = item.Name;
                        vs[2] = item.JobTitle;
                        vs[3] = item.EmailAddress1;
                        vs[4] = item.City;
                        vs[5] = item.StateProvinceName;
                        vs[6] = item.BusinessEntityID;

                        employeeGrid.Rows.Add(vs.ToArray());
                    }
                }
                else if (currentSession.isManager)
                {
                    foreach (var employeeID in managerEmployee)
                    {
                        foreach (var item in mainQuery)
                        {
                            if (item.BusinessEntityID.Equals(employeeID))
                            {
                                object[] vs = new object[7];
                                vs[0] = item.Title;
                                vs[1] = item.Name;
                                vs[2] = item.JobTitle;
                                vs[3] = item.EmailAddress1;
                                vs[4] = item.City;
                                vs[5] = item.StateProvinceName;
                                vs[6] = item.BusinessEntityID;

                                employeeGrid.Rows.Add(vs.ToArray());
                            }
                        }

                    }
                }
                else
                {

                }
            }
        }

        private void ViewExitedStaffBtn_Click(object sender, EventArgs e)
        {
            using (var context = new AdventureWorks2017Entities())
            {
                var mainQuery = from x in context.vEmployees
                                join y in context.EmailAddresses on x.BusinessEntityID equals y.BusinessEntityID
                                join z in context.EmployeeDepartmentHistories on x.BusinessEntityID equals z.BusinessEntityID
                                select new
                                {
                                    x.Title,
                                    Name = x.FirstName + " " + x.MiddleName + " " + x.LastName,
                                    x.JobTitle,
                                    y.EmailAddress1,
                                    x.City,
                                    x.StateProvinceName,
                                    x.BusinessEntityID,
                                    z.EndDate
                                };
                if (ViewExitedStaffBtn.Text.Contains("Exited"))
                {
                    ViewExitedStaffBtn.Text = "View Current Staff";
                    AddNewStaffBtn.Visible = false;
                    employeeGrid.Rows.Clear();
                    foreach (var item in mainQuery)
                    {
                        if (item.EndDate != null)
                        {
                            object[] vs = new object[7];
                            vs[0] = item.Title;
                            vs[1] = item.Name;
                            vs[2] = item.JobTitle;
                            vs[3] = item.EmailAddress1;
                            vs[4] = item.City;
                            vs[5] = item.StateProvinceName;
                            vs[6] = item.BusinessEntityID;

                            employeeGrid.Rows.Add(vs.ToArray());
                        }
                    }
                }
                else
                {
                    ViewExitedStaffBtn.Text = "View Exited Staff";
                    AddNewStaffBtn.Visible = true;
                    employeeGrid.Rows.Clear();
                    foreach (var item in mainQuery)
                    {
                        object[] vs = new object[7];
                        vs[0] = item.Title;
                        vs[1] = item.Name;
                        vs[2] = item.JobTitle;
                        vs[3] = item.EmailAddress1;
                        vs[4] = item.City;
                        vs[5] = item.StateProvinceName;
                        vs[6] = item.BusinessEntityID;

                        employeeGrid.Rows.Add(vs.ToArray());
                    }
                }

            }
        }

        private void ManageStaffBtn_Click(object sender, EventArgs e)
        {
            if (currentSession.modifiedUserID == 0)
            {
                MessageBox.Show("Please select an Employee to modify.");
            }
            else
            {
                UpdateStaff update = new UpdateStaff(currentSession);
                update.ShowDialog();
                ManageHumanResources_Load(null, null);
            }
        }

        private void employeeGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = e.RowIndex;

            if (index > 0)
            {
                var selectedRow = employeeGrid.Rows[index];
                currentSession.modifiedUserID = Int32.Parse(selectedRow.Cells[6].Value.ToString());
                label2.Text = currentSession.modifiedUserID.ToString();
            }
            
        }

        private void AddNewStaffBtn_Click(object sender, EventArgs e)
        {
            AddNewStaff addNewStaff = new AddNewStaff(currentSession);
            addNewStaff.ShowDialog();
        }
    }
}
