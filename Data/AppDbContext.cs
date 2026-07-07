using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }



    }
}

