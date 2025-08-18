using API_IA_DB.Conexion;
using API_IA_DB.Modelo;
using Npgsql;

namespace API_IA_DB.Data
{
    public class TotalesFactura_SP_DATA
    {
        private readonly PostgreSql conn = new PostgreSql();

        public void GestionTotalesFactura(string tipoProceso, TotalesFactura_SP totales)
        {
            using var connection = conn.AbrirConexion();
            using var cmd = new NpgsqlCommand(
                "CALL sp_totales_factura_gestion(@tipoProceso, @p_id, @p_factura_id, @p_subtotal_tarifa_especial, @p_subtotal_no_objeto_iva, @p_subtotal_exento_iva, @p_subtotal_sin_impuestos, @p_total_descuento, @p_ice, @p_iva_tarifa_especial, @p_irbpnr, @p_propina, @p_valor_total, @p_valor_total_sin_subsidio, @p_ahorro_subsidio)",
                connection);
            cmd.Parameters.AddWithValue("tipoProceso", tipoProceso);
            cmd.Parameters.AddWithValue("p_id", totales.Id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_factura_id", totales.FacturaId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_subtotal_tarifa_especial", totales.SubtotalTarifaEspecial ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_subtotal_no_objeto_iva", totales.SubtotalNoObjetoIva ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_subtotal_exento_iva", totales.SubtotalExentoIva ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_subtotal_sin_impuestos", totales.SubtotalSinImpuestos ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_total_descuento", totales.TotalDescuento ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_ice", totales.Ice ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_iva_tarifa_especial", totales.IvaTarifaEspecial ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_irbpnr", totales.Irbpnr ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_propina", totales.Propina ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_valor_total", totales.ValorTotal ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_valor_total_sin_subsidio", totales.ValorTotalSinSubsidio ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_ahorro_subsidio", totales.AhorroSubsidio ?? (object)DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public void CrearTotalesFactura(TotalesFactura_SP totales) => GestionTotalesFactura("inst", totales);
        public void ActualizarTotalesFactura(TotalesFactura_SP totales) => GestionTotalesFactura("upd", totales);
        public void EliminarTotalesFactura(int id) => GestionTotalesFactura("del", new TotalesFactura_SP { Id = id });
    }
}