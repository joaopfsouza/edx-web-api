using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {

        //Get All People
        [HttpGet]
        public Person[] Get()
        {

            return Repository.People.OrderBy(p=>p.Id).ToArray();
        }

        // Get person by Id
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return Repository.GetPersonById(id);
        }

        //Create new person
        [HttpPost]
        public void Post([FromBody]Person person)
        {
            Repository.AddPerson(person);
        }

        //Replace existing person
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Person person)
        {
            Repository.ReplacePersonById(id, person);
        }

        //Delete existing person
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Repository.RemovePersonById(id);
        }
    }
}