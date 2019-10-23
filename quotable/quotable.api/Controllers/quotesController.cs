using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotable.api.Models;
using quotable.core;

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

        public ActionResult<QuotableData> Get(string id)
        {
            var data = new QuotableData();
            data.quote = Generator.RetrieveQuoteById(id);
            data.author = Generator.RetrieveQuoteByAuthor(id);
            data.id = id;
            data.allQuotes = Generator.returnAllQuotes();

            return data;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

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
