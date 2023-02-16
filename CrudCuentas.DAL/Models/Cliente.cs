using CrudCuentas.DAL.Validations;
using System.ComponentModel.DataAnnotations;

namespace CrudCuentas.DAL.Models
{
    public class Cliente
    {
        public int Id  { get; set; }

        [Required]
        public int TipoDocumentoId { get; set; }

        [Required]
        public string NumeroIdentificacion { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "La longitud del campo {0} debe estar entre {1} y {2}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "La longitud del campo {0} debe estar entre {1} y {2}")]
        public string Apellido { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage ="El campo {0} debe ser un email valido")]
        public string Correo { get; set; }

        [MayorEdad]
        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }



    }
}