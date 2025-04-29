using SoftlineApp.DTOs;

namespace SoftlineApp.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetAllAsync();
        Task<ClienteDTO?> GetByIdAsync(int id);
        Task AddAsync(ClienteDTO dto);
        Task UpdateAsync(ClienteDTO dto);
        Task DeleteAsync(int id);
    }
}
