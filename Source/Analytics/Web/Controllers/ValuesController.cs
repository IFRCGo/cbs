using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Read;

namespace Web.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("values")]
        public ActionResult<string> Get()
        {
            MongoDBHandler handler = new MongoDBHandler();

            var queryable = handler.GetQueryable().AsQueryable();         

            return "HelloBro";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
