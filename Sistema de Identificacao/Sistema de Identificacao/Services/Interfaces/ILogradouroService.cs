using Sistema_de_Identificacao.DTOs;
using Sistema_de_Identificacao.Models;

namespace Sistema_de_Identificacao.Services.Interfaces
{
    public interface ILogradouroService
    {
        Task<List<Logradouro>> ObterTodos();
        Task<Logradouro?> ObterPorId(int id);
        Task<List<Logradouro>?> ObterPorClienteId(int clienteId);
        Task Criar(LogradouroCreateDto dto);
        Task<bool> Atualizar(LogradouroUpdateDto dto);
        Task<bool> Remover(int id);
    }
}
