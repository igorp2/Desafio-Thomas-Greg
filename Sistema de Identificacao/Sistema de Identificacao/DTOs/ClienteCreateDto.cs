using Sistema_de_Identificacao.Models;

namespace Sistema_de_Identificacao.DTOs
{
    public class ClienteCreateDto
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string? Logotipo { get; set; }

        public List<LogradouroCreateDto> Logradouros { get; set; } = new();
    }
}
