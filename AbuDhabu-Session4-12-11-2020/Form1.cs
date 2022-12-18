using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbuDhabu_Session4_12_11_2020
{
    public partial class Form1 : Form
    {
        private Session4Entities1 context = new Session4Entities1();

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var queryCache = context.AnswerTables.ToList();
            var columns = new List<string>
            {
                "Male", "Female", "18-24", "25-39", "40-59", "60+", "Economy", "Business", "First", "AUH", "BAH", "DOH", "RYU", "CAI"
            };

            foreach (var column in columns)
            {
                summaryDGV.Columns.Add(column, column);
            }

            var maleCount = queryCache.Where(x => x.gender == "M").Count();
            var femaleCount = queryCache.Where(x => x.gender == "F").Count();
            var count18 = queryCache.Where(x => x.age >= 18 && x.age <= 24).Count();
            var count25 = queryCache.Where(x => x.age >= 25 && x.age <= 39).Count();
            var count40 = queryCache.Where(x => x.age >= 40 && x.age <= 59).Count();
            var count60 = queryCache.Where(x => x.age >= 60).Count();
            var economyCount = queryCache.Where(x => x.CabinType.cabinTypeName == "Economy").Count();
            var businessCount = queryCache.Where(x => x.CabinType.cabinTypeName == "Business").Count();
            var firstCount = queryCache.Where(x => x.CabinType.cabinTypeName == "First").Count();
            var AUH = queryCache.Where(x => x.arrival == "AUH").Count();
            var BAH = queryCache.Where(x => x.arrival == "BAH").Count();
            var DOH = queryCache.Where(x => x.arrival == "DOH").Count();
            var RYU = queryCache.Where(x => x.arrival == "RYU").Count();
            var CAI = queryCache.Where(x => x.arrival == "CAI").Count();

            var dateRange = from x in queryCache
                            group x by new { Date = x.dateOfAnswer.Value.ToString("MMMM yyyy"), } into y
                            select y;

            var row = new List<string>
            {
                maleCount.ToString(), femaleCount.ToString(), count18.ToString(), count25.ToString(),
                count40.ToString(), count60.ToString(), economyCount.ToString(), businessCount.ToString(), firstCount.ToString(),
                AUH.ToString(), BAH.ToString(), DOH.ToString(), RYU.ToString(), CAI.ToString()
            };

            summaryDGV.Rows.Add(row.ToArray());

            fieldWorkLbl.Text = $"Fieldwork: {dateRange.First().Key.Date} - {dateRange.Last().Key.Date}";
            sampleSizeLbl.Text = $"Sample Size: {queryCache.Count()}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            if (new DetailedView().ShowDialog() == DialogResult.No)
            {
                Close();
                return;
            }

            Show();
        }
    }
}