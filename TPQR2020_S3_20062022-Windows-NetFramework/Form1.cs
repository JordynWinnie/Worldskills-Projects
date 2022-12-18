using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR2020_S3_20062022_Windows_NetFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var newForm = new CountryRepAccCreation();

            Hide();
            newForm.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (useridTb.Text == string.Empty || passwordTb.Text == string.Empty)
            {
                MessageBox.Show("Please fill in all the fields");
                return;
            }

            using (var context = new Session3Entities())
            {
                var user = context.Users.Where(x=>x.passwd == passwordTb.Text && x.userId == useridTb.Text).FirstOrDefault();

                if (user != null)
                {

                }
                else
                {
                    MessageBox.Show("");
                }
            }
        }
    }
}
