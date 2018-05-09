using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WADTestApp2.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WADTestApp2
{
    [Route("api/[controller]")]   
    [Produces("application/json")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
       
        public ProductsController(ApplicationDbContext dbContext)
            :base()
        {
            this.dbContext = dbContext;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return dbContext.Products.AsEnumerable();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = dbContext.Products.Where(prod => prod.Id == id).FirstOrDefault();
            return product;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Product newProduct)
        {
            Product retProduct = null;
            var existingProduct = dbContext.Products.Where(prod => prod.Id == newProduct.Id).FirstOrDefault();
            if (existingProduct != null)
            {
                retProduct = existingProduct;
            }
            else
            {
                retProduct = newProduct;
                dbContext.Products.Add(newProduct);
                dbContext.SaveChanges();
            }
            return Ok(existingProduct);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            Product retProduct = product;
            IActionResult retResult = null;
            var existingProduct = dbContext.Products.Where(prod => prod.Id == id).FirstOrDefault();
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                retProduct = existingProduct;
                retResult = Ok(retProduct);
            }
            else
            {
                retResult = NotFound(retProduct);
            }
           
            return retResult;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
