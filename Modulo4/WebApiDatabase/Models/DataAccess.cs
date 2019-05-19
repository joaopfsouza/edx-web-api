using Microsoft.EntityFrameworkCore;

namespace WebApiDatabase.Models
{
    public class DataAccessDbContext : DbContext
    {
        public DataAccessDbContext(DbContextOptions<DataAccessDbContext> options)
        : base(options)
        {

        }

        public DbSet<Film> Film { get; set; }
        public DbSet<Actor> Actor{get;set;}

    }

    public class DataAccessDbContextFactory
    {
        public static DataAccessDbContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataAccessDbContext>();
            optionsBuilder.UseMySQL(connectionString);
            var dataAccessDb = new DataAccessDbContext(optionsBuilder.Options);
            return dataAccessDb;
        }
    }
}