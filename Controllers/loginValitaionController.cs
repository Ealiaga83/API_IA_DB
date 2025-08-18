using API_IA_DB.Data;
using API_IA_DB.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API_IA_DB.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginValitaionController : ControllerBase
    {
        private readonly LoginValidationRepository repo = new LoginValidationRepository();

        [HttpPost("validar")]
        public async Task<IActionResult> Validar([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new LoginValidationResponse
                {
                    IsValid = false,
                    Detalle = "Username y password requeridos"
                });
            }

            var response = await repo.ValidarCredencialesHashAsync(request.Username, request.Password);

            if (!response.IsValid)
                return Unauthorized(response);

            return Ok(response);
        }
    }
}