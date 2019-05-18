using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet("all")]
        public Product[] GetAllProducts()
        {
            return FakeData.Products.Values.ToArray();
        }

        [HttpGet]
        public ActionResult Get()
        {
            if (FakeData.Products != null)
            {
                return Ok(FakeData.Products.Values.ToArray());
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (FakeData.Products.ContainsKey(id))
                return Ok(FakeData.Products[id]);
            else
                return NotFound();
        }

        [HttpGet("ById/{id}")]
        public Product GetById(int id)
        {
            if (FakeData.Products.ContainsKey(id))
            {

                return FakeData.Products[id];
            }
            else
            {
                return null;
            }

        }

        [HttpGet("from/{low}/to/{high}")]
        public ActionResult Get(int low, int high)
        {
            var products = FakeData.Products.Values
            .Where(p => p.Price >= low && p.Price <= high).ToArray();
            if (products.Length > 0)
            { // LINQ guarantees the products won't be null
                return Ok(products);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("from/{low}/to/{high}")]
        public Product[] GetIntervalPrice(double low, double high)
        {
            return FakeData.Products.Values.Where(p => p.Price >= low && p.Price <= high).ToArray();
        }

        [HttpPost]
        public ActionResult Post([FromBody]Product product)
        {
            product.ID = FakeData.Products.Keys.Max() + 1;
            FakeData.Products.Add(product.ID, product);
            return Created($"api/products/{product.ID}",product); // contains the new ID
        }

        // [HttpPost]
        // public Product CreateProduct([FromBody]Product product)
        // {
        //     product.ID = FakeData.Products.Keys.Max() + 1;
        //     FakeData.Products.Add(product.ID, product);

        //     return product;
        // }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Product product)
        {
            if (FakeData.Products.ContainsKey(id))
            {
                var target = FakeData.Products[id];
                target.ID = product.ID;
                target.Name = product.Name;
                target.Price = product.Price;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public void UpdateProductByID(int id, [FromBody] Product product)
        {
            if (FakeData.Products.ContainsKey(id))
            {

                var target = FakeData.Products[id];
                target.ID = product.ID;
                target.Name = product.Name;
                target.Price = product.Price;
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (FakeData.Products.ContainsKey(id))
            {
                FakeData.Products.Remove(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public void DeleteProductByID(int id)
        {
            if (FakeData.Products.ContainsKey(id))
            {
                FakeData.Products.Remove(id);
            }
        }
    }
}