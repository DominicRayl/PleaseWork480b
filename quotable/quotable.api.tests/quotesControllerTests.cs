using quotable.core;
using quotable.api.Controllers;
using quotable.api.Models;
using NUnit.Framework;
using System.Collections.Generic;

//Got to comment this stuff

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {


        }

      
        [Test]
        public void Test_Get_0()
        {
            IEnumerable<string> quoteList = System.IO.File.ReadLines(@"C:\Users\drayl20\source\repos\PleaseWork480b\quotable\quotable.core\quotesFile");

            DefaultRandomQuoteGenerator generator = new DefaultRandomQuoteGenerator(quoteList);
            quotesController controller = new quotesController(generator);

            var actual = controller.Get(0.ToString());

           
            
            //String instead of object
            Assert.That(actual.Value.id, Is.EqualTo(0.ToString()));
            Assert.That(actual.Value.quote, Is.EqualTo("You can get straight A's and still flunk life"));
            Assert.That(actual.Value.author, Is.EqualTo("Walker Percy"));
        }
        [Test]
        public void Test_Get_1()
        {
            IEnumerable<string> quoteList = System.IO.File.ReadLines(@"C:\Users\drayl20\source\repos\PleaseWork480b\quotable\quotable.core\quotesFile");

            DefaultRandomQuoteGenerator generator = new DefaultRandomQuoteGenerator(quoteList);
            quotesController controller = new quotesController(generator);

            var actual = controller.Get(1.ToString());



            //String instead of object
            Assert.That(actual.Value.id, Is.EqualTo(1.ToString()));
            Assert.That(actual.Value.quote, Is.EqualTo("Never regret anything that made you smile"));
            Assert.That(actual.Value.author, Is.EqualTo("Mark Twain"));
        }

        [Test]
        public void Test_Get_2()
        {
            IEnumerable<string> quoteList = System.IO.File.ReadLines(@"C:\Users\drayl20\source\repos\PleaseWork480b\quotable\quotable.core\quotesFile");

            DefaultRandomQuoteGenerator generator = new DefaultRandomQuoteGenerator(quoteList);
            quotesController controller = new quotesController(generator);

            var actual = controller.Get(2.ToString());



            //String instead of object
            Assert.That(actual.Value.id, Is.EqualTo(2.ToString()));
            Assert.That(actual.Value.quote, Is.EqualTo("Anything can happen in life, especially nothing"));
            Assert.That(actual.Value.author, Is.EqualTo("Michel Houellebecq"));
        }

        [Test]
        public void Test_GetAll()
        {
            IEnumerable<string> quoteList = System.IO.File.ReadLines(@"C:\Users\drayl20\source\repos\PleaseWork480b\quotable\quotable.core\quotesFile");
            DefaultRandomQuoteGenerator generator = new DefaultRandomQuoteGenerator(quoteList);
            quotesController controller = new quotesController(generator);



            int sizeOfList = 0;
            int count = 0;
            int actualCount = 0;
            var actual = controller.Get();

            foreach (QuotableData quote in actual.Value)
            {
                sizeOfList++;
                if (quote.quote == generator.RetrieveQuoteById(count.ToString()) && quote.author == generator.RetrieveAuthorById(count.ToString()))
                {
                    actualCount++;
                }
                count++;
            }
            Assert.AreEqual(actualCount, sizeOfList);



        }

   

    }
}