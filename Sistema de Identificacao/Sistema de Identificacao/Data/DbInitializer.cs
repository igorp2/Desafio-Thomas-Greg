using Microsoft.EntityFrameworkCore;
using Sistema_de_Identificacao.Models;
using System.Security.Cryptography;
using System.Text;

namespace Sistema_de_Identificacao.Data
{
    public class DbInitializer
    {
        public static async Task CriarAdminPadraoAsync(IServiceProvider serviceProvider, IConfiguration config)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Verifica se já existe algum usuário
            if (!await context.Usuarios.AnyAsync())
            {
                var email = config["AdminDados:Email"];
                var senha = config["AdminDados:Senha"];

                var admin = new Usuario
                {
                    Nome = "Admin",
                    Email = email!,
                    Cargo = CargoUsuario.Admin,
                    PasswordHash = GerarHash(senha!)
                };

                context.Usuarios.Add(admin);
                await context.SaveChangesAsync();               
            }
        }

        private static string GerarHash(string senha)
        {
            var bytes = Encoding.UTF8.GetBytes(senha);
            var hash = SHA256.HashData(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
