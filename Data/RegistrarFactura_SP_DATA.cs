using API_IA_DB.Conexion;
using API_IA_DB.Modelo;
using Npgsql;
using NpgsqlTypes;
using System;

namespace API_IA_DB.Data
{
    public class RegistrarFactura_SP_DATA
    {
        private readonly PostgreSql conn = new PostgreSql();

        public void InsertarFactura(RegistrarFactura factura)
        {
            using var connection = conn.AbrirConexion();
            using var cmd = new NpgsqlCommand("CALL sp_factura_insercion_completa_con_calls(" +
                "@p_empresa_nombre_comercial, @p_empresa_razon_social, @p_empresa_ruc, @p_empresa_contribuyente_especial, @p_empresa_obligado_contabilidad, @p_empresa_direccion_matriz, @p_empresa_direccion_sucursal, " +
                "@p_cliente_nombre, @p_cliente_identificacion, @p_cliente_correo, " +
                "@p_numero_factura, @p_numero_autorizacion, @p_clave_acceso, @p_fecha_emision, @p_hora_autorizacion, @p_ambiente, @p_emision, @p_placa_matricula, " +
                "@p_detalles, @p_totales, @p_formas_pago, @p_json_factura)", connection);

            // Empresa
            cmd.Parameters.AddWithValue("p_empresa_nombre_comercial", factura.EmpresaNombreComercial ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_empresa_razon_social", factura.EmpresaRazonSocial ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_empresa_ruc", factura.EmpresaRuc ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_empresa_contribuyente_especial", factura.EmpresaContribuyenteEspecial ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_empresa_obligado_contabilidad", factura.EmpresaObligadoContabilidad);
            cmd.Parameters.AddWithValue("p_empresa_direccion_matriz", factura.EmpresaDireccionMatriz ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_empresa_direccion_sucursal", factura.EmpresaDireccionSucursal ?? (object)DBNull.Value);

            // Cliente
            cmd.Parameters.AddWithValue("p_cliente_nombre", factura.ClienteNombre ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_cliente_identificacion", factura.ClienteIdentificacion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_cliente_correo", factura.ClienteCorreo ?? (object)DBNull.Value);

            // Factura
            // Factura
            cmd.Parameters.AddWithValue("p_numero_factura", factura.NumeroFactura ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_numero_autorizacion", factura.NumeroAutorizacion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_clave_acceso", factura.ClaveAcceso ?? (object)DBNull.Value);

            // Fecha y hora como string (sin conversión)
            cmd.Parameters.AddWithValue("p_fecha_emision", factura.FechaEmision ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_hora_autorizacion", factura.HoraAutorizacion ?? (object)DBNull.Value);

            cmd.Parameters.AddWithValue("p_ambiente", factura.Ambiente ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_emision", factura.Emision ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_placa_matricula", factura.PlacaMatricula ?? (object)DBNull.Value);

            // JSONB
            cmd.Parameters.Add("p_detalles", NpgsqlDbType.Jsonb).Value = string.IsNullOrWhiteSpace(factura.Detalles) ? (object)DBNull.Value : factura.Detalles;
            cmd.Parameters.Add("p_totales", NpgsqlDbType.Jsonb).Value = string.IsNullOrWhiteSpace(factura.Totales) ? (object)DBNull.Value : factura.Totales;
            cmd.Parameters.Add("p_formas_pago", NpgsqlDbType.Jsonb).Value = string.IsNullOrWhiteSpace(factura.FormasPago) ? (object)DBNull.Value : factura.FormasPago;
            cmd.Parameters.Add("p_json_factura", NpgsqlDbType.Jsonb).Value = string.IsNullOrWhiteSpace(factura.JsonFactura) ? (object)DBNull.Value : factura.JsonFactura;

            cmd.ExecuteNonQuery();
        }
    }
}
