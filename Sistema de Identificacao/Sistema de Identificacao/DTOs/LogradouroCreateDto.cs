using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Identificacao.DTOs
{
    public class LogradouroCreateDto : LogradouroClienteDto
    {
        public int ClienteId { get; set; }
    }
}
