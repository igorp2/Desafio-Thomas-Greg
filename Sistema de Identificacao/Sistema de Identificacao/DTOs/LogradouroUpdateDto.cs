using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Identificacao.DTOs
{
    public class LogradouroUpdateDto : LogradouroCreateDto
    {
        [Required]
        public int Id { get; set; }
    }
}
