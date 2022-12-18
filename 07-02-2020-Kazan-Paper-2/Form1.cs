using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07_02_2020_Kazan_Paper_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                var isAdmin = context.Employees.Where(x => x.Username == usernameTb.Text && x.Password == passwordTb.Text).First();
                if (context.Employees.Where(x=>x.Username == usernameTb.Text && x.Password == passwordTb.Text).Select(x=>x.isAdmin).First() == true)
                {
                    //Open the admin page
                    (new FormManagingEMRequestsAccountableParty(isAdmin.ID)).ShowDialog();
                }
                else
                {
                    //Open the non-admin page
                    (new FormManagingEMRequestsMaintenanceManager(isAdmin.ID)).ShowDialog();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
