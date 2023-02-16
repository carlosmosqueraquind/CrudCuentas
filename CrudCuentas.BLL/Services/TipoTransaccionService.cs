using AutoMapper;
using CrudCuentas.BLL.Interfaces;
using CrudCuentas.DAL.DTOs.TipoTransaccionDTOs;
using CrudCuentas.DAL.Models;
using CrudCuentas.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.BLL.Services
{
    public class TipoTransaccionService: ITipoTransaccionService
    {
        private readonly ITipoTransaccionRepository tipoTransaccionRepository;
        private readonly IMapper mapper;
        public TipoTransaccionService(ITipoTransaccionRepository tipoTransaccionRepository, IMapper mapper)
        {
            this.tipoTransaccionRepository = tipoTransaccionRepository;
            this.mapper = mapper;


        }

        public async Task<List<TipoTransaccion>> GetAll()
        {

            var tipoTransaccions = await tipoTransaccionRepository.GetAll();

            return tipoTransaccions;
        }

        public async Task<TipoTransaccion> GetById(int id)
        {
            var tipoTransaccion = await tipoTransaccionRepository.GetById(id);

            return tipoTransaccion;
        }

        public async Task<TipoTransaccionDTO> Create(TipoTransaccionCreacionDTO tipoTransaccionCreacionDTO)
        {
            TipoTransaccionDTO resultTipoTransaccionDTO;
            int response;
            try
            {


                TipoTransaccion tipoTransaccion = mapper.Map<TipoTransaccion>(tipoTransaccionCreacionDTO);

                

                response = await tipoTransaccionRepository.Create(tipoTransaccion);

                resultTipoTransaccionDTO = mapper.Map<TipoTransaccionDTO>(tipoTransaccion);
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Create(TipoTransaccionCreacionDTO tipoTransaccionCreacionDTO) Exception: ", exception.Message));

            }


            return resultTipoTransaccionDTO;
        }

        public async Task<int> Delete(int id)
        {
            int response;

            response = await tipoTransaccionRepository.Delete(id);

            return response;
        }

        public async Task<TipoTransaccionDTO> Update(TipoTransaccionEdicionDTO tipoTransaccionEdicionDTO)
        {
            int response;
            TipoTransaccionDTO tipoTransaccionDTO;
            try
            {

                //TipoTransaccion tipoTransaccionActual = await tipoTransaccionRepository.GetById(tipoTransaccionEdicionDTO.Id);


                TipoTransaccion tipoTransaccion = mapper.Map<TipoTransaccion>(tipoTransaccionEdicionDTO);

                response = await tipoTransaccionRepository.Update(tipoTransaccion);


                TipoTransaccion tipoTransaccionEdited = await tipoTransaccionRepository.GetById(response);

                tipoTransaccionDTO = mapper.Map<TipoTransaccionDTO>(tipoTransaccionEdited);
            }
            catch (Exception exception)
            {

                throw new Exception(string.Concat("TipoTransaccionService.Update(TipoTransaccionEdicionDTO tipoTransaccionEdicionDTO) Exception: ", exception.Message));
            }


            return tipoTransaccionDTO;
        }
    }
}
