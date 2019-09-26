using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// <summary>
    /// This class will print a certain number of quotes depending on the console input.
    /// </summary>
    public class SimpleRandomQuoteProvider : RandomQuoteProvider
    {
      /// <summary>
      /// Here to keep things from crashing.
      /// </summary>
      /// <param name="args"></param>
        static void Main(string[] args)
            {
            

            }
        /// <summary>
        /// Hard coded the quotes into a list. Some may be removed depending on the value of numOfQuotes.
        /// </summary>
        /// <param name="numOfQuotes"> Number that the user inputs into the console.</param>
        /// <returns>the list to be turned into a IEnumerable.</returns>
        public IEnumerable<string> quotez(long numOfQuotes)
           {
            List<string> quoteList = new List<string>();
            quoteList.Add("You can get straight A's and still flunk life.");
            quoteList.Add("Never regret anything that made you smile.");
            quoteList.Add("Anything can happen in life, especially  nothing.");

            if(numOfQuotes == 0)
            {
                quoteList.Remove("You can get straight A's and still flunk life.");
                quoteList.Remove("Never regret anything that made you smile.");
                quoteList.Remove("Anything can happen in life, especially  nothing.");
            }

            else if (numOfQuotes == 1)
            {
                quoteList.Remove("Never regret anything that made you smile.");
                quoteList.Remove("Anything can happen in life, especially  nothing.");
            }
            else if (numOfQuotes == 2)
            {
                quoteList.Remove("Anything can happen in life, especially  nothing.");
            }
            else if (numOfQuotes > 3)
            {
                quoteList.Remove("You can get straight A's and still flunk life.");
                quoteList.Remove("Never regret anything that made you smile.");
                quoteList.Remove("Anything can happen in life, especially  nothing.");
            }


            return quoteList;

            throw new NotImplementedException();
           }
    }
}
