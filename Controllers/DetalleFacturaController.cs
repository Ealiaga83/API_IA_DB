using API_IA_DB.Data;
using API_IA_DB.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_IA_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleFacturaController : ControllerBase
    {
        private readonly DetalleFactura_SP_DATA detalleData = new DetalleFactura_SP_DATA();

        [HttpPost("inst")]
        public IActionResult Insertar([FromBody] DetalleFactura_SP detalle)
        {
            detalleData.GestionDetalleFactura("inst", detalle);
            return Ok("Detalle de factura insertado");
        }

        [HttpPut("upd/{id}")]
        public IActionResult Actualizar(int id, [FromBody] DetalleFactura_SP detalle)
        {
            detalle.Id = id;
            detalleData.GestionDetalleFactura("upd", detalle);
            return Ok("Detalle de factura actualizado");
        }

        [HttpDelete("del/{id}")]
        public IActionResult Eliminar(int id)
        {
            var detalle = new DetalleFactura_SP { Id = id };
            detalleData.GestionDetalleFactura("del", detalle);
            return Ok("Detalle de factura eliminado");
        }

        // Si tienes un método para obtener por ID, agrégalo aquí
        // [HttpGet("{id}")]
        // public ActionResult<DetalleFactura_SP> Get(int id)
        // {
        //     var detalle = detalleData.ObtenerPorId(id);
        //     return detalle != null ? Ok(detalle) : NotFound("Detalle no encontrado");
        // }
    }
}