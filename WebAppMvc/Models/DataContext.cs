using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebAppMvc.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<DataContext>
        //{
        //    public DataContext CreateDbContext(string[] args)
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        //        optionsBuilder.UseInMemoryDatabase("TestDataBase");

        //        return new DataContext(optionsBuilder.Options);
        //    }
        //}
        public DbSet<Product> Products { get; set; }
    }
}
