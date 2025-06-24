using Microsoft.AspNetCore.Mvc;
using Sistema_de_Identificacao.Data;
using Sistema_de_Identificacao.DTOs;
using Sistema_de_Identificacao.Services.Interfaces;

namespace Sistema_de_Identificacao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteService.ObterPorId(id);

            if (cliente == null) return NotFound("Cliente não encontrado!");

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.ObterTodos();

            if (clientes.Count == 0) return Ok("Nenhum cliente cadastrado!");

            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteCreateDto clienteDto)
        {
            try
            {
                await _clienteService.Criar(clienteDto);
                return Ok("Cliente criado com sucesso.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteUpdateDto dto)
        {
            var atualizado = await _clienteService.Atualizar(id, dto);
            return atualizado ? Ok("Cliente atualizado com sucesso.") : NotFound("Cliente não encontrado.");
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _clienteService.Remover(id);
            return removido ? Ok("Cliente removido.") : NotFound("Cliente não encontrado.");            
        }
    }
}
