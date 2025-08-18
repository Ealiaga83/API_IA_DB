using API_IA_DB.Conexion;
using API_IA_DB.Modelo;
using Npgsql;
using System.Text.Json.Nodes;

namespace API_IA_DB.Data
{
    public class FacturaJson_SP_DATA
    {
        private readonly PostgreSql conn = new PostgreSql();

        public void GestionFacturaJson(string tipoProceso, FacturaJson_SP facturaJson)
        {
            using var connection = conn.AbrirConexion();
            using var cmd = new NpgsqlCommand(
                "CALL sp_factura_json_gestion(@tipoProceso, @p_id, @p_factura_id, @p_contenido)",
                connection);
            cmd.Parameters.AddWithValue("tipoProceso", tipoProceso);
            cmd.Parameters.AddWithValue("p_id", facturaJson.Id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_factura_id", facturaJson.FacturaId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_contenido", facturaJson.Contenido?.ToJsonString() ?? (object)DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public void CrearFacturaJson(FacturaJson_SP facturaJson) => GestionFacturaJson("inst", facturaJson);
        public void ActualizarFacturaJson(FacturaJson_SP facturaJson) => GestionFacturaJson("upd", facturaJson);
        public void EliminarFacturaJson(int id) => GestionFacturaJson("del", new FacturaJson_SP { Id = id });
    }
}