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

namespace ASEAN_2018_Paper1_27_10_2020
{
    public partial class Form1 : Form
    {
        private Session1Entities context = new Session1Entities();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filterTypeCb.SelectedIndex = 0;
        }

        private void NumberRolesByOffice()
        {
            chart1.Series.Clear();

            var avgPairing = new Dictionary<string, double>();
            var numberOfRolesByOffice = from x in context.Users
                                        where x.Active == true
                                        group x by x.Office.Title into y
                                        select y;

            chart1.Series.Add("Admin");
            chart1.Series.Add("User");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            foreach (var office in numberOfRolesByOffice)
            {
                chart1.Series["Admin"].Points.AddXY(office.Key, office.Where(x => x.Role.Title == "Administrator").Count());
                chart1.Series["User"].Points.AddXY(office.Key, office.Where(x => x.Role.Title == "User").Count());
                double countOfAdmin = office.Where(x => x.Role.Title == "Administrator").Count();
                double percentageOfAdmin = (countOfAdmin / office.Count());
                avgPairing.Add(office.Key, percentageOfAdmin);
            }

            var largestVal = avgPairing.Values.Max();
            var companies = avgPairing.Where(x => x.Value == largestVal).Select(x => x.Key);
            mostNumberLbl.Text = $"Highest Percentage: {string.Join(", ", companies)}";
        }

        private void GenerateFirstGraph()
        {
            chart1.Series.Clear();
            chart1.Series.Add("");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            var numberOfUsersByOffice = from x in context.Users
                                        where x.Active == true
                                        group x by x.Office.Title into y
                                        orderby y.Count() descending
                                        select y;

            foreach (var officeGroup in numberOfUsersByOffice)
            {
                //chart1.Series.Add(officeGroup.Key);

                chart1.Series[0].Points.AddXY(officeGroup.Key, officeGroup.Count());
            }
            var officesUserCount = numberOfUsersByOffice.First().Count();
            var officeWithNumberUser = from x in context.Users
                                       where x.Active == true
                                       group x by x.Office.Title into y
                                       where y.Count() == officesUserCount
                                       select y.Key;

            mostNumberLbl.Text = $"Office(s) with most number of users: {string.Join(",", officeWithNumberUser)}";
        }

        private void LoadData()
        {
            //rolename, email, password, Firstname, lastname, officeName, dateOfBirth, isActive

            var fileToRead = File.ReadAllLines(@"C:\Users\geenj\Downloads\01_SG\01_SG\Datafiles\WSC2018_TP09_A1_UserData_actual.csv");

            var id = 1;
            foreach (var item in fileToRead)
            {
                var row = item.Split(',');

                var roleName = row[0].Trim();
                var email = row[1].Trim();
                var password = row[2].Trim();
                var firstName = row[3].Trim();
                var lastName = row[4].Trim();
                var date = row[6].Trim();
                var officeName = row[5].Trim();
                var dateOfBirth = DateTime.ParseExact(date, "M/d/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                var isActive = row[7].Trim().Equals("1") ? true : false;

                var roleId = context.Roles.Where(x => x.Title == roleName).First().ID;
                var officeId = context.Offices.Where(x => x.Title == officeName).First().ID;

                var user = new User
                {
                    ID = id,
                    RoleID = roleId,
                    FirstName = firstName,
                    LastName = lastName,
                    Active = isActive,
                    Birthdate = dateOfBirth,
                    Email = email,
                    OfficeID = officeId,
                    Password = password
                };
                context.Users.Add(user);

                id++;
            }

            context.SaveChanges();
        }

        private void filterTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var startTime = DateTime.Now;

            switch (filterTypeCb.SelectedIndex)
            {
                case 0:
                    GenerateFirstGraph();
                    break;

                case 1:
                    NumberRolesByOffice();
                    break;

                default:
                    break;
            }

            var endTime = DateTime.Now;

            var timeTaken = endTime - startTime;

            timeTakenLabel.Text = $"Time Taken to Generate: {timeTaken.Minutes} mins, {timeTaken.Seconds} seconds, {timeTaken.Milliseconds} milsec";
        }
    }
}