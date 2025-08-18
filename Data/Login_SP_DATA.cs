using API_IA_DB.Conexion;
using API_IA_DB.Modelo;
using Npgsql;

namespace API_IA_DB.Data{ 

    public class LoginRepository
    {
        private readonly PostgreSql conn = new PostgreSql();

        public void EjecutarProcedimiento(string tipoProceso, Login_SP login)
        {
            using var connection = conn.AbrirConexion();

            using var cmd = new NpgsqlCommand("CALL sp_login_user_gestion(@tipoProceso, @userId, @username, @passwordHash, @email, @isActive)", connection);
            cmd.Parameters.AddWithValue("tipoProceso", tipoProceso);
            cmd.Parameters.AddWithValue("userId", login.UserId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("username", login.Username ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("passwordHash", login.PasswordHash ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("email", login.Email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("isActive", login.IsActive ?? (object)DBNull.Value);
            cmd.ExecuteNonQuery();           
        }
        // Métodos CRUD
        public void CrearFactura(Login_SP login) => EjecutarProcedimiento("inst", login);
        public void ActualizarFactura(Login_SP login) => EjecutarProcedimiento("upd", login);
        public void EliminarFactura(int id) => EjecutarProcedimiento("del", new Login_SP { UserId = id });
    }
}