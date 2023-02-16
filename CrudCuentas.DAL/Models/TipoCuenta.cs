using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.DAL.Models
{
    public class TipoCuenta
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Iniciales { get; set;}

        public string Prefijo { get; set;}

    }
}
