using SoftlineApp.DTOs;

namespace SoftlineApp.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetAllAsync();
        Task<ProdutoDTO?> GetByIdAsync(int id);
        Task AddAsync(ProdutoDTO dto);
        Task UpdateAsync(ProdutoDTO dto);
        Task DeleteAsync(int id);
    }
}
