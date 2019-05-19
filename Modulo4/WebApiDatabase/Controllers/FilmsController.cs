using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiDatabase.Models;

namespace WebApiDatabase.Controllers
{
    [Route("api/[controller]")]
    public class FilmsController : ControllerBase
    {
        private readonly DataAccessDbContext _dbContext;

        public FilmsController(DataAccessDbContext dbContext)
        {
            // string connectionString =
            // "server=localhost;port=3306;database=sakila;userid=root;pwd=joao000000;sslmode=none";

            // _dbContext = DataAccessDbContextFactory.Create(connectionString);

            _dbContext = dbContext;

        }

        [HttpGet]
        public Film[] Get()
        {
            return _dbContext.Film.ToArray();
        }


        [HttpGet("ById")]
        public Film Get([FromQuery] int id)
        {

            return _dbContext.Film.FirstOrDefault(f => f.Film_Id == id);

        }

    }
}