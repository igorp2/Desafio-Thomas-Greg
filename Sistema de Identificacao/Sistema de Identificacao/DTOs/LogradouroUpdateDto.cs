namespace Sistema_de_Identificacao.DTOs
{
    public class LogradouroUpdateDto
    {
        public int Id { get; set; }
        public string Rua { get; set; } = null!;
        public int ClienteId { get; set; }
    }
}
