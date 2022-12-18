using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPage
{
    public partial class ManageStaff : Form
    {
        private Session s = new Session();

        public ManageStaff(Session session)
        {
            InitializeComponent();
            s = session;
        }

        private void ManageStaff_Load(object sender, EventArgs e)
        {
            using (AdventureWorks2017Entities context = new AdventureWorks2017Entities())
            {
                businessEnLbl.Text = s.modifiedCurrentUserID.ToString();

                var currentModified = s.modifiedCurrentUserID;

                //businessEnLbl.Text = currentModified.ToString();

                var infoQuery = from x in context.vEmployees
                                join y in context.Employees on x.BusinessEntityID equals y.BusinessEntityID
                                join z in context.EmployeeDepartmentHistories on y.BusinessEntityID equals z.BusinessEntityID
                                where x.BusinessEntityID.Equals(s.modifiedCurrentUserID)
                                select new
                                {
                                    FirstName = x.FirstName,
                                    MiddleName = x.MiddleName,
                                    LastName = x.LastName,
                                    DateOfBirth = y.BirthDate,
                                    Gender = y.Gender,
                                    Married = y.MaritalStatus,
                                    Department = z.Department.Name + " " + z.Department.GroupName,
                                    PhoneNo = x.PhoneNumber,
                                    PhoneType = x.PhoneNumberType,
                                    Email = x.EmailAddress,
                                    AddressL1 = x.AddressLine1,
                                    AddressL2 = x.AddressLine2,
                                    City = x.City,
                                    State = x.StateProvinceName,
                                    Postal = x.PostalCode,
                                    DepartmentID = z.Department.DepartmentID
                                };

                var managerList = from x in context.Employees
                                  join y in context.EmployeeDepartmentHistories on x.BusinessEntityID equals y.BusinessEntityID
                                  where x.OrganizationLevel <= 2
                                  select new { 
                                  y.DepartmentID,
                                  Name = x.Person.FirstName + " " + x.Person.MiddleName + " " + x.Person.LastName
                                  };

                var departmentList = from x in context.Departments
                                     orderby x.DepartmentID
                                     select new
                                     {
                                         x.DepartmentID,
                                         x.GroupName,
                                         x.Name
                                     };
               
                var selectedEmployeeDepID = infoQuery.First().DepartmentID;


                MessageBox.Show(selectedEmployeeDepID.ToString());

                foreach (var manager in managerList)
                {
                    if (manager.DepartmentID == selectedEmployeeDepID)
                    {
                        managerCb.Items.Add(manager.Name);
                    }
                }

                foreach (var department in departmentList)
                {
                    departmentCb.Items.Add(department.GroupName + " - " + department.Name);
                }

                employeeList.DataSource = infoQuery.ToList();

                genderCb.Items.Add("F");
                genderCb.Items.Add("M");

                martialCb.Items.Add("M");
                martialCb.Items.Add("S");

                phoneNoCb.Items.Add("Cell");
                phoneNoCb.Items.Add("Home");
                phoneNoCb.Items.Add("Work");

                foreach (var information in infoQuery)
                {
                    firstNameTb.Text = information.FirstName;
                    middleNameTb.Text = information.MiddleName;
                    lastNameTb.Text = information.LastName;

                    departmentCb.SelectedIndex = information.DepartmentID;

                    datePickerDOB.Value = information.DateOfBirth;

                    genderCb.SelectedItem = information.Gender;

                    martialCb.SelectedItem = information.Married;

                    phoneNoTb.Text = information.PhoneNo;

                    phoneNoCb.SelectedItem = information.PhoneType;

                    emailTb.Text = information.Email;

                    addressLine1Tb.Text = information.AddressL1;

                    addressLine2Tb.Text = information.AddressL2;

                    cityTb.Text = information.City;

                    postalCodeTb.Text = information.Postal;

                    stateTb.Text = information.State;
                }

            }

        }
    }
}
