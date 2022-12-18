using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LoginPage
{

    public partial class FrontPage : Form
    {


        public FrontPage()
        {
            InitializeComponent();
        }


        private void OKbtn_Click(object sender, EventArgs e)
        {
            using (AdventureWorks2017Entities context = new AdventureWorks2017Entities())
            {
                //Password Validation & Date Conversion
                IQueryable<Employee> username = from user in context.Employees
                                                where user.LoginID.Equals(usernameTb.Text)
                                                select user;

                if (passwordTb.Text.Equals("") || usernameTb.Text.Equals(""))
                {
                    MessageBox.Show("Please enter both username and password", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!username.Any())
                {
                    MessageBox.Show("Either username or password is incorrect!", "Hello",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (Employee item in username)
                    {
                        if (passwordTb.Text.Equals(item.BirthDate.ToString("yyyyMMdd")))
                        {
                            IQueryable<string> department = from x in context.vEmployeeDepartments
                                                            where x.BusinessEntityID.Equals(item.BusinessEntityID)
                                                            select x.Department;

                            MessageBox.Show($"Welcome, {item.Person.FirstName} from {department.FirstOrDefault()}");
                            Hide();
                            
                            ManageHumanResources mh = new ManageHumanResources(new Session(item, checkManager(item.OrganizationLevel),checkHR(department.FirstOrDefault())));
                            mh.ShowDialog();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Either username or password is incorrect!", "Hello",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private bool checkHR(string d)
        {
            if (d.Contains("Human Resources"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool checkManager(short? orgLevel)
        {
            if (orgLevel <= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usernameTb.Text = @"adventure-works\gordon0";
            passwordTb.Text = "19661129";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usernameTb.Text = @"adventure-works\roberto0";
            passwordTb.Text = "19741112";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            usernameTb.Text = @"adventure-works\paula0";
            passwordTb.Text = "19760211";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            usernameTb.Text = @"adventure-works\grant0";
            passwordTb.Text = "19760416";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ManageStaff form = new ManageStaff(new Session(new Employee(), false, false));

           form.Show();
        }

        private void FrontPage_Load(object sender, EventArgs e)
        {

        }
    }
}
