using BookStore.ProductService.Models;
using Swashbuckle.AspNetCore.Examples;
using System;

namespace BookStore.ProductService.ApiExamples
{
    public class ProductAddExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new Product
            {                
                Name = "Product Tests",
                Description = "detail reference to product",
                Image = "the url image",
                Price = 10.25m,
                CategoryId = Guid.NewGuid()
            };
        }
    }
}
