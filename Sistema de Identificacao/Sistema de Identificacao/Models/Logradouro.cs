using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sistema_de_Identificacao.Models
{
    public class Logradouro
    {
        public int Id { get; set; }

        [MaxLength(150)]
        public string Rua { get; set; } = null!;

        [MaxLength(20)]
        public string Numero { get; set; } = null!;

        [MaxLength(100)]
        public string Bairro { get; set; } = null!;

        [MaxLength(100)]
        public string Cidade { get; set; } = null!;

        [MaxLength(2)] 
        public string Estado { get; set; } = null!;

        [MaxLength(9)]  
        public string Cep { get; set; } = null!;
        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; } = null!;
    }
}
