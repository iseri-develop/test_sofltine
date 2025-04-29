using Microsoft.EntityFrameworkCore;
using SoftlineApp.Data;
using SoftlineApp.Models;
using SoftlineApp.Repositories.Interfaces;

namespace SoftlineApp.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        //Injeção de dependência do DbContext (acesso ao banco)
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByLoginAndSenhaAsync(string login, string senha)
        {
            // Consulta no banco o usuário com login e senha fornecidos
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Login == login && u.Senha == senha);
        }

        public async Task AddAsync(Usuario usuario)
        {
            // Adiciona um novo usuario ao banco
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
