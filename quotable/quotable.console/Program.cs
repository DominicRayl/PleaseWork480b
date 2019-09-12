using System;
using System.Collections.Generic;
using quotable.core;

namespace quotable.console
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleRandomQuoteProvider nw = new SimpleRandomQuoteProvider();
            long n = long.Parse(Console.ReadLine());
            IEnumerable<string> quotes = nw.quotez(n);

            foreach (string s in quotes)
            {
                Console.WriteLine(s);
            }
            

        }
    }
}
