using API_IA_DB.Conexion;
using Npgsql;

namespace API_IA_DB.Data
{
    public class FuncionGenerica_DATA
    {
        private readonly PostgreSql conn = new PostgreSql();


        private readonly HashSet<string> funcionesPermitidas = new()
        {
            "fn_cliente_por_id", "fn_detalle_factura_por_id", "fn_empresa_por_id",
            "fn_factura_json_por_id", "fn_factura_por_id", "fn_forma_pago_por_id", "fn_user_exists_user",
            "fn_totales_factura_por_id", "fn_login_user", "fn_user_exists_id", "fn_list_all_users",
            "fn_consulta_factura_por_ruc", "fn_consulta_factura_por_identificacion", 
            "fn_consulta_factura_por_nombre_comercial","fn_consulta_factura_con_json_por_ruc"
        };

        private readonly HashSet<string> funcionesTexto = new()
        {
            "fn_consulta_factura_por_ruc",
            "fn_consulta_factura_por_identificacion",
            "fn_consulta_factura_por_nombre_comercial",
            "fn_consulta_factura_con_json_por_ruc"
        };

        private readonly HashSet<string> funcionesNumericas = new()
        {
            "fn_cliente_por_id",
            "fn_detalle_factura_por_id",
            "fn_empresa_por_id",
            "fn_factura_json_por_id",
            "fn_factura_por_id",
            "fn_forma_pago_por_id",
            "fn_totales_factura_por_id",
            "fn_login_user",
            "fn_user_exists_id", 
            "fn_list_all_users",
            "fn_user_exists_user",
        };

        public async Task<List<Dictionary<string, object>>> EjecutarFuncionAsync(string nombreFuncion, params object[] parametros)
        {
            if (!funcionesPermitidas.Contains(nombreFuncion))
                throw new ArgumentException($"Función '{nombreFuncion}' no está permitida.");

            using var connection = conn.AbrirConexion();
            if (connection.State != System.Data.ConnectionState.Open)
                throw new InvalidOperationException("No se pudo abrir la conexión a la base de datos.");

            string ConvertirParametro(object p)
            {
                if (p == null) return "NULL";

                if (funcionesTexto.Contains(nombreFuncion))
                {
                    return $"'{p.ToString().Replace("'", "''")}'";
                }

                if (funcionesNumericas.Contains(nombreFuncion))
                {
                    return p.ToString();
                }
                
                return $"'{p.ToString().Replace("'", "''")}'";
            }

            var parametrosSql = string.Join(", ", parametros.Select(ConvertirParametro));
            var query = $"SELECT * FROM {nombreFuncion}({parametrosSql});";

            using var cmd = new NpgsqlCommand(query, connection);
            var resultados = new List<Dictionary<string, object>>();

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var fila = Enumerable.Range(0, reader.FieldCount)
                                     .ToDictionary(i => reader.GetName(i), i => reader.GetValue(i));
                resultados.Add(fila);
            }

            return resultados;
        }

        public int ValidarUserToken(string usuario, string contrasena)
        {
            using var connection = conn.AbrirConexion();
            using var cmd = new NpgsqlCommand("SELECT fn_validar_token(@usuario, @contrasena)", connection);
            cmd.Parameters.AddWithValue("usuario", usuario);
            cmd.Parameters.AddWithValue("contrasena", contrasena);

            var resultado = cmd.ExecuteScalar();
            return resultado != null ? Convert.ToInt32(resultado) : 0;
        }

    }
}