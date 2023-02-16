using CrudCuentas.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.Repositories.Interfaces
{
    public interface ITipoTransaccionRepository
    {
        public Task<List<TipoTransaccion>> GetAll();

        public Task<TipoTransaccion> GetById(int id);

        public Task<int> Create(TipoTransaccion tipoTransaccion);

        public Task<int> Update(TipoTransaccion tipoTransaccion);

        public Task<int> Delete(int id);

        public Task<TipoTransaccion> GetByCode(string code);
    }
}
