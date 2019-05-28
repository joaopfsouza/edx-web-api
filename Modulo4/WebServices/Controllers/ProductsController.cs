using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebServices.Infrastructure;
using WebServices.Model;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DbContextProduct _dbContext;
        public ProductsController(DbContextProduct dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult All()
        {
            return Ok(_dbContext.Products.ToArray());
        }

        [HttpGet("ById")]
        public ActionResult ById([FromQuery] int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public ActionResult Post([FromBody]Product product)
        {

            if (product != null)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
            }

            return Created("api/[controller]", product);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Product product)
        {
            var target = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            if (target != null && ModelState.IsValid)
            {
                _dbContext.Entry(target).CurrentValues.SetValues(product);
                _dbContext.SaveChanges();
                return Ok(_dbContext.Products.SingleOrDefault(p => p.Id == id));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {

            var target = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            if (target != null)
            {
                _dbContext.Products.Remove(target);
                _dbContext.SaveChanges();

                return Ok(target);
            }
            else
            {
                return NotFound();
            }
        }

    }
}