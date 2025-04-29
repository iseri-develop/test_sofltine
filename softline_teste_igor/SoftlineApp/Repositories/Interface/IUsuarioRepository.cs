using SoftlineApp.Models;

namespace SoftlineApp.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByLoginAndSenhaAsync(string login, string senha);
        Task AddAsync(Usuario usuario);
    }
}
