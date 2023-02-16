using AutoMapper;
using CrudCuentas.DAL.DTOs.EstadoCuentaDTOs;
using CrudCuentas.DAL.DTOs.TipoCuentaDTOs;
using CrudCuentas.DAL.Models;
using CrudCuentas.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.BLL.Services
{
    public class TipoCuentaService
    {
        private readonly ITipoCuentaRepository tipoCuentaRepository;
        private readonly IMapper mapper;
        public TipoCuentaService(ITipoCuentaRepository tipoCuentaRepository, IMapper mapper)
        {
            this.tipoCuentaRepository = tipoCuentaRepository;
            this.mapper = mapper;


        }

        public async Task<List<TipoCuenta>> GetAll()
        {

            var tipoCuentas = await tipoCuentaRepository.GetAll();

            return tipoCuentas;
        }

        public async Task<TipoCuenta> GetById(int id)
        {
            var tipoCuenta = await tipoCuentaRepository.GetById(id);

            return tipoCuenta;
        }

        public async Task<EstadoCuentaDTO> Create(TipoCuentaCreacionDTO tipoCuentaCreacionDTO)
        {
            EstadoCuentaDTO resultTipoCuentaDTO;
            int response;
            try
            {


                TipoCuenta tipoCuenta = mapper.Map<TipoCuenta>(tipoCuentaCreacionDTO);

                
                response = await tipoCuentaRepository.Create(tipoCuenta);

                resultTipoCuentaDTO = mapper.Map<EstadoCuentaDTO>(tipoCuenta);
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Create(TipoCuentaCreacionDTO tipoCuentaCreacionDTO) Exception: ", exception.Message));

            }


            return resultTipoCuentaDTO;
        }

        public async Task<int> Delete(int id)
        {
            int response;

            response = await tipoCuentaRepository.Delete(id);

            return response;
        }

        public async Task<EstadoCuentaDTO> Update(TipoCuentaEdicionDTO tipoCuentaEdicionDTO)
        {
            int response;
            EstadoCuentaDTO tipoCuentaDTO;
            try
            {

                //TipoCuenta tipoCuentaActual = await tipoCuentaRepository.GetById(tipoCuentaEdicionDTO.Id);


                TipoCuenta tipoCuenta = mapper.Map<TipoCuenta>(tipoCuentaEdicionDTO);

                response = await tipoCuentaRepository.Update(tipoCuenta);


                TipoCuenta tipoCuentaEdited = await tipoCuentaRepository.GetById(response);

                tipoCuentaDTO = mapper.Map<EstadoCuentaDTO>(tipoCuentaEdited);
            }
            catch (Exception exception)
            {

                throw new Exception(string.Concat("TipoCuentaService.Update(TipoCuentaEdicionDTO tipoCuentaEdicionDTO) Exception: ", exception.Message));
            }


            return tipoCuentaDTO;
        }
    }
}
