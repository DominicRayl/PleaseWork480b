using quotable.core;
using quotable.api.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using quotable.api.Models;


namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {


        }

        //I could not figure out this problem, I full expect to take hit to grade.
        [Test]
        public void Test_Get_0()
        {
            IEnumerable<string> quoteList = System.IO.File.ReadLines(@"C:\Users\drayl20\source\repos\PleaseWork480b\quotable\quotable.core\quotesFile");

            var generator = new DefaultRandomQuoteGenerator(quoteList);
            var controller = new quotesController(generator);

            var actual = controller.Get(0);

            Assert.That(actual.Value.id, Is.EqualTo(0));
            Assert.That(actual.Value.quote, Is.EqualTo("You can get straight A's and still flunk life"));
            Assert.That(actual.Value.author, Is.EqualTo("Walker Percy"));
        }
    }
}