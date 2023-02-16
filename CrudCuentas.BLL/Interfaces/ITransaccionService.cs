using CrudCuentas.DAL.DTOs.TransaccionDTOs;
using CrudCuentas.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.BLL.Interfaces
{
    public interface ITransaccionService
    {
        public Task<List<Transaccion>> GetAll();

        public Task<Transaccion> GetById(int id);

        //public Task<TransaccionDTO> Create(TransaccionCreacionDTO cliente);

        public Task<TransaccionDTO> Consignar(TransaccionCreacionDTO transaccionCreacionDTO);

        public Task<TransaccionDTO> Retirar(TransaccionCreacionDTO transaccionCreacionDTO);

        public Task<TransaccionDTO> Transferir(TransaccionCreacionTransferenciaDTO transaccionCreacionDTO);

        //public Task<TransaccionDTO> Update(TransaccionEdicionDTO cliente);

        //public Task<int> Delete(int id);
    }
}
