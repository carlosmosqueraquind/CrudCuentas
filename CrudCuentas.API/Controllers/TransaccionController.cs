using CrudCuentas.BLL.Interfaces;
using CrudCuentas.BLL.Services;
using CrudCuentas.DAL.DTOs.TransaccionDTOs;
using CrudCuentas.DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudCuentas.API.Controllers
{
    [Route("api/transacciones")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        private readonly ITransaccionService _transaccionService;
        private readonly ICuentaService _cuentaService;
        private readonly ITipoTransaccionService _tipoTransaccionService;

        public TransaccionController(ITransaccionService transaccionService, ICuentaService cuentaService, ITipoTransaccionService tipoTransaccionService)
        {
            _transaccionService = transaccionService;
            _cuentaService = cuentaService;
            _tipoTransaccionService = tipoTransaccionService;
        }


        // GET: api/<TransaccionController>
        [HttpGet]
        public async Task<ActionResult<List<Transaccion>>> Get()
        {
            var transaccions = await _transaccionService.GetAll();

            return transaccions;
        }

        // GET api/<TransaccionController>/5
        [HttpGet("{id}", Name = "GetTransaccionById")]
        public async Task<ActionResult<Transaccion>> Get(int id)
        {
            var transaccion = await _transaccionService.GetById(id);
            return transaccion;
        }


        //[HttpPost]
        //public async Task<ActionResult<int>> Post([FromBody] TransaccionCreacionDTO transaccionDTO)
        //{

        //    var existCuenta = await _cuentaService.GetById(transaccionDTO.CuentaOrigenId);

        //    if (existCuenta == null)
        //    {
        //        return NotFound();
        //    }

            

        //    var existCuentaDestino = await _cuentaService.GetById(transaccionDTO.CuentaOrigenId);

        //    if (existCuentaDestino == null)
        //    {
        //        return NotFound();
        //    }



        //    var existeTipoTransaccion = await _tipoTransaccionService.GetById(transaccionDTO.TipoTransaccionId);

        //    if (existeTipoTransaccion == null)
        //    {
        //        return NotFound();
        //    }



        //    var result = await _transaccionService.Create(transaccionDTO);

        //    if (result == null)
        //    {
        //        return BadRequest();
        //    }

        //    //return Ok(result);
        //    return CreatedAtRoute("GetTransaccionById", new { id = result.Id }, result);
        //}



        // POST api/<TransaccionController>
        [HttpPost("consignar")]
        public async Task<ActionResult<int>> Consignar([FromBody] TransaccionCreacionDTO transaccionDTO)
        {

            var existCuenta = await _cuentaService.GetById(transaccionDTO.CuentaId); 

            if (existCuenta == null)
            {
                return NotFound();
            }       

            var result = await _transaccionService.Consignar(transaccionDTO);

            if (result == null)
            {
                return BadRequest();
            }

            //return Ok(result);
            return CreatedAtRoute("GetTransaccionById", new { id = result.Id }, result);
        }

        [HttpPost("retirar")]
        public async Task<ActionResult<int>> Retirar([FromBody] TransaccionCreacionDTO transaccionDTO)
        {

            var existCuenta = await _cuentaService.GetById(transaccionDTO.CuentaId);

            if (existCuenta == null)
            {
                return NotFound();
            }

            

            var result = await _transaccionService.Retirar(transaccionDTO);

            if (result == null)
            {
                return BadRequest();
            }

            //return Ok(result);
            return CreatedAtRoute("GetTransaccionById", new { id = result.Id }, result);
        }

        [HttpPost("transferir")]
        public async Task<ActionResult<int>> Transferir([FromBody] TransaccionCreacionTransferenciaDTO transaccionDTO)
        {

            var existCuentaOrigen = await _cuentaService.GetById(transaccionDTO.CuentaOrigenId);

            if (existCuentaOrigen == null)
            {
                return NotFound();
            }

            var existCuentaDestino = await _cuentaService.GetById(transaccionDTO.CuentaOrigenId);

            if (existCuentaOrigen == null)
            {
                return NotFound();
            }

            var result = await _transaccionService.Transferir(transaccionDTO);

            if (result == null)
            {
                return BadRequest();
            }

            //return Ok(result);
            return CreatedAtRoute("GetTransaccionById", new { id = result.Id }, result);
        }


    }
}
