using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.DAL.DTOs.TransaccionDTOs
{
    public class TransaccionCreacionTransferenciaDTO
    {
        //public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, Double.MaxValue)]
        public decimal Monto { get; set; }

               

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int CuentaOrigenId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int CuentaDestinoId { get; set; }


        
    }
}
