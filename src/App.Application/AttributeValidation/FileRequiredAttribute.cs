using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace App.Application.AttributeValidation
{
    public sealed class FileRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {

                return new ValidationResult("File é obrigatório.");
            }

            if (value.GetType() == typeof(IFormFile))
            {

                return ValidationResult.Success;
            }

            else
            {
                return new ValidationResult("Formato File é invalido.");
            }


        }
    }
}
