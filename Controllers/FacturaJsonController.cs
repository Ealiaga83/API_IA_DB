using API_IA_DB.Data;
using API_IA_DB.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_IA_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaJsonController : ControllerBase
    {
        private readonly FacturaJson_SP_DATA facturaJsonData = new FacturaJson_SP_DATA();

        [HttpPost("inst")]
        public IActionResult Insertar([FromBody] FacturaJson_SP facturaJson)
        {
            facturaJsonData.GestionFacturaJson("inst", facturaJson);
            return Ok("Factura JSON insertada");
        }

        [HttpPut("upd/{id}")]
        public IActionResult Actualizar(int id, [FromBody] FacturaJson_SP facturaJson)
        {
            facturaJson.Id = id;
            facturaJsonData.GestionFacturaJson("upd", facturaJson);
            return Ok("Factura JSON actualizada");
        }

        [HttpDelete("del/{id}")]
        public IActionResult Eliminar(int id)
        {
            var facturaJson = new FacturaJson_SP { Id = id };
            facturaJsonData.GestionFacturaJson("del", facturaJson);
            return Ok("Factura JSON eliminada");
        }
    }
}