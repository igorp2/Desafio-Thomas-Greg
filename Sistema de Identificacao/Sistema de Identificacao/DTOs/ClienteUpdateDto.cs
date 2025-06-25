using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Identificacao.DTOs
{
    public class ClienteUpdateDto : ClienteCreateDto
    {
        public int Id { get; set; }        
    }
}
