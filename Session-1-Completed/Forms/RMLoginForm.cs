using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session1_JordanKhong.Forms
{
    public partial class RMLoginForm : Form
    {
        public RMLoginForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            #region Login Logic

            using (var context = new Session1Entities())
            {
                //Gets the login info based on Username and password, tries to get user type.
                var loginQuery = context.Users.Where(x => x.userId == userIdTb.Text && x.userPw == passwordTb.Text)
                    .Select(x => x.User_Type)
                    .FirstOrDefault();

                if (loginQuery == null)
                {
                    //if no results are returned, it means wrong password/username
                    MessageBox.Show("Wrong username or password!");
                }
                else if (loginQuery.userTypeId != 1)
                {
                    //Does not allow anyone who is not a resource manager to log in.
                    //1 refers to Resource Manager
                    MessageBox.Show("Only resource managers can log in. You are currently a: " + loginQuery.userTypeName); ;
                }
                else
                {
                    //Login to resource mgr
                    this.Hide();
                    (new ResourceManagementForm()).ShowDialog();
                    this.Show();
                }
            }

            #endregion
        }

        private void RMLoginForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
