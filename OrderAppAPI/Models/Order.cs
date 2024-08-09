using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrderAppAPI.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace OrderAppAPI.Models
{
    public class Order
    {
        [BindNever]
        public int? OrderNo { get; set; }

        [Required(ErrorMessage = "date time cannot be empty")]
        public DateTime? OrderDate { get; set; }

        [MinInvoicePriceValidator]
        [CheckMatchingPriceValidator("Products")]
        [Required(ErrorMessage = "invoce price cannot be empty")]
        public double? InvoicePrice { get; set; }
        [Required(ErrorMessage = "product list cannot be empty or null")]
        public List<Product>? Products { get; set; }

    }
}
