using System.ComponentModel.DataAnnotations;

namespace OrderAppAPI.CustomValidators
{
    public class MinInvoicePriceValidatorAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            double price = Convert.ToDouble(value);
            if (price < 0)
            {
                return new ValidationResult("Invoice great has to be at least 0");
            }
            return ValidationResult.Success;
        }
    }
}
