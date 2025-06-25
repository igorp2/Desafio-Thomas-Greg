using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Identificacao.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; } = null!;

        [MaxLength(150)]
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public CargoUsuario Cargo { get; set; } = CargoUsuario.Comum;

    }
    public enum CargoUsuario
    {
        Comum = 0,
        Admin = 1
    }
}
