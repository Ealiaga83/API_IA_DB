using API_IA_DB.Conexion;
using API_IA_DB.Modelo;
using Npgsql;

namespace API_IA_DB.Data
{
    public class DetalleFactura_SP_DATA
    {
        private readonly PostgreSql conn = new PostgreSql();

        public void GestionDetalleFactura(string tipoProceso, DetalleFactura_SP detalle)
        {
            using var connection = conn.AbrirConexion();
            using var cmd = new NpgsqlCommand(
                "CALL sp_detalle_factura_gestion(@tipoProceso, @p_id, @p_factura_id, @p_codigo_principal, @p_codigo_auxiliar, @p_cantidad, @p_descripcion, @p_precio_unitario, @p_subsidio, @p_precio_sin_subsidio, @p_descuento, @p_precio_total)",
                connection);
            cmd.Parameters.AddWithValue("tipoProceso", tipoProceso);
            cmd.Parameters.AddWithValue("p_id", detalle.Id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_factura_id", detalle.FacturaId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_codigo_principal", detalle.CodigoPrincipal ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_codigo_auxiliar", detalle.CodigoAuxiliar ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_cantidad", detalle.Cantidad ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_descripcion", detalle.Descripcion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_precio_unitario", detalle.PrecioUnitario ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_subsidio", detalle.Subsidio ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_precio_sin_subsidio", detalle.PrecioSinSubsidio ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_descuento", detalle.Descuento ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_precio_total", detalle.PrecioTotal ?? (object)DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public void CrearDetalleFactura(DetalleFactura_SP detalle) => GestionDetalleFactura("inst", detalle);
        public void ActualizarDetalleFactura(DetalleFactura_SP detalle) => GestionDetalleFactura("upd", detalle);
        public void EliminarDetalleFactura(int id) => GestionDetalleFactura("del", new DetalleFactura_SP { Id = id });
    }
}