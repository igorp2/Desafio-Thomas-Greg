using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Identificacao.DTOs
{
    public class LoginDto
    {
        [Required]
        [StringLength(150)]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

    }
}
