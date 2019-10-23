using NUnit.Framework;
using System.Collections.Generic;
using quotable.core;

namespace Tests
{
    public class Tests
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
        }

        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// test that I cannot get to work.
        /// </summary>
        [Test]
        public void Test()
        {
            IEnumerable<string> quoteList = System.IO.File.ReadLines(@"C:\Users\drayl20\source\repos\PleaseWork480b\quotable\quotable.core\quotesFile");

            var generator = new DefaultRandomQuoteGenerator(quoteList);


            var id = 0;
            string quote = generator.RetrieveQuoteById(0);
            string author = generator.RetrieveAuthorById(0);

            Assert.That(id, Is.EqualTo(0));
            Assert.That(quote, Is.EqualTo("You can get straight A's and still flunk life"));
            Assert.That(author, Is.EqualTo("Walker Percy"));
        }


    }
    }
}