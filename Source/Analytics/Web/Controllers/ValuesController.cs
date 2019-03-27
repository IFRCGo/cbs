using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Read;

namespace Web.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MongoDBHandler mongoDbHandler;

        public ValuesController(MongoDBHandler mongoDbHandler)
        {
            this.mongoDbHandler = mongoDbHandler;
        }

        // GET api/values/5
        [HttpGet("values")]
        public ActionResult<string> Get()
        {
            var queryable = mongoDbHandler.GetQueryable<CaseReport>().Where(x => x.Id == ObjectId.Parse("5c9a0d8afe28b239e7da280d")).ToList();

      

            y = new SomeGenericClass("UPDATE ME", "PLZ");
            mongoDbHandler.UpdateRecordInDb(y, ObjectId.Parse("5c9b76e7fe28b239e7da3453"));

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
