using BookStore.ProductService.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStore.ProductService.Controller
{
    [Route(Routes.Product)]
    public class ProductController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}