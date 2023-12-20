using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Orders_App.Models
{
    public class Product
    {
        [DisplayName("Product Code")]
        [Required(ErrorMessage ="{0} can not be blank")]
        [Range(1,int.MaxValue,ErrorMessage ="{0} should be greater than 1")]

         
        public int Productcode { get; set; }

        [DisplayName("Product Price")]
        [Required(ErrorMessage = "{0} can not be blank")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be greater than 1")]
        public double Price { get; set; }


        [DisplayName("Product Quantity")]
        [Required(ErrorMessage = "{0} can not be blank")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be greater than 1")]
        public int Quantity { get; set; }
    }
}
