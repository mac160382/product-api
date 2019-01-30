using BookStore.Configuration.Constants;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.ProductService.Controller
{
    [Route(Routes.Ping)]
    public class PingController : ControllerBase
    {        
        [HttpGet]
        public string Get()
        {
            return "Pong!";
        }
    }
}
