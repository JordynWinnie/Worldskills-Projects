using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTUPracticeMock2
{
    public partial class UpdateStaff : Form
    {
        public SessionInformation currentSession;

        public UpdateStaff(SessionInformation s)
        {
            currentSession = s;
            InitializeComponent();
        }

        private void UpdateStaff_Load(object sender, EventArgs e)
        {

            using (var context = new AdventureWorks2017Entities())
            {
                #region Updating Comboboxes
                HashSet<string> genderHash = new HashSet<string>();
                HashSet<string> marrageHash = new HashSet<string>();
                HashSet<string> phoneNumberTypeHash = new HashSet<string>();
                HashSet<string> departmentHash = new HashSet<string>();
                HashSet<string> stateHash = new HashSet<string>();

                //ComboBox Population
                var genderQuery = from x in context.Employees
                                  select x.Gender;

                var marrageQuery = from x in context.Employees
                                   select x.MaritalStatus;

                var phoneTypeQ = from x in context.PhoneNumberTypes
                                 select x.Name;
                var stateQ = from x in context.StateProvinces
                             orderby x.StateProvinceID
                             select x;

                foreach (var state in stateQ)
                {
                    stateHash.Add(state.Name);
                }
                foreach (var gender in genderQuery)
                {
                    genderHash.Add(gender);
                }

                foreach (var marrageStatus in marrageQuery)
                {
                    marrageHash.Add(marrageStatus);
                }

                foreach (var phoneType in phoneTypeQ)
                {
                    phoneNumberTypeHash.Add(phoneType);
                }

                var departments = from x in context.Departments
                                  orderby x.DepartmentID
                                  select new
                                  {
                                      Department = x.GroupName + " - " + x.Name,
                                  };

                foreach (var item in departments)
                {
                    departmentHash.Add(item.Department);
                }

                GenderCb.Items.AddRange(genderHash.ToArray());
                MaritalStatusCb.Items.AddRange(marrageHash.ToArray());
                PhoneNumberTypeCb.Items.AddRange(phoneNumberTypeHash.ToArray());
                DepartmentCb.Items.AddRange(departmentHash.ToArray());
                stateCb.Items.AddRange(stateHash.ToArray());


                var managerList = from x in context.Employees
                                  join y in context.EmployeeDepartmentHistories on x.BusinessEntityID equals y.BusinessEntityID
                                  where x.OrganizationLevel <= 2
                                  select new
                                  {
                                      y.DepartmentID,
                                      x.Person.FirstName,
                                      x.Person.LastName
                                  };


                var getEmployeeManager = (from x in context.uspGetEmployeeManagers(currentSession.modifiedUserID)
                                          select new
                                          {
                                              x.ManagerFirstName,
                                              x.ManagerLastName
                                          }).FirstOrDefault();

                var getCurrentEmployeeDipID = context.EmployeeDepartmentHistories.Where(p => p.BusinessEntityID == currentSession.modifiedUserID).FirstOrDefault();

                foreach (var manager in managerList)
                {
                    if (manager.DepartmentID == getCurrentEmployeeDipID.DepartmentID)
                    {
                        StringBuilder sb = new StringBuilder(manager.FirstName + " " + manager.LastName);
                        ManagerCb.Items.Add(sb.ToString());
                    }
                }
                ManagerCb.SelectedItem = getEmployeeManager.ManagerFirstName + " " + getEmployeeManager.ManagerLastName;

                #endregion

                label11.Text = getEmployeeManager.ManagerFirstName + " " + getEmployeeManager.ManagerLastName;

                var infoQuery = from x in context.Employees
                                where x.BusinessEntityID.Equals(currentSession.modifiedUserID)
                                join y in context.BusinessEntityAddresses on x.BusinessEntityID equals y.BusinessEntityID
                                join z in context.Addresses on y.AddressID equals z.AddressID
                                join a in context.PersonPhones on x.BusinessEntityID equals a.BusinessEntityID
                                join b in context.PhoneNumberTypes on a.PhoneNumberTypeID equals b.PhoneNumberTypeID
                                join c in context.EmployeeDepartmentHistories on x.BusinessEntityID equals c.BusinessEntityID
                                join d in context.Departments on c.DepartmentID equals d.DepartmentID
                                join f in context.EmailAddresses on x.BusinessEntityID equals f.BusinessEntityID
                                join g in context.StateProvinces on z.StateProvinceID equals g.StateProvinceID
                                select new
                                {
                                    BusId = x.BusinessEntityID,
                                    FirstName = x.Person.FirstName,
                                    MiddleName = x.Person.MiddleName,
                                    LastName = x.Person.LastName,
                                    Birthday = x.BirthDate,
                                    Gender = x.Gender,
                                    Married = x.MaritalStatus,
                                    AddressL1 = z.AddressLine1,
                                    AddressL2 = z.AddressLine2,
                                    City = z.City,
                                    State = g.Name,
                                    PostalCode = z.PostalCode,
                                    PhoneNumber = a.PhoneNumber,
                                    PhoneNumberType = b.Name,
                                    DepartmentName = d.Name,
                                    Email = f.EmailAddress1,
                                    DepartmentID = d.DepartmentID,
                                    StateId = g.StateProvinceID
                                };


                var currentEmDepartment = (from x in context.Departments
                                           orderby x.DepartmentID descending
                                           join y in context.EmployeeDepartmentHistories on x.DepartmentID equals y.DepartmentID
                                           where y.BusinessEntityID == currentSession.modifiedUserID
                                           select new
                                           {
                                               Department = x.GroupName + " - " + x.Name,
                                               x,
                                               y
                                           }).First();

                var currentState = (from x in context.Addresses
                                    join y in context.BusinessEntityAddresses on x.AddressID equals y.AddressID
                                    join z in context.StateProvinces on x.StateProvinceID equals z.StateProvinceID
                                    orderby x.AddressID
                                    where y.BusinessEntityID == currentSession.modifiedUserID
                                    select new { x.StateProvinceID, z.Name }).First();


                foreach (var item in infoQuery)
                {
                    BusinessEntityLbl.Text = item.BusId.ToString();
                    FirstNameTb.Text = item.FirstName;
                    MiddleNameTb.Text = item.MiddleName;
                    LastNameTb.Text = item.LastName;

                    DateOfBirthdtp.Value = item.Birthday;
                    GenderCb.SelectedItem = item.Gender;
                    MaritalStatusCb.SelectedItem = item.Married;
                    stateCb.SelectedItem = currentState.Name;
                    DepartmentCb.SelectedItem = currentEmDepartment.Department;

                    PhoneNumberTypeCb.SelectedItem = item.PhoneNumberType;
                    PhoneNoTb.Text = item.PhoneNumber;
                    EmailTb.Text = item.Email;

                    AddressLine1Tb.Text = item.AddressL1;
                    AddressLine2Tb.Text = item.AddressL2;
                    CityTb.Text = item.City;
                    //StateTb.Text = item.State;
                    PostalCodeTb.Text = item.PostalCode;

                    //ManagerCb.SelectedItem = getEmployeeManager.First();
                }

            }
        }

        private void UpdateStaffInfoBtn_Click(object sender, EventArgs e)
        {
            using (var context = new AdventureWorks2017Entities())
            {
                SqlProviderServices.SqlServerTypesAssemblyName = typeof(SqlGeography).Assembly.FullName;
                var infoQuery = (from x in context.Employees
                                 where x.BusinessEntityID.Equals(currentSession.modifiedUserID)
                                 join y in context.BusinessEntityAddresses on x.BusinessEntityID equals y.BusinessEntityID
                                 join z in context.Addresses on y.AddressID equals z.AddressID
                                 join a in context.PersonPhones on x.BusinessEntityID equals a.BusinessEntityID
                                 join b in context.PhoneNumberTypes on a.PhoneNumberTypeID equals b.PhoneNumberTypeID
                                 join c in context.EmployeeDepartmentHistories on x.BusinessEntityID equals c.BusinessEntityID
                                 join d in context.Departments on c.DepartmentID equals d.DepartmentID
                                 join f in context.EmailAddresses on x.BusinessEntityID equals f.BusinessEntityID
                                 join g in context.StateProvinces on z.StateProvinceID equals g.StateProvinceID
                                 select new
                                 {
                                     /*BusId = x.BusinessEntityID,
                                     FirstName = x.Person.FirstName,
                                     MiddleName = x.Person.MiddleName,
                                     LastName = x.Person.LastName,
                                     Birthday = x.BirthDate,
                                     Gender = x.Gender,
                                     Married = x.MaritalStatus,

                                     AddressL1 = z.AddressLine1,
                                     AddressL2 = z.AddressLine2,

                                     City = z.City,
                                     State = g.Name,
                                     PostalCode = z.PostalCode,
                                     PhoneNumber = a.PhoneNumber,
                                     PhoneNumberType = b.Name,
                                     DepartmentName = d.Name,
                                     Email = f.EmailAddress1,
                                     DepartmentID = d.DepartmentID,
                                     StateId = g.StateProvinceID*/
                                     x,
                                     y,
                                     z,
                                     a,
                                     b,
                                     c,
                                     d,
                                     f,
                                     g
                                 }).First();

                infoQuery.x.Person.FirstName = FirstNameTb.Text;
                infoQuery.x.Person.MiddleName = MiddleNameTb.Text;
                infoQuery.x.Person.LastName = LastNameTb.Text;

                infoQuery.x.Gender = GenderCb.SelectedItem.ToString();
                infoQuery.x.MaritalStatus = MaritalStatusCb.SelectedItem.ToString();

                infoQuery.x.BirthDate = DateOfBirthdtp.Value;
                infoQuery.z.City = CityTb.Text;
                infoQuery.z.PostalCode = PostalCodeTb.Text;

                /*infoQuery.z.AddressLine1 = AddressLine1Tb.Text;
                infoQuery.z.AddressLine2 = AddressLine2Tb.Text;*/

                context.SaveChanges();
            }
        }
    }
}
