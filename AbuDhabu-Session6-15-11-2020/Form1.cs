using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbuDhabu_Session6_15_11_2020
{
    public partial class Form1 : Form
    {
        private Session6Entities context = new Session6Entities();

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
            var startTime = DateTime.Parse("20 Oct 2017 8:00 PM");
            var endTime = startTime.AddDays(-30);

            var userQuery = context.Users.ToList();
            var officeQuery = context.Offices.ToList();
            var baseQuery = (from x in context.Tickets
                             select x).ToList();

            var datedQuery = from x in baseQuery
                             where x.Schedule.Date.Add(x.Schedule.Time) <= startTime
                             && x.Schedule.Date.Add(x.Schedule.Time) >= endTime
                             select x;

            flightsConfirmed.Text = $"Number Confirmed: {datedQuery.Where(x => x.Confirmed == true).Count()}";
            flightsCancelled.Text = $"Number Cancelled: {datedQuery.Where(x => x.Confirmed == false).Count()}";
            averageDailyFlightTime.Text = $"Average Daily Flight Time: {datedQuery.Average(x => x.Schedule.Route.FlightTime).ToString("0.00")} minutes";

            var topCustomers = (from x in datedQuery
                                group x by x.UserID into y
                                orderby y.Count() descending
                                select y).Take(3).ToList();
            var firstCustomer = userQuery.Where(x => x.ID == topCustomers[0].Key).First();
            var secondCustomer = userQuery.Where(x => x.ID == topCustomers[1].Key).First();
            var thridCustomer = userQuery.Where(x => x.ID == topCustomers[2].Key).First();
            topCustomer1.Text = $"1. {firstCustomer.FirstName} {firstCustomer.LastName} ({topCustomers[0].Count()} tickets)";
            topCustomer2.Text = $"2. {secondCustomer.FirstName} {secondCustomer.LastName} ({topCustomers[1].Count()} tickets)";
            topCustomer3.Text = $"3. {thridCustomer.FirstName} {thridCustomer.LastName} ({topCustomers[2].Count()} tickets)";

            var busiestDay = from x in datedQuery
                             group x by x.Schedule.Date into y
                             orderby y.Count() descending
                             select y;

            busiestDayLbl.Text = $"{busiestDay.First().Key.ToString("MM/dd")} with {busiestDay.First().Count()} flights";
            quietestDayLbl.Text = $"{busiestDay.Last().Key.ToString("MM/dd")} with {busiestDay.Last().Count()} flights";

            var topOffices = (from x in datedQuery
                              group x by x.User.OfficeID into y
                              orderby y.Count() descending
                              select y).Take(3).ToList();
            var firstOffice = officeQuery.Where(x => x.ID == topOffices[0].Key).First();
            var secondOffice = officeQuery.Where(x => x.ID == topOffices[1].Key).First();
            var thirdOffice = officeQuery.Where(x => x.ID == topOffices[2].Key).First();
            topOffice1.Text = $"1. {firstOffice.Title}";
            topOffice2.Text = $"2. {secondOffice.Title}";
            topOffice3.Text = $"3. {thirdOffice.Title}";

            var ticketPriceCalculation1 = from x in datedQuery
                                          where x.Schedule.Date.Add(x.Schedule.Time) >= startTime.AddDays(-1)
                                          select x;
            decimal total1 = 0;
            foreach (var ticket in ticketPriceCalculation1)
            {
                switch (ticket.CabinTypeID)
                {
                    case 1:
                        //Economy
                        total1 += ticket.Schedule.EconomyPrice;
                        break;

                    case 2:
                        //Business
                        total1 += ticket.Schedule.EconomyPrice * (decimal)1.35;
                        break;

                    case 3:
                        //FirstClass
                        total1 += ticket.Schedule.EconomyPrice * (decimal)1.3;
                        break;

                    default:
                        break;
                }
            }
            var ticketPriceCalculation2 = from x in datedQuery
                                          where x.Schedule.Date.Add(x.Schedule.Time) >= startTime.AddDays(-2)
                                          select x;
            decimal total2 = 0;
            foreach (var ticket in ticketPriceCalculation2)
            {
                switch (ticket.CabinTypeID)
                {
                    case 1:
                        //Economy
                        total2 += ticket.Schedule.EconomyPrice;
                        break;

                    case 2:
                        //Business
                        total2 += ticket.Schedule.EconomyPrice * (decimal)1.35;
                        break;

                    case 3:
                        //FirstClass
                        total2 += ticket.Schedule.EconomyPrice * (decimal)1.3;
                        break;

                    default:
                        break;
                }
            }

            var ticketPriceCalculation3 = from x in datedQuery
                                          where x.Schedule.Date.Add(x.Schedule.Time) >= startTime.AddDays(-3)
                                          select x;
            decimal total3 = 0;
            foreach (var ticket in ticketPriceCalculation3)
            {
                switch (ticket.CabinTypeID)
                {
                    case 1:
                        //Economy
                        total3 += ticket.Schedule.EconomyPrice;
                        break;

                    case 2:
                        //Business
                        total3 += ticket.Schedule.EconomyPrice * (decimal)1.35;
                        break;

                    case 3:
                        //FirstClass
                        total3 += ticket.Schedule.EconomyPrice * (decimal)1.3;
                        break;

                    default:
                        break;
                }
            }

            yesterdayTicketSale.Text = $"Yesterday: ${Math.Truncate(total1)}";
            twoDaysAgo.Text = $"Two Days Ago: {Math.Truncate(total2)}";
            threeDaysAgo.Text = $"Three Days Ago: {Math.Truncate(total3)}";

            var emptySeat = from x in datedQuery
                            where x.Schedule.Date >= startTime.Date.AddDays(-7)
                            select x;

            var numberOfSeats = (double)emptySeat.Count() / emptySeat.Sum(x => x.Schedule.Aircraft.TotalSeats);

            thisWeekSales.Text = $"{numberOfSeats * 100}%";
        }
    }
}