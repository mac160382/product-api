using BookStore.ProductService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.ProductService.Repository
{
    public interface IProductRepository
    {
        Task Add(Product product);

        Task<IEnumerable<Product>> GetBy(Guid id);
    }
}
