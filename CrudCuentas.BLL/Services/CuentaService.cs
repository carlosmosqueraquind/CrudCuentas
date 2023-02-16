using AutoMapper;
using CrudCuentas.BLL.Interfaces;
using CrudCuentas.DAL.DTOs.CuentaDTOs;
using CrudCuentas.DAL.Models;
using CrudCuentas.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.BLL.Services
{
    public class CuentaService: ICuentaService
    {
        private readonly ICuentaRepository cuentaRepository;
        private readonly ITipoCuentaRepository tipoCuentaRepository;
        private readonly IEstadoCuentaRepository estadoCuentaRepository;
        private readonly IMapper mapper;
        public CuentaService(ICuentaRepository cuentaRepository, ITipoCuentaRepository tipoCuentaRepository, IEstadoCuentaRepository estadoCuentaRepository, IMapper mapper)
        {
            this.cuentaRepository = cuentaRepository;
            this.tipoCuentaRepository = tipoCuentaRepository;
            this.estadoCuentaRepository = estadoCuentaRepository;
            this.mapper = mapper;

        }

        public async Task<List<Cuenta>> GetAll()
        {

            var cuentas = await cuentaRepository.GetAll();

            return cuentas;
        }

        public async Task<Cuenta> GetById(int id)
        {
            var cuenta = await cuentaRepository.GetById(id);

            return cuenta;
        }

        public async Task<CuentaDTO> Create(CuentaCreacionDTO cuentaCreacionDTO)
        {
            CuentaDTO resultCuentaDTO;
            int response;
            try
            {

                Cuenta cuenta = mapper.Map<Cuenta>(cuentaCreacionDTO);

                var index = await cuentaRepository.ObtenerUltimoId();
                var tipoCuenta = await tipoCuentaRepository.GetById(cuentaCreacionDTO.TipoCuentaId);

                var accountNumber = CrearNumeroCuenta(index , tipoCuenta.Prefijo);

                cuenta.FechaCreacion = DateTime.Now;
                cuenta.FechaModificacion = DateTime.Now;
                cuenta.EstadoCuentaId = 1;
                cuenta.NumeroCuenta = accountNumber;
                //cuenta.ExentaGMF = cuentaCreacionDTO.ExentaGMF;

                response = await cuentaRepository.Create(cuenta);

                resultCuentaDTO = mapper.Map<CuentaDTO>(cuenta);
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Create(CuentaCreacionDTO cuentaCreacionDTO) Exception: ", exception.Message));

            }


            return resultCuentaDTO;
        }

        public async Task<int> Delete(int id)
        {
            int response;

            response = await cuentaRepository.Delete(id);

            return response;
        }

        public async Task<CuentaDTO> Update(CuentaEdicionDTO cuentaEdicionDTO)
        {
            int response;
            CuentaDTO cuentaDTO;
            try
            {

                //Cuenta cuentaActual = await cuentaRepository.GetById(cuentaEdicionDTO.Id);


                Cuenta cuenta = mapper.Map<Cuenta>(cuentaEdicionDTO);

                response = await cuentaRepository.Update(cuenta);


                Cuenta cuentaEditada = await cuentaRepository.GetById(response);

                cuentaDTO = mapper.Map<CuentaDTO>(cuentaEditada);
            }
            catch (Exception exception)
            {

                throw new Exception(string.Concat("CuentaService.Update(CuentaEdicionDTO cuentaEdicionDTO) Exception: ", exception.Message));
            }


            return cuentaDTO;
        }

        public async Task<CuentaDTO> ActualizaEstado(int id, int estadoId)
        {
            int response;
            CuentaDTO cuentaDTO;
            
            try
            {
                var estado = await estadoCuentaRepository.GetById(estadoId);

                if(estado.Iniciales == "C")
                {
                    var cuenta = await cuentaRepository.GetById(id);

                    if(cuenta.Saldo != 0)
                    {
                        return null;
                    }
                }

                //Cuenta cuentaActual = await cuentaRepository.GetById(cuentaEdicionDTO.Id);


                //Cuenta cuenta = mapper.Map<Cuenta>(cuentaEdicionDTO);

                response = await cuentaRepository.UpdateState(id, estadoId);


                Cuenta cuentaEditada = await cuentaRepository.GetById(response);

                cuentaDTO = mapper.Map<CuentaDTO>(cuentaEditada);
            }
            catch (Exception exception)
            {

                throw new Exception(string.Concat("CuentaService.Update(CuentaEdicionDTO cuentaEdicionDTO) Exception: ", exception.Message));
            }


            return cuentaDTO;
        }

       

        public string CrearNumeroCuenta(int index, string prefijoTipoCuenta)
        {
            string numeroCuenta = "";

            var prefijoANumero = Convert.ToInt64(prefijoTipoCuenta) * 1000000000 + index + 1;
            
            numeroCuenta =  prefijoANumero.ToString();

            return numeroCuenta;
        }
    }
}
