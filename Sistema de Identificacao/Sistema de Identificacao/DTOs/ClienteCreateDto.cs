﻿using Sistema_de_Identificacao.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Identificacao.DTOs
{
    public class ClienteCreateDto
    {
        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "O nome deve conter apenas letras.")]
        [DefaultValue("Nome do Cliente")]
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(150)]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(500)]
        [DefaultValue("https://servidornuvem.com/logo.png")]
        public string Logotipo { get; set; } = null!;

        [MinLength(1, ErrorMessage = "Informe ao menos um logradouro.")]
        public List<LogradouroClienteDto> Logradouros { get; set; } = [];
    }
}
