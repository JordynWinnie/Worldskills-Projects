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
    public partial class MainMenuForm : Form
    {
        /// <summary> GOAL:
        /// Create the main menu of the application, as outlined in “1. Main menu” in the wireframe.
        /// This screen can be accessed by all users.
        /// </summary>

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void createNewAccountBtn_Click(object sender, EventArgs e)
        {
            //Shows account creation form
            this.Hide();
            (new RMAccountCreationForm()).ShowDialog();
            this.Show();
        }

        private void resourceManagerLoginBtn_Click(object sender, EventArgs e)
        {
            //Shows login form
            this.Hide();
            (new RMLoginForm()).ShowDialog();
            this.Show();
        }
    }
}
