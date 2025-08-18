using API_IA_DB.Conexion;
using API_IA_DB.Modelo;
using Npgsql;

namespace API_IA_DB.Data
{
    public class Cliente_SP_DATA
    {
        private readonly PostgreSql conn = new PostgreSql();

        public void GestionCliente(string tipoProceso, Cliente_SP cliente)
        {
            using var connection = conn.AbrirConexion();
            using var cmd = new NpgsqlCommand("CALL sp_cliente_gestion(@tipoProceso, @p_id, @p_nombre, @p_identificacion, @p_correo)", connection);
            cmd.Parameters.AddWithValue("tipoProceso", tipoProceso);
            cmd.Parameters.AddWithValue("p_id", cliente.Id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_nombre", cliente.Nombre ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_identificacion", cliente.Identificacion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_correo", cliente.Correo ?? (object)DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        // Métodos CRUD
        public void CrearCliente(Cliente_SP cliente) => GestionCliente("inst", cliente);
        public void ActualizarCliente(Cliente_SP cliente) => GestionCliente("upd", cliente);
        public void EliminarCliente(int id) => GestionCliente("del", new Cliente_SP { Id = id });
    }
}