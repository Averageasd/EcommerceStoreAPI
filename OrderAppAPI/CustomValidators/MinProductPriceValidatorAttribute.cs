using System.ComponentModel.DataAnnotations;

namespace OrderAppAPI.CustomValidators
{
    public class MinProductPriceValidatorAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            double productPrice = Convert.ToDouble(value);
            if (productPrice < 0)
            {
                return new ValidationResult("Product price has to be at least 0");
            }
            return ValidationResult.Success;
        }
    }
}
