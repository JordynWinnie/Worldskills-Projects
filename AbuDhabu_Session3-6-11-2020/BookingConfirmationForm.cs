using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AbuDhabu_Session3_6_11_2020
{
    public partial class BookingConfirmationForm : Form
    {
        private List<int> outboundFlightsList = new List<int>();
        private List<int> returnFlightsList = new List<int>();
        private int _cabinTypeId = -1;
        private int _requestedPassengers = -1;

        private int _passengerSelectedRow = -1;

        public BookingConfirmationForm(List<int> outboundFlights, List<int> returnFlights, int requestedPassengers, int cabinTypeId)
        {
            _requestedPassengers = requestedPassengers;
            outboundFlightsList = outboundFlights;
            returnFlightsList = returnFlights;
            _cabinTypeId = cabinTypeId;
            InitializeComponent();
        }

        private void selectFlightsBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BookingConfirmationForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                countryCb.Items.AddRange(context.Countries.Select(x => x.Name).ToArray());
                countryCb.SelectedIndex = 0;
                var columns = new List<string>
            {
                "From", "To", "Cabin Type", "Date", "Flight Number"
            };

                var passengerColumns = new List<string>
            {
                "First Name", "Last Name", "Birthday", "Passport Number", "Passport Country", "Phone"
            };

                foreach (var column in columns)
                {
                    outboundDGV.Columns.Add(column, column);
                    returnDGV.Columns.Add(column, column);
                }

                foreach (var column in passengerColumns)
                {
                    passengerDGV.Columns.Add(column, column);
                }

                var cabinType = context.CabinTypes.Where(x => x.ID == _cabinTypeId).First().Name;
                foreach (var outbound in outboundFlightsList)
                {
                    var flight = context.Schedules.Where(x => x.ID == outbound).First();

                    var row = new List<string>
                {
                    flight.Route.Airport.IATACode,
                    flight.Route.Airport1.IATACode,
                    cabinType,
                    flight.Date.ToShortDateString(),
                    flight.FlightNumber
                };

                    outboundDGV.Rows.Add(row.ToArray());
                }

                foreach (var returnFlight in returnFlightsList)
                {
                    var flight = context.Schedules.Where(x => x.ID == returnFlight).First();

                    var row = new List<string>
                {
                    flight.Route.Airport.IATACode,
                    flight.Route.Airport1.IATACode,
                    cabinType,
                    flight.Date.ToShortDateString(),
                    flight.FlightNumber
                };

                    returnDGV.Rows.Add(row.ToArray());
                }
            }
        }

        private void addPassenger_Click(object sender, EventArgs e)
        {
            if (passengerDGV.Rows.Count >= _requestedPassengers)
            {
                MessageBox.Show("You have exceeded the number of requested passengers");
                return;
            }
            //"First Name", "Last Name", "Birthday", "Passport Number", "Passport Country", "Phone"
            if (firstNameTb.Text.Equals("") || lastNameTb.Text.Equals("") || passportNoTb.Text.Equals("") ||
                phoneTb.Text.Equals(""))
            {
                MessageBox.Show("Fill up all fields");
                return;
            }

            var row = new List<string>
            {
                firstNameTb.Text, lastNameTb.Text, birthdateDTP.Value.ToString("dd-MM-yyyy")
                ,passportNoTb.Text,countryCb.SelectedItem.ToString(), phoneTb.Text
            };

            passengerDGV.Rows.Add(row.ToArray());
            firstNameTb.Text = string.Empty;
            lastNameTb.Text = string.Empty;
            passportNoTb.Text = string.Empty;
            phoneTb.Text = string.Empty;
        }

        private void removePassengerBtn_Click(object sender, EventArgs e)
        {
            if (_passengerSelectedRow == -1)
            {
                MessageBox.Show("Please select a passenger");
            }
            else
            {
                passengerDGV.Rows.RemoveAt(_passengerSelectedRow);
                _passengerSelectedRow = -1;
            }
        }

        private void passengerDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _passengerSelectedRow = e.RowIndex;
        }

        private void confirmBookingBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                decimal totalCost = 0;
                //Flight list gives you list of Schedule IDs
                foreach (var outboundFlight in outboundFlightsList)
                {
                    var flight = context.Schedules.Where(x => x.ID == outboundFlight).First();

                    foreach (DataGridViewRow passenger in passengerDGV.Rows)
                    {
                        decimal cost = 0;
                        //Calculate Flight Cost:
                        switch (_cabinTypeId)
                        {
                            case 1:
                                //Economy
                                cost = flight.EconomyPrice;
                                break;

                            case 2:
                                cost = Math.Truncate(flight.EconomyPrice * (decimal)1.35);
                                //Business
                                break;

                            case 3:
                                //FirstClass:
                                cost = Math.Truncate(flight.EconomyPrice * (decimal)1.35 * (decimal)1.3);
                                break;

                            default:
                                break;
                        }
                        //"First Name", "Last Name", "Birthday", "Passport Number", "Passport Country", "Phone"
                        totalCost += cost;
                        var firstName = passenger.Cells[0].Value.ToString();
                        var lastName = passenger.Cells[1].Value.ToString();
                        var passportNumber = passenger.Cells[3].Value.ToString();
                        var phone = passenger.Cells[5].Value.ToString();

                        var passportCountry = passenger.Cells[4].Value.ToString();
                        var passportCountryID = context.Countries.Where(x => x.Name == passportCountry).First().ID;
                        var insertTicket = new Ticket
                        {
                            BookingReference = GenerateBookingNumber(),
                            CabinTypeID = _cabinTypeId,
                            Confirmed = true,
                            Email = null,
                            Firstname = firstName,
                            Lastname = lastName,
                            PassportNumber = passportNumber,
                            Phone = phone,
                            ScheduleID = flight.ID,
                            UserID = 1,
                            PassportCountryID = passportCountryID
                        };

                        context.Tickets.Add(insertTicket);
                    }
                }

                foreach (var returnFlight in returnFlightsList)
                {
                    var flight = context.Schedules.Where(x => x.ID == returnFlight).First();

                    decimal cost = 0;
                    foreach (DataGridViewRow passenger in passengerDGV.Rows)
                    {
                        //Calculate Flight Cost:
                        switch (_cabinTypeId)
                        {
                            case 1:
                                //Economy
                                cost = flight.EconomyPrice;
                                break;

                            case 2:
                                cost = Math.Truncate(flight.EconomyPrice * (decimal)1.35);
                                //Business
                                break;

                            case 3:
                                //FirstClass:
                                cost = Math.Truncate(flight.EconomyPrice * (decimal)1.35 * (decimal)1.3);
                                break;

                            default:
                                break;
                        }

                        totalCost += cost;

                        var firstName = passenger.Cells[0].Value.ToString();
                        var lastName = passenger.Cells[1].Value.ToString();
                        var passportNumber = passenger.Cells[3].Value.ToString();
                        var phone = passenger.Cells[5].Value.ToString();

                        var passportCountry = passenger.Cells[4].Value.ToString();
                        var passportCountryID = context.Countries.Where(x => x.Name == passportCountry).First().ID;
                        var insertTicket = new Ticket
                        {
                            BookingReference = GenerateBookingNumber(),
                            CabinTypeID = _cabinTypeId,
                            Confirmed = true,
                            Email = null,
                            Firstname = firstName,
                            Lastname = lastName,
                            PassportNumber = passportNumber,
                            Phone = phone,
                            ScheduleID = flight.ID,
                            UserID = 1,
                            PassportCountryID = passportCountryID
                        };

                        context.Tickets.Add(insertTicket);
                    }
                }
                var newForm = new ConfirmAmountForm(totalCost);
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    context.SaveChanges();
                    MessageBox.Show("Changes Saved");
                    Close();
                }
            }
        }

        private string GenerateBookingNumber()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var numbers = "0123456789";

            var sb = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < 6; i++)
            {
                Thread.Sleep(1);
                if (random.Next(0, 2) == 0)
                {
                    sb.Append(characters[random.Next(characters.Length)]);
                }
                else
                {
                    sb.Append(numbers[random.Next(numbers.Length)]);
                }
            }

            return sb.ToString();
        }
    }
}