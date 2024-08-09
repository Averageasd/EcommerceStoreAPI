using OrderAppAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OrderAppAPI.CustomValidators
{
    public class CheckMatchingPriceValidatorAttribute : ValidationAttribute
    {
        public string ProductListName { get; set; }
        public CheckMatchingPriceValidatorAttribute(string productListName)
        {
            ProductListName = productListName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            double invoicePrice = Convert.ToDouble(value);

            // ObjectType will the type of object that owns the property on which we apply
            // this custom validator
            PropertyInfo? propertyInfo = validationContext.ObjectType.GetProperty(ProductListName);

            if (propertyInfo != null)
            {

                // get value of property with name ProductListName.
                // ObjectInstance is the object that owns the property
                // in this case, it is Order
                List<Product>? products = propertyInfo?.GetValue(validationContext.ObjectInstance) as List<Product>;
                double? totalProdPrice = 0;

                foreach (Product product in products)
                {
                    if (product.ProductCode == null || product.Quantity == null || product.Price == null)
                    {
                        return null;
                    }
                    totalProdPrice += (product.Price * product.Quantity);
                }

                return (invoicePrice == totalProdPrice) ? ValidationResult.Success : new ValidationResult("prod price does not match invoice price");
            }
            return null;
        }
    }
}
