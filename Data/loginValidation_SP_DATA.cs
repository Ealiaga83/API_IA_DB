using API_IA_DB.Conexion;
using API_IA_DB.Modelo;
using Npgsql;
using System.Threading.Tasks;

namespace API_IA_DB.Data
{
    public class LoginValidationRepository
    {
        private readonly PostgreSql conn = new PostgreSql();

        public async Task<LoginValidationResponse> ValidarCredencialesHashAsync(string username, string password)
        {
            using var connection = conn.AbrirConexion();
            using var cmd = new NpgsqlCommand("SELECT fn_user_exists_user(@user)", connection);
            cmd.Parameters.AddWithValue("user", username);

            var result = await cmd.ExecuteScalarAsync();
            string hash = result?.ToString();

            if (string.IsNullOrEmpty(hash))
            {
                return new LoginValidationResponse
                {
                    IsValid = false,
                    Detalle = "Usuario no encontrado"
                };
            }

            bool isValid = BCrypt.Net.BCrypt.Verify(password, hash);

            return new LoginValidationResponse
            {
                IsValid = isValid,
                Detalle = isValid ? "Login exitoso" : "Contraseña incorrecta"
            };
        }
    }
}