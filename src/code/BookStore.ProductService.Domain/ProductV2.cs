using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.ProductService.Models
{
    /// <summary>
    /// Definition of product
    /// </summary>
    public class ProductV2
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
    }
}
