using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sistema_de_Identificacao.Models
{
    public class Logradouro
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Rua { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string Numero { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Bairro { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Cidade { get; set; } = null!;

        [Required]
        [MaxLength(2)] 
        public string Estado { get; set; } = null!;

        [Required]
        [MaxLength(9)]  // Formato 00000-000
        public string Cep { get; set; } = null!;
        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; } = null!;
    }
}
