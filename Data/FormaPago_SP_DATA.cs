using API_IA_DB.Conexion;
using API_IA_DB.Modelo;
using Npgsql;

namespace API_IA_DB.Data
{
    public class FormaPago_SP_DATA
    {
        private readonly PostgreSql conn = new PostgreSql();

        public void GestionFormaPago(string tipoProceso, FormaPago_SP formaPago)
        {
            using var connection = conn.AbrirConexion();
            using var cmd = new NpgsqlCommand(
                "CALL sp_forma_pago_gestion(@tipoProceso, @p_id, @p_factura_id, @p_codigo_pago, @p_descripcion_pago, @p_valor)",
                connection);
            cmd.Parameters.AddWithValue("tipoProceso", tipoProceso);
            cmd.Parameters.AddWithValue("p_id", formaPago.Id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_factura_id", formaPago.FacturaId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_codigo_pago", formaPago.CodigoPago ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_descripcion_pago", formaPago.DescripcionPago ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_valor", formaPago.Valor ?? (object)DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public void CrearFormaPago(FormaPago_SP formaPago) => GestionFormaPago("inst", formaPago);
        public void ActualizarFormaPago(FormaPago_SP formaPago) => GestionFormaPago("upd", formaPago);
        public void EliminarFormaPago(int id) => GestionFormaPago("del", new FormaPago_SP { Id = id });
    }
}