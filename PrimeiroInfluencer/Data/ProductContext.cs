using Microsoft.EntityFrameworkCore;
using PrimeiroInfluencer.Model;

namespace PrimeiroInfluencer.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public  DbSet<Product> ProductDb { get; set; }
    }
}
