using API_IA_DB.Data;
using API_IA_DB.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_IA_DB.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FuncionController : ControllerBase
    {
        private readonly FuncionGenerica_DATA _funcionGenericaData;
        private readonly ILogger<FuncionController> _logger;

        public FuncionController(FuncionGenerica_DATA funcionGenericaData, ILogger<FuncionController> logger)
        {
            _funcionGenericaData = funcionGenericaData;
            _logger = logger;
        }

        [HttpPost("ejecutar-funcion")]
        public async Task<IActionResult> EjecutarFuncion([FromBody] FuncionRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _logger.LogInformation("Ejecutando función: {Funcion} con parámetros: {Parametros}",
                    request.NombreFuncion, string.Join(", ", request.Parametros));

                var resultado = await _funcionGenericaData.EjecutarFuncionAsync(
                    request.NombreFuncion,
                    request.Parametros?.ToArray() ?? Array.Empty<object>()
                );

                return Ok(new
                {
                    Exito = true,
                    Datos = resultado
                });
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Función no permitida: {Funcion}", request.NombreFuncion);
                return BadRequest(new { Exito = false, Mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al ejecutar la función");
                return StatusCode(500, new { Exito = false, Mensaje = "Error interno del servidor." });
            }
        }
    }
}