namespace API_IA_DB.Modelo
{
    public class FormaPago_SP
    {
        public int? Id { get; set; }
        public int? FacturaId { get; set; }
        public string CodigoPago { get; set; }
        public string DescripcionPago { get; set; }
        public decimal? Valor { get; set; }
    }
}