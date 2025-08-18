namespace API_IA_DB.Modelo
{
    public class Factura_SP
    {
        public int? Id { get; set; }
        public string NumeroFactura { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string ClaveAcceso { get; set; }      
        public string FechaEmision { get; set; }
        public string HoraAutorizacion { get; set; }
        public string Ambiente { get; set; }
        public string Emision { get; set; }
        public string PlacaMatricula { get; set; }
        public int? EmpresaId { get; set; }
        public int? ClienteId { get; set; }
    }
}