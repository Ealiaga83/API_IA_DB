// Servicios/JwtService.cs
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_IA_DB.Servicios
{
    public class JwtService
    {
        private readonly string secretKey;

        public JwtService(IConfiguration config)
        {
            secretKey = config["Jwt:Key"];
        }

        public string GenerarToken(string usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario),
                new Claim("rol", "admin") // puedes personalizar esto
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "tuApp",
                audience: "tuApp",
                claims: claims,
                //expires: DateTime.Now.AddHours(2),
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}