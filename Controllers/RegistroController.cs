using API_IA_DB.Data;
using API_IA_DB.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_IA_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly RegistrarFactura_SP_DATA facturaData = new RegistrarFactura_SP_DATA();

        [HttpPost("insertar")]
        public IActionResult InsertarFactura([FromBody] RegistrarFactura factura)
        {
            try
            {
                facturaData.InsertarFactura(factura);
                return Ok("Factura insertada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al insertar factura: {ex.Message}");
            }
        }
    }
}
