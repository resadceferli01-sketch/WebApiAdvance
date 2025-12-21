using Microsoft.EntityFrameworkCore;
using WebApiAdvance.Entities.Common;
using WebApiAdvance.DAL.Configuration;

namespace WebApiAdvance.DAL.EFcore
{
    public class ApiDbContext:DbContext

    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) 
        { }



        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfigurations).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfigurations).Assembly);
        }

    }

 
}
