using Microsoft.EntityFrameworkCore;
using PlayerApp.API.Models;

namespace PlayerApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        
        public DbSet<Player> Players {get; set;}
    }
}