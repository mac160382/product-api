

using FluentValidation;

namespace BookStore.ProductService.Models.Validators
{
    /// <summary>
    /// The validation to Product
    /// </summary>
    public class ProductValidator : AbstractValidator<Product>
    {
        /// <summary>
        /// The conctructor
        /// </summary>
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(0, 150);
            RuleFor(x => x.Description).Length(0, 150);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.CategoryId).NotDefaultGuidValidator();
        }
    }
}
