using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using quotable.core;
using System.Data.Common;
using System.Threading.Tasks;

namespace quotable.console
{
    class Program
    {
        /// <summary>
        /// Where the magic happends. First section (1) is where the simpleQuoteProvider works. It takes the user input, passes it into quotez, then loops through 
        /// the IEnumerable to print quotes. Second section (2) make IEnumerable equal to a file from the repository. Call DefaultRandomQuoteGenerator on it.
        /// </summary>
        /// <param name="args"></param>
        static async Task Main(string[] args)
        {
            //1
            // SimpleRandomQuoteProvider nw = new SimpleRandomQuoteProvider();
            // long n = long.Parse(Console.ReadLine());
            // IEnumerable<string> quotes = nw.quotez(n);
            // Console.WriteLine("This is the simple random quote: ");

            // foreach (string s in quotes)
            // {

            //     Console.WriteLine(s);
            // }

            // //2
            // Console.WriteLine();
            // Console.WriteLine("This is the default random quote: ");
            // IEnumerable<string> moreQuotes = System.IO.File.ReadLines(@"C:\Users\drayl20\source\repos\PleaseWork480b\quotable\quotable.core\quotesFile").ToList();

            // DefaultRandomQuoteGenerator nw1 = new DefaultRandomQuoteGenerator(moreQuotes);


            // Console.WriteLine("");
            // nw1.RetrieveQuoteById(0.ToString());
            //// nw1.RetrieveQuoteByAuthor("Walker Percy");
            // nw1.RetrieveAuthorById(0.ToString());

            Console.WriteLine("This kid's got alot of heart, I'm not going to fail him");

            var container = new ServiceCollection();

            container.AddDbContext<quotableContext>(options => options.UseSqlite("Data Source=lorem.db"), ServiceLifetime.Transient);

            var provider = container.BuildServiceProvider();

            using (var context = provider.GetService<quotableContext>())
            {
                await context.Database.EnsureDeletedAsync();
            }
        }
    }
}
