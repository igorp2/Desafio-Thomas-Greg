using Sistema_de_Identificacao.Models;

namespace Sistema_de_Identificacao.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }
}
