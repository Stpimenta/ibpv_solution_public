using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IbpvDtos.personvalidations
{
    public class DataPersonFutureValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is null)
            {   
                return ValidationResult.Success;
            }
            DateTime data = (DateTime)value;
            if (data > DateTime.Today)
            {
                return new ValidationResult("A data não pode estar no futuro.");
            }

            return ValidationResult.Success;
        }
    }   
}