using API_IA_DB.Data;
using API_IA_DB.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_IA_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly Empresa_SP_DATA empresaData = new Empresa_SP_DATA();

        [HttpPost("inst")]
        public IActionResult Insertar([FromBody] Empresa_SP empresa)
        {
            empresaData.GestionEmpresa("inst", empresa);
            return Ok("Empresa insertada");
        }

        [HttpPut("upd/{id}")]
        public IActionResult Actualizar(int id, [FromBody] Empresa_SP empresa)
        {
            empresa.Id = id;
            empresaData.GestionEmpresa("upd", empresa);
            return Ok("Empresa actualizada");
        }

        [HttpDelete("del/{id}")]
        public IActionResult Eliminar(int id)
        {
            var empresa = new Empresa_SP { Id = id };
            empresaData.GestionEmpresa("del", empresa);
            return Ok("Empresa eliminada");
        }
    }

}
