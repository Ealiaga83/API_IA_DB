using API_IA_DB.Data;
using API_IA_DB.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_IA_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TotalesFacturaController : ControllerBase
    {
        private readonly TotalesFactura_SP_DATA totalesData = new TotalesFactura_SP_DATA();

        [HttpPost("inst")]
        public IActionResult Insertar([FromBody] TotalesFactura_SP totales)
        {
            totalesData.GestionTotalesFactura("inst", totales);
            return Ok("Totales de factura insertados");
        }

        [HttpPut("upd/{id}")]
        public IActionResult Actualizar(int id, [FromBody] TotalesFactura_SP totales)
        {
            totales.Id = id;
            totalesData.GestionTotalesFactura("upd", totales);
            return Ok("Totales de factura actualizados");
        }

        [HttpDelete("del/{id}")]
        public IActionResult Eliminar(int id)
        {
            var totales = new TotalesFactura_SP { Id = id };
            totalesData.GestionTotalesFactura("del", totales);
            return Ok("Totales de factura eliminados");
        }
    }
}