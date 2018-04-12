using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WADTestApp2.Model;

namespace WADTestApp2.Controllers
{
    [Produces("application/json")]
    [Route("api/Students")]
    public class StudentsController : Controller
    {
        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> Get()
        {
         return new Student[]
            {
                new Student{ FirstName="FirstTest", LastName ="LastTest", Id = 1},
                new Student{ FirstName="TestFirstName", LastName = "TestLastNme", Id = 2}
            };
        }

        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Students
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Students/5
        [HttpPut("{id}")]
        public Student Put(int id, [FromBody]Student value)
        {
            return value;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
