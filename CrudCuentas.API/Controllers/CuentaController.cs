using CrudCuentas.BLL.Interfaces;
using CrudCuentas.DAL.DTOs.CuentaDTOs;
using CrudCuentas.DAL.Models;
using CrudTipoCuentas.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudCuentas.API.Controllers
{
    [Route("api/cuentas")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;
        private readonly IEstadoCuentaService _estadoCuentaService;

        public CuentaController(ICuentaService cuentaService, IEstadoCuentaService estadoCuentaService)
        {
            _cuentaService = cuentaService;
            _estadoCuentaService = estadoCuentaService;
        }


        // GET: api/<CuentaController>
        [HttpGet]
        public async Task<ActionResult<List<Cuenta>>> Get()
        {
            var cuentas = await _cuentaService.GetAll();

            return cuentas;
        }

        // GET api/<CuentaController>/5
        [HttpGet("{id}", Name = "GetCuentaById")]
        public async Task<ActionResult<Cuenta>> Get(int id)
        {
            var cuenta = await _cuentaService.GetById(id);
            return cuenta;
        }

        // POST api/<CuentaController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CuentaCreacionDTO cuentaDTO)
        {
            var result = await _cuentaService.Create(cuentaDTO);

            if (result == null)
            {
                return BadRequest();
            }

            //return Ok(result);
            return CreatedAtRoute("GetCuentaById", new { id = result.Id }, result);
        }

        // PUT api/<CuentaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CuentaDTO>> Put(int id, [FromBody] CuentaEdicionDTO cuentaEdicion)
        {
            if (id != cuentaEdicion.Id)
            {

                return BadRequest("Id de Cuenta no coincide con Id en URL");
            }
            var existe = await _cuentaService.GetById(id);

            if (existe == null)
            {
                return NotFound();
            }

            var result = await _cuentaService.Update(cuentaEdicion);


            //return Ok();
            return CreatedAtRoute("GetCuentaById", new { id = result.Id }, result);
        }

        // DELETE api/<CuentaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var existe = await _cuentaService.GetById(id);

            if (existe == null)
            {
                return NotFound();
            }

            await _cuentaService.Delete(id);

            return Ok();

        }

        [HttpPut("actualizar-estado/{id:int}")]
        public async Task<ActionResult<CuentaDTO>> ActualizarEstadoCuenta(int id, [FromBody] CuentaActualizacionEstadoDTO cuentaEdicion)
        {
            var existeTipoEstadoCuenta = await _estadoCuentaService.GetById(cuentaEdicion.EstadoCuentaId);

            if (id == cuentaEdicion.Id)
            {

                return BadRequest("Id de Cuenta no coincide con Id en URL");
            }

            if (existeTipoEstadoCuenta == null)
            {
                return BadRequest("Id de Estado Cuenta no encontrado");
            }
            
            
            var cuentaActual = await _cuentaService.GetById(id);

            if (cuentaActual == null)
            {
                return NotFound();
            }

            var result = await _cuentaService.ActualizaEstado(id, cuentaEdicion.EstadoCuentaId);

            if (result == null)
            {
                return BadRequest("No se pudo actualizar");
            }

            //return Ok();
            return CreatedAtRoute("GetCuentaById", new { id = result.Id }, result);
        }

    }
}
