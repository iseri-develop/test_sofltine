using SoftlineApp.DTOs;
using SoftlineApp.Models;
using SoftlineApp.Repositories.Interfaces;
using SoftlineApp.Services.Interfaces;

namespace SoftlineApp.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ValidarLoginAsync(LoginDTO dto)
        {
            // Chama o repository para verificar se o usuário existe
            var usuario = await _repository.GetByLoginAndSenhaAsync(dto.Login, dto.Senha);
            return usuario != null;
        }

        public async Task CadastrarAsync(UsuarioDTO dto)
        {
            var novo = new Usuario
            {
                Nome = dto.Nome,
                Login = dto.Login,
                Senha = dto.Senha
            };

            await _repository.AddAsync(novo);
        }
    }
}
