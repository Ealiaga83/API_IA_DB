using API_IA_DB.Conexion;
using API_IA_DB.Modelo;
using Npgsql;
using System.IO;

namespace API_IA_DB.Data
{
    public class Empresa_SP_DATA
    {
        private readonly PostgreSql conn = new PostgreSql();

        public void GestionEmpresa(string tipoProceso, Empresa_SP empresa)
        {
            using var connection = conn.AbrirConexion();
            using var cmd = new NpgsqlCommand("CALL sp_empresa_gestion(@tipoProceso, @p_id, @p_nombre_comercial, @p_razon_social, @p_ruc, @p_contribuyente_especial, @p_obligado_contabilidad, @p_direccion_matriz, @p_direccion_sucursal)", connection);
            cmd.Parameters.AddWithValue("tipoProceso", tipoProceso);
            cmd.Parameters.AddWithValue("p_id", empresa.Id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_nombre_comercial", empresa.NombreComercial ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_razon_social", empresa.RazonSocial ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_ruc", empresa.RUC ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_contribuyente_especial", empresa.Contribuyente ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_obligado_contabilidad", empresa.Obligado != null ? bool.Parse(empresa.Obligado) : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_direccion_matriz", empresa.DireccionMatriz ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p_direccion_sucursal", empresa.DireccionSucursal ?? (object)DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public Empresa_SP ObtenerPorId(int id)
        {
            Empresa_SP empresa = null;
            using var connection = conn.AbrirConexion();
            using var cmd = new NpgsqlCommand("SELECT * FROM fn_empresa_por_id(@id)", connection);
            cmd.Parameters.AddWithValue("id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                empresa = new Empresa_SP
                {
                    Id = id,
                    NombreComercial = reader.GetString(reader.GetOrdinal("nombre_comercial")),
                    RazonSocial = reader.GetString(reader.GetOrdinal("razon_social")),
                    RUC = reader.GetString(reader.GetOrdinal("ruc")),
                    Contribuyente = reader.GetString(reader.GetOrdinal("contribuyente_especial")),
                    Obligado = reader.GetString(reader.GetOrdinal("obligado_contabilidad")),
                    DireccionMatriz = reader.GetString(reader.GetOrdinal("direccion_matriz")),
                    DireccionSucursal = reader.GetString(reader.GetOrdinal("direccion_sucursal"))
                };
            }
            return empresa;
        }

        //// POST: Crear empresa
        //public void CrearEmpresa(Empresa_SP empresa)
        //{
        //    GestionEmpresa("inst", empresa);
        //}

        //// PUT: Actualizar empresa
        //public void ActualizarEmpresa(Empresa_SP empresa)
        //{
        //    GestionEmpresa("upd", empresa);
        //}

        //// DELETE: Eliminar empresa
        //public void EliminarEmpresa(int id)
        //{
        //    var empresa = new Empresa_SP { Id = id };
        //    GestionEmpresa("del", empresa);
        //}

        //// Subir archivo PDF asociado a la empresa
        //public string SubirArchivoPdf(int empresaId, Stream archivoStream, string nombreArchivo)
        //{
        //    var carpeta = Path.Combine("ArchivosEmpresas", empresaId.ToString());
        //    if (!Directory.Exists(carpeta))
        //        Directory.CreateDirectory(carpeta);

        //    var rutaCompleta = Path.Combine(carpeta, nombreArchivo);

        //    using (var fileStream = new FileStream(rutaCompleta, FileMode.Create, FileAccess.Write))
        //    {
        //        archivoStream.CopyTo(fileStream);
        //    }

        //    // Aquí podrías guardar la ruta en la base de datos si lo necesitas

        //    return rutaCompleta;
        //}
    }
}
