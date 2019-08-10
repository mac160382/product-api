using System;
using System.Collections.Generic; 
using System.Threading.Tasks;
using BookStore.ProductService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.ProductService.Repository
{
    public class CatalogRepository : ICategoryRepository
    {
        private readonly ProductContext context;

        public CatalogRepository(ProductContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await context.Categories.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Category> GetBy(Guid id)
        {
            return await context.Categories.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }
    }
}
