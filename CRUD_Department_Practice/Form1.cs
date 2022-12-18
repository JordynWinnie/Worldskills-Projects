using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Department_Practice
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreateForm form = new CreateForm();
            form.ShowDialog();
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            ReadForm form = new ReadForm();
            form.ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete form = new Delete();
            form.ShowDialog();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateForm form = new UpdateForm();
            form.ShowDialog();
        }
    }
}
