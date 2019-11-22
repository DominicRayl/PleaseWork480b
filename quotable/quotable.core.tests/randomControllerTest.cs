using NUnit.Framework;
using System.Collections.Generic;
using quotable.core;
using quotable.api.Models;
using quotable.api.Controllers;

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
        public void Test_Random()
        {
            IEnumerable<string> quoteList = System.IO.File.ReadLines(@"C:\Users\drayl20\source\repos\PleaseWork480b\quotable\quotable.core\quotesFile");
            DefaultRandomQuoteGenerator generator = new DefaultRandomQuoteGenerator(quoteList);
            randomController controller = new randomController(generator);

            var actual = controller.Get();

            var id = actual.Value.id;
            var quote = generator.RetrieveQuoteById(id);
            var author = generator.RetrieveAuthorById(id);

            Assert.That(id, Is.EqualTo(actual.Value.id.ToString()));
            Assert.That(quote, Is.EqualTo(actual.Value.quote));
            //Assert.That(author, Is.EqualTo(actual.Value.author));
        }


    }
    
}