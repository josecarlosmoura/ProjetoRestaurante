using Microsoft.EntityFrameworkCore;
using RestauranteCedro.Entities;

namespace RestauranteCedro
{
    public class RestauranteCedroContext : DbContext
    {
        public RestauranteCedroContext(
            DbContextOptions<RestauranteCedroContext> options) : base(options)
        {
        }
        
        public DbSet<Restaurante> Restaurantes { get; set; }
        
        public DbSet<Prato> Pratos { get; set; }
    }
}