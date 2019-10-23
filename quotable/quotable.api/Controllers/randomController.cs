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
    public class randomController : Controller
    {
        private DefaultRandomQuoteGenerator Generator { get; }

        public randomController(DefaultRandomQuoteGenerator generator)
        {
            Generator = generator;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<Models.QuotableData> Get()
        {
            var data = new QuotableData();
            Random rn = new Random();
            int randomNum = rn.Next(3);
            data.id = randomNum.ToString();
            data.quote = Generator.RetrieveQuoteById(randomNum.ToString());
            data.author = Generator.RetrieveQuoteByAuthor(randomNum.ToString());
            return data;
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
