using AutoMapper;
using CrudCuentas.BLL.Interfaces;
using CrudCuentas.DAL.DTOs.EstadoCuentaDTOs;
using CrudCuentas.DAL.Models;
using CrudCuentas.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.BLL.Services
{
    public class EstadoCuentaService: IEstadoCuentaService
    {
        private readonly IEstadoCuentaRepository estadoCuentaRepository;
        private readonly IMapper mapper;
        public EstadoCuentaService(IEstadoCuentaRepository estadoCuentaRepository, IMapper mapper)
        {
            this.estadoCuentaRepository = estadoCuentaRepository;
            this.mapper = mapper;


        }

        public async Task<List<EstadoCuenta>> GetAll()
        {

            var estadoCuentas = await estadoCuentaRepository.GetAll();

            return estadoCuentas;
        }

        public async Task<EstadoCuenta> GetById(int id)
        {
            var estadoCuenta = await estadoCuentaRepository.GetById(id);

            return estadoCuenta;
        }

        public async Task<EstadoCuentaDTO> Create(EstadoCuentaCreacionDTO estadoCuentaCreacionDTO)
        {
            EstadoCuentaDTO resultEstadoCuentaDTO;
            int response;
            try
            {


                EstadoCuenta estadoCuenta = mapper.Map<EstadoCuenta>(estadoCuentaCreacionDTO);

               

                response = await estadoCuentaRepository.Create(estadoCuenta);

                resultEstadoCuentaDTO = mapper.Map<EstadoCuentaDTO>(estadoCuenta);
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Create(EstadoCuentaCreacionDTO estadoCuentaCreacionDTO) Exception: ", exception.Message));

            }


            return resultEstadoCuentaDTO;
        }

        public async Task<int> Delete(int id)
        {
            int response;

            response = await estadoCuentaRepository.Delete(id);

            return response;
        }

        public async Task<EstadoCuentaDTO> Update(EstadoCuentaEdicionDTO estadoCuentaEdicionDTO)
        {
            int response;
            EstadoCuentaDTO estadoCuentaDTO;
            try
            {

                //EstadoCuenta estadoCuentaActual = await estadoCuentaRepository.GetById(estadoCuentaEdicionDTO.Id);


                EstadoCuenta estadoCuenta = mapper.Map<EstadoCuenta>(estadoCuentaEdicionDTO);

                response = await estadoCuentaRepository.Update(estadoCuenta);


                EstadoCuenta estadoCuentaEdited = await estadoCuentaRepository.GetById(response);

                estadoCuentaDTO = mapper.Map<EstadoCuentaDTO>(estadoCuentaEdited);
            }
            catch (Exception exception)
            {

                throw new Exception(string.Concat("EstadoCuentaService.Update(EstadoCuentaEdicionDTO estadoCuentaEdicionDTO) Exception: ", exception.Message));
            }


            return estadoCuentaDTO;
        }
    }
}
