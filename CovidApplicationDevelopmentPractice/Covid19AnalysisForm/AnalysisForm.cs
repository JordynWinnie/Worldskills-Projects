using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Covid19AnalysisForm
{
    public partial class AnalysisForm : Form
    {
        public AnalysisForm()
        {
            InitializeComponent();
            officeCloseTime.Value = DateTime.Parse("5:00 PM");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new CovidEntities())
            {
                percentileLb.Items.Clear();
                var travelHistory = GetTravelHistory(textBox1.Text);
                var percentileTracking = PercentileCalculation(travelHistory);
                var tempPersonList = new List<string>();
                
                if (percentileTracking == null)
                {
                    percentileLb.Items.Add("Not enough records to track percentile");
                }
                else
                {
                    foreach (var percentile in percentileTracking.OrderByDescending(x=>x.Key))
                    {
                        percentileLb.Items.Add($"{percentile.Key} Percentile:");
                        int tempCount = 0;
                        foreach (var travel in travelHistory)
                        {
                            if (travel.Value >= percentile.Value)
                            {
                                var person = context.ContactTracings.Where(x => x.Contact == travel.Key).FirstOrDefault();

                                if (!tempPersonList.Contains(person.Contact))
                                {
                                    tempCount++;
                                    percentileLb.Items.Add($"\t{person.FullName} - {person.Contact} " +
                                    $"({travel.Value} Contacts)");
                                    tempPersonList.Add(person.Contact);
                                }
                            }
                        }

                        if (tempCount == 0)
                        {
                            percentileLb.Items.Add("No Records found");
                        }
                        percentileLb.Items.Add("");
                    }
                }
            }
            
        }

        private Dictionary<string, int> GetTravelHistory(string contactNumber)
        {
            var percentileTracking = new Dictionary<string, int>();

            using (var context = new CovidEntities())
            {
                var directContactList = new List<ContactTracing>();
                var indirectContactList = new List<ContactTracing>();

                directContactMembers.Items.Clear();
                indirectContactMembers.Items.Clear();
                travelHistoryLb.Items.Clear();

                var daysBefore = (dateTimePicker1.Value.Date.AddDays(-14));
                var daysAfter = dateTimePicker1.Value.Date.AddDays(1);
                var query = (from x in context.ContactTracings
                             orderby x.RegisterDateTime
                             where x.Contact.Equals(contactNumber) && x.RegisterDateTime >= daysBefore && x.RegisterDateTime <= daysAfter
                             select x).ToList();

                var groupQuery = from x in query
                                 group x by x.RegisterDateTime.Date into y
                                 select y;

                

                foreach (var item in groupQuery)
                {
                    var contactTrace = new List<ContactTracing>();
                    travelHistoryLb.Items.Add(item.Key);

                    foreach (var date in item)
                    {
                        contactTrace.Add(date);
                    }

                    for (int i = 0; i < contactTrace.Count; i++)
                    {
                        if (i != contactTrace.Count - 1)
                        {
                            travelHistoryLb.Items.Add($"\tFloor: {contactTrace[i].Location.LocationFloor} Unit: {contactTrace[i].Location.LocationUnitNumber} " +
                            $"Time: {contactTrace[i].RegisterDateTime.ToString("HH:mm:ss")} " +
                            $"Travelled from: {contactTrace[i].LocationID} to {contactTrace[i + 1].LocationID}");

                            var locationList = GetLocationIDs(contactTrace[i].LocationID, contactTrace[i + 1].LocationID);

                            var lol = string.Join(", ", locationList);
                            var clockOutTime = contactTrace[i + 1].RegisterDateTime.AddSeconds(-(Convert.ToDouble(timeToTravelNUD.Value) * locationList.Count));
                            travelHistoryLb.Items.Add($"\t\t Rooms Travelled: {lol} " +
                                $"ClockOutTime: {clockOutTime}");

                            travelHistoryLb.Items.Add("");

                            var startTime = contactTrace[i].RegisterDateTime;
                            var currentContact = contactTrace[i].Contact;
                            var currentLocation = contactTrace[i].LocationID;

                            //Check DIRECT Contact First (Same Room, within time frame):
                            var directContect = from x in context.ContactTracings
                                                where x.RegisterDateTime >= startTime && x.RegisterDateTime <= clockOutTime && x.Contact != currentContact
                                                && x.LocationID == currentLocation
                                                select x;

                            

                            foreach (var person in directContect)
                            {
                                directContactList.Add(person);
                            }

                            //Check for INDIRECT Contact (Passed by Affected while Affected is travelling to the other room)
                            var nextRoomStartTime = contactTrace[i + 1].RegisterDateTime;

                            foreach (var location in locationList)
                            {
                                var indirectContact = from x in context.ContactTracings
                                                      where x.RegisterDateTime >= clockOutTime && x.RegisterDateTime <= nextRoomStartTime && x.Contact != currentContact
                                                      && x.LocationID == location
                                                      select x;

                                foreach (var person in indirectContact)
                                {
                                    indirectContactList.Add(person);
                                }
                            }
                        }
                        else
                        {
                            travelHistoryLb.Items.Add($"\tFloor: {contactTrace[i].Location.LocationFloor} Unit: {contactTrace[i].Location.LocationUnitNumber} " +
                            $"Time: {contactTrace[i].RegisterDateTime.ToString("HH:mm:ss")}");

                            var startTime = contactTrace[i].RegisterDateTime;
                            var currentContact = contactTrace[i].Contact;
                            var currentLocation = contactTrace[i].LocationID;
                            var clockOutTime = contactTrace[i].RegisterDateTime.Date.AddHours(officeCloseTime.Value.Hour);

                            var directContect = from x in context.ContactTracings
                                                where x.RegisterDateTime >= startTime && x.RegisterDateTime <= clockOutTime && x.Contact != currentContact
                                                && x.LocationID == currentLocation
                                                select x;

                            travelHistoryLb.Items.Add($"\t\tStayed in room until: {clockOutTime} (Office Closed)");

                            travelHistoryLb.Items.Add("");
                            foreach (var person in directContect)
                            {
                                directContactList.Add(person);
                            }
                        }
                    }
                }

                var occurances = (from x in directContactList
                                  group x by x.Contact into y
                                  select y).OrderBy(x => x.Key.Count());

                var indirectOccurances = (from x in indirectContactList
                                          group x by x.Contact into y
                                          select y).OrderBy(x => x.Key.Count());


                foreach (var person in occurances)
                {
                    directContactMembers.Items.Add($"{person.Select(x => x.FullName).First()} - {person.Select(x => x.Contact).First()} ({person.Count()} Contacts)");
                }

                foreach (var person in indirectOccurances)
                {
                    indirectContactMembers.Items.Add($"{person.Select(x => x.FullName).First()} - {person.Select(x => x.Contact).First()} ({person.Count()} Contacts)");
                    var tempKey = person.Select(x => x.Contact).First();
                    if (!percentileTracking.ContainsKey(tempKey))
                    {
                        percentileTracking.Add(tempKey, person.Count());
                    }
                }

                if (directContactMembers.Items.Count == 0)
                {
                    directContactMembers.Items.Add("No direct contact found");
                }

                if (indirectContactMembers.Items.Count == 0)
                {
                    indirectContactMembers.Items.Add("No indirect contact found");
                }

                if (travelHistoryLb.Items.Count == 0)
                {
                    travelHistoryLb.Items.Add("No travel history found");
                }
                return percentileTracking;

            }

        }

        private List<long> GetLocationIDs(long sourceLocationId, long destinationLocationId)
        {
            using (var context = new CovidEntities())
            {
                var locationIdList = new List<long>();
                var currentLocation = context.Locations.Where(x => x.ID == sourceLocationId).First();
                var destinationLocation = context.Locations.Where(x => x.ID == destinationLocationId).First();

                if (currentLocation.LocationFloor != destinationLocation.LocationFloor)
                {
                    //For currentfloor:

                    var stepThrough = Enumerable.Range(1, currentLocation.LocationUnitNumber);
                    var stepThrough2 = Enumerable.Range(1, destinationLocation.LocationUnitNumber);

                    foreach (var item in stepThrough)
                    {
                        //Console.WriteLine(item);
                        var steppedLocationId = context.Locations.Where(x => x.LocationFloor == currentLocation.LocationFloor
                         && x.LocationUnitNumber == item).Select(x => x.ID).First();

                        locationIdList.Add(steppedLocationId);
                    }
                    foreach (var item in stepThrough2)
                    {
                        //Console.WriteLine(item);
                        var steppedLocationId = context.Locations.Where(x => x.LocationFloor == destinationLocation.LocationFloor
                         && x.LocationUnitNumber == item).Select(x => x.ID).First();

                        locationIdList.Add(steppedLocationId);
                    }

                    return locationIdList;
                }
                else
                {
                    //Check unit numbers:
                    var min = Math.Min(currentLocation.LocationUnitNumber, destinationLocation.LocationUnitNumber);
                    var max = Math.Max(currentLocation.LocationUnitNumber, destinationLocation.LocationUnitNumber);
                    var stepThrough = Enumerable.Range(min, (max - min) + 1);


                    foreach (var item in stepThrough)
                    {
                        Console.WriteLine(item);
                        var steppedLocationId = context.Locations.Where(x => x.LocationFloor == currentLocation.LocationFloor
                         && x.LocationUnitNumber == item).Select(x => x.ID).First();

                        locationIdList.Add(steppedLocationId);
                    }
                    return locationIdList;
                }
            }

        }

        private Dictionary<int, double> PercentileCalculation(Dictionary<string, int> percentileDictionary)
        {
            var num = new List<int>();
            var percentileReturn = new Dictionary<int, double>();

            Console.WriteLine("Count of P.Dict: " + percentileDictionary.Count());

            foreach (var percentilePair in percentileDictionary)
            {
                Console.WriteLine(percentilePair.Value);
                num.Add(percentilePair.Value);
            }

            Console.WriteLine("Count Of Num.List: " + num.Count);
            num.Sort();
            if (num.Count < 3) return null;
            else
            {
                var percentileList = new List<double>
            {
                10,20,30,40,50,60,70,80,90
            };

                foreach (var percentile in percentileList)
                {
                    double index = Convert.ToDouble(num.Count) * (percentile / 100);

                    if (index % 1 == 0)
                    {
                        //Non-Decimal
                        var calculatedResult = (num[(int)index - 1] + num[(int)index]) / 2;
                        Console.WriteLine($"{percentile} Percentile is: {(num[(int)index - 1] + num[(int)index]) / 2}");
                        percentileReturn.Add((int)percentile, calculatedResult);
                    }
                    else
                    {
                        //Decimal based
                        index = Math.Ceiling(index);
                        var calculatedResult = num[(int)index - 1];
                        Console.WriteLine($"{percentile} Percentile is: {num[(int)index - 1]}");
                        percentileReturn.Add((int)percentile, calculatedResult);
                    }
                }
                return percentileReturn;

            }


        }
    }
}
