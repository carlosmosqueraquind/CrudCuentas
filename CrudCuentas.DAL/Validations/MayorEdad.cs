using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CrudCuentas.DAL.Validations
{
    public class MayorEdad:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var MinAge = 18;

            if (value == null )
            {
                return ValidationResult.Success;
            }

            var val = (DateTime)value;

            if (val.AddYears(MinAge) > DateTime.Now)
                return  new ValidationResult("Usuario menor de edad");


           

            return ValidationResult.Success;


           

            

            //return (val.AddYears(MaxAge) > DateTime.Now);
        }
    }
}
