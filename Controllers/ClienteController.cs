using API_IA_DB.Data;
using API_IA_DB.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_IA_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Cliente_SP_DATA clienteData = new Cliente_SP_DATA();

        [HttpPost("inst")]
        public IActionResult Insertar([FromBody] Cliente_SP cliente)
        {
            clienteData.GestionCliente("inst", cliente);
            return Ok("Cliente insertado");
        }

        [HttpPut("upd/{id}")]
        public IActionResult Actualizar(int id, [FromBody] Cliente_SP cliente)
        {
            cliente.Id = id;
            clienteData.GestionCliente("upd", cliente);
            return Ok("Cliente actualizado");
        }

        [HttpDelete("del/{id}")]
        public IActionResult Eliminar(int id)
        {
            var cliente = new Cliente_SP { Id = id };
            clienteData.GestionCliente("del", cliente);
            return Ok("Cliente eliminado");
        }     
    }
}