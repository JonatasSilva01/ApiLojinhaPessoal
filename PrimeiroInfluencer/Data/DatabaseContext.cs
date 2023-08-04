using Microsoft.EntityFrameworkCore;
using PrimeiroInfluencer.Model;

namespace PrimeiroInfluencer.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Product> ProductDb { get; set; }
        public DbSet<Address> AddressDb { get; set; }
    }
}
