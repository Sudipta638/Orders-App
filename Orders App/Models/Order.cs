using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Orders_App.CustomValidators;
namespace Orders_App.Models
{
    public class Order
    {
        [DisplayName("Order Number")]
        public int? OrderNo { get; set; }

        [DisplayName("Orders Date")]
        [Required(ErrorMessage ="{0} should not be blank")]
       
        [DateRangeValidator("2000-01-01",ErrorMessage ="{0} cannot be greater than or equal to 2000")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Invoice Price")]
        
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        [InvoicePriceValidatorcs]
        public double InvoicePrice { get; set; }

        [ProductListvalidator]
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
