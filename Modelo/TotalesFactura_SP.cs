namespace API_IA_DB.Modelo
{
    public class TotalesFactura_SP
    {
        public int? Id { get; set; }
        public int? FacturaId { get; set; }
        public decimal? SubtotalTarifaEspecial { get; set; }
        public decimal? SubtotalNoObjetoIva { get; set; }
        public decimal? SubtotalExentoIva { get; set; }
        public decimal? SubtotalSinImpuestos { get; set; }
        public decimal? TotalDescuento { get; set; }
        public decimal? Ice { get; set; }
        public decimal? IvaTarifaEspecial { get; set; }
        public decimal? Irbpnr { get; set; }
        public decimal? Propina { get; set; }
        public decimal? ValorTotal { get; set; }
        public decimal? ValorTotalSinSubsidio { get; set; }
        public decimal? AhorroSubsidio { get; set; }
    }
}