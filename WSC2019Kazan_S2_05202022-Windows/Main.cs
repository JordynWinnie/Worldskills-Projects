using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSC2019Kazan_S5_05202022_Windows
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Context())
            {
                var user = context.Employees
                    .Where(x=>x.Username == usernameTb.Text && x.Password == passwordTb.Text)
                    .FirstOrDefault();

                if (user != null)
                {
                    if (user.IsAdmin.HasValue)
                    {
                        // Admin Login, Maintainence Manager
                        var newForm = new ManagingEmRequestsByMaintencanceManager();
                        Hide();
                        newForm.ShowDialog();
                        Show();

                    }
                    else
                    {
                        // Non Admin Login, Accountable Party
                        var newForm = new ManagingEMRequestsAccountableParty();
                        Hide();
                        newForm.ShowDialog();
                        Show();
                    }
                }
                else
                {
                    MessageBox.Show("Username or password is wrong");
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
