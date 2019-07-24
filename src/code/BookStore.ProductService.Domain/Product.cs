using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ProductService.Models
{
    /// <summary>
    /// Definition of product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The unic identifier
        /// </summary>
        [DisplayName(DisplayNames.Id)]
        public Guid? Id { get; set; }

        /// <summary>
        /// The name of product
        /// </summary>
        [Required]
        [DisplayName(DisplayNames.Name)]
        public string Name { get; set; }

        /// <summary>   
        /// The descripcion of product
        /// </summary>
        [Required]
        [DisplayName(DisplayNames.Description)]
        public string Description { get; set; }

        /// <summary>
        /// The url image of product
        /// </summary>
        ////[StringLength(150)]
        [DisplayName(DisplayNames.Image)]
        public string Image { get; set; }

        /// <summary>
        /// The unit price of product
        /// </summary>
        [Required]
        [DisplayName(DisplayNames.Price)]
        public decimal Price { get; set; }

        /// <summary>
        /// The category releated to product
        /// </summary>
        [Required]
        [DisplayName(DisplayNames.CategoryId)]
        public Guid CategoryId { get; set; }
    }
}
