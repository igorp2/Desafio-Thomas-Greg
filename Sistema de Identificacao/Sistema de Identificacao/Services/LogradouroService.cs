using Microsoft.EntityFrameworkCore;
using Sistema_de_Identificacao.Data;
using Sistema_de_Identificacao.DTOs;
using Sistema_de_Identificacao.Models;
using Sistema_de_Identificacao.Services.Interfaces;

namespace Sistema_de_Identificacao.Services
{
    public class LogradouroService : ILogradouroService
    {
        private readonly AppDbContext _context;

        public LogradouroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Logradouro>> ObterTodos()
        {
            var logradouros = await _context.Logradouros.ToListAsync(); ;
            return logradouros;
        }

        public async Task<Logradouro?> ObterPorId(int id)
        {
            var logradouro = await _context.Logradouros
                .FirstOrDefaultAsync(l => l.Id == id);

            return logradouro;
        }

        public async Task Criar(LogradouroCreateDto dto)
        {
            bool existeCliente = await _context.Clientes.AnyAsync(c => c.Id == dto.ClienteId);
            if (!existeCliente) throw new ArgumentException("Cliente não encontrado!");

            var logradouro = new Logradouro
            {
                Rua = dto.Rua,
                ClienteId = dto.ClienteId
            };

            _context.Logradouros.Add(logradouro);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Atualizar(LogradouroUpdateDto dto)
        {
            var logradouro = await _context.Logradouros.FindAsync(dto.Id); ;
            if (logradouro == null) return false;

            logradouro.Rua = dto.Rua;
            logradouro.ClienteId = dto.ClienteId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            var logradouro = await _context.Logradouros.FindAsync(id);
            if (logradouro == null) return false;

            _context.Logradouros.Remove(logradouro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
