using CrudCuentas.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.Repositories.Interfaces
{
    public interface ITipoCuentaRepository
    {
        public Task<List<TipoCuenta>> GetAll();

        public Task<TipoCuenta> GetById(int id);

        public Task<int> Create(TipoCuenta tipoCuenta);

        public Task<int> Update(TipoCuenta tipoCuenta);

        public Task<int> Delete(int id);
    }
}
