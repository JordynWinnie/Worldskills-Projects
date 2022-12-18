using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace ReplicationProject
{
    class Program
    {

        static void Main(string[] args)
        {

            using (var context = new Model1())
            {
                //Lazy Loading loads all entires from the database regardless of call
                //if enabled, it causes conflict as it loads irrelavant data which may cause a loop

                //context.Configuration.LazyLoadingEnabled = true;


                using (var reader = new StreamReader(@"D:\OneDrive - Personal\OneDrive - Temasek Polytechnic\Year 1, Sem 2\WorldSkills\CurrencyRate.csv"))
                {
                    #region FileReading
                    List<CurrencyRate> currencyRates = new List<CurrencyRate>();


                    while (!reader.EndOfStream)
                    {

                        var rawData = reader.ReadLine();
                        var values = rawData.Split('\t');
                        CurrencyRate currency = new CurrencyRate();

                        currency.CurrencyRateID = Int32.Parse(values[0]);

                        currency.CurrencyRateDate = DateTime.Parse(values[1]);

                        currency.FromCurrencyCode = values[2];
                        currency.ToCurrencyCode = values[3];
                        currency.AverageRate = Decimal.Parse(values[4]);
                        currency.EndOfDayRate = Decimal.Parse(values[5]);
                        currency.ModifiedDate = DateTime.Parse(values[6]);

                        currencyRates.Add(currency);

                    }
                    #endregion

                    #region Prints SourceCountry, Des, and Conv rate (2.5)

                    /*
                    var query = from x in currencyRates
                                select new { SourceCountry = x.FromCurrencyCode, DestinationCountry = x.ToCurrencyCode, ConversionRate = x.AverageRate };


                    foreach (var item in query)
                    {
                        Console.WriteLine(item);
                    }
                    */

                    //Prints based on UserInput (2.6)

                    /*
                    Console.Write("Enter Destination Country Code");
                    var userInput = Console.ReadLine();

                    var askForRate = from x in currencyRates
                                     where x.ToCurrencyCode.Contains(userInput)
                                     select new { SourceCountry = x.FromCurrencyCode, DestinationCountry = x.ToCurrencyCode, ConversionRate = x.AverageRate };

                    foreach (var item in askForRate)
                    {
                        Console.WriteLine(item);
                    }
                    */
                    #endregion

                    #region Group by Dest Country

                    //    var groupByDest = from x in currencyRates
                    //                      group x by x.ToCurrencyCode;

                    //    foreach (var exchange in groupByDest)
                    //    {
                    //        Console.WriteLine(exchange.Key);

                    //        var average = exchange.Average(p => p.AverageRate);
                    //        var min = exchange.Min(p => p.AverageRate);
                    //        var max = exchange.Max(p => p.AverageRate);
                    //        Console.WriteLine($"Average: {average} Min: {min} Max: {max}");
                    //    }

                    //    Console.ReadKey();
                    //}

                    //var input = Console.ReadLine();

                    #endregion

                    #region JSON OUT
                    /*var input = Console.ReadLine();

                    var people = context.People;
                    var emails = context.EmailAddresses;
                    

                    var query = from p in people
                                where p.FirstName.Contains("A")
                                select new {  p.FirstName, p.LastName };

                    var emailQ = from e in emails
                                where e.Person.FirstName.Contains(input)
                                 orderby e.Person.FirstName
                               select new { FirstName = e.Person.FirstName, LastName = e.Person.LastName, Email = e.EmailAddress1 };

                    
                    var JsonQuery = from e in people
                                    where e.FirstName.Contains("Jordan")
                                    select e;

                    
                    var ser = new JavaScriptSerializer();                    
                    var x = ser.Serialize(JsonQuery);*/

                    //Console.WriteLine(x);



                    //Look at the Top of code for LazyLoading Explanation

                    //Db Pull: 
                    var people = context.People.Include(p => p.PersonCreditCards);
                    var emails = context.EmailAddresses;

                    var query = from p in people
                                orderby p.FirstName
                                select p.PersonCreditCards;

                    var jss = new JavaScriptSerializer();

                    var jsonQuery = jss.Serialize(query);

                    Console.WriteLine(jsonQuery);

                    #endregion


                    #region CSV -> JSON

                


                    var lol = JsonConvert.SerializeObject(currencyRates, Formatting.Indented);
                    var lol2 = JsonConvert.SerializeObject(currencyRates, Formatting.None);

                    Console.WriteLine(lol);

                    File.WriteAllText(@"D:\OneDrive - Personal\OneDrive - Temasek Polytechnic\Year 1, Sem 2\WorldSkills\TestIndented.txt", lol);
                    File.WriteAllText(@"D:\OneDrive - Personal\OneDrive - Temasek Polytechnic\Year 1, Sem 2\WorldSkills\TestNone.txt", lol2);
                    #endregion
                }


                Console.ReadKey();

            }

        }
    }
}