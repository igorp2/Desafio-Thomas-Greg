using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Identificacao.Data;
using Sistema_de_Identificacao.DTOs;
using Sistema_de_Identificacao.Models;
using Sistema_de_Identificacao.Services.Interfaces;

namespace Sistema_de_Identificacao.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> ObterTodos()
        {
            var clientes = await _context.Clientes
                .Include(c => c.Logradouros)
                .ToListAsync();

            return clientes;
        }

        public async Task<Cliente?> ObterPorId(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Logradouros)
                .FirstOrDefaultAsync(c => c.Id == id);

            return cliente;
        }

        public async Task Criar(ClienteCreateDto dto)
        {
            bool existeEmail = await _context.Clientes.AnyAsync(c => c.Email == dto.Email);

            if (existeEmail) 
                throw new ArgumentException("Já existe um cliente cadastrado com este e-mail.");

            //Aqui seria onde a imagem seria salva em algum servidor em nuvem, seria gerado e salvo a url de acesso
            //Ex.: https://meuservidor.com/logo_cliente_X.png

            var cliente = new Cliente
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Logotipo = dto.Logotipo,
                Logradouros = dto.Logradouros.Select(l => new Logradouro
                {
                    Rua = l.Rua,
                    Numero = l.Numero,
                    Bairro = l.Bairro,
                    Cidade = l.Cidade,
                    Estado = l.Estado,
                    Cep = l.Cep
                }).ToList()
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Atualizar(ClienteUpdateDto dto)
        {
            var cliente = await _context.Clientes
               .Include(c => c.Logradouros)
               .FirstOrDefaultAsync(c => c.Id == dto.Id);

            if (cliente == null) 
                return false;

            bool existeEmail = await _context.Clientes.AnyAsync(c => c.Email == dto.Email && c.Id != dto.Id);

            if (existeEmail) 
                throw new ArgumentException("Já existe um cliente cadastrado com este e-mail.");

            cliente.Nome = dto.Nome;
            cliente.Email = dto.Email;
            cliente.Logotipo = dto.Logotipo;

            //Remover os logradouros antigos e ficar apenas os que estão no JSON do Update
            //O ideal seria manter os que não foram modificados e apenas remover e/ou adicionar os alterados(novos e excluídos)
            _context.Logradouros.RemoveRange(cliente.Logradouros);

            cliente.Logradouros = dto.Logradouros.Select(l => new Logradouro
            {
                Rua = l.Rua,
                Numero = l.Numero,
                Bairro = l.Bairro,
                Cidade = l.Cidade,
                Estado = l.Estado,
                Cep = l.Cep
            }).ToList();

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            var cliente = await _context.Clientes
              .Include(c => c.Logradouros)
              .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null) 
                return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
      
    }
}
