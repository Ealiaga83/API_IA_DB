namespace API_IA_DB.Modelo
{
    public class DetalleFactura_SP
    {
        public int? Id { get; set; }
        public int? FacturaId { get; set; }
        public string CodigoPrincipal { get; set; }
        public string CodigoAuxiliar { get; set; }
        public decimal? Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Subsidio { get; set; }
        public decimal? PrecioSinSubsidio { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? PrecioTotal { get; set; }
    }
}