using OrderAppAPI.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace OrderAppAPI.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Product id must be supplied")]
        public int? ProductCode { get; set; }

        [Required(ErrorMessage = "Product price must be supplied")]
        [MinProductPriceValidator]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Product quantity must be supplied")]
        [MinProductQuantityValidator]
        public int? Quantity { get; set; }
    }
}
