namespace API_IA_DB.Modelo
{
    using System.ComponentModel.DataAnnotations;

    public class Login_SP
    {
        public int? UserId { get; set; }

        [Required]
        public string TipoProceso { get; set; }

        public string Username { get; set; }

        [StringLength(100, MinimumLength = 6)]
        public string PasswordHash { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public bool? IsActive { get; set; }
    }

    public class LoginUpdate_SP
    {
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
    }
}