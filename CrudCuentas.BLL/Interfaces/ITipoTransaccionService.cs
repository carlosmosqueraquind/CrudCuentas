using CrudCuentas.DAL.DTOs.TipoTransaccionDTOs;
using CrudCuentas.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.BLL.Interfaces
{
    public interface ITipoTransaccionService
    {
        public Task<List<TipoTransaccion>> GetAll();

        public Task<TipoTransaccion> GetById(int id);

        public Task<TipoTransaccionDTO> Create(TipoTransaccionCreacionDTO tipoTransaccion);

        public Task<TipoTransaccionDTO> Update(TipoTransaccionEdicionDTO tipoTransaccion);

        public Task<int> Delete(int id);
    }
}
