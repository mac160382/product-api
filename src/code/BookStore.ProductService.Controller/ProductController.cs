using BookStore.Configuration.Constants;
using BookStore.ProductService.ApiExamples;
using BookStore.ProductService.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Net;

namespace BookStore.ProductService.Controller
{    
    [Route(Routes.Product)]
    public class ProductController : ControllerBase
    {
        [HttpGet(Routes.ProductList)]
        public IEnumerable<string> GetList()
        {
            return new string[] { "value1", "value2" };
        }
        
        [HttpGet(Routes.Id)]
        public IEnumerable<string> Get([FromRoute] Guid id)
        {
            return new string[] { id.ToString() };
        }

        [HttpPost]
        [Consumes(MimeType.ApplicationJson)]
        [Produces(MimeType.ApplicationJson, Type = typeof(Product))]
        [ActionName(Actions.AddAsync)]
        [SwaggerRequestExample(typeof(Product), typeof(ProductAddExample))]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Created)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Product))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(ProductAddExample))]
        ////[ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        ////[SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        ////[SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(ProductAddExample))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(ErrorResponse400Example))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(ErrorResponse500Example))]
        public IActionResult Add([FromBody]Product product)
        {
            return this.CreatedAtAction(Actions.AddAsync, product);
        }

        [HttpPut]
        public void Update()
        {
        }

        [HttpDelete]
        public void Delete()
        {
        }
    }
}