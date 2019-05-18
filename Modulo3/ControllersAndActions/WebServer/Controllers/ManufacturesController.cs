using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    public class ManufacturesController : ControllerBase
    {
        [HttpGet]
        public Product Action1([FromQuery] Product p)
        {
            return p;
        }

        [HttpGet("{id}/{name}/{price}")]
        public Product Action2([FromRoute] Product p)
        {
            return p;
        }

        [HttpGet("{id}/{name}")]
        public Product Action3(Product p)
        {
            return p;
        }

        [HttpPost]
        public Product Action4([FromForm] Product p)
        {
            return p;
        }


        // [HttpPost]
        // public Product Action5([FromBody]Product p)
        // {
        //     return p;
        // }


        

    }
}