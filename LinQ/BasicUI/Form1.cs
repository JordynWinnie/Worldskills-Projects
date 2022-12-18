using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicUI
{
    public partial class Form1 : Form
    {

        List<string[]> tempList = new List<string[]>();

        DataTable table = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var columns = new string[] { "Name", "Email" };

            foreach (var item in columns)
            {
                table.Columns.Add(item);
            }

            dataGridView1.DataSource = table;

            table.Clear();

            using (var db = new AdventureWorks2017Entities1())
            {
                var query = (from x in db.EmailAddresses
                             orderby x.Person.FirstName
                             select x);

                foreach (var item in query)
                {
                    tempList.Add(new string[] { item.Person.FirstName + " " + item.Person.LastName, item.EmailAddress1 });

                }
                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            table.Clear();

           

            if (textBox1.Text.Equals(""))
            {
                string[] helpRow = new string[] { "Enter a query!", "" };
                table.Rows.Add(helpRow);
            }
            else
            {
                var liveQuery = from x in tempList
                                where x[0].Contains(textBox1.Text)
                                select new { Name = x[0], Email = x[1] };

                if (!liveQuery.Any())
                {
                    string[] helpRow = new string[] { "No Results returned!", "" };
                    table.Rows.Add(helpRow);
                }
                else
                {
                    foreach (var item in liveQuery)
                    {
                        string[] row = new string[] { item.Name, item.Email };
                        
                        table.Rows.Add(row);
                    }
                }
                
            }
           
        }

        private void printName_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRows = dataGridView1.Rows[index];
            try
            {
                string firstName = selectedRows.Cells[0].Value.ToString();

                label3.Text = $"{firstName}";
            }
            catch (Exception exception)
            {

                throw exception;
            }

        }

        public class NameEmail 
        {
            public string name { get; set; }
            public string email { get; set; }

            public NameEmail(string name, string email)
            {
                this.name = name;
                this.email = email;
            }

            public NameEmail()
            {
            }
        }

    }
}
