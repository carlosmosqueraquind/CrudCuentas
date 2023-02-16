using CrudCuentas.DAL.DTOs.ClienteDTOs;
using CrudCuentas.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.BLL.Interfaces
{
    public interface IClienteService
    {
        public Task<List<Cliente>> GetAll();

        public Task<Cliente> GetById(int id);

        public Task<ClienteDTO> Create(ClienteCreacionDTO cliente);

        public Task<ClienteDTO> Update(ClienteEdicionDTO cliente);

        public Task<int> Delete(int id);
    }
}
