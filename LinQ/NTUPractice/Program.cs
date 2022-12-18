using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTUPractice
{
    class Program
    {
        //Test Commit Message 
        static void Main(string[] args)
        {

            
            //Use Using () to ensure the Database closes after access:
            using (var context = new AdventureWorks2017Entities())
            {
                using (var fileReader = new StreamReader(@"D:\OneDrive - Personal\OneDrive - Temasek Polytechnic\Year 1, Sem 2\WorldSkills\CurrencyRate.csv"))
                {
                    List<CurrencyRate> currencyRates = new List<CurrencyRate>();

                    while (!fileReader.EndOfStream)
                    {
                        var rawData = fileReader.ReadLine();
                        var values = rawData.Split('\t');

                       
                    }

                   

                   
                }
                Console.WriteLine("Find a name!");

                var people = context.People;

                var emailAddress = Console.ReadLine();

                var input = Console.ReadLine();

                //var inputEmail = Console.ReadLine();

                var query = from p in people
                            where p.MiddleName.Contains(input) //&& p.EmailAddresses.Where(e => e.EmailAddress1.Contains(input))
                            group p by p.FirstName;
                

                /*
                foreach (var item in query)
                {
                    Console.WriteLine(item.Key);

                    Console.WriteLine($"\t{item.Key.Count()}");
                }

                var query2 = from p in people
                            where p.MiddleName.Contains(input) 
                            select p;

                
                foreach(var x in query2)
                {
                    
                    var gotEmail = (from p in x.EmailAddresses
                                    where p.EmailAddress1.Contains(emailAddress)
                                    select p).Count() > 0;
                                    

                    if (x.EmailAddresses.Where(p => p.EmailAddress1.Contains(emailAddress)).Count() > 0)
                    {
                        //write functions
                    }
                }
                
            */


                //Access the one-to-many relationship from the 'Many' side instead of the 'one' side:
                var q = from p in context.EmailAddresses
                        where p.EmailAddress1.Contains(emailAddress) && p.Person.MiddleName.Contains(input)
                        select p.Person.FirstName;


                foreach (var item in q)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }
        }
    }
}
