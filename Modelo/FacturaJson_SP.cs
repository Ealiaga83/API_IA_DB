using System.Text.Json.Nodes;

namespace API_IA_DB.Modelo
{
    public class FacturaJson_SP
    {
        public int? Id { get; set; }
        public int? FacturaId { get; set; }
        public JsonNode Contenido { get; set; }
    }
}