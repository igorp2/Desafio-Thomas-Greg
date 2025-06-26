using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Sistema_de_Identificacao.DTOs
{
    public class LogradouroClienteDto
    {
        [Required]
        [StringLength(150)]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s\.\-ºª]+$", ErrorMessage = "A rua deve conter apenas letras, números, espaços, ponto, hífen ou abreviações.")]
        [DefaultValue("Nome da Rua ou Avenida")]
        public string Rua { get; set; } = null!;

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^(?=.*\d)[0-9A-Za-z\s]+$", ErrorMessage = "O número do local deve conter pelo menos um número e pode conter letras e espaços. Ex.: 123, 49 ap 120, 25A")]
        [DefaultValue("Número do Logradouro")]
        public string Numero { get; set; } = null!;

        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s\-ºª]+$", ErrorMessage = "O bairro deve conter apenas letras, números, espaços, hífen ou abreviações.")]
        [DefaultValue("Nome do Bairro")]
        public string Bairro { get; set; } = null!;

        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s\-]+$", ErrorMessage = "A cidade deve conter apenas letras, espaços ou hífens.")]
        [DefaultValue("Nome da Cidade")]
        public string Cidade { get; set; } = null!;

        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Estado deve ter 2 letras.")]
        [RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "O estado deve conter exatamente duas letras maiúsculas.")]
        [DefaultValue("MG")]
        public string Estado { get; set; } = null!;

        [Required]
        [StringLength(9)]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP inválido! Use o formato 00000-000.")]
        [DefaultValue("00000-000")]
        public string Cep { get; set; } = null!;
    }
}
