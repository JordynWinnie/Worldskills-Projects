using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var reader = new StreamReader(@"D:\OneDrive - Personal\OneDrive - Temasek Polytechnic\Year 1, Sem 2\WorldSkills\CurrencyRate.csv"))
                {
                    Console.Write("Write down the country: ");
                    var userInput = Console.ReadLine();

                    List<CurrencyRate> currencyRates = new List<CurrencyRate>();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split('\t');

                        currencyRates.Add(new CurrencyRate(Int32.Parse(values[0]), DateTime.Parse(values[1]),
                            values[2], values[3], Double.Parse(values[4]), Double.Parse(values[5]), DateTime.Parse(values[6])));

                    }

                    var query = from exchange in currencyRates
                                where exchange.destinationCountry.Contains(userInput)
                                group exchange by exchange.destinationCountry into newGroup
                                select newGroup;

                    foreach (var x in query)
                    {
                        Console.WriteLine($"Found: {x.Key}");

                        foreach (var item in x)
                        {
                            
                            double max = x.Max(b => b.sourceRate / b.destinationRate);
                            double min = x.Min(r => r.sourceRate / r.destinationRate);
                            double average = x.Average(r => r.sourceRate / r.destinationRate);

                            if (max > 0 && min > 0 && average > 0)
                            {
                                Console.WriteLine($"The max rate is {max}, min is {min} and average is {average} for {x.Key}");
                                break;
                            }
                        }
                    }

                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");

            }
            catch (PathTooLongException)
            {
                Console.WriteLine("System Path is too long! Consider moving it to a nearer directory");
            }
            catch (FileLoadException)
            {
                Console.WriteLine("Failed to load file, please try again");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }

    }

    public class CurrencyRate
    {
        public int id { get; set; }
        public DateTime startDate { get; set; }
        public string sourceCountry { get; set; }
        public string destinationCountry { get; set; }
        public double sourceRate { get; set; }
        public double destinationRate { get; set; }
        public DateTime endDate { get; set; }

        public CurrencyRate(int id, DateTime startDate, string firstExchange, string secondExchange, double firstRate, double secondRate, DateTime endDate)
        {
            this.id = id;
            this.startDate = startDate;
            this.sourceCountry = firstExchange;
            this.destinationCountry = secondExchange;
            this.sourceRate = firstRate;
            this.destinationRate = secondRate;
            this.endDate = endDate;
        }
    }
}
  