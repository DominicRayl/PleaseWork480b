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

        IEnumerable<string> quoteList = System.IO.File.ReadLines(@"C:\Users\drayl20\source\repos\PleaseWork480b\quotable\quotable.core\quotesFile").ToList();
        /// <summary>
        /// It takes a IEnumerbale from the program class and prints a random element from the sequence.
        /// </summary>C:\Users\drayl20\Source\Repos\PleaseWork480b\quotable\quotable.core\quotesFile
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
        /// Method from: https://whatis.techtarget.com/definition/controller
        /// </summary>
        /// <param name="s"></param>
        /// <param name="beginIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public string JavaStyleSubstring(string s, int beginIndex, int endIndex)
        {
            // simulates Java substring function
            int len = endIndex - beginIndex;
            return s.Substring(beginIndex, len);
        }


        /// <summary>
        /// Returns quote by the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string RetrieveQuoteById(string id)
        {
            string quoteByID = "";
            string theId = "";
            

            foreach ( string quote in quoteList)
            {
                int end = (quote.IndexOf('-'));
                end = end - 2;
                theId += quote[0].ToString();
                if (theId == id)
                {
                    Console.WriteLine(end);
                    quoteByID = JavaStyleSubstring(quote ,3, end);
                }
                theId = "";
            }

            //personal testing purposes 
            Console.WriteLine("This is quote by ID: " + quoteByID);
            return quoteByID;
        }

        public string RetrieveAuthorById(string id)
        {
            string authorByID = "";
            string theId = "";
            Boolean done = false;
            

            foreach (string quote in quoteList)
            {
                int start = quote.IndexOf('-');
                start = start + 1;
                theId += quote[0].ToString();
                //Console.WriteLine("this is 'theId' " + theId + "." + " This is 'id' " + id);
                if (theId == id)
                {
                    Console.WriteLine("We got here.");
                    //authorByID = quote.Substring('-' + 1);

                    authorByID = JavaStyleSubstring(quote, start, quote.IndexOf('.'));
                }
                theId = "";
            }

           // authorByID.Remove(0, 1); //Removes unslightly blemish as beginning of string

            Console.WriteLine("This is 'RetrieveAuthorByID': " + authorByID);
            return authorByID;
        }

        /// <summary>
        /// Returns quote by the author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public string RetrieveQuoteByAuthor(string author)
        {
            string quoteByAuthor = "";
            string theAuthor = "";
            Boolean done = false;
            int start = 0;
            
            //I hate myself for doing it like this, but I am on a lot of caffine, and I am tired.

            foreach (string quote in quoteList)
            {
                if (!done)
                {
                    foreach (char c in quote)
                    {
                        if(c == '-')
                        {
                            start = quote.IndexOf(c) +1;
                        }
                    }
                }
                int length = quote.IndexOf(']');
                theAuthor = quote.Substring(start);
                if (theAuthor == author)
                {
                    quoteByAuthor = quote.Substring(3, '-');
                }
            }

            //personal testing purposes 
            Console.WriteLine("This is quote by Author: " + quoteByAuthor);
            return quoteByAuthor;
        }

        /// <summary>
        /// Returns all the quotes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> returnAllQuotes()
        {
            return System.IO.File.ReadLines(@"C:\Users\drayl20\source\repos\PleaseWork480b\quotable\quotable.core\quotesFile").ToList();
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
