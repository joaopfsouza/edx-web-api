using Microsoft.AspNetCore.Mvc;
using WebApiDatabase.Controllers;
using WebApiDatabase.Models;
using Xunit;

namespace EFCoreWebAPI.Test
{
    public class ActorsControllerFunctionTest
    {

        public DataAccessDbContext _dbContext;
        public ActorsControllerFunctionTest()
        {
            var connectionString = "server=localhost;port=3306;database=sakila;userid=root;pwd=joao000000;sslmode=none";
            var _dbContext = DataAccessDbContextFactory.Create(connectionString);

        }

        [Fact]
        public void GetActorByIdSmokeTest()
        {

            var controller = new ActorsController(_dbContext);
            var result = controller.GetById(101) as OkObjectResult;
            var actor = result.Value as Actor;
            Assert.Equal(actor.Id, 101);
            Assert.Equal(actor.FirstName, "SUSAN");
            Assert.Equal(actor.LastName, "DAVIS");
        }
    }
}