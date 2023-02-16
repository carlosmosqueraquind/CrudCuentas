using CrudCuentas.DAL.Models;


namespace CrudCuentas.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        public Task<List<Cliente>> GetAll();

        public Task<Cliente> GetById(int id);

        public Task<int> Create(Cliente cliente);

        public Task<int> Update(Cliente cliente);

        public Task<int> Delete(int id);
    }
}
