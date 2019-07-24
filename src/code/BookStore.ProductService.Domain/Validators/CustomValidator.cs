using FluentValidation;
using System;

namespace BookStore.ProductService.Models.Validators
{
    public static class CustomValidator
    {
        public static IRuleBuilderOptions<T, Guid> NotDefaultGuidValidator<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        {
            return ruleBuilder.Must(m => m != default).WithMessage("'{PropertyName}' should not start with default value");
        }
    }
}
