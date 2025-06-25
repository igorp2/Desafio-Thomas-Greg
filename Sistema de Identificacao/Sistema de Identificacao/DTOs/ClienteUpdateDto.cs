namespace Sistema_de_Identificacao.DTOs
{
    public class ClienteUpdateDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Logotipo { get; set; }

        public List<LogradouroClienteDto> Logradouros { get; set; } = new();
    }
}
