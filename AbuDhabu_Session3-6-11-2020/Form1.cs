using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AbuDhabu_Session3_6_11_2020
{
    public partial class Form1 : Form
    {
        private Session3Entities context = new Session3Entities();
        private List<int> returnFlightNumbersList = new List<int>();
        private List<int> outboundFlightNumberList = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "From", "To", "Date", "Time", "Flight Numbers", "Cabin Price", "Number of Stops", "ScheduleID"
            };

            foreach (var column in columns)
            {
                outboundFlightDGV.Columns.Add(column, column);
                returnFlightDGV.Columns.Add(column, column);
            }

            outboundDTP.Value = DateTime.Parse("2017-10-17");
            returnDTP.Value = DateTime.Parse("2017-10-20");

            using (var context = new Session3Entities())
            {
                fromCb.Items.AddRange(context.Airports.Select(x => x.IATACode).ToArray());
                toCb.Items.AddRange(context.Airports.Select(x => x.IATACode).ToArray());
                cabinCb.Items.AddRange(context.CabinTypes.Select(x => x.Name).ToArray());

                fromCb.SelectedIndex = 0;
                toCb.SelectedIndex = 0;
                cabinCb.SelectedIndex = 0;

                UpdateDGV1();
            }
        }

        private void UpdateDGV()
        {
            using (var context = new Session3Entities())
            {
                outboundFlightDGV.Rows.Clear();
                returnFlightDGV.Rows.Clear();
                var routes = context.Schedules.ToList();
                var fromCode = fromCb.SelectedItem.ToString();
                var toCode = toCb.SelectedItem.ToString();
                var outboundRoutes = from x in routes
                                     where x.Route.Airport.IATACode == fromCode && x.Route.Airport1.IATACode == toCode
                                     select x;

                var returnRoutes = from x in routes
                                   where x.Route.Airport.IATACode == toCode && x.Route.Airport1.IATACode == fromCode
                                   select x;

                if (outboundCheckBox.Checked)
                {
                    outboundRoutes = from x in outboundRoutes
                                     where outboundDTP.Value >= x.Date.AddDays(-3) && outboundDTP.Value <= x.Date.AddDays(3)
                                     select x;

                    returnRoutes = from x in returnRoutes
                                   where returnDTP.Value >= x.Date.AddDays(-3) && returnDTP.Value <= x.Date.AddDays(3)
                                   select x;
                }
                else
                {
                    outboundRoutes = from x in outboundRoutes
                                     where outboundDTP.Value == x.Date
                                     select x;

                    returnRoutes = from x in returnRoutes
                                   where returnDTP.Value == x.Date
                                   select x;
                }

                foreach (var route in outboundRoutes)
                {
                    var row = new List<string>
                    {
                        route.Route.Airport.IATACode,
                        route.Route.Airport1.IATACode,
                        route.Date.ToShortDateString(),
                        route.Time.ToString(),
                        route.FlightNumber
                    };

                    switch (cabinCb.SelectedIndex)
                    {
                        case 0:
                            row.Add(route.EconomyPrice.ToString("0"));
                            break;

                        case 1:
                            row.Add(Math.Truncate(route.EconomyPrice * (decimal)1.35).ToString("0"));
                            break;

                        case 2:
                            row.Add(Math.Truncate(route.EconomyPrice * (decimal)1.35 * (decimal)1.3).ToString("0"));
                            break;

                        default:
                            break;
                    }

                    row.Add("0");
                    row.Add(route.ID.ToString());
                    outboundFlightDGV.Rows.Add(row.ToArray());
                }

                foreach (var route in returnRoutes)
                {
                    var row = new List<string>
                    {
                        route.Route.Airport.IATACode,
                        route.Route.Airport1.IATACode,
                        route.Date.ToShortDateString(),
                        route.Time.ToString(),
                        route.FlightNumber
                    };

                    switch (cabinCb.SelectedIndex)
                    {
                        case 0:
                            row.Add(route.EconomyPrice.ToString("0"));
                            break;

                        case 1:
                            row.Add(Math.Truncate(route.EconomyPrice * (decimal)1.35).ToString("0"));
                            break;

                        case 2:
                            row.Add(Math.Truncate(route.EconomyPrice * (decimal)1.35 * (decimal)1.3).ToString("0"));
                            break;

                        default:
                            break;
                    }
                    row.Add("0");
                    row.Add(route.ID.ToString());
                    returnFlightDGV.Rows.Add(row.ToArray());
                }
            }
        }

        private void UpdateDGV1()
        {
            //Code Supposed to Search Inner Flights + Connecting Flights too:
            using (var context = new Session3Entities())
            {
                var cabinName = cabinCb.SelectedItem.ToString();
                outboundFlightDGV.Rows.Clear();
                returnFlightDGV.Rows.Clear();
                var routes = context.Schedules.ToList();
                var fromCode = fromCb.SelectedItem.ToString();
                var toCode = toCb.SelectedItem.ToString();
                var outboundRoutes = from x in routes
                                     where x.Route.Airport.IATACode == fromCode
                                     select x;

                var returnRoutes = from x in routes
                                   where x.Route.Airport.IATACode == toCode
                                   select x;

                if (outboundCheckBox.Checked)
                {
                    outboundRoutes = from x in outboundRoutes
                                     where outboundDTP.Value >= x.Date.AddDays(-3) && outboundDTP.Value <= x.Date.AddDays(3)
                                     select x;

                    returnRoutes = from x in returnRoutes
                                   where returnDTP.Value >= x.Date.AddDays(-3) && returnDTP.Value <= x.Date.AddDays(3)
                                   select x;
                }
                else
                {
                    outboundRoutes = from x in outboundRoutes
                                     where outboundDTP.Value == x.Date
                                     select x;

                    returnRoutes = from x in returnRoutes
                                   where returnDTP.Value == x.Date
                                   select x;
                }

                foreach (var outboundRoute in outboundRoutes)
                {
                    if (outboundRoute.Route.Airport1.IATACode == toCode)
                    {
                        var row = new List<string>
                        {
                            outboundRoute.Route.Airport.IATACode,
                            outboundRoute.Route.Airport1.IATACode,
                            outboundRoute.Date.ToShortDateString(),
                            outboundRoute.Time.ToString(),
                            outboundRoute.FlightNumber,
                            ReturnPriceBasedOnCabin(outboundRoute.EconomyPrice, cabinName).ToString("0"),
                            "0",
                            outboundRoute.ID.ToString()
                        };
                        outboundFlightDGV.Rows.Add(row.ToArray());
                    }
                    else
                    {
                        //Search Inner Routes:
                        var outBoundDateArrival = outboundRoute.Date.Add(outboundRoute.Time).AddMinutes(outboundRoute.Route.FlightTime);
                        var outBoundDateDepature = outBoundDateArrival.AddDays(1);
                        var newOutBoundRoute = (from x in routes
                                                where x.Route.Airport.IATACode == outboundRoute.Route.Airport1.IATACode
                                                && x.Route.Airport1.IATACode == toCode
                                                select x).ToList();
                        var newOutBoundRoute1 = from x in newOutBoundRoute
                                                where x.Date.Add(x.Time) > outBoundDateArrival
                                                && x.Date.Add(x.Time) < outBoundDateDepature
                                                select x;

                        //"From", "To", "Date", "Time", "Flight Numbers", "Cabin Price", "Number of Stops", "ScheduleID"
                        foreach (var route in newOutBoundRoute1)
                        {
                            var row = new List<string>
                        {
                            outboundRoute.Route.Airport.IATACode,
                            route.Route.Airport1.IATACode,
                            outboundRoute.Date.ToShortDateString(),
                            outboundRoute.Time.ToString(),
                            $"{outboundRoute.FlightNumber} - {route.FlightNumber}",
                            $"{(ReturnPriceBasedOnCabin(outboundRoute.EconomyPrice, cabinName) + ReturnPriceBasedOnCabin(route.EconomyPrice, cabinName)).ToString("0")}",
                            "1",
                            $"{outboundRoute.ID}, {route.ID}",
                        };
                            outboundFlightDGV.Rows.Add(row.ToArray());
                        }
                    }
                }

                foreach (var returnRoute in returnRoutes)
                {
                    if (returnRoute.Route.Airport1.IATACode == fromCode)
                    {
                        var row = new List<string>
                        {
                            returnRoute.Route.Airport.IATACode,
                            returnRoute.Route.Airport1.IATACode,
                            returnRoute.Date.ToShortDateString(),
                            returnRoute.Time.ToString(),
                            returnRoute.FlightNumber,
                            ReturnPriceBasedOnCabin(returnRoute.EconomyPrice, cabinName).ToString("0"),
                            "0",
                            returnRoute.ID.ToString()
                        };
                        outboundFlightDGV.Rows.Add(row.ToArray());
                    }
                    else
                    {
                        //Search Inner Routes:
                        var outBoundDateArrival = returnRoute.Date.Add(returnRoute.Time).AddMinutes(returnRoute.Route.FlightTime);
                        var outBoundDateDepature = outBoundDateArrival.AddDays(1);
                        var newOutBoundRoute = (from x in routes
                                                where x.Route.Airport.IATACode == returnRoute.Route.Airport1.IATACode
                                                && x.Route.Airport1.IATACode == fromCode
                                                select x).ToList();
                        var newOutBoundRoute1 = from x in newOutBoundRoute
                                                where x.Date.Add(x.Time) > outBoundDateArrival
                                                && x.Date.Add(x.Time) < outBoundDateDepature
                                                select x;

                        //"From", "To", "Date", "Time", "Flight Numbers", "Cabin Price", "Number of Stops", "ScheduleID"
                        foreach (var route in newOutBoundRoute1)
                        {
                            var row = new List<string>
                        {
                            returnRoute.Route.Airport.IATACode,
                            route.Route.Airport1.IATACode,
                            returnRoute.Date.ToShortDateString(),
                            returnRoute.Time.ToString(),
                            $"{returnRoute.FlightNumber} - {route.FlightNumber}",
                            $"{(ReturnPriceBasedOnCabin(returnRoute.EconomyPrice, cabinName) + ReturnPriceBasedOnCabin(route.EconomyPrice, cabinName)).ToString("0")}",
                            "1",
                            $"{returnRoute.ID}, {route.ID}",
                        };
                            returnFlightDGV.Rows.Add(row.ToArray());
                        }
                    }
                }
            }
        }

        private void onewayRadio_CheckedChanged(object sender, EventArgs e)
        {
            returnFlightGroupBox.Visible = !onewayRadio.Checked;
            returnDTP.Enabled = !onewayRadio.Checked;
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            UpdateDGV1();
            outboundFlightNumberList.Clear();
            returnFlightNumbersList.Clear();
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            var cabinTypeId = context.CabinTypes.Where(x => x.Name == cabinCb.SelectedItem.ToString()).First().ID;
            if (outboundFlightNumberList.Count == 0)
            {
                MessageBox.Show("Please select an outbound flight");
                return;
            }

            if (returnFlightNumbersList.Count == 0 && !onewayRadio.Checked)
            {
                MessageBox.Show("Please select a return flight");
                return;
            }

            if (passengersNUD.Value == 0)
            {
                MessageBox.Show("There must at least be one passenger");
                return;
            }

            foreach (var scheduleID in outboundFlightNumberList)
            {
                var numberOfPassengersForFlight = context.Tickets.Where(x => x.ScheduleID == scheduleID && x.CabinTypeID == cabinTypeId).Count();
                var aircraft = context.Schedules.Where(x => x.ID == scheduleID).First().Aircraft;
                var planeCapacity = 0;
                switch (cabinCb.SelectedIndex)
                {
                    case 0:
                        //Economy
                        planeCapacity = aircraft.EconomySeats - numberOfPassengersForFlight - (int)passengersNUD.Value;
                        break;

                    case 1:
                        //Business:
                        planeCapacity = aircraft.BusinessSeats - numberOfPassengersForFlight - (int)passengersNUD.Value;
                        break;

                    case 2:
                        //FirstClass:
                        planeCapacity = (aircraft.TotalSeats - aircraft.EconomySeats - aircraft.BusinessSeats) - numberOfPassengersForFlight - (int)passengersNUD.Value;
                        break;

                    default:
                        break;
                }

                if (planeCapacity < 0)
                {
                    MessageBox.Show("Not enough seats for current passenger count (Outbound Flight)");
                    return;
                }
            }

            foreach (var scheduleID in returnFlightNumbersList)
            {
                var numberOfPassengersForFlight = context.Tickets.Where(x => x.ScheduleID == scheduleID && x.CabinTypeID == cabinTypeId).Count();
                var aircraft = context.Schedules.Where(x => x.ID == scheduleID).First().Aircraft;
                var planeCapacity = 0;
                switch (cabinCb.SelectedIndex)
                {
                    case 0:
                        //Economy
                        planeCapacity = aircraft.EconomySeats - numberOfPassengersForFlight - (int)passengersNUD.Value;
                        break;

                    case 1:
                        //Business:
                        planeCapacity = aircraft.BusinessSeats - numberOfPassengersForFlight - (int)passengersNUD.Value;
                        break;

                    case 2:
                        //FirstClass:
                        planeCapacity = (aircraft.TotalSeats - aircraft.EconomySeats - aircraft.BusinessSeats) - numberOfPassengersForFlight - (int)passengersNUD.Value;
                        break;

                    default:
                        break;
                }

                if (planeCapacity < 0)
                {
                    MessageBox.Show("Not enough seats for current passenger count (Return Flight)");
                    return;
                }
            }

            new BookingConfirmationForm(outboundFlightNumberList, returnFlightNumbersList, (int)passengersNUD.Value, cabinTypeId).ShowDialog();
        }

        private void outboundFlightDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            outboundFlightNumberList.Clear();
            //"From", "To", "Date", "Time", "Flight Numbers", "Cabin Price", "Number of Stops", "ScheduleID"
            var clicked = outboundFlightDGV[7, e.RowIndex].Value.ToString();
            var numbers = clicked.Split(',');
            foreach (var number in numbers)
            {
                outboundFlightNumberList.Add(int.Parse(number.Trim()));
            }

            foreach (var no in outboundFlightNumberList)
            {
                Console.WriteLine(no);
            }
        }

        private void returnFlightDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            returnFlightNumbersList.Clear();
            //"From", "To", "Date", "Time", "Flight Numbers", "Cabin Price", "Number of Stops", "ScheduleID"
            var clicked = returnFlightDGV[7, e.RowIndex].Value.ToString();
            var numbers = clicked.Split(',');
            foreach (var number in numbers)
            {
                returnFlightNumbersList.Add(int.Parse(number.Trim()));
            }

            foreach (var no in returnFlightNumbersList)
            {
                Console.WriteLine(no);
            }
        }

        private decimal ReturnPriceBasedOnCabin(decimal economyPrice, string cabinName)
        {
            switch (cabinName)
            {
                case "Economy":
                    return economyPrice;

                case "Business":
                    return Math.Truncate(economyPrice * (decimal)1.35);

                case "First Class":
                    return Math.Truncate(economyPrice * (decimal)1.35 * (decimal)1.3);

                default:
                    return 0;
            }
        }
    }
}