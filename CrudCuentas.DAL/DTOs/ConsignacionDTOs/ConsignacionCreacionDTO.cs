using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.DAL.DTOs.ConsignacionDTOs
{
    public class ConsignacionCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int CuentaOrigen { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int CuentaDestino { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, Double.MaxValue)]
        public decimal Monto { get; set; }
    }
}
