using System.ComponentModel.DataAnnotations;

namespace Orders_App.CustomValidators
{
    public class DateRangeValidator:ValidationAttribute
    {
        public string DefualtErrorMessage { get; set; } = "Order date should be greater than or equal to {0}";
        public DateTime MinimumDate { get; set; } 
         public DateRangeValidator(string minimumdate)
        {
            MinimumDate  = Convert.ToDateTime(minimumdate);

        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            { 
                DateTime date = (DateTime)value;
                if (date > MinimumDate)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefualtErrorMessage, MinimumDate.ToString("yyyy-mm-dd")),new string[] {nameof(validationContext.MemberName)});
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }

    }
}
