using CrudCuentas.DAL.DTOs.CuentaDTOs;
using CrudCuentas.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.BLL.Interfaces
{
    public interface ICuentaService
    {
        public Task<List<Cuenta>> GetAll();

        public Task<Cuenta> GetById(int id);

        public Task<CuentaDTO> Create(CuentaCreacionDTO cliente);

        public Task<CuentaDTO> Update(CuentaEdicionDTO cliente);

        public Task<int> Delete(int id);

        public Task<CuentaDTO> ActualizaEstado(int id, int stateId);
    }
}
