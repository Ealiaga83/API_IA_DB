using System.ComponentModel.DataAnnotations;

namespace API_IA_DB.Modelo
{
    public class FuncionRequest
    {
        [Required(ErrorMessage = "El nombre de la función es obligatorio.")]
        public string NombreFuncion { get; set; }

        public List<object> Parametros { get; set; } = new();
    }
}