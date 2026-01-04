using Microsoft.EntityFrameworkCore;
using WebApiAdvance.Entities.Common;
using WebApiAdvance.DAL.Configuration;
using WebApiAdvance.Entities;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApiAdvance.Entities.Auth;

namespace WebApiAdvance.DAL.EFcore
{
    public class ApiDbContext : IdentityDbContext<AppUser<Guid>>

    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) 
        { }



        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders {  get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            
        }

    }

 
}
