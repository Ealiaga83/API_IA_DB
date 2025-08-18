using API_IA_DB.Data;
using API_IA_DB.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_IA_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagoController : ControllerBase
    {
        private readonly FormaPago_SP_DATA formaPagoData = new FormaPago_SP_DATA();

        [HttpPost("inst")]
        public IActionResult Insertar([FromBody] FormaPago_SP formaPago)
        {
            formaPagoData.GestionFormaPago("inst", formaPago);
            return Ok("Forma de pago insertada");
        }

        [HttpPut("upd/{id}")]
        public IActionResult Actualizar(int id, [FromBody] FormaPago_SP formaPago)
        {
            formaPago.Id = id;
            formaPagoData.GestionFormaPago("upd", formaPago);
            return Ok("Forma de pago actualizada");
        }

        [HttpDelete("del/{id}")]
        public IActionResult Eliminar(int id)
        {
            var formaPago = new FormaPago_SP { Id = id };
            formaPagoData.GestionFormaPago("del", formaPago);
            return Ok("Forma de pago eliminada");
        }
    }
}