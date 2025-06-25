using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Identificacao.DTOs;
using Sistema_de_Identificacao.Models;
using Sistema_de_Identificacao.Services.Interfaces;

namespace Sistema_de_Identificacao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LogradouroController : ControllerBase
    {
        private readonly ILogradouroService _logradouroService;

        public LogradouroController(ILogradouroService logradouroService)
        {
            _logradouroService = logradouroService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logradouros = await _logradouroService.ObterTodos();

            if (logradouros.Count == 0) 
                return Ok("Nenhum logradouro cadastrado.");

            return Ok(logradouros);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var logradouro = await _logradouroService.ObterPorId(id);

            if (logradouro == null) 
                return NotFound("Logradouro não encontrado.");
            
            return Ok(logradouro);
        }

        [HttpGet("ClienteId")]
        public async Task<IActionResult> GetByClienteId(int clienteId)
        {
            var logradouro = await _logradouroService.ObterPorClienteId(clienteId);

            if (logradouro == null)
                return NotFound("Cliente não encontrado.");

            return Ok(logradouro);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LogradouroCreateDto logradouroDto)
        {
            try
            {
                await _logradouroService.Criar(logradouroDto);
                return Ok("Logradouro criado com sucesso.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(LogradouroUpdateDto logradouroDto)
        {
            var atualizado = await _logradouroService.Atualizar(logradouroDto);
            return atualizado ? Ok("Logradouro atualizado com sucesso.") : NotFound("Logradouro não encontrado.");
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _logradouroService.Remover(id);
            return removido ? Ok("Logradouro removido.") : NotFound("Logradouro não encontrado.");
        }
    }
}
