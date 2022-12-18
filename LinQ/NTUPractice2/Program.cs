using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace NTUPractice2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rawData = File.ReadAllText(@"D:\OneDrive - Personal\OneDrive - Temasek Polytechnic\Year 1, Sem 2\WorldSkills\TestIndented.txt");
         
            using (var context = new AdventureWorks2017Entities())
            {
                Console.Write("Please input your Country Pair (i.e. USDAUD): ");
                var userinput = Console.ReadLine();

                var product = context.SalesOrderHeaders;

                var help = JsonConvert.DeserializeObject<List<CurrencyRate>>(rawData);

                var query = from x in help
                            join p in product on x.CurrencyRateID equals p.CurrencyRateID
                            orderby x.ToCurrencyCode
                            group x by x.ToCurrencyCode into currencies
                            select new { To = currencies.Key, Source = currencies.First(), Rate = currencies.Average(x => x.AverageRate) };

                /*var query2 = from x in product
                             join y in help on x.CurrencyRateID equals y.CurrencyRateID
                             select new { lol = x.CurrencyRateID, lol2 = y.CurrencyRateID };  */
                
                //int totalEntries = 0;

                IDictionary<string,decimal> dictionary = new Dictionary<string, decimal>();
                


                //Console.WriteLine($"Total currencies found: {query.Count()} // Entries Found: {totalEntries} entries");
                
                foreach (var item in query)
                {
                    //Console.WriteLine($"From {item.Source.FromCurrencyCode} to {item.To} is {item.Rate}");
                    dictionary.Add($"{item.Source.FromCurrencyCode}{item.To}",  item.Rate );
                }


                foreach (var keyValuePair in dictionary)
                {
                    if (keyValuePair.Key.Contains(userinput))
                    {
                        Console.WriteLine($"{keyValuePair.Key} -- {keyValuePair.Value}");
                    }
                    
                }

                //Hashsets do not care about order, but does not allow any duplicate elements
                //it is far more performant than other lists that allow sorting.
                //more info: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=netframework-4.8 

                var hashset = query.ToHashSet();

                foreach (var item in hashset)
                {
                    Console.WriteLine($"{item.Source.FromCurrencyCode} {item.To} == {item.Rate}");
                }

                Console.ReadKey();


                

            }
        }
    }
}
