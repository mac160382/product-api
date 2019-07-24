using BookStore.ProductService.Models;
using BookStore.ProductService.Models.Validators;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace BookStore.ProductServiceTest
{
    public class ProductValidatorTest
    {
        [Fact]
        public void ProductValidator_Throw_Exception_When_Name_Is_Empty()
        {
            var validator = new ProductValidator();
            var product = new Product();
            validator.ShouldHaveValidationErrorFor(y => y.Name, product);
        }

        [Fact]
        public void ProductValidator_Throw_Exception_When_Name_Is_Null()
        {
            var validator = new ProductValidator();
            var product = new Product { Name = null };
            validator.ShouldHaveValidationErrorFor(y => y.Name, product);
        }

        [Fact]
        public void ProductValidator_Throw_Exception_When_Category_Id_Is_Default()
        {
            var validator = new ProductValidator();
            var product = new Product { CategoryId = default };
            validator.ShouldHaveValidationErrorFor(y => y.CategoryId, product);
        }

        [Fact]
        public void ProductValidator_Throw_Exception_When_Category_Id_Is_Not_Default()
        {
            var validator = new ProductValidator();
            var product = new Product { CategoryId = Guid.NewGuid() };
            validator.ShouldNotHaveValidationErrorFor(y => y.CategoryId, product);
        }
    }
}
