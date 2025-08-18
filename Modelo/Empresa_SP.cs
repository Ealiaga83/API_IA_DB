namespace API_IA_DB.Modelo
{
    public class Empresa_SP
    {
        public int? Id { get; set; } // Nullable para "inst"
        public string NombreComercial { get; set; }
        public string RazonSocial { get; set; }
        public string RUC { get; set; }
        public string Obligado { get; set; }
        public string Contribuyente { get; set; }
        public string DireccionMatriz { get; set; }
        public string DireccionSucursal { get; set; }
    }    
}
