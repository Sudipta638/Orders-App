using Orders_App.Models;
using System.ComponentModel.DataAnnotations;

namespace Orders_App.CustomValidators
{

    public class ProductListvalidator:ValidationAttribute
    {

        public string DefaultErrorMessage { get; set; } = "Order should have at least one product";
        public ProductListvalidator() { }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                List<Product> products = (List<Product>)value;

                
                if (products.Count == 0)
                {
                    
                    return new ValidationResult(DefaultErrorMessage, new string[] { nameof(validationContext.MemberName) });
                }

                
                return ValidationResult.Success;
            }
            return null;
        }
    }
}
