using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.DAL.DTOs.TipoTransaccionDTOs
{
    public class TipoTransaccionEdicionDTO
    {
        public int Id { get; set; }

        public string Transaccion { get; set; }

        public string Iniciales { get; set; }

       
    }
}
