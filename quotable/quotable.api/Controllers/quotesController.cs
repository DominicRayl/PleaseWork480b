using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotable.api.Models;
using quotable.core;

//The problem is in here!!!!!!!
//You should do some research

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quotable.api.Controllers
{
    [Route("api/[controller]")]
    public class quotesController : Controller
    {
        private DefaultRandomQuoteGenerator Generator { get; }

        public quotesController(DefaultRandomQuoteGenerator generator)
        {
            Generator = generator;
        }

        [HttpGet]
        public ActionResult<List<QuotableData>> Get()
        {
            IEnumerable<string> quoteList = System.IO.File.ReadLines(@"C:\Users\drayl20\source\repos\PleaseWork480b\quotable\quotable.core\quotesFile").ToList();
            int count = 0;
            List<QuotableData> allQuotes = new List<QuotableData>();
            foreach (string quote in quoteList)
            {
                var data = new QuotableData();
                data.id = count.ToString();
                data.quote = Generator.RetrieveQuoteById(count.ToString());
                data.author = Generator.RetrieveAuthorById(count.ToString());
                allQuotes.Add(data);
                count++;
            }
            return allQuotes;
        }

        [HttpGet]
        public ActionResult<QuotableData> Get(string id)
        {
            var data = new QuotableData();
            data.quote = Generator.RetrieveQuoteById(id);
            data.author = Generator.RetrieveAuthorById(id);
            data.id = id;
            //data.allQuotes = Generator.returnAllQuotes();
            return data;
        }

        // GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
