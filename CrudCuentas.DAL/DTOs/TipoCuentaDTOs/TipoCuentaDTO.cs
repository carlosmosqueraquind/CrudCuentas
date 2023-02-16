using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.DAL.DTOs.TipoCuentaDTOs
{
    public class TipoCuentaDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Iniciales { get; set; }

        public string Prefijo { get; set; }
    }
}
