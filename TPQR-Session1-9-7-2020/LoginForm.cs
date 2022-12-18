using System;
using System.Windows.Forms;

namespace TPQR_Session1_9_7_2020
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void CreateAccBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new RMAccountCreationForm().ShowDialog();
            Show();
        }

        private void ResourceMgrLoginBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new RMLoginForm().ShowDialog();
            Show();
        }
    }
}