using Microsoft.EntityFrameworkCore;
using WebServices.Model;

namespace WebServices.Infrastructure
{
    public class DbContextProduct:DbContext
    {
        public DbContextProduct(DbContextOptions<DbContextProduct> options)
        :base(options){}

        public DbSet<Product> Products { get; set; }
        
    }

    public class DbContextProductFactory
    {
        public static DbContextProductFactory Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContextProduct>();
            optionsBuilder.UseMySQL(connectionString);
            var dataAccessDb = new DbContextProduct(optionsBuilder.Options);
            return dataAccessDb;
        }
    }
}