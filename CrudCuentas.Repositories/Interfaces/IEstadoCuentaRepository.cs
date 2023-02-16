using CrudCuentas.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.Repositories.Interfaces
{
    public interface IEstadoCuentaRepository
    {
        public Task<List<EstadoCuenta>> GetAll();

        public Task<EstadoCuenta> GetById(int id);

        public Task<int> Create(EstadoCuenta estadoCuenta);

        public Task<int> Update(EstadoCuenta estadoCuenta);

        public Task<int> Delete(int id);
    }
}
