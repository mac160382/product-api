using BookStore.ProductService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.ProductService.Repository
{
    interface ICategoryRepository
    {
        Task<Category> GetBy(Guid id);

        Task<IEnumerable<Category>> Get();
    }
}
