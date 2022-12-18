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

namespace AbuDhabu_Session2_4_11_2020
{
    public partial class ImportFlightsForm : Form
    {
        public ImportFlightsForm()
        {
            InitializeComponent();
        }

        private void ImportFlightsForm_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog()
            {
                RestoreDirectory = true,
                Filter = "csv Files (.csv)|*.csv"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }

        private void ReadFile()
        {
            using (var context = new Session2Entities())
            {
                var rawFile = File.ReadAllLines(textBox1.Text);
                int missingFields = 0;
                int duplicateFields = 0;
                int changesApplied = 0;

                foreach (var line in rawFile)
                {
                    DateTime depDate;
                    TimeSpan depTime;
                    var row = line.Split(',');
                    if (row.Length < 9 || row.Length > 9)
                    {
                        missingFields++;
                        continue;
                    }
                    var action = row[0];
                    if (!DateTime.TryParse(row[1], out depDate))
                    {
                        missingFields++;
                        continue;
                    }

                    if (!TimeSpan.TryParse(row[2], out depTime))
                    {
                        missingFields++;
                        continue;
                    }

                    var flightNo = row[3];
                    var depIATA = row[4];
                    var arrIATA = row[5];
                    var aircraftCode = int.Parse(row[6]);
                    var economyPrice = decimal.Parse(row[7]);
                    var confirmation = row[8].Equals("OK") ? true : false;
                    /*operation, departure date, departure time, flight number,
                     * IATA code of departure airport, IATA code of arrival airport,
                     * aircraft code, base price and confirmation*/

                    var routeId = context.Routes.Where(x => x.Airport.IATACode == depIATA && x.Airport1.IATACode == arrIATA).First().ID;

                    if (action.Equals("ADD"))
                    {
                        var confirmFlight = context.Schedules.ToList().Where(x => x.FlightNumber == flightNo && x.Date.ToShortDateString() == depDate.ToShortDateString()).Any();

                        if (confirmFlight)
                        {
                            duplicateFields++;
                            continue;
                        }

                        var newFlight = new Schedule
                        {
                            Date = depDate,
                            Time = depTime,
                            AircraftID = aircraftCode,
                            EconomyPrice = economyPrice,
                            FlightNumber = flightNo,
                            RouteID = routeId,
                            Confirmed = confirmation
                        };

                        context.Schedules.Add(newFlight);
                        changesApplied++;
                    }
                    else
                    {
                        var flightToEdit = context.Schedules.ToList().Where(x => x.FlightNumber == flightNo && x.Date.ToShortDateString() == depDate.ToShortDateString());

                        if (flightToEdit.Any())
                        {
                            flightToEdit.First().AircraftID = aircraftCode;
                            flightToEdit.First().Date = depDate;
                            flightToEdit.First().Time = depTime;
                            flightToEdit.First().EconomyPrice = economyPrice;
                            flightToEdit.First().FlightNumber = flightNo;
                            flightToEdit.First().RouteID = routeId;
                            flightToEdit.First().Confirmed = confirmation;
                            changesApplied++;
                        }
                        else
                        {
                            missingFields++;
                            continue;
                        }
                    }
                }

                successfulRecords.Text = $"Successful Changes Applied: {changesApplied}";
                duplicateRecords.Text = $"Duplicate Records Found: {duplicateFields}";
                missingRecords.Text = $"Records with missing fields discarded: {missingFields}";

                context.SaveChanges();
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            ReadFile();
        }
    }
}