using SoftlineApp.DTOs;

namespace SoftlineApp.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> ValidarLoginAsync(LoginDTO dto);
        Task CadastrarAsync(UsuarioDTO dto);
    }
}
