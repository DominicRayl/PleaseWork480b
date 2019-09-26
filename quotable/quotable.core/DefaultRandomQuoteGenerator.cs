using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quotable.core
{
  /// <summary>
  /// This class will print a random, default quote.
  /// </summary>
    public class DefaultRandomQuoteGenerator : RandomQuoteProvider
    {
      /// <summary>
      /// It takes a IEnumerbale from the program class and prints a random element from the sequence.
      /// </summary>
      /// <param name="data"></param>
        public DefaultRandomQuoteGenerator(IEnumerable<string> data)
        {
            //IEnumerable<string> moreQuotes = System.IO.File.ReadLines(@"C:\Users\drayl20\source\repos\PleaseWork480b\quotable\quotable.core\quotesFile").ToList();

            //List<string> lines

            Random rn = new Random();
            int location = rn.Next(data.Count());
            Console.WriteLine(data.ElementAt(location));
            
        }
        /// <summary>
        /// I need this to use the RandomQuoteProvider interface. I don't know exactly why I need it though. I feel it should be used. Let me know if that is the case. 
        /// </summary>
        /// <param name="numOfQuotes"></param>
        /// <returns></returns>
        public IEnumerable<string> quotez(long numOfQuotes)
        {
            throw new NotImplementedException();
        }
    }
}
