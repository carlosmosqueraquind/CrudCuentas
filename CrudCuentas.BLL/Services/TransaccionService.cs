using AutoMapper;
using CrudCuentas.BLL.Interfaces;
using CrudCuentas.DAL.DTOs.TransaccionDTOs;
using CrudCuentas.DAL.Models;
using CrudCuentas.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.BLL.Services
{
    public class TransaccionService: ITransaccionService
    {
        private readonly ITransaccionRepository transaccionRepository;
        private readonly ITipoTransaccionRepository tipoTransaccionRepository;
        private readonly ICuentaRepository cuentaRepository;
        private readonly IMapper mapper;
        public TransaccionService(ITransaccionRepository transaccionRepository, IMapper mapper, ITipoTransaccionRepository tipoTransaccionRepository, ICuentaRepository cuentaRepository)
        {
            this.transaccionRepository = transaccionRepository;
            this.mapper = mapper;
            this.tipoTransaccionRepository = tipoTransaccionRepository;
            this.cuentaRepository = cuentaRepository;


        }

        public async Task<List<Transaccion>> GetAll()
        {

            var transaccions = await transaccionRepository.GetAll();

            return transaccions;
        }

        public async Task<Transaccion> GetById(int id)
        {
            var transaccion = await transaccionRepository.GetById(id);

            return transaccion;
        }

        //public async Task<TransaccionDTO> Create(TransaccionCreacionDTO transaccionCreacionDTO)
        //{
        //    TransaccionDTO resultTransaccionDTO;
        //    int response;

        //    var tipoTransaccionId = transaccionCreacionDTO.TipoTransaccionId;

        //    var tipoTransaccion = await tipoTransaccionRepository.GetById(tipoTransaccionId);

        //    var cuenta = await cuentaRepository.GetById(transaccionCreacionDTO.CuentaId);

        //    if (tipoTransaccion.Iniciales == "CON")
        //    {
        //        cuenta.Saldo += transaccionCreacionDTO.Monto;

        //    }

        //    if (tipoTransaccion.Iniciales == "RET")
        //    {
        //        cuenta.Saldo -= transaccionCreacionDTO.Monto;

        //    }


        //    try
        //    {

        //        Transaccion transaccion = mapper.Map<Transaccion>(transaccionCreacionDTO);

        //        transaccion.FechaTransaccion = DateTime.Now;


        //        response = await transaccionRepository.Create(transaccion);

        //        resultTransaccionDTO = mapper.Map<TransaccionDTO>(transaccion);
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(string.Concat("Create(TransaccionCreacionDTO transaccionCreacionDTO) Exception: ", exception.Message));

        //    }


        //    return resultTransaccionDTO;
        //}

        public async Task<TransaccionDTO> Consignar(TransaccionCreacionDTO transaccionCreacionDTO)
        {
            TransaccionDTO resultTransaccionDTO;
            int response;

            

            var tipoTransaccion = await tipoTransaccionRepository.GetByCode("CON");
            var tipoTransaccionId = tipoTransaccion.Id;

            var cuenta = await cuentaRepository.GetById(transaccionCreacionDTO.CuentaId);

            cuenta.Saldo += transaccionCreacionDTO.Monto;

            try
            {

                Transaccion transaccion = mapper.Map<Transaccion>(transaccionCreacionDTO);

                transaccion.FechaTransaccion = DateTime.Now;
                transaccion.TipoTransaccionId = tipoTransaccionId;
                transaccion.Descripcion = "Consiganacion";

                response = await transaccionRepository.Create(transaccion);

                resultTransaccionDTO = mapper.Map<TransaccionDTO>(transaccion);
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Create(TransaccionCreacionDTO transaccionCreacionDTO) Exception: ", exception.Message));

            }


            return resultTransaccionDTO;
        }

        public async Task<TransaccionDTO> Retirar(TransaccionCreacionDTO transaccionCreacionDTO)
        {
            TransaccionDTO resultTransaccionDTO;
            int response;

            try
            {
                var tipoTransaccion = await tipoTransaccionRepository.GetByCode("RET");
                var tipoTransaccionId = tipoTransaccion.Id;

                var cuenta = await cuentaRepository.GetById(transaccionCreacionDTO.CuentaId);

                if (await ValidarSaldoRetiro(transaccionCreacionDTO))
                {
                    cuenta.Saldo -= transaccionCreacionDTO.Monto;
                    

                }
                else
                {
                    return null;
                }




                Transaccion transaccion = mapper.Map<Transaccion>(transaccionCreacionDTO);

                transaccion.FechaTransaccion = DateTime.Now;
                transaccion.TipoTransaccionId = tipoTransaccionId;
                transaccion.Descripcion = "Retiro";

                response = await transaccionRepository.Create(transaccion);

                resultTransaccionDTO = mapper.Map<TransaccionDTO>(transaccion);
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Create(TransaccionCreacionDTO transaccionCreacionDTO) Exception: ", exception.Message));

            }


            return resultTransaccionDTO;
        }

        public async Task<TransaccionDTO> Transferir(TransaccionCreacionTransferenciaDTO transaccionCreacionDTO)
        {
            TransaccionDTO resultTransaccionDTO;
            int response;            

            try
            {
                var tipoTransaccion = await tipoTransaccionRepository.GetByCode("TRA");
                var tipoTransaccionId = tipoTransaccion.Id;

                var cuentaOrigen = await cuentaRepository.GetById(transaccionCreacionDTO.CuentaOrigenId);
                var cuentaDestino = await cuentaRepository.GetById(transaccionCreacionDTO.CuentaDestinoId);

                if (await ValidarSaldo(transaccionCreacionDTO))
                {
                    cuentaOrigen.Saldo -= transaccionCreacionDTO.Monto;
                    cuentaDestino.Saldo += transaccionCreacionDTO.Monto;

                }
                else
                {
                    return null;
                }
                

                Transaccion transaccionOrigen = mapper.Map<Transaccion>(transaccionCreacionDTO);
                Transaccion transaccionDestino = mapper.Map<Transaccion>(transaccionCreacionDTO);

                transaccionOrigen.Descripcion = "Debito transferencia";
                transaccionDestino.Descripcion = "Credito transferencia";


                transaccionOrigen.FechaTransaccion = DateTime.Now;
                transaccionOrigen.TipoTransaccionId = tipoTransaccionId;
                transaccionOrigen.CuentaId = transaccionCreacionDTO.CuentaOrigenId;

                transaccionDestino.FechaTransaccion = DateTime.Now;
                transaccionDestino.TipoTransaccionId = tipoTransaccionId;
                transaccionDestino.CuentaId = transaccionCreacionDTO.CuentaDestinoId;

                await transaccionRepository.Create(transaccionOrigen);
                await transaccionRepository.Create(transaccionDestino);

                resultTransaccionDTO = mapper.Map<TransaccionDTO>(transaccionOrigen);
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Create(TransaccionCreacionDTO transaccionCreacionDTO) Exception: ", exception.Message));

            }


            return resultTransaccionDTO;
        }

        public async Task<bool> ValidarSaldo(TransaccionCreacionTransferenciaDTO transaccionCreacionDTO)
        {
            var cuentaOrigen = await cuentaRepository.GetById(transaccionCreacionDTO.CuentaOrigenId);
            var result = false;

            if (cuentaOrigen.Saldo >= transaccionCreacionDTO.Monto)
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> ValidarSaldoRetiro(TransaccionCreacionDTO transaccionCreacionDTO)
        {
            var cuenta = await cuentaRepository.GetById(transaccionCreacionDTO.CuentaId);
            var result = false;

            if (cuenta.Saldo >= transaccionCreacionDTO.Monto)
            {
                result = true;
            }

            return result;
        }


        //public async Task<int> Delete(int id)
        //{
        //    int response;

        //    response = await transaccionRepository.Delete(id);

        //    return response;
        //}

        //public async Task<TransaccionDTO> Update(TransaccionEdicionDTO transaccionEdicionDTO)
        //{
        //    int response;
        //    TransaccionDTO transaccionDTO;
        //    try
        //    {

        //        //Transaccion transaccionActual = await transaccionRepository.GetById(transaccionEdicionDTO.Id);


        //        Transaccion transaccion = mapper.Map<Transaccion>(transaccionEdicionDTO);

        //        response = await transaccionRepository.Update(transaccion);


        //        Transaccion transaccionEdited = await transaccionRepository.GetById(response);

        //        transaccionDTO = mapper.Map<TransaccionDTO>(transaccionEdited);
        //    }
        //    catch (Exception exception)
        //    {

        //        throw new Exception(string.Concat("TransaccionService.Update(TransaccionEdicionDTO transaccionEdicionDTO) Exception: ", exception.Message));
        //    }


        //    return transaccionDTO;
        //}
    }
}
