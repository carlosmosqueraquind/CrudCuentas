using System.ComponentModel.DataAnnotations;

namespace CrudCuentas.DAL.Models
{
    public class Transaccion
    {
        public int Id { get; set; }

        public  string Descripcion { get; set; }
       
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, Double.MaxValue)]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaTransaccion { get; set; }
        
        public Cuenta Cuenta { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int CuentaId { get; set; }


        public TipoTransaccion TipoTransaccion { get; set; }
        public int TipoTransaccionId { get; set; }
    }
}
