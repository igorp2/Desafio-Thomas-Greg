namespace Sistema_de_Identificacao.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[]? Logotipo { get; set; }
        public List<Logradouro> Logradouros { get; set; } = new();
    }
}
