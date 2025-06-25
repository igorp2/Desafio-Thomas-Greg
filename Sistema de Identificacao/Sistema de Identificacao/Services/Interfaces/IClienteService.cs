using Sistema_de_Identificacao.Data;
using Sistema_de_Identificacao.DTOs;
using Sistema_de_Identificacao.Models;

namespace Sistema_de_Identificacao.Services.Interfaces
{
    public interface IClienteService
    {
        Task<List<Cliente>> ObterTodos();
        Task<Cliente?> ObterPorId(int id);
        Task Criar(ClienteCreateDto dto);
        Task<bool> Atualizar(ClienteUpdateDto dto);
        Task<bool> Remover(int id);
    }
}
