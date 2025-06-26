using Sistema_de_Identificacao.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Identificacao.DTOs
{
    public class RegistrarUsuarioDto : LoginDto
    {
        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "O nome deve conter apenas letras.")]
        [DefaultValue("Nome do Usuário")]
        public string Nome { get; set; } = null!;

        public CargoUsuario Cargo { get; set; } = CargoUsuario.Comum;
    }
}
