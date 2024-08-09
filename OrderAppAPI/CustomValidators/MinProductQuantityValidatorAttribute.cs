using System.ComponentModel.DataAnnotations;

namespace OrderAppAPI.CustomValidators
{
    public class MinProductQuantityValidatorAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int productQuantity = Convert.ToInt32(value);
            if (productQuantity <= 0)
            {
                return new ValidationResult("Product quantity has to be at least 1");
            }
            return ValidationResult.Success;    
        }
    }
}
