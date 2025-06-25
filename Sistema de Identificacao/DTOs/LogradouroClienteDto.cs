using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Identificacao.DTOs
{
    public class LogradouroClienteDto
    {
        [Required]
        [StringLength(150)]
        public string Rua { get; set; } = null!;

        [Required]
        [StringLength(10)]
        public string Numero { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Bairro { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Cidade { get; set; } = null!;

        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Estado deve ter 2 letras.")]
        public string Estado { get; set; } = null!;

        [Required]
        [StringLength(9)]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP inválido! Use o formato 00000-000.")]
        public string Cep { get; set; } = null!;
    }
}
