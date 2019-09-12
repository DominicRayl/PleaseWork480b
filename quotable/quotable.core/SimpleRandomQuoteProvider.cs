using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    public class SimpleRandomQuoteProvider : RandomQuoteProvider
    {
      
        static void Main(string[] args)
            {
            

            }

        public IEnumerable<string> quotez(long numOfQuotes)
           {
            List<string> quoteList = new List<string>();
            quoteList.Add("You can get straight A's and still flunk life.");
            quoteList.Add("Never regret anything that made you smile.");
            quoteList.Add("Just do it.");

            if(numOfQuotes == 0)
            {
                quoteList.Remove("Hello World!");
                quoteList.Remove("Never regret anything that made you smile.");
                quoteList.Remove("Just do it.");
            }

            else if (numOfQuotes == 1)
            {
                quoteList.Remove("Never regret anything that made you smile.");
                quoteList.Remove("Just do it.");
            }
            else if (numOfQuotes == 2)
            {
                quoteList.Remove("Just do it.");
            }
            else if (numOfQuotes > 3)
            {
                quoteList.Remove("Hello World!");
                quoteList.Remove("Never regret anything that made you smile.");
                quoteList.Remove("Just do it.");
            }


            return quoteList;

            throw new NotImplementedException();
           }
    }
}
