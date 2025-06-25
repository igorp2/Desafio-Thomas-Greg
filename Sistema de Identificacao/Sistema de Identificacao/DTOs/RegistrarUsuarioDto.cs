using Sistema_de_Identificacao.Models;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Identificacao.DTOs
{
    public class RegistrarUsuarioDto : LoginDto
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = null!;

        public CargoUsuario Cargo { get; set; } = CargoUsuario.Comum;
    }
}
