using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ProductService.Models
{
    public class ErrorResponse
    {
        public int ErrorCode { get; set; }

        public string Message { get; set; }
    }
}
