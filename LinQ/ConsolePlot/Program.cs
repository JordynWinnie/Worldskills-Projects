using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlot
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AdventureWorks2017Entities())
            {
                var data = db.CurrencyRates;


                var query = from x in data
                            where x.ToCurrencyCode.Equals("CAD")
                            orderby x.ModifiedDate
                            select x;

                List<decimal> averageRates = new List<decimal>();
                List<DateTime> dateTimes = new List<DateTime>();

                
                
                decimal datePos = 1;

                foreach (var item in query)
                {
                    averageRates.Add(item.AverageRate);
                    dateTimes.Add(item.ModifiedDate);

                }

                foreach (var item in query)
                {
                    //Console.WriteLine(item.AverageRate);
                }

              

                var largestScale = averageRates.Max();
                decimal largestScaleDate = dateTimes.Count();

                //Console.SetBufferSize(1920, 1080);

                foreach (var item in averageRates)
                {
                    var currencyPos = Math.Round(item / largestScale * 100);
                    var datePosition = Math.Round((datePos / largestScaleDate) * 100, MidpointRounding.ToEven);


                   // Console.WriteLine($"{currencyPos} , { datePosition}");
                    //Console.SetCursorPosition(Decimal.ToInt32(datePosition), Decimal.ToInt32(currencyPos));
                    //Console.WriteLine("x");

                    datePos++;
                }

                var cords = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore } );
                Console.WriteLine(cords);

            }
            Console.ReadKey();
        }
    }
}
