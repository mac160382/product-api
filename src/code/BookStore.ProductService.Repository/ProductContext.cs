using BookStore.ProductService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.ProductService.Repository
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
