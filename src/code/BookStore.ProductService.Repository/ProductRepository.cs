using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.ProductService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.ProductService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext context;

        public ProductRepository(ProductContext context)
        {
            this.context = context;
        }

        public async Task Add(Product product)
        {
            context.Add(product);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Product>> GetBy(Guid id)
        {
            return await context.Products.Where(x => x.Id == id).ToListAsync().ConfigureAwait(false);
        }
    }
}
