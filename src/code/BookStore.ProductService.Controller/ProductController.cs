using BookStore.Configuration.Constants;
using BookStore.ProductService.ApiExamples;
using BookStore.ProductService.Controller.Filters;
using BookStore.ProductService.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Net;

namespace BookStore.ProductService.Controller
{    
    /// <summary>
    /// The Product Controller
    /// </summary>
    [Route(Routes.Product)]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of Product</returns>
        [MapToApiVersion("1.0")]
        [HttpGet(Routes.ProductList)]
        [Consumes(MimeType.ApplicationJson)]
        [Produces(MimeType.ApplicationJson, Type = typeof(Product))]
        [ActionName(Actions.GetById)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Product>))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(ProductAllExample))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(ErrorResponse400Example))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(ErrorResponse404Example))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(ErrorResponse500Example))]
        public IActionResult GetList()
        {
            return this.Ok(new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = nameof(Product.Name),
                    Description = nameof(Product.Description),
                    Price = 12.25M,
                    CategoryId = Guid.NewGuid()
                }
            });
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of Product</returns>
        [MapToApiVersion("2.0")]
        [HttpGet(Routes.ProductList)]
        [Consumes(MimeType.ApplicationJson)]
        [Produces(MimeType.ApplicationJson, Type = typeof(Product))]
        [ActionName(Actions.GetById)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Product>))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(ProductAllExample))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(ErrorResponse400Example))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(ErrorResponse404Example))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(ErrorResponse500Example))]
        public IActionResult GetList2()
        {
            return this.Ok(new List<ProductV2>
            {
                new ProductV2
                {
                    Id = Guid.NewGuid(),
                    Name = nameof(Product.Name),
                }
            });
        }

        /// <summary>
        /// Get product by identifier
        /// </summary>
        /// <param name="id">The product identifier</param>
        /// <returns>The specific product by id</returns>
        ////[HttpGet(Routes.Id)]
        [HttpGet]
        [Consumes(MimeType.ApplicationJson)]
        [Produces(MimeType.ApplicationJson, Type = typeof(Product))]
        [ActionName(Actions.GetById)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Product))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(ProductGetByIdExample))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(ErrorResponse400Example))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(ErrorResponse404Example))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(ErrorResponse500Example))]

        public IActionResult Get([FromRoute] Guid id)
        {
            return this.Ok(new Product
            {
                Id = Guid.NewGuid(),
                Name = nameof(Product.Name),
                Description = nameof(Product.Description),
                Price = 12.25M,
                CategoryId = Guid.NewGuid()
            });
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="product">The product will be created</param>
        /// <returns>The product creates</returns>
        [HttpPost]
        [Consumes(MimeType.ApplicationJson)]
        [Produces(MimeType.ApplicationJson, Type = typeof(Product))]
        [ActionName(Actions.Add)]
        [SwaggerRequestExample(typeof(Product), typeof(ProductAddExample))]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Created)]
        [SwaggerResponse((int)HttpStatusCode.Created, Type = typeof(Product))]
        [SwaggerResponseExample((int)HttpStatusCode.Created, typeof(ProductExample))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(ErrorResponse404Example))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(ErrorResponse400Example))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(ErrorResponse500Example))]
        [ModelStateFilter]
        public IActionResult Add([FromBody]Product product)
        {
            product.Id = Guid.NewGuid();
            return this.CreatedAtAction(Actions.GetById, product);
        }

        /// <summary>
        /// Update current product
        /// </summary>
        /// <param name="product"></param>
        /// <returns> </returns>
        [HttpPut(Routes.Id)]
        [Consumes(MimeType.ApplicationJson)]
        [Produces(MimeType.ApplicationJson, Type = typeof(Product))]
        [ActionName(Actions.Update)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Created)]
        [SwaggerResponse((int)HttpStatusCode.Created, Type = typeof(Product))]
        [SwaggerResponseExample((int)HttpStatusCode.Created, typeof(ProductExample))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(ErrorResponse404Example))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(ErrorResponse400Example))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(ErrorResponse500Example))]
        public IActionResult Update([FromRoute] Guid id, [FromBody]Product product)
        {
            product.Price = product.Price * 1.1m;
            return this.Ok(product);
        }

        [HttpDelete(Routes.Id)]
        [Consumes(MimeType.ApplicationJson)]
        [Produces(MimeType.ApplicationJson, Type = typeof(Product))]
        [ActionName(Actions.Update)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Created)]
        [SwaggerResponse((int)HttpStatusCode.Created, Type = typeof(Product))]
        [SwaggerResponseExample((int)HttpStatusCode.Created, typeof(ProductExample))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(ErrorResponse404Example))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(ErrorResponse400Example))]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(ErrorResponse500Example))]
        public IActionResult Delete([FromRoute] Guid id)
        {
            return this.Ok();
        }
    }
}