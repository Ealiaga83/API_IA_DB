namespace API_IA_DB.Modelo
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginValidationResponse
    {
        public bool IsValid { get; set; }
        public string Detalle { get; set; }
    }
}