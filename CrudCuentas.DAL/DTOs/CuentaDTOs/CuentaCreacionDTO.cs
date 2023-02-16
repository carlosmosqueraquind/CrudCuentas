using CrudCuentas.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.DAL.DTOs.CuentaDTOs
{
    public class CuentaCreacionDTO
    {
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(0, Double.MaxValue, ErrorMessage = "El valor del campo {0} no debe ser menor a 0")]
        public decimal Saldo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool ExentaGMF { get; set; }

       

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int ClienteId { get; set; }

       

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int TipoCuentaId { get; set; }

       
    }
}
