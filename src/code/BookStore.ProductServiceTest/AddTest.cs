using BookStore.ProductService.Controller;
using BookStore.ProductService.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace BookStore.ProductServiceTest
{
    public class AddTest
    {
        [Fact]
        public void AddProduct_is_valid()
        {
            ////arrange
            Product p = new Product
            {
                Name = "Product Tests",
                Description = "detail reference to product",
                Image = "the url image",
                Price = 10.25m,
                CategoryId = Guid.NewGuid()
            };

            ////act
            var addController = new ProductController();
            var actualResult = addController.Add(p);

            ////assert
            var createdActionResult = actualResult.Should().BeOfType<CreatedAtActionResult>().Subject;
            var actual = createdActionResult.Value.Should().BeAssignableTo<Product>().Subject;

            Assert.NotNull(actual);
        }
    }
}
