using Orders_App.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Orders_App.CustomValidators
{
    public class InvoicePriceValidatorcs: ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "Invoice Price should be equal to the total cost of all products (i.e. {0}) in the order.";
        public InvoicePriceValidatorcs() { }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                PropertyInfo? otherproperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));
                if (otherproperty != null)
                {
                    List<Product> products = (List<Product>)otherproperty.GetValue(validationContext.ObjectInstance)!; 

                   
                    double totalPrice = 0;
                    foreach (Product product in products)
                    {
                        totalPrice += product.Price * product.Quantity;
                    }

                    double actualPrice = (double)value;

                    if (totalPrice > 0)
                    {
   
                        if (totalPrice != actualPrice)
                        {
                    
                            return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, totalPrice), new string[] { nameof(validationContext.MemberName) });
                        }
                    }
                    else
                    {
                        return new ValidationResult("No products found to validate invoice price", new string[] { nameof(validationContext.MemberName) });
                    }

                    return ValidationResult.Success;
                }
                return null;

            }
            return null;
            

         
        }
    }
}
