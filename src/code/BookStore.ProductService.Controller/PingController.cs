using BookStore.ProductService.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.ProductService.Controller
{
    [Route(Routes.Ping)]
    public class PingController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Pong!";
        }
    }
}
