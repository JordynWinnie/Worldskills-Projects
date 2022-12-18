using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NTUPracticeMock2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            using (var context = new AdventureWorks2017Entities())
            {
                var query = from x in context.Employees
                            join y in context.EmployeeDepartmentHistories on x.BusinessEntityID equals y.BusinessEntityID
                            join z in context.Departments on y.DepartmentID equals z.DepartmentID
                            where x.LoginID.Equals(UsernameTb.Text)
                            select new
                            {
                                x,
                                x.BirthDate,
                                x.OrganizationLevel,
                                z.Name,
                                z.GroupName
                            };

                foreach (var item in query)
                {
                    if (PasswordTb.Text.Equals(item.BirthDate.ToString("yyyyMMdd")))
                    {
                        if (item.OrganizationLevel <= 2 && item.Name.Contains("Human"))
                        {
                            //Human Resource + Manager
                            MessageBox.Show("HR + Manager");

                            ManageHumanResources form = new ManageHumanResources(new SessionInformation(true,
                                true, item.x));
                            form.ShowDialog();
                            

                        }
                        else if (item.OrganizationLevel <= 2)
                        {
                            //Manager Only
                            MessageBox.Show("Manager ONLY");
                            ManageHumanResources form = new ManageHumanResources(new SessionInformation(false,
                                true, item.x));
                            form.ShowDialog();
                            

                        }
                        else if (item.Name.Contains("Human"))
                        {
                            //HR only
                            MessageBox.Show("HR Only");
                            ManageHumanResources form = new ManageHumanResources(new SessionInformation(true,
                                false, item.x));
                            form.ShowDialog();
                            
                        }
                        else
                        {
                            //Neither
                            MessageBox.Show("Sorry, you are not allowed to access this page");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong password or username! Please try again");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsernameTb.Text = @"adventure-works\paula0";
            PasswordTb.Text = "19760211";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsernameTb.Text = @"adventure-works\grant0";
            PasswordTb.Text = "19760416";
        }
    }
}
