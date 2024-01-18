using crud.Models;
using Microsoft.EntityFrameworkCore;

namespace crud.DAL
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }
    }
}