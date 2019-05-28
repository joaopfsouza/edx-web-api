using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiDatabase.Models;

namespace WebApiDatabase.Controllers
{
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly DataAccessDbContext _dbContext;
        public ActorsController(DataAccessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_dbContext.Actor.ToArray());
        }

        [HttpGet("ById")]
        public ActionResult GetById(int id)
        {

            var actor = _dbContext.Actor.SingleOrDefault(a => a.Id == id);

            if (actor != null)
            {
                return Ok(actor);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dbContext.Actor.Add(actor);
            _dbContext.SaveChanges();
            return Created("api/actors", actor);

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Actor actor)
        {
            var target = _dbContext.Actor.SingleOrDefault(a => a.Id == id);
            actor.Id = id;

            if (target != null && ModelState.IsValid)
            {
                _dbContext.Entry(target).CurrentValues.SetValues(actor);
                _dbContext.SaveChanges();
                return Ok("api/actors/ById?id={id}");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var actor = _dbContext.Actor.SingleOrDefault(a => a.Id == id);
            if (actor != null)
            {

                _dbContext.Actor.Remove(actor);
                _dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}