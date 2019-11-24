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


                var dbDidntExist = await context.Database.EnsureCreatedAsync();

                if (dbDidntExist)
                {
                    //await PopulateDatabase(context);
                }
            }

            using (var context = provider.GetService<quotableContext>())
            {
                var quotes = context.Quotes
                                            .Include(d => d.QuoteAuthor)
                                            .ThenInclude(x => x.Author);
                foreach (var quote in quotes)
                {
                    Console.WriteLine($"quote.id = {quote.Id}");
                    Console.WriteLine($"quote.title = {quote.Title}");

                    foreach (var author in quote.Authors)
                    {
                        Console.WriteLine($"document.author.id = {author.Id}");
                        Console.WriteLine($"document.author.firstname = {author.FirstName}");
                        Console.WriteLine($"document.author.firstname = {author.LastName}");
                    }

                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        
           
        }
        /// <summary>
        /// In the intrest of completing this assignment, I decided to hard code the quotes instead of reading from file.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static async Task PopulateDatabase(quotableContext context)
        {
            var author1 = new Author()
            {
                FirstName = "Walker",
                LastName = "Percy"
            };
            var author2 = new Author()
            {
                FirstName = "Mark",
                LastName = "Twain"
            };
            var author3 = new Author()
            {
                FirstName = "Michel",
                LastName = "Houellebecq"
            };

            var quote1 = new Quote();
            quote1.Title = "You can get straight A's and still flunk life";

            var quote2 = new Quote();
            quote2.Title = "Never regret anything that made you smile";

            var quote3 = new Quote();
            quote3.Title = "Anything can happen in life, especially nothing";

            var da1 = new QuoteAuthor() { Quote = quote1, Author = author1 };
            var da2 = new QuoteAuthor() { Quote = quote2, Author = author2 };
            var da3 = new QuoteAuthor() { Quote = quote3, Author = author3 };
       
            context.AddRange(da1, da2, da3);

            await context.SaveChangesAsync();
        }
    }

}
