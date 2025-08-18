using API_IA_DB.Data;
using API_IA_DB.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_IA_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly Factura_SP_DATA facturaData = new Factura_SP_DATA();

        [HttpPost("inst")]
        public IActionResult Insertar([FromBody] Factura_SP factura)
        {
            facturaData.GestionFactura("inst", factura);
            return Ok("Factura insertada");
        }

        [HttpPut("upd/{id}")]
        public IActionResult Actualizar(int id, [FromBody] Factura_SP factura)
        {
            factura.Id = id;
            facturaData.GestionFactura("upd", factura);
            return Ok("Factura actualizada");
        }

        [HttpDelete("del/{id}")]
        public IActionResult Eliminar(int id)
        {
            var factura = new Factura_SP { Id = id };
            facturaData.GestionFactura("del", factura);
            return Ok("Factura eliminada");
        }

        // Si tienes un método para obtener por ID, agrégalo aquí
        // [HttpGet("{id}")]
        // public ActionResult<Factura_SP> Get(int id)
        // {
        //     var factura = facturaData.ObtenerPorId(id);
        //     return factura != null ? Ok(factura) : NotFound("Factura no encontrada");
        // }
    }
}