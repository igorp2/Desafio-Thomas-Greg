using System.Text.Json.Serialization;

namespace Sistema_de_Identificacao.Models
{
    public class Logradouro
    {
        public int Id { get; set; }
        public string Rua { get; set; } = null!;
        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; } = null!;
    }
}
