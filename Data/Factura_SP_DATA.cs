using API_IA_DB.Conexion;
using API_IA_DB.Modelo;
using Npgsql;

namespace API_IA_DB.Data
{
    public class Factura_SP_DATA
    {
        private readonly PostgreSql conn = new PostgreSql();

        public void GestionFactura(string tipoProceso, Factura_SP factura)
        {
            using var connection = conn.AbrirConexion();    
            using var cmd = new NpgsqlCommand(
                "CALL sp_factura_gestion(@tipoProceso, @p_id, @p_numero_factura, @p_numero_autorizacion, @p_clave_acceso, @p_fecha_emision, @p_hora_autorizacion, @p_ambiente, @p_emision, @p_placa_matricula, @p_empresa_id, @p_cliente_id)", 
                connection);
            cmd.Parameters.AddWithValue("tipoProceso", tipoProceso);
            cmd.Parameters.AddWithValue("p_id", factura.Id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_numero_factura", factura.NumeroFactura ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_numero_autorizacion", factura.NumeroAutorizacion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_clave_acceso", factura.ClaveAcceso ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_fecha_emision", factura.FechaEmision ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_hora_autorizacion", factura.HoraAutorizacion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_ambiente", factura.Ambiente ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_emision", factura.Emision ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_placa_matricula", factura.PlacaMatricula ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_empresa_id", factura.EmpresaId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_cliente_id", factura.ClienteId ?? (object)DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        // Métodos CRUD
        public void CrearFactura(Factura_SP factura) => GestionFactura("inst", factura);
        public void ActualizarFactura(Factura_SP factura) => GestionFactura("upd", factura);
        public void EliminarFactura(int id) => GestionFactura("del", new Factura_SP { Id = id });        
    }
}