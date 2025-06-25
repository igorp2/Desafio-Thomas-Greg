using Sistema_de_Identificacao.Models;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Identificacao.DTOs
{
    public class RegistrarUsuarioDto
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(150)]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
        public CargoUsuario Cargo { get; set; } = CargoUsuario.Comum;
    }
}
