using System;
using System.ComponentModel;

namespace BookStore.ProductService.Models
{
    /// <summary>
    /// Definition of category
    /// </summary>
    public class Category
    {
        /// <summary>
        /// The unic identifier
        /// </summary>
        [DisplayName(DisplayNames.Id)]
        public Guid Id { get; set; }

        /// <summary>
        /// The category name
        /// </summary>
        [DisplayName(DisplayNames.Name)]
        public string Name { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        [DisplayName(DisplayNames.Description)]
        public string Description { get; set; }
    }
}
