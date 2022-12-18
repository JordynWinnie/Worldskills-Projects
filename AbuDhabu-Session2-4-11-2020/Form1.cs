using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbuDhabu_Session2_4_11_2020
{
    public partial class Form1 : Form
    {
        private Session2Entities context = new Session2Entities();
        private int _selectedId = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void sortByCb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sortByCb.Items.AddRange(new string[] { "Date & Time", "Price of Flight", "Confirmed" });
            sortByCb.SelectedIndex = 0;

            fromCb.Items.Add("All Flights");
            toCb.Items.Add("All Flights");

            fromCb.Items.AddRange(context.Airports.Select(x => x.IATACode).ToArray());
            toCb.Items.AddRange(context.Airports.Select(x => x.IATACode).ToArray());

            fromCb.SelectedIndex = 0;
            toCb.SelectedIndex = 0;

            var columns = new List<string>
            {
                "Date", "Time", "From", "To", "Flight Number", "Aircraft", "Economy Price", "Business Price", "First Class Price", "ID", "Confirmed"
            };

            foreach (var column in columns)
            {
                flightsDGV.Columns.Add(column, column);
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            ApplySearch();
        }

        private void ApplySearch()
        {
            using (var context = new Session2Entities())
            {
                var defaultFlights = (from x in context.Schedules

                                      select x).ToList();
                switch (sortByCb.SelectedIndex)
                {
                    case 0:
                        defaultFlights = defaultFlights.OrderByDescending(x => x.Date).ToList();
                        break;

                    case 1:
                        defaultFlights = defaultFlights.OrderByDescending(x => x.EconomyPrice).ToList();
                        break;

                    case 2:
                        defaultFlights = defaultFlights.OrderByDescending(x => x.Confirmed).ToList();
                        break;

                    default:
                        break;
                }

                if (fromCb.SelectedIndex != 0)
                {
                    defaultFlights = defaultFlights.Where(x => x.Route.Airport.IATACode == fromCb.SelectedItem.ToString()).ToList();
                }

                if (toCb.SelectedIndex != 0)
                {
                    defaultFlights = defaultFlights.Where(x => x.Route.Airport1.IATACode == toCb.SelectedItem.ToString()).ToList();
                }

                if (outboundDTP.Checked)
                {
                    defaultFlights = defaultFlights.Where(x => x.Date.ToShortDateString() == outboundDTP.Value.ToShortDateString()).ToList();
                }

                if (flightNoTb.TextLength > 0)
                {
                    defaultFlights = defaultFlights.Where(x => x.FlightNumber.Contains(flightNoTb.Text)).ToList();
                }

                flightsDGV.Rows.Clear();

                foreach (var flight in defaultFlights)
                {
                    //"Date", "Time", "From", "To", "Flight Number", "Aircraft", "Economy Price", "Business Price", "First Class Price"
                    var row = new List<string>
                {
                    flight.Date.ToShortDateString(),
                    flight.Time.ToString(),
                    flight.Route.Airport.IATACode,
                    flight.Route.Airport1.IATACode,
                    flight.FlightNumber,
                    flight.Aircraft.Name,
                    flight.EconomyPrice.ToString("0"),
                    Math.Truncate( double.Parse((flight.EconomyPrice * new decimal(1.35)).ToString())).ToString(),
                    Math.Truncate(double.Parse((flight.EconomyPrice * new decimal(1.35) * new decimal(1.3)).ToString())).ToString(),
                    flight.ID.ToString(),
                    flight.Confirmed.ToString()
                };

                    flightsDGV.Rows.Add(row.ToArray());
                }

                foreach (DataGridViewRow row1 in flightsDGV.Rows)
                {
                    if (row1.Cells[10].Value.ToString() == "False")
                    {
                        row1.DefaultCellStyle.BackColor = Color.Red;
                        row1.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        private void flightsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //"Date", "Time", "From", "To", "Flight Number", "Aircraft", "Economy Price", "Business Price", "First Class Price", "ID"
            _selectedId = int.Parse(flightsDGV[9, e.RowIndex].Value.ToString());
            Console.WriteLine(_selectedId);
        }

        private void cancelFlightButton_Click(object sender, EventArgs e)
        {
            if (_selectedId == -1)
            {
                MessageBox.Show("Please select a flight");
            }
            else
            {
                using (var context = new Session2Entities())
                {
                    var flightToModify = context.Schedules.Where(x => x.ID == _selectedId).First();

                    flightToModify.Confirmed = !flightToModify.Confirmed;
                    context.SaveChanges();
                    _selectedId = -1;
                    ApplySearch();
                }
            }
        }

        private void editFlightBtn_Click(object sender, EventArgs e)
        {
            if (_selectedId == -1)
            {
                MessageBox.Show("Please select a flight");
            }
            else
            {
                new EditFlightForm(_selectedId).ShowDialog();
                ApplySearch();
            }
        }

        private void importChangesButton_Click(object sender, EventArgs e)
        {
            new ImportFlightsForm().ShowDialog();
            ApplySearch();
        }
    }
}