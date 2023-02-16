using AutoMapper;
using CrudCuentas.DAL.DTOs.ClienteDTOs;
using CrudCuentas.DAL.DTOs.CuentaDTOs;
using CrudCuentas.DAL.DTOs.TransaccionDTOs;
using CrudCuentas.DAL.Models;


namespace CrudCuentas.DAL.Utilities
{
    public class AutoMapperProfiles: Profile
    {
       
        public AutoMapperProfiles()
        {
            CreateMap<ClienteCreacionDTO, Cliente>();
            CreateMap<ClienteEdicionDTO, Cliente>();
            CreateMap<Cliente, ClienteDTO>();


            CreateMap<CuentaCreacionDTO, Cuenta>();
            CreateMap<CuentaEdicionDTO, Cuenta>();
            CreateMap<Cuenta, CuentaDTO>();


            CreateMap<TransaccionCreacionDTO, Transaccion>();
            CreateMap<TransaccionCreacionTransferenciaDTO, Transaccion>();
            //CreateMap<TransaccionEdicionDTO, Transaccion>();
            CreateMap<Transaccion, TransaccionDTO>();



        }
       
    }
}
