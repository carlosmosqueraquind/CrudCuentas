using CrudCuentas.DAL.DTOs.TipoCuentaDTOs;
using CrudCuentas.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTipoCuentas.BLL.Interfaces
{
    public interface ITipoCuentaService
    {
        public Task<List<TipoCuenta>> GetAll();

        public Task<TipoCuenta> GetById(int id);

        public Task<TipoCuentaDTO> Create(TipoCuentaCreacionDTO cuenta);

        public Task<TipoCuentaDTO> Update(TipoCuentaEdicionDTO cuenta);

        public Task<int> Delete(int id);

        public Task<TipoCuentaDTO> UpdateState(TipoCuentaEdicionDTO cuentaEdicionDTO);
    }
}
