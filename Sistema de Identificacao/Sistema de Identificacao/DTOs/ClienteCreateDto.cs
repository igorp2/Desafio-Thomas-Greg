using Sistema_de_Identificacao.Models;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Identificacao.DTOs
{
    public class ClienteCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(150)]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Logotipo { get; set; } = null!;

        [MinLength(1, ErrorMessage = "Informe ao menos um logradouro.")]
        public List<LogradouroClienteDto> Logradouros { get; set; } = [];
    }
}
