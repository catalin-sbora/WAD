using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WADTestApp2.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WADTestApp2.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return dbContext.Categories.AsEnumerable();
        }

        // GET api/<controller>/5
        [HttpGet("{id}/Products")]
        public IActionResult Get(int id)
        {
           
            var categoryData = dbContext
                .Categories
                .Include("Products")
                .Where(categ => categ.Id == id).FirstOrDefault();
            if (categoryData != null)
            {              
                
                return Ok(categoryData.Products.AsEnumerable());
            }

            return NotFound();
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
