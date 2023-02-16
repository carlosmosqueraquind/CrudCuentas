using CrudCuentas.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.Repositories.Interfaces
{
    public interface ITransaccionRepository
    {
        public Task<List<Transaccion>> GetAll();

        public Task<Transaccion> GetById(int id);

        public Task<int> Create(Transaccion transaccion);

        //public Task<int> Update(Transaccion transaccion);

        //public Task<int> Delete(int id);
    }
}
