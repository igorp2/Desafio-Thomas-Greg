using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Identificacao.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; } = null!;

        [MaxLength(150)]
        public string Email { get; set; } = null!;

        [MaxLength(500)]
        public string Logotipo { get; set; } = null!;
        public List<Logradouro> Logradouros { get; set; } = [];
    }
}
