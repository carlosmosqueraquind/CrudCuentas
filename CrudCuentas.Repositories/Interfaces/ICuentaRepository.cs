using CrudCuentas.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.Repositories.Interfaces
{
    public interface ICuentaRepository
    {
        public Task<List<Cuenta>> GetAll();

        public Task<Cuenta> GetById(int id);

        public Task<int> Create(Cuenta cuenta);

        public Task<int> Update(Cuenta cuenta);

        public Task<int> Delete(int id);

        public Task<int> ObtenerUltimoId();

        public Task<int> UpdateState(int id, int stateId);
    }
}
