using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbuDhabu_Session4_12_11_2020
{
    public partial class ImportData : Form
    {
        private Session4Entities1 context = new Session4Entities1();

        public ImportData()
        {
            InitializeComponent();
        }

        private void ImportData_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                RestoreDirectory = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var file = File.ReadAllLines(ofd.FileName).Skip(1);

                foreach (var line in file)
                {
                    var row = line.Split(',');
                    var departure = row[0];
                    var arrival = row[1];
                    var age = row[2];

                    int outAge = -1;

                    int.TryParse(age, out outAge);
                    var gender = row[3];
                    var cabinType = row[4];
                    var q1 = int.Parse(row[5]);
                    var q2 = int.Parse(row[6]);
                    var q3 = int.Parse(row[7]);
                    var q4 = int.Parse(row[8]);

                    var q1Rating = context.RatingTables.Where(x => x.rating == q1).Select(x => x.ratingId).FirstOrDefault();
                    var q2Rating = context.RatingTables.Where(x => x.rating == q2).Select(x => x.ratingId).FirstOrDefault();
                    var q3Rating = context.RatingTables.Where(x => x.rating == q3).Select(x => x.ratingId).FirstOrDefault();
                    var q4Rating = context.RatingTables.Where(x => x.rating == q4).Select(x => x.ratingId).FirstOrDefault();

                    var cabinTypeID = context.CabinTypes.Where(x => x.cabinTypeName == cabinType).Select(x => x.cabinTypeId).FirstOrDefault();
                    var insertAnswer = new AnswerTable
                    {
                        depature = departure.Equals(string.Empty) ? null : departure,
                        arrival = arrival.Equals(string.Empty) ? null : arrival,
                        cabinTypeIdFK = cabinTypeID,
                        dateOfAnswer = DateTime.Parse("1 July 2017"),
                        gender = gender.Equals(string.Empty) ? null : gender,
                        q1RatingFK = q1Rating,
                        q2RatingFK = q2Rating,
                        q3RatingFK = q3Rating,
                        q4RatingFK = q4Rating,
                        age = outAge == 0 ? -1 : outAge
                    };

                    context.AnswerTables.Add(insertAnswer);
                    context.SaveChanges();
                }

                MessageBox.Show("Changes Saved");
            }
        }
    }
}