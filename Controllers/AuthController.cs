// Controllers/AuthController.cs
using API_IA_DB.Modelo;
using API_IA_DB.Servicios;
using API_IA_DB.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace API_IA_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService jwtService;

        public AuthController(IConfiguration config)
        {
            jwtService = new JwtService(config);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioLogin usuario)
        {
            // consulta si el usuario y contraseña son validos 
            var funcionGen = new FuncionGenerica_DATA();

            int valiUserToken = funcionGen.ValidarUserToken(usuario.Usuario, usuario.Clave);

            if (valiUserToken == 1)
            {
                // Genera el token JWT
                var token = jwtService.GenerarToken(usuario.Usuario);
                return Ok(new { token });
            }

            //// Aquí deberías validar contra la base de datos
            //if (usuario.Usuario == "admin" && usuario.Clave == "1234")
            //{
            //    var token = jwtService.GenerarToken(usuario.Usuario);
            //    return Ok(new { token });
            //}

            return Unauthorized("Credenciales inválidas");
        }

        [Authorize]
        [HttpPost("revocar-token")]
        public IActionResult RevocarToken([FromServices] TokenRevocadoService revocadoService)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
                return BadRequest("Token no encontrado");

            revocadoService.RevocarToken(token);
            return Ok("Token revocado exitosamente");
        }

    }
}