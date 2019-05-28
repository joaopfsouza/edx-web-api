using WebServices.Controllers;
using WebServices.Infrastructure;
using Xunit;

namespace WebServices.Test
{
    public class FunctionalTest
    {

        public DbContextProduct _dbContext;
        public FunctionalTest(DbContextProduct dbContext)
        {

            _dbContext = dbContext;

        }


        [Fact]
        public void CreateProductsControllerInstanceTest()
        {
            var controller = new ProductsController(_dbContext);
            Assert.NotNull(controller);
        }
    }
}