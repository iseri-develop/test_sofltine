using SoftlineApp.DTOs;
using SoftlineApp.Models;
using SoftlineApp.Repositories.Interfaces;
using SoftlineApp.Services.Interfaces;

namespace SoftlineApp.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetAllAsync()
        {
            var produtos = await _repository.GetAllAsync();

            return produtos.Select(p => new ProdutoDTO
            {
                Id = p.Id,
                Descricao = p.Descricao,
                CodigoDeBarras = p.CodigoDeBarras,
                ValorVenda = p.ValorVenda,
                PesoBruto = p.PesoBruto,
                PesoLiquido = p.PesoLiquido
            });
        }

        public async Task<ProdutoDTO?> GetByIdAsync(int id)
        {
            var p = await _repository.GetByIdAsync(id);
            if (p == null) return null;

            return new ProdutoDTO
            {
                Id = p.Id,
                Descricao = p.Descricao,
                CodigoDeBarras = p.CodigoDeBarras,
                ValorVenda = p.ValorVenda,
                PesoBruto = p.PesoBruto,
                PesoLiquido = p.PesoLiquido
            };
        }

        public async Task AddAsync(ProdutoDTO dto)
        {
            var produto = new Produto
            {
                Descricao = dto.Descricao,
                CodigoDeBarras = dto.CodigoDeBarras,
                ValorVenda = dto.ValorVenda,
                PesoBruto = dto.PesoBruto,
                PesoLiquido = dto.PesoLiquido
            };

            await _repository.AddAsync(produto);
        }

        public async Task UpdateAsync(ProdutoDTO dto)
        {
            var produto = await _repository.GetByIdAsync(dto.Id);
            if (produto == null) return;

            produto.Descricao = dto.Descricao;
            produto.CodigoDeBarras = dto.CodigoDeBarras;
            produto.ValorVenda = dto.ValorVenda;
            produto.PesoBruto = dto.PesoBruto;
            produto.PesoLiquido = dto.PesoLiquido;

            await _repository.UpdateAsync(produto);
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await _repository.GetByIdAsync(id);
            if (produto != null)
            {
                await _repository.DeleteAsync(produto);
            }
        }
    }
}
