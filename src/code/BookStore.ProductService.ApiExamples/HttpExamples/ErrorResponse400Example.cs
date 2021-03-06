﻿using BookStore.Configuration.Constants;
using BookStore.ProductService.Models;
using Swashbuckle.AspNetCore.Examples;

namespace BookStore.ProductService.ApiExamples
{
    public class ErrorResponse400Example : IExamplesProvider
    {
        public object GetExamples()
        {
            return new ErrorResponse
            {
                ErrorCode = 400,
                Message = ErrorMessages.Message400Example
            };
        }
    }
}
