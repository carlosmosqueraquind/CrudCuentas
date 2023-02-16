using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.DAL.DTOs.CuentaDTOs
{
    public class CuentaEdicionDTO
    {
        public int Id { get; set; }

        //[Required]
        //public int IdCliente { get; set; }

        //[Required]
        //public int TipoCuentaId { get; set; }

        //[StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "La longitud del campo {0} debe estar entre {1} y {2}")]
        //public string NumeroCuenta { get; set; }

        public int EstadoCuentaId { get; set; }

        public decimal Saldo { get; set; }

        public bool ExentaGMF { get; set; }
    }
}
