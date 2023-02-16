using AutoMapper;
using CrudCuentas.BLL.Interfaces;
using CrudCuentas.DAL.DTOs.ClienteDTOs;
using CrudCuentas.DAL.Models;
using CrudCuentas.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.BLL.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;


        }

        public async Task<List<Cliente>> GetAll()
        {

            var clientes = await clienteRepository.GetAll();

            return clientes;
        }

        public async Task<Cliente> GetById(int id)
        {
            var cliente = await clienteRepository.GetById(id);

            return cliente;
        }

        public async Task<ClienteDTO> Create(ClienteCreacionDTO clienteCreacionDTO)
        {
            ClienteDTO resultClienteDTO;
            int response;
            try
            {
                

                Cliente cliente = mapper.Map<Cliente>(clienteCreacionDTO);

                cliente.FechaCreacion = DateTime.Now;
                cliente.FechaModificacion = DateTime.Now;

                response = await clienteRepository.Create(cliente);

                resultClienteDTO = mapper.Map<ClienteDTO>(cliente);
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Create(ClienteCreacionDTO clienteCreacionDTO) Exception: ", exception.Message));
                
            }


            return resultClienteDTO;
        }

        public async Task<int> Delete(int id)
        {
            int response;

            response = await clienteRepository.Delete(id);

            return response;
        }

        public async Task<ClienteDTO> Update(ClienteEdicionDTO clienteEdicionDTO)
        {
            int response;
            ClienteDTO clienteDTO;
            try
            {
                
                //Cliente clienteActual = await clienteRepository.GetById(clienteEdicionDTO.Id);

               
                Cliente cliente = mapper.Map<Cliente>(clienteEdicionDTO);
                                               
                response = await clienteRepository.Update(cliente);
                
                
                Cliente clienteEdited = await clienteRepository.GetById(response);

                clienteDTO = mapper.Map<ClienteDTO>(clienteEdited);
            }
            catch (Exception exception)
            {

                throw new Exception(string.Concat("ClienteService.Update(ClienteEdicionDTO clienteEdicionDTO) Exception: ", exception.Message));
            }
            

            return clienteDTO;
        }
    }
}
