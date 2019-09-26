using System;
using System.Collections.Generic;
using System.Linq;
using quotable.core;

namespace quotable.console
{
    class Program
    {
        /// <summary>
        /// Where the magic happends. First section (1) is where the simpleQuoteProvider works. It takes the user input, passes it into quotez, then loops through 
        /// the IEnumerable to print quotes. Second section (2) make IEnumerable equal to a file from the repository. Call DefaultRandomQuoteGenerator on it.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //1
            SimpleRandomQuoteProvider nw = new SimpleRandomQuoteProvider();
            long n = long.Parse(Console.ReadLine());
            IEnumerable<string> quotes = nw.quotez(n);
            Console.WriteLine("This is the simple random quote: ");

            foreach (string s in quotes)
            {
               
                Console.WriteLine(s);
            }

            //2
            Console.WriteLine();
            Console.WriteLine("This is the default random quote: ");
            IEnumerable<string> moreQuotes = System.IO.File.ReadLines(@"C:\Users\drayl20\source\repos\PleaseWork480b\quotable\quotable.core\quotesFile").ToList();

            DefaultRandomQuoteGenerator nw1 = new DefaultRandomQuoteGenerator(moreQuotes);
            

        }
    }
}
