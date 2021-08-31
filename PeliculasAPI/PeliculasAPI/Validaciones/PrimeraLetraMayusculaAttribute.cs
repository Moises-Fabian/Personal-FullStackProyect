using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Validaciones
{
    public class PrimeraLetraMayusculaAttribute: ValidationAttribute //clase de validacion
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) //método para validar
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var Primeraletra = value.ToString()[0].ToString();
            if (Primeraletra != Primeraletra.ToUpper())
            {
                return new ValidationResult("La primera letra debe ser mayúscula");
            }

            return ValidationResult.Success;
        }
    }
}
