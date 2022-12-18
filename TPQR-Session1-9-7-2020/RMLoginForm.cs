using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TPQR_Session1_9_7_2020
{
    public partial class RMLoginForm : Form
    {
        private Session1Entities context = new Session1Entities();

        public RMLoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            var user = context.Users.Where(x => x.userId == usernameTb.Text && x.userPw == passwordTb.Text);

            if (user.Any())
            {
                if (user.First().userTypeIdFK == 1)
                {
                    //open form
                    Hide();
                    new ResourceManagementForm().ShowDialog();
                    Show();
                }
                else
                {
                    MessageBox.Show("Admins are not allowed to log into this portal");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        private void RMLoginForm_Load(object sender, EventArgs e)
        {
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}