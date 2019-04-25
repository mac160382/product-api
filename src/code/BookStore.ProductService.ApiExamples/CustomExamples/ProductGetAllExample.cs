using BookStore.ProductService.Models;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;

namespace BookStore.ProductService.ApiExamples
{
    public class ProductAllExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = nameof(Product.Name),
                    Description = nameof(Product.Description),
                    Price = 12.25M,
                    CategoryId = Guid.NewGuid()
                }
            };
        }
    }
}
