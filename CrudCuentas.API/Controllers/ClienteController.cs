using CrudCuentas.BLL.Interfaces;
using CrudCuentas.DAL.DTOs.ClienteDTOs;
using CrudCuentas.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudCuentas.API.Controllers
{

    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            var clientes = await _clienteService.GetAll();

            return clientes;
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}", Name ="GetClienteById")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await _clienteService.GetById(id);
            return cliente;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ClienteCreacionDTO clienteDTO)
        {
            var result = await _clienteService.Create(clienteDTO);

            if (result == null)
            {
                return BadRequest();
            }

            //return Ok(result);
            return CreatedAtRoute("GetClienteById", new { id = result.Id }, result);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDTO>> Put(int id, [FromBody] ClienteEdicionDTO clienteEdicion)
        {
            if (id != clienteEdicion.Id)
            {

                return BadRequest("Id de Cliente no coincide con Id en URL");
            }
            var existe = await _clienteService.GetById(id);

            if (existe == null)
            {
                return NotFound();
            }

            var result = await _clienteService.Update(clienteEdicion);


            //return Ok();
            return CreatedAtRoute("GetClienteById", new { id = result.Id }, result);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var existe = await _clienteService.GetById(id);

            if (existe == null)
            {
                return NotFound();
            }

            await _clienteService.Delete(id);

            return Ok();

        }
    }
}
