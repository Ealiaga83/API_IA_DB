using API_IA_DB.Data;
using API_IA_DB.Modelo;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_IA_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        private readonly LoginRepository loginRepo = new LoginRepository();

        [HttpPost("inst")]
        public IActionResult Insertar([FromBody] Login_SP login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Encriptar la contraseña
            if (!string.IsNullOrEmpty(login.PasswordHash))
            {
                login.PasswordHash = BCrypt.Net.BCrypt.HashPassword(login.PasswordHash);
            }

            loginRepo.EjecutarProcedimiento("inst", login);
            return Ok("Usuario insertado");
        }

        [HttpPut("upd/{id}")]
        public IActionResult Actualizar(int id, [FromBody] LoginUpdate_SP login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var loginSP = new Login_SP
            {
                UserId = id,
                Username = login.Username,
                PasswordHash = string.IsNullOrEmpty(login.PasswordHash) ? null : BCrypt.Net.BCrypt.HashPassword(login.PasswordHash),
                Email = login.Email,
                IsActive = login.IsActive,
                TipoProceso = "upd"
            };

            loginRepo.EjecutarProcedimiento("upd", loginSP);
            return Ok("Usuario actualizado");
        }

        [HttpDelete("del/{id}")]
        public IActionResult Eliminar(int id)
        {
            var login = new Login_SP { UserId = id };           
            loginRepo.EjecutarProcedimiento("del", login);
            return Ok("Usuario eliminado");
        }        
    }
}