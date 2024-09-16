using CarroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarroApi.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<CarroModel> Carros { get; set; }
    }
}
