using System.ComponentModel.DataAnnotations;

namespace CrudCuentas.DAL.Models
{
    public class Cuenta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "La longitud del campo {0} debe estar entre {1} y {2}")]
        public string NumeroCuenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(0, Double.MaxValue, ErrorMessage = "El valor del campo {0} no debe ser menor a 0")]
        public decimal Saldo { get; set;}

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool ExentaGMF { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaCreacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaModificacion { get; set; }

        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int ClienteId { get; set; }

        public TipoCuenta TipoCuenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int TipoCuentaId { get; set; }

        public EstadoCuenta EstadoCuenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int EstadoCuentaId { get; set; }
    }
}