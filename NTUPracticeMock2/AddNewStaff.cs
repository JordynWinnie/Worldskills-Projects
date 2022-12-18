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
    
    public partial class AddNewStaff : Form
    {
        public int NationalIdNo;
        public SessionInformation currentSession;
        public AddNewStaff(SessionInformation session)
        {
            currentSession = session;
            InitializeComponent();
        }

        private void AddNewStaffBtn_Click(object sender, EventArgs e)
        {
            SqlProviderServices.SqlServerTypesAssemblyName = typeof(SqlGeography).Assembly.FullName;

            using (AdventureWorks2017Entities context = new AdventureWorks2017Entities())
            {

                Person insertPerson = new Person();
                Employee insertEmployee = new Employee();
                Address insertAddress = new Address();
                EmailAddress insertEmailAddress = new EmailAddress();
                BusinessEntityAddress insertBEA = new BusinessEntityAddress();
                BusinessEntity insertBusinessEntity = new BusinessEntity();


                //Assigning Person Table first:
                int assignedBusinessID = context.People.OrderByDescending(x => x.BusinessEntityID).Select(x => x.BusinessEntityID).First();
                #region Inserting Person
                //Assigning new BusinessID:


                insertPerson.BusinessEntityID = assignedBusinessID;
                insertPerson.PersonType = "EM";
                insertPerson.NameStyle = false;
                insertPerson.Title = null;
                insertPerson.EmailPromotion = 0;
                insertPerson.AdditionalContactInfo = null;
                insertPerson.Demographics = context.People.Select(x => x.Demographics).FirstOrDefault();
                insertPerson.rowguid = Guid.NewGuid();
                insertPerson.ModifiedDate = DateTime.Now;


                if (!(FirstNameTb.Text.Equals("") || LastNameTb.Text.Equals("")))
                {
                    insertPerson.FirstName = FirstNameTb.Text;
                    insertPerson.MiddleName = MiddleNameTb.Text;
                    insertPerson.LastName = LastNameTb.Text;
                }
                else
                {
                    MessageBox.Show("Please enter at least a first and last name");
                }

                #endregion

                #region Insert Employee
                insertEmployee.BusinessEntityID = assignedBusinessID;
                insertEmployee.NationalIDNumber = NationalIdNo.ToString();


                busID.Text = assignedBusinessID.ToString();

                //Assigning new LoginID, do checks for duplicatename:

                StringBuilder loginID = new StringBuilder();

                Employee nameCheck = context.Employees.Where(x => x.LoginID.Contains(FirstNameTb.Text.ToLower())).OrderByDescending(x => x.LoginID).FirstOrDefault();

                if (nameCheck == null)
                {
                    loginID.Append(@"adventure-works\");
                    loginID.Append(FirstNameTb.Text.ToLower());
                    loginID.Append(0);

                    loginIDlbl.Text = loginID.ToString();

                    insertEmployee.LoginID = loginID.ToString();
                }
                else
                {
                    loginID.Append(@"adventure-works\");
                    char lastNo = nameCheck.LoginID.Last();
                    int loginIdNo = int.Parse(lastNo.ToString()) + 1;
                    loginID.Append(FirstNameTb.Text.ToLower());
                    loginID.Append(loginIdNo);

                    loginIDlbl.Text = loginID.ToString();

                    insertEmployee.LoginID = loginID.ToString();
                }

                insertEmployee.OrganizationLevel = (short)(OrgLevelCb.SelectedIndex + 1);
                insertEmployee.JobTitle = jobTitleTb.Text;
                insertEmployee.BirthDate = DateOfBirthdtp.Value;

                insertEmployee.MaritalStatus = MaritalStatusCb.SelectedItem.ToString();
                insertEmployee.Gender = GenderCb.SelectedItem.ToString();
                insertEmployee.HireDate = hireDateDtp.Value;
                insertEmployee.SalariedFlag = false;
                insertEmployee.VacationHours = 0;
                insertEmployee.SickLeaveHours = 0;
                insertEmployee.CurrentFlag = true;
                insertEmployee.rowguid = Guid.NewGuid();
                insertEmployee.ModifiedDate = DateTime.Now;
                
                #endregion

                #region Insert Address
                insertAddress.AddressID = context.Addresses.OrderByDescending(x => x.AddressID).Select(x => x.AddressID).FirstOrDefault() + 1;
                insertAddress.AddressLine1 = AddressLine1Tb.Text;
                insertAddress.AddressLine2 = AddressLine2Tb.Text;
                insertAddress.City = CityTb.Text;
                insertAddress.StateProvinceID = stateProvCb.SelectedIndex + 1;
                insertAddress.PostalCode = PostalCodeTb.Text;
                insertAddress.rowguid = Guid.NewGuid();
                insertAddress.ModifiedDate = DateTime.Now;

                #endregion

                #region Inserting Email
                insertEmailAddress.BusinessEntityID = assignedBusinessID;
                insertEmailAddress.EmailAddressID = context.EmailAddresses.OrderByDescending(x => x.EmailAddressID).Select(x => x.EmailAddressID).First() + 1;
                insertEmailAddress.EmailAddress1 = EmailTb.Text;
                insertEmailAddress.rowguid = Guid.NewGuid();
                insertEmailAddress.ModifiedDate = DateTime.Now;

                #endregion

                #region Inserting BusinessEntityAddress
                insertBEA.BusinessEntityID = assignedBusinessID;
                insertBEA.AddressID = context.Addresses.OrderByDescending(x => x.AddressID).Select(x => x.AddressID).First() + 1;
                insertBEA.AddressTypeID = 2;
                insertBEA.ModifiedDate = DateTime.Now;
                insertBEA.rowguid = Guid.NewGuid();

                #endregion

                #region Inserting BusinessEntity
                insertBusinessEntity.BusinessEntityID = assignedBusinessID;
                insertBusinessEntity.rowguid = Guid.NewGuid();
                insertBusinessEntity.ModifiedDate = DateTime.Now;

                #endregion

                context.People.Add(insertPerson);
                context.BusinessEntities.Add(insertBusinessEntity);
                context.Employees.Add(insertEmployee);
                context.Addresses.Add(insertAddress);
                context.EmailAddresses.Add(insertEmailAddress);
                context.BusinessEntityAddresses.Add(insertBEA);

                context.SaveChanges();

            }
        }

        private void AddNewStaff_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 9; i++)
            {
                sb.Append(random.Next(0, 9).ToString());
            }

            nationalIDLbl.Text = sb.ToString();

            NationalIdNo = int.Parse(sb.ToString());

            using (AdventureWorks2017Entities context = new AdventureWorks2017Entities())
            {
                DateOfBirthdtp.Value = DateTime.Now.AddYears(-19);

                #region Updating Comboboxes
                HashSet<string> genderHash = new HashSet<string>();
                HashSet<string> marrageHash = new HashSet<string>();
                HashSet<string> phoneNumberTypeHash = new HashSet<string>();
                HashSet<string> departmentHash = new HashSet<string>();
                HashSet<string> organisationLevelHash = new HashSet<string>();
                HashSet<string> stateProvincesHash = new HashSet<string>();

                //ComboBox Population

                IQueryable<string> phoneTypeQ = from x in context.PhoneNumberTypes
                                                select x.Name;

                foreach (string gender in context.Employees.OrderBy(x => x.Gender).Select(x => x.Gender))
                {
                    genderHash.Add(gender);
                }

                foreach (string marrageStatus in context.Employees.OrderBy(x => x.MaritalStatus).Select(x => x.MaritalStatus))
                {
                    marrageHash.Add(marrageStatus);
                }

                foreach (string phoneType in context.PhoneNumberTypes.OrderBy(x => x.PhoneNumberTypeID).Select(x => x.Name))
                {
                    phoneNumberTypeHash.Add(phoneType);
                }

                foreach (short? item in context.Employees.OrderBy(x => x.OrganizationLevel).Select(x => x.OrganizationLevel))
                {
                    if (item != null)
                    {
                        organisationLevelHash.Add(item.ToString());
                    }
                }

                foreach (var item in context.StateProvinces.OrderBy(x => x.StateProvinceID).Select(x => x.Name))
                {
                    stateProvincesHash.Add(item);
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
                OrgLevelCb.Items.AddRange(organisationLevelHash.ToArray());
                stateProvCb.Items.AddRange(stateProvincesHash.ToArray());

                GenderCb.SelectedIndex = 0;
                MaritalStatusCb.SelectedIndex = 0;
                PhoneNumberTypeCb.SelectedIndex = 0;
                DepartmentCb.SelectedIndex = 0;
                OrgLevelCb.SelectedIndex = 0;

                var managerList = from x in context.Employees
                                  join y in context.EmployeeDepartmentHistories on x.BusinessEntityID equals y.BusinessEntityID
                                  where x.OrganizationLevel <= 2
                                  select new
                                  {
                                      y.DepartmentID,
                                      x.Person.FirstName,
                                      x.Person.LastName
                                  };

                EmployeeDepartmentHistory getCurrentEmployeeDipID = context.EmployeeDepartmentHistories.Where(p => p.BusinessEntityID == currentSession.modifiedUserID).FirstOrDefault();

                foreach (var manager in managerList)
                {
                    StringBuilder stringBuilder = new StringBuilder(manager.FirstName + " " + manager.LastName);
                    ManagerCb.Items.Add(stringBuilder.ToString());

                }
                ManagerCb.SelectedIndex = 0;

                #endregion
            }
        }
    }
}
