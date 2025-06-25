using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Identificacao.Data;
using Sistema_de_Identificacao.DTOs;
using Sistema_de_Identificacao.Models;
using Sistema_de_Identificacao.Services;
using Sistema_de_Identificacao.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Sistema_de_Identificacao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;

        public AutenticacaoController(AppDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("registrar")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Registrar(RegistrarUsuarioDto dto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("Usuário já cadastrado com esse e-mail.");

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                PasswordHash = GerarHash(dto.Senha),
                Cargo = dto.Cargo
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok("Usuário registrado com sucesso.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || user.PasswordHash != GerarHash(dto.Senha))
                return Unauthorized("Email ou senha inválidos.");

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }

        private static string GerarHash(string senha)
        {
            var bytes = Encoding.UTF8.GetBytes(senha);
            var hash = SHA256.HashData(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
