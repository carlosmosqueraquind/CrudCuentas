using CrudCuentas.DAL.DTOs.EstadoCuentaDTOs;
using CrudCuentas.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.BLL.Interfaces
{
    public interface IEstadoCuentaService
    {
        public Task<List<EstadoCuenta>> GetAll();

        public Task<EstadoCuenta> GetById(int id);

        public Task<EstadoCuentaDTO> Create(EstadoCuentaCreacionDTO estado);

        public Task<EstadoCuentaDTO> Update(EstadoCuentaEdicionDTO estado);

        public Task<int> Delete(int id);
    }
}
