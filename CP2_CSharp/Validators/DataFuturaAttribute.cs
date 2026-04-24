using System.ComponentModel.DataAnnotations;

namespace CP2_CSharp.Validators;

public class DataFuturaAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime data)
        {
            if (data.Date < DateTime.Now.Date)
                return new ValidationResult(ErrorMessage ?? "A data não pode ser no passado");
        }

        return ValidationResult.Success;
    }
}
